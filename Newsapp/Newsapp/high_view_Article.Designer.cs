namespace Newsapp
{
    partial class high_view_Article
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(high_view_Article));
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_view = new System.Windows.Forms.Label();
            this.pic_hight_view_Article = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_hight_view_Article)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.lbl_title.Location = new System.Drawing.Point(190, 0);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(255, 127);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "SaiGonTiurist Group tung nhiều ưu đãi tại hội chợ du lịch";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_title.Click += new System.EventHandler(this.lbl_title_Click);
            // 
            // lbl_view
            // 
            this.lbl_view.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_view.AutoSize = true;
            this.lbl_view.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_view.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_view.Location = new System.Drawing.Point(383, 163);
            this.lbl_view.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_view.Name = "lbl_view";
            this.lbl_view.Size = new System.Drawing.Size(41, 20);
            this.lbl_view.TabIndex = 2;
            this.lbl_view.Text = "0000";
            this.lbl_view.Click += new System.EventHandler(this.lbl_view_Click);
            // 
            // pic_hight_view_Article
            // 
            this.pic_hight_view_Article.Dock = System.Windows.Forms.DockStyle.Left;
            this.pic_hight_view_Article.Location = new System.Drawing.Point(0, 0);
            this.pic_hight_view_Article.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pic_hight_view_Article.Name = "pic_hight_view_Article";
            this.pic_hight_view_Article.Size = new System.Drawing.Size(190, 195);
            this.pic_hight_view_Article.TabIndex = 4;
            this.pic_hight_view_Article.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(351, 161);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // high_view_Article
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pic_hight_view_Article);
            this.Controls.Add(this.lbl_view);
            this.Controls.Add(this.lbl_title);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "high_view_Article";
            this.Size = new System.Drawing.Size(445, 195);
            ((System.ComponentModel.ISupportInitialize)(this.pic_hight_view_Article)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox pic_hight_view_Article;
        public System.Windows.Forms.Label lbl_view;
        public System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}
