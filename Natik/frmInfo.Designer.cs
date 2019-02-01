namespace SwfReader
{
    partial class frmInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfo));
            this.btnExit = new System.Windows.Forms.Button();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFrameSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(57, 258);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(231, 35);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtVersion
            // 
            this.txtVersion.BackColor = System.Drawing.SystemColors.Control;
            this.txtVersion.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtVersion.ForeColor = System.Drawing.Color.DarkRed;
            this.txtVersion.Location = new System.Drawing.Point(186, 90);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(102, 30);
            this.txtVersion.TabIndex = 2;
            this.txtVersion.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(53, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Flash Version";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmInfo_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(58, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Frame size";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmInfo_MouseDown);
            // 
            // txtFrameSize
            // 
            this.txtFrameSize.BackColor = System.Drawing.SystemColors.Control;
            this.txtFrameSize.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtFrameSize.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtFrameSize.Location = new System.Drawing.Point(186, 128);
            this.txtFrameSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFrameSize.Name = "txtFrameSize";
            this.txtFrameSize.ReadOnly = true;
            this.txtFrameSize.Size = new System.Drawing.Size(102, 30);
            this.txtFrameSize.TabIndex = 3;
            this.txtFrameSize.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(99, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "File size";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmInfo_MouseDown);
            // 
            // txtFileSize
            // 
            this.txtFileSize.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtFileSize.Location = new System.Drawing.Point(186, 52);
            this.txtFileSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFileSize.Name = "txtFileSize";
            this.txtFileSize.ReadOnly = true;
            this.txtFileSize.Size = new System.Drawing.Size(102, 30);
            this.txtFileSize.TabIndex = 1;
            this.txtFileSize.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(71, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Frame rate";
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmInfo_MouseDown);
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRate.Location = new System.Drawing.Point(186, 166);
            this.txtRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRate.Name = "txtRate";
            this.txtRate.ReadOnly = true;
            this.txtRate.Size = new System.Drawing.Size(102, 30);
            this.txtRate.TabIndex = 5;
            this.txtRate.WordWrap = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(57, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Frame count";
            this.label6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmInfo_MouseDown);
            // 
            // txtCount
            // 
            this.txtCount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCount.Location = new System.Drawing.Point(186, 204);
            this.txtCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(102, 30);
            this.txtCount.TabIndex = 6;
            this.txtCount.WordWrap = false;
            // 
            // lblFileName
            // 
            this.lblFileName.BackColor = System.Drawing.Color.Transparent;
            this.lblFileName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFileName.Location = new System.Drawing.Point(57, 9);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(231, 23);
            this.lblFileName.TabIndex = 15;
            this.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFileName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmInfo_MouseDown);
            // 
            // lstTags
            // 
            this.lstTags.FormattingEnabled = true;
            this.lstTags.ItemHeight = 16;
            this.lstTags.Location = new System.Drawing.Point(355, 12);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(235, 116);
            this.lstTags.TabIndex = 16;
            this.lstTags.SelectedIndexChanged += new System.EventHandler(this.lstTags_SelectedIndexChanged);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(355, 144);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(234, 148);
            this.txtContent.TabIndex = 17;
            // 
            // frmInfo
            // 
            this.AcceptButton = this.btnExit;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SwfReader.Properties.Resources.Form;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lstTags);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFileSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFrameSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInfo";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Natik";
            this.Load += new System.EventHandler(this.frmInfo_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmInfo_DragDrop);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmInfo_MouseDown);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmInfo_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFrameSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFileSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.TextBox txtContent;
    }
}

