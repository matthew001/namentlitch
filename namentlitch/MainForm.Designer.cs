namespace namentlitch
{
    partial class frmNamentlitch
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNamentlitch));
            this.btnApply = new System.Windows.Forms.Button();
            this.lstImageList = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtName = new System.Windows.Forms.TextBox();
            this.S = new System.Windows.Forms.Button();
            this.btnRotateImageRight = new System.Windows.Forms.Button();
            this.btnRotateImageLeft = new System.Windows.Forms.Button();
            this.btnUpFolder = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.pctBox = new System.Windows.Forms.PictureBox();
            this.textBoxSrc = new System.Windows.Forms.TextBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(451, 386);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "&Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lstImageList
            // 
            this.lstImageList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstImageList.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lstImageList.GridLines = true;
            this.lstImageList.Location = new System.Drawing.Point(13, 72);
            this.lstImageList.MultiSelect = false;
            this.lstImageList.Name = "lstImageList";
            this.lstImageList.Size = new System.Drawing.Size(290, 335);
            this.lstImageList.SmallImageList = this.imageList1;
            this.lstImageList.TabIndex = 2;
            this.lstImageList.UseCompatibleStateImageBehavior = false;
            this.lstImageList.View = System.Windows.Forms.View.List;
            this.lstImageList.SelectedIndexChanged += new System.EventHandler(this.lstImageList_SelectedIndexChanged);
            this.lstImageList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstImageList_MouseDoubleClick);
            this.lstImageList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstImageList_MouseUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder.ico");
            this.imageList1.Images.SetKeyName(1, "FileTypeUnknown.ico");
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtName.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(309, 358);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(379, 22);
            this.txtName.TabIndex = 3;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            // 
            // S
            // 
            this.S.Location = new System.Drawing.Point(157, 9);
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(30, 30);
            this.S.TabIndex = 10;
            this.S.UseVisualStyleBackColor = true;
            this.S.Visible = false;
            this.S.Click += new System.EventHandler(this.S_Click);
            // 
            // btnRotateImageRight
            // 
            this.btnRotateImageRight.Image = global::namentlitch.Properties.Resources.RotateRight1;
            this.btnRotateImageRight.Location = new System.Drawing.Point(85, 9);
            this.btnRotateImageRight.Name = "btnRotateImageRight";
            this.btnRotateImageRight.Size = new System.Drawing.Size(30, 30);
            this.btnRotateImageRight.TabIndex = 9;
            this.btnRotateImageRight.UseVisualStyleBackColor = true;
            this.btnRotateImageRight.Click += new System.EventHandler(this.btnRotateImageRight_Click);
            // 
            // btnRotateImageLeft
            // 
            this.btnRotateImageLeft.Image = global::namentlitch.Properties.Resources.RotateLeft1;
            this.btnRotateImageLeft.Location = new System.Drawing.Point(121, 9);
            this.btnRotateImageLeft.Name = "btnRotateImageLeft";
            this.btnRotateImageLeft.Size = new System.Drawing.Size(30, 30);
            this.btnRotateImageLeft.TabIndex = 8;
            this.btnRotateImageLeft.UseVisualStyleBackColor = true;
            this.btnRotateImageLeft.Click += new System.EventHandler(this.btnRotateImageLeft_Click);
            // 
            // btnUpFolder
            // 
            this.btnUpFolder.Image = global::namentlitch.Properties.Resources.GoToParentFolderHS1;
            this.btnUpFolder.Location = new System.Drawing.Point(13, 9);
            this.btnUpFolder.Name = "btnUpFolder";
            this.btnUpFolder.Size = new System.Drawing.Size(30, 30);
            this.btnUpFolder.TabIndex = 7;
            this.btnUpFolder.UseVisualStyleBackColor = true;
            this.btnUpFolder.Click += new System.EventHandler(this.btnUpFolder_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = global::namentlitch.Properties.Resources.openfolderHS1;
            this.btnOpen.Location = new System.Drawing.Point(49, 8);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(30, 30);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // pctBox
            // 
            this.pctBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pctBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pctBox.Location = new System.Drawing.Point(309, 72);
            this.pctBox.Name = "pctBox";
            this.pctBox.Size = new System.Drawing.Size(379, 280);
            this.pctBox.TabIndex = 4;
            this.pctBox.TabStop = false;
            // 
            // textBoxSrc
            // 
            this.textBoxSrc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSrc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSrc.Location = new System.Drawing.Point(13, 46);
            this.textBoxSrc.Name = "textBoxSrc";
            this.textBoxSrc.ReadOnly = true;
            this.textBoxSrc.Size = new System.Drawing.Size(675, 13);
            this.textBoxSrc.TabIndex = 11;
            this.textBoxSrc.WordWrap = false;
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Location = new System.Drawing.Point(613, 384);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 12;
            this.buttonNext.Text = "&Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrev.Location = new System.Drawing.Point(532, 386);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(75, 23);
            this.buttonPrev.TabIndex = 13;
            this.buttonPrev.Text = "&Previous";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // frmNamentlitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 430);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.textBoxSrc);
            this.Controls.Add(this.S);
            this.Controls.Add(this.btnRotateImageRight);
            this.Controls.Add(this.btnRotateImageLeft);
            this.Controls.Add(this.btnUpFolder);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.pctBox);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lstImageList);
            this.Controls.Add(this.btnApply);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(493, 394);
            this.Name = "frmNamentlitch";
            this.Text = "Namentlich";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pctBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ListView lstImageList;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.PictureBox pctBox;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnUpFolder;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnRotateImageLeft;
        private System.Windows.Forms.Button btnRotateImageRight;
        private System.Windows.Forms.Button S;
        private System.Windows.Forms.TextBox textBoxSrc;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
    }
}

