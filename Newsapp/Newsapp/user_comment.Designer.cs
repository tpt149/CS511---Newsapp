namespace Newsapp
{
    partial class user_comment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(user_comment));
            this.lbl_content = new System.Windows.Forms.Label();
            this.lbl_UserID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_content
            // 
            this.lbl_content.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_content.Location = new System.Drawing.Point(88, 32);
            this.lbl_content.Name = "lbl_content";
            this.lbl_content.Size = new System.Drawing.Size(747, 52);
            this.lbl_content.TabIndex = 1;
            this.lbl_content.Text = "content";
            this.lbl_content.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_UserID
            // 
            this.lbl_UserID.AutoSize = true;
            this.lbl_UserID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserID.Location = new System.Drawing.Point(88, 6);
            this.lbl_UserID.Name = "lbl_UserID";
            this.lbl_UserID.Size = new System.Drawing.Size(61, 21);
            this.lbl_UserID.TabIndex = 2;
            this.lbl_UserID.Text = "UserID";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // user_comment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbl_UserID);
            this.Controls.Add(this.lbl_content);
            this.Controls.Add(this.pictureBox1);
            this.Name = "user_comment";
            this.Size = new System.Drawing.Size(848, 90);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lbl_content;
        public System.Windows.Forms.Label lbl_UserID;
    }
}
