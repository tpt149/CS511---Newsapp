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
                    Article_image.Size = new Size(int.Parse(dr["Width"].ToString()), int.Parse(dr["Height"].ToString()));
                    Article_image.Location = new Point(50,lbl_articles1.Size.Height + 20);
                    Article_image.ImageLocation = dr["Represent"].ToString();
                    Article_image.SizeMode=PictureBoxSizeMode.StretchImage; 
                    Article_image.Show();



                    lbl_pic_des.Text = dr["pic_des"].ToString();
                    lbl_pic_des.Location = new Point(50,Article_image.Size.Height + lbl_articles1.Size.Height + 30);

                    lbl_articles2.Text = dr["articles2"].ToString();
                    lbl_articles2.Location = new Point(1,50 +  lbl_articles1.Size.Height + lbl_pic_des.Size.Height + Article_image.Size.Height);

                    //pn_article.Controls.Add(lbl_author);
                    lbl_author.Text = dr["Author"].ToString();
                    lbl_author.Location = new Point(730, 50 +  lbl_articles2.Size.Height + lbl_articles1.Size.Height + lbl_pic_des.Size.Height + Article_image.Size.Height);
                }
            }
            #region Load những tin liên quan
            foreach (DataRow dr in Main.table_All.Rows)
            {
                if (dr["Category"].ToString() == Article.choosen.Category)
                {
                    flp_TinLienQuan.Controls.Clear();
                    DataRow[] filteredRows = new DataRow[Main.table_All.Rows.Count];
                    
                    filteredRows = Main.table_All.Select("Category LIKE '%" + Article.choosen.Category + "%'");
                    foreach (DataRow row in filteredRows)
                    {
                        high_view_Article a = new high_view_Article();
                        flp_TinLienQuan.Controls.Add(a);
                        a.lbl_title.Text = row["titles"].ToString();
                        a.lbl_view.Text = row["View"].ToString();
                        a.pic_hight_view_Article.ImageLocation = row["Represent"].ToString();
                        a.pic_hight_view_Article.Show();
                    }
                    break;
                }
            }
            #endregion

            #region Load Comment và Đánh giá
            Label rod = new Label();
            rod.Text = "";
            rod.BackColor = Color.Black;
            rod.Size = new Size(845,3);
            Panel_Article.Controls.Add(rod);
            rod.Location = new Point(92, 690);

            Label YKien = new Label();
            YKien.Text = "Ý kiến";
            //YKien.Font.Size = 11;
            Panel_Article.Controls.Add(rod);
            YKien.Location = new Point(92, 700);

            RichTextBox comment = new RichTextBox();
            Panel_Article.Controls.Add(comment);
            comment.Size = new Size(845,70);
            comment.Location = new Point(92,715);
            


            Panel comment_stored = new Panel();
            Panel_Article.Controls.Add(comment_stored);
            comment_stored.Size = new Size(850,300);
            comment_stored.AutoScroll = true;
            comment_stored.Location = new Point(92, 780);

         
            //comment.KeyDown += EventKeyDownComment(comment, Panel_Article);
            #endregion
        }



        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
