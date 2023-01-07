namespace Newsapp
{
    partial class Article
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
            this.pic_Article = new System.Windows.Forms.PictureBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.elipseControl1 = new ElipseToolDemo.ElipseControl();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Article)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Article
            // 
            this.pic_Article.Dock = System.Windows.Forms.DockStyle.Top;
            this.pic_Article.Location = new System.Drawing.Point(0, 0);
            this.pic_Article.Name = "pic_Article";
            this.pic_Article.Size = new System.Drawing.Size(272, 254);
            this.pic_Article.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Article.TabIndex = 0;
            this.pic_Article.TabStop = false;
            this.pic_Article.Click += new System.EventHandler(this.pic_Article_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(-1, 257);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(273, 60);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "Tiêu đề";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_date
            // 
            this.lbl_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_date.AutoSize = true;
            this.lbl_date.Location = new System.Drawing.Point(46, 327);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(30, 13);
            this.lbl_date.TabIndex = 2;
            this.lbl_date.Text = "Date";
            // 
            // elipseControl1
            // 
            this.elipseControl1.CornerRadius = 35;
            this.elipseControl1.TargetControl = this;
            // 
            // Article
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.Controls.Add(this.lbl_date);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.pic_Article);
            this.Name = "Article";
            this.Size = new System.Drawing.Size(272, 361);
            this.Load += new System.EventHandler(this.Article_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Article)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pic_Article;
        public System.Windows.Forms.Label lbl_Title;
        public System.Windows.Forms.Label lbl_date;
        private ElipseToolDemo.ElipseControl elipseControl1;
    }
}
