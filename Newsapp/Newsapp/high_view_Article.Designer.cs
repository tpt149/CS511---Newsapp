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
            this.elipseControl1 = new ElipseToolDemo.ElipseControl();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_view = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.pic_hight_view_Article = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_hight_view_Article)).BeginInit();
            this.SuspendLayout();
            // 
            // elipseControl1
            // 
            this.elipseControl1.CornerRadius = 20;
            this.elipseControl1.TargetControl = this;
            // 
            // lbl_title
            // 
            this.lbl_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.Location = new System.Drawing.Point(-1, 163);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(244, 37);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "Titles";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_view
            // 
            this.lbl_view.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_view.AutoSize = true;
            this.lbl_view.Location = new System.Drawing.Point(184, 200);
            this.lbl_view.Name = "lbl_view";
            this.lbl_view.Size = new System.Drawing.Size(29, 13);
            this.lbl_view.TabIndex = 2;
            this.lbl_view.Text = "view";
            // 
            // lbl_time
            // 
            this.lbl_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_time.AutoSize = true;
            this.lbl_time.Location = new System.Drawing.Point(19, 200);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(30, 13);
            this.lbl_time.TabIndex = 3;
            this.lbl_time.Text = "Time";
            // 
            // pic_hight_view_Article
            // 
            this.pic_hight_view_Article.Location = new System.Drawing.Point(0, 3);
            this.pic_hight_view_Article.Name = "pic_hight_view_Article";
            this.pic_hight_view_Article.Size = new System.Drawing.Size(246, 157);
            this.pic_hight_view_Article.TabIndex = 4;
            this.pic_hight_view_Article.TabStop = false;
            // 
            // high_view_Article
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.pic_hight_view_Article);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.lbl_view);
            this.Controls.Add(this.lbl_title);
            this.Name = "high_view_Article";
            this.Size = new System.Drawing.Size(246, 228);
            ((System.ComponentModel.ISupportInitialize)(this.pic_hight_view_Article)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ElipseToolDemo.ElipseControl elipseControl1;
        public System.Windows.Forms.PictureBox pic_hight_view_Article;
        public System.Windows.Forms.Label lbl_time;
        public System.Windows.Forms.Label lbl_view;
        public System.Windows.Forms.Label lbl_title;
    }
}
