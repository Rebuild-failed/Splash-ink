﻿namespace Splash_ink
{
    partial class Scene
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
            this.pnlBase = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlSource = new System.Windows.Forms.Panel();
            this.picSource = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.tb = new System.Windows.Forms.TrackBar();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnSelectSourcePic = new System.Windows.Forms.Button();
            this.btnSelectMainPic = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.pnlBase.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.pnlLeft);
            this.pnlBase.Controls.Add(this.pnlRight);
            this.pnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBase.Location = new System.Drawing.Point(0, 0);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Padding = new System.Windows.Forms.Padding(2);
            this.pnlBase.Size = new System.Drawing.Size(1022, 809);
            this.pnlBase.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlSource);
            this.pnlLeft.Controls.Add(this.pnlMain);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(2, 2);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(900, 805);
            this.pnlLeft.TabIndex = 2;
            // 
            // pnlSource
            // 
            this.pnlSource.Controls.Add(this.picSource);
            this.pnlSource.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSource.Location = new System.Drawing.Point(0, 405);
            this.pnlSource.Name = "pnlSource";
            this.pnlSource.Size = new System.Drawing.Size(900, 400);
            this.pnlSource.TabIndex = 1;
            // 
            // picSource
            // 
            this.picSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSource.Location = new System.Drawing.Point(0, 0);
            this.picSource.Name = "picSource";
            this.picSource.Size = new System.Drawing.Size(900, 400);
            this.picSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSource.TabIndex = 0;
            this.picSource.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.picMain);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(900, 400);
            this.pnlMain.TabIndex = 0;
            // 
            // picMain
            // 
            this.picMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMain.Location = new System.Drawing.Point(0, 0);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(900, 400);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMain.TabIndex = 0;
            this.picMain.TabStop = false;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.btnSave);
            this.pnlRight.Controls.Add(this.tb);
            this.pnlRight.Controls.Add(this.btnOk);
            this.pnlRight.Controls.Add(this.btnSelectSourcePic);
            this.pnlRight.Controls.Add(this.btnSelectMainPic);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(902, 2);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(118, 805);
            this.pnlRight.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enabled = false;
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(30, 134);
            this.tb.Maximum = 100;
            this.tb.Minimum = 10;
            this.tb.Name = "tb";
            this.tb.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tb.Size = new System.Drawing.Size(45, 237);
            this.tb.TabIndex = 3;
            this.tb.TickFrequency = 2;
            this.tb.Value = 60;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(20, 377);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "开始";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnSelectSourcePic
            // 
            this.btnSelectSourcePic.Location = new System.Drawing.Point(20, 105);
            this.btnSelectSourcePic.Name = "btnSelectSourcePic";
            this.btnSelectSourcePic.Size = new System.Drawing.Size(75, 23);
            this.btnSelectSourcePic.TabIndex = 1;
            this.btnSelectSourcePic.Text = "选择色源图";
            this.btnSelectSourcePic.UseVisualStyleBackColor = true;
            this.btnSelectSourcePic.Click += new System.EventHandler(this.btnSelectSourcePic_Click);
            // 
            // btnSelectMainPic
            // 
            this.btnSelectMainPic.Location = new System.Drawing.Point(20, 69);
            this.btnSelectMainPic.Name = "btnSelectMainPic";
            this.btnSelectMainPic.Size = new System.Drawing.Size(75, 23);
            this.btnSelectMainPic.TabIndex = 0;
            this.btnSelectMainPic.Text = "选择主图片";
            this.btnSelectMainPic.UseVisualStyleBackColor = true;
            this.btnSelectMainPic.Click += new System.EventHandler(this.btnSelectMainPic_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "file";
            this.ofd.Filter = "图片|*.jpg;*.png";
            // 
            // Scene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 809);
            this.Controls.Add(this.pnlBase);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Scene";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scene";
            this.Load += new System.EventHandler(this.Scene_Load);
            this.pnlBase.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlSource;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnSelectSourcePic;
        private System.Windows.Forms.Button btnSelectMainPic;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TrackBar tb;
        private System.Windows.Forms.PictureBox picSource;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog ofd;
    }
}
