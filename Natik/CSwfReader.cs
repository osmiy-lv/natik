using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using ComponentAce.Compression.Libs.zlib;

namespace SwfReader
{
    enum SWF_TAG_CODES
    {
        End = 0,
        ShowFrame = 1,
        DefineShape = 2,
        FreeCharacter = 3,
        PlaceObject = 4,
        RemoveObject = 5,
        DefineBits = 6,
        DefineButton = 7,// * 
        JPEGTables = 8,
        SetBackgroundColor = 9,
        DefineFont = 10,
        DefineText = 11,
        DoAction = 12,//* 
        DefineFontInfo = 13,
        DefineSound = 14,
        StartSound = 15,
        StopSound = 16,
        DefineButtonSound = 17,
        SoundStreamHead = 18,
        SoundStreamBlock = 19,
        DefineBitsLossless = 20,
        DefineBitsJPEG2 = 21,
        DefineShape2 = 22,
        DefineButtonCxform = 23,
        Protect = 24,
        PathSharePostScript = 25,
        PlaceObject2 = 26,// * 
        RemoveObject2 = 28,
        SyncFrame = 29,
        FreeAll = 31,
        DefineShape3 = 32,
        DefineText2 = 33,
        DefineButton2 = 34,// * 
        DefineBitsJPEG3 = 35,
        DefineBitsLossless2 = 36,
        DefineEditText = 37,
        DefineVideo = 38,
        DefineSprite = 39,
        NameCharacter = 40,
        SerialNumber = 41,
        DefineTextFormat = 42,
        FrameLabel = 43,
        SoundStreamHead2 = 45,
        DefineMorphShape = 46,
        GenFrame = 47,
        DefineFont2 = 48,
        GenCommand = 49,
        DefineCommanObj = 50,
        CharacterSet = 51,
        FontRef = 52,
        ExportAssets = 56,
        ImportAssets = 57,
        EnableDebugger = 58,
        DoInitAction = 59,//* 
        DefineVideoStream = 60,
        VideoFrame = 61,
        DefineFontInfo2 = 62,
        DebugID = 63,
        EnableDebugger2 = 64,
        ScriptLimits = 65,
        SetTabIndex = 66,
        DefineShape4 = 67,
        FileAttributes = 69,
        PlaceObject3 = 70,
        ImportAssets2 = 71,
        DefineFontAlignZones = 73,
        CSMTextSettings = 74,
        DefineFont3 = 75,
        SymbolClass = 76,
        Metadata = 77,
        DefineScalingGrid = 78,
        DoABC = 82,// ?? 
        DefineShape5 = 83,
        DefineMorphShape2 = 84,
        DefineSceneAndFrameLabelData = 86,
        DefineBinaryData = 87,
        DefineFontName = 88,
        StartSound2 = 89,
        DefineBitsJPEG4 = 90,
        DefineFont4 = 91,
        DefineBitsPtr = 1023  
    };

    enum SWF_ACTION_CODES
    {
        SWF_ACTION_EOL = 0x0,
        SWF_ACTION_GetURL = 0x83,
        SWF_ACTION_GetURL2 = 0x9A
    };

    class CSwfAction
    {
        public Byte ActionCode;

        public CSwfAction(Byte nActionCode)
        {
            ActionCode = nActionCode;
        }

        public override string ToString()
        {
            return String.Format("0x{0,2:X2}", ActionCode);
        }

        public virtual String ContentToString()
        {
            return "";
        }
    }

    class CSwfActionByteArray : CSwfAction
    {
        public Byte[] buffer;

        public CSwfActionByteArray(Byte nActionCode, BinaryReader rd, Int32 nActionLength)
            : base(nActionCode)
        {
            buffer = rd.ReadBytes(nActionLength);
        }

        public override String ToString()
        {
            return String.Format("{0}: {1:0,0.#} b", base.ToString(), buffer.Length);
        }
    }

    class CSwfActionGetURL : CSwfAction
    {
        public String UrlString;
        public String TargetString;

        public CSwfActionGetURL(Byte nActionCode, BinaryReader rd)
            : base(nActionCode)
        {
            Char c = '\0';

            UrlString = "";
            while ('\0' != (c = rd.ReadChar()))
            {
                UrlString += c;
            }

            TargetString = "";
            while (0 != (c = rd.ReadChar()))
            {
                TargetString += c;
            }
        }

        public override String ToString()
        {
            return String.Format("getURL(\"{0}\", \"{1}\");", UrlString, TargetString);
        }
    }

    class CSwfTag
    {
        private const Byte SWF_SHORT_TAG_SIZE_MAX = 62;

        public SWF_TAG_CODES TagCode;

        public CSwfTag(SWF_TAG_CODES nTagCode)
        {
            TagCode = nTagCode;
        }

        public override string ToString()
        {
            return TagCode.ToString();
        }

