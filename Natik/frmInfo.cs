using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SwfReader;
using System.IO;
using System.Runtime.InteropServices;

namespace SwfReader
{
    public partial class frmInfo : Form
    {
        private CSwfReader SwfRd;

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        public frmInfo()
        {
            InitializeComponent();
        }

        private void frmInfo_Load(object sender, EventArgs e)
        {
            String[] sFileName = Environment.GetCommandLineArgs();

            if (sFileName.GetLength(0) > 1)
            {
                ReadSvfFile(sFileName[1]);
            }
        }

        private void frmInfo_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // allow them to continue
                // (without this, the cursor stays a "NO" symbol
                e.Effect = DragDropEffects.Link;
            }
        }

        private void ReadSvfFile(String sFileName)
        {
            try
            {
                SwfRd = new CSwfReader(sFileName);

                lblFileName.Text = Path.GetFileName(SwfRd.sFileName);

                float size = (float)SwfRd.FileInformation.Length;
                size /= 1024;
                txtFileSize.Text = size.ToString("0.##") + " kB";
                txtVersion.Text = SwfRd.nVersion.ToString();
                txtFrameSize.Text = String.Format("{0}x{1}", 
                    SwfRd.FrameSize.Width, SwfRd.FrameSize.Height);
                txtRate.Text = SwfRd.nFrameRate.ToString("0.#");
                txtCount.Text = SwfRd.nFrameCount.ToString();

                lstTags.Items.Clear();
                lstTags.Items.AddRange(SwfRd.tags_actions.ToArray());

            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "ERROR: " + e.Message,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmInfo_DragDrop(object sender, DragEventArgs e)
        {
            // transfer the filenames to a string array
            // (yes, everything to the left of the "=" can be put in the 
            // foreach loop in place of "files", but this is easier to understand.)
            String[] sFileName = (String[])e.Data.GetData(DataFormats.FileDrop);

            if (sFileName.GetLength(0) > 0)
            {
                ReadSvfFile(sFileName[0]);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void lstTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTags.SelectedItem != null)
                txtContent.Text = ((CSwfTag)lstTags.SelectedItem).ContentToString();
            else
                txtContent.Text = "";

        }

   }
}