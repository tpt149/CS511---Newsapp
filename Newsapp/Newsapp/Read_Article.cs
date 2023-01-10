using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Newsapp
{
    public partial class Read_Article : Form
    {
        public Read_Article()
        {
            InitializeComponent();
        }

        private void Read_Article_Load(object sender, EventArgs e)
        {
            foreach(DataRow dr in Main.table_All.Rows)
            {
                if (Article.choosen.title == dr["titles"].ToString())
                {
                    lbl_Date.Text= dr["Date"].ToString();
                    lbl_Category.Text = dr["Category"].ToString();
                    lbl_Description.Text = dr["descriptions"].ToString();
                    lbl_Title.Text = dr["titles"].ToString();
                    lbl_articles1.Text = dr["articles1"].ToString();

                    PictureBox Article_image = new PictureBox();
                    pn_article.Controls.Add(Article_image);
                    Article_image.Size = new Size(602, 372);
                    Article_image.Location = new Point(140,lbl_articles1.Size.Height + 20);
                    Article_image.ImageLocation = dr["Represent"].ToString();
                    Article_image.SizeMode=PictureBoxSizeMode.StretchImage; 
                    Article_image.Show();



                    lbl_pic_des.Text = dr["pic_des"].ToString();
                    lbl_pic_des.Location = new Point(150,Article_image.Size.Height + lbl_articles1.Size.Height + 50);

                    lbl_articles2.Text = dr["articles2"].ToString();
                    lbl_articles2.Location = new Point(1,150 +  lbl_articles1.Size.Height + lbl_pic_des.Size.Height + Article_image.Size.Height);

                    //pn_article.Controls.Add(lbl_author);
                    lbl_author.Text = dr["Author"].ToString();
                    lbl_author.Location = new Point(730, 140 + lbl_articles2.Size.Height + lbl_articles1.Size.Height + lbl_pic_des.Size.Height + Article_image.Size.Height);
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