        public virtual String ContentToString()
        {
            return "";
        }
    }

    class CSwfTagByteArray : CSwfTag
    {
        public Byte[] buffer;

        public CSwfTagByteArray(SWF_TAG_CODES nTagCode, BinaryReader rd, Int32 nTagLength)
            : base(nTagCode)
        {
            buffer = rd.ReadBytes(nTagLength);
        }

        public override String ToString()
        {
           return String.Format("{0}: {1:0,0.#} b", base.ToString(), buffer.Length);
        }

        public override String ContentToString()
        {
            return System.Text.Encoding.ASCII.GetString(buffer);
        }
    }

    class CSwfTagDoAction : CSwfTag
    {
        public List<CSwfAction> actions_get_url;
        public List<CSwfAction> actions_all;

        public CSwfTagDoAction(SWF_TAG_CODES nTagCode) : base(nTagCode) { }

        public CSwfTagDoAction(SWF_TAG_CODES nTagCode, BinaryReader rd)
            : base(nTagCode)
        {
            ReadActions(rd);
        }

        protected void ReadActions(BinaryReader rd)
        {
            Byte ActionCode = 0;

            actions_get_url = new List<CSwfAction>();
            actions_all = new List<CSwfAction>();

            while ((ActionCode = rd.ReadByte()) > 0) 
            {
                UInt16 Length = 0;
                CSwfAction newAction;

                if (ActionCode > 0x80)
                    Length = rd.ReadUInt16();

                switch ((SWF_ACTION_CODES)ActionCode)
                {
                    case SWF_ACTION_CODES.SWF_ACTION_EOL: 
                        return; /* End Of Action List*/
                    case SWF_ACTION_CODES.SWF_ACTION_GetURL:
                        newAction = new CSwfActionGetURL(ActionCode, rd);
                        actions_get_url.Add(newAction);
                        break;
                    default:
                        newAction = new CSwfActionByteArray(ActionCode, rd, Length);
                        break;
                }

                actions_all.Add(newAction);
            }
        }

        public override String ToString()
        {
            return "DoAction";
        }

        public override String ContentToString()
        {
            String result = "";

            foreach (CSwfAction action in actions_get_url)
            {
                result += "\r\n" + action.ToString();
            }
            return result;
        }
    }

    class CSwfTagDoInitAction : CSwfTagDoAction
    {
        private UInt16 SpriteID;

        public CSwfTagDoInitAction(SWF_TAG_CODES nTagCode, BinaryReader rd)
            : base(nTagCode)
        {
            SpriteID = rd.ReadUInt16();

            ReadActions(rd);
        }

        public override String ToString()
        {
            return "DoInitAction";
        }

        public override String ContentToString()
        {
            return String.Format("SpriteID: {0}\r\n", SpriteID) + base.ContentToString();
        }
    }

    class CSwfReader
    {
        private const Byte SWF_HEADER_LEN = 8;

        public String sFileName;

        public String sSigature;
        public Byte nVersion;
        public UInt32 nContentLength;
        public FileInfo FileInformation;
        public Rectangle FrameSize;
        public float nFrameRate;
        public UInt16 nFrameCount;

        public CSwfReader()
        {
            tags_actions = new List<CSwfTag>();
            tags_all = new List<CSwfTag>();
        }

        public CSwfReader(String sOpenFileName) : this()
        {
            Open(sOpenFileName);
        }

        public void Open(String sOpenFileName)
        {
            sFileName = sOpenFileName;

            if (!File.Exists(sFileName))
                throw new Exception("File '" + sFileName + "' is not exists");

            this.FileInformation = new FileInfo(sFileName);

            if (FileInformation.Length < SWF_HEADER_LEN)
                throw new Exception("File too small");
            
            ReadHeader();
        }

        protected Byte nLastByte;
        protected Byte nLeaveBits;
        protected UInt32 ReadUBits(BinaryReader rd, Byte nBits, Boolean bCleanPreviousData)
        {
            UInt32 nResult = 0;
            UInt32 nResultLen = 0;

            if (nBits > 32)
                throw new Exception("Requested too large bit field");

            if (bCleanPreviousData)
            {
                nLastByte = 0;
                nLeaveBits = 0;
            }

            while (nResultLen < nBits)
            {

                if (nLeaveBits == 0)
                {
                    nLastByte = rd.ReadByte();
                    nLeaveBits = 8;
                }     

                Byte nBitOffset = (Byte)(8 - nLeaveBits);
                Byte nReadBits = (Byte)Math.Min(nLeaveBits, nBits - nResultLen);
                Byte nReadBitOffset = (Byte)(nLeaveBits - nReadBits);

                nResult <<= nReadBits;
                nResult |= (UInt32)(nLastByte >> (nBitOffset + nReadBitOffset));
                nResultLen += nReadBits;

                nLastByte <<= nReadBits;
                nLeaveBits -= nReadBits;
            }

            return nResult;
        }

        protected Int32 ReadSBits(BinaryReader rd, Byte nBits, Boolean bCleanPreviousData)
        {
            Int32 nResult = 0;

            nResult = (Int32)ReadUBits(rd, nBits, bCleanPreviousData);

            /* This expansion is called sign extension. For example, the 4-bit 
             * unsigned value UB[4] = 1110 would be expanded to a 16-bit value 
             * like this: 0000000000001110 = 14. The same value interpreted as 
             * a signed value, SB[4] = 1110 would be expanded to 
             * 1111111111111110 = –2.
             */
            if (((nResult >> (nBits - 1)) & 0x01) == 0x01)
            {
                nResult *= -1;
            }

            return nResult;
        }

        public List<CSwfTag> tags_actions;
        public List<CSwfTag> tags_all; 

        protected void ReadHeader()
        {
            FileStream fs = new FileStream(sFileName, FileMode.Open, FileAccess.Read);
            BinaryReader rd = new BinaryReader (fs);

            try
            {
                sSigature = new String(
                    new Char[3] {
                        (Char)rd.ReadByte(),
                        (Char)rd.ReadByte(),
                        (Char)rd.ReadByte()});

                nVersion = rd.ReadByte();

                nContentLength = rd.ReadUInt32();

                if (String.Compare(sSigature, "FWS") == 0)
                {
                    // Uncompressed content
                    // rd = new BinaryReader(fs); // leave as is
                }
                else if (String.Compare(sSigature, "CWS") == 0)
                {
                    // Compressed content
                    rd = new ZInputStream(fs);
                }
                else if (String.Compare(sSigature, 1, "WS", 0, 2) == 0)
                {
                    throw new Exception("Unknown file signature '" + sSigature + "'");
                }
                else
                {
                    throw new Exception("Unknown file format");
                }


                Byte nbits = (Byte)ReadUBits(rd, 5, true);

                /* twip is 1/20th of a logical pixel. */
                FrameSize.X = ReadSBits(rd, nbits, false) / 20;// Xmin - Frame size in twips
                FrameSize.Width = ReadSBits(rd, nbits, false) / 20;// Xmax - Frame size in twips
                FrameSize.Width -= FrameSize.X;
                FrameSize.X = 0;

                FrameSize.Y = ReadSBits(rd, nbits, false) / 20; // Ymin - Frame size in twips
                FrameSize.Height = ReadSBits(rd, nbits, false) / 20; // Ymax - Frame size in twips
                FrameSize.Height -= FrameSize.Y;
                FrameSize.Y = 0;

                // Frame delay in 8.8 fixed number of frames per second
                nFrameRate  = (float)(rd.ReadByte());
                nFrameRate /= 256;
                nFrameRate += (float)(rd.ReadByte());

                nFrameCount = rd.ReadUInt16();

                while (true)
                {
                    UInt16 nTagCodeAndLength = 0;
                    Int32 nTagLength = 0;
                    SWF_TAG_CODES nTagCode;

                    try
                    {
                        nTagCodeAndLength = rd.ReadUInt16();

                        nTagCode = (SWF_TAG_CODES)(nTagCodeAndLength >> 6);

                        nTagLength = (Int32)(nTagCodeAndLength & 0x3F);

                        if (nTagLength == 0x3F)
                        {
                            nTagLength = rd.ReadInt32();
                        }
                    }
                    catch (EndOfStreamException)
                    {
                        break;
                    }

                    CSwfTag newTag;

                    switch (nTagCode)
                    {
                        case SWF_TAG_CODES.DefineButton:
                        case SWF_TAG_CODES.DefineButton2:
                        case SWF_TAG_CODES.DoAction:
                        case SWF_TAG_CODES.DoInitAction:
                        case SWF_TAG_CODES.PlaceObject2:
                            newTag = new CSwfTagByteArray(nTagCode, rd, nTagLength);
                            break;

/*                        case SWF_TAG_CODES.DoInitAction:
                            newTag = new CSwfTagByteArray(nTagCode, rd, nTagLength);
//                            newTag = new CSwfTagDoInitAction(nTagCode, rd);
//                            this.tags_actions.Add(newTag);
                            break;
                        case SWF_TAG_CODES.DoAction:
//                            newTag = new CSwfTagDoAction(nTagCode, rd);
                            newTag = new CSwfTagByteArray(nTagCode, rd, nTagLength);
//                            this.tags_actions.Add(newTag);
                            break;
                        case SWF_TAG_CODES.DoABC:*/
                        default:
                            newTag = new CSwfTagByteArray(nTagCode, rd, nTagLength);
                            break;
                    }
                    this.tags_actions.Add(newTag);
                    this.tags_all.Add(newTag);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
