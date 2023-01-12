using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
namespace Newsapp
{
    public partial class Read_Article : Form
    {
        public Read_Article()
        {
            InitializeComponent();
            comboBox1.Text = "Ha Noi";
            getWeather();
        }

        string APIKey = "4e866087617d8e5d10db4ea5a0df0b54";
        private void getWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", comboBox1.Text, APIKey);
                var json = web.DownloadString(url);
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                pic_Icon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";
                lab_sunrise.Text = convertDateTime(Info.sys.sunset).ToString();
                lblTemp.Text = (Info.main.temp - 273.15).ToString() + "°C";

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getWeather();
        }
        DateTime convertDateTime(long millisec)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(millisec).ToLocalTime();

            return day;
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
                        a.lbl_Category.Text = row["Category"].ToString();
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
            rod.SendToBack();
            rod.Location = new Point(92, 690);

            Label YKien = new Label();
            YKien.Text = "Ý kiến";
            YKien.Font = new Font("Arial", 13);
            Panel_Article.Controls.Add(YKien);
            YKien.Location = new Point(92, 700);


            Panel_Article.Controls.Add(comment);
            comment.Size = new Size(750,35);
            comment.Location = new Point(92,725);
            comment.Font = new Font("Arial", 15);
            Panel_Article.Controls.Add(btn_emoji);
            Panel_Article.Controls.Add(fpl_Emoji);
            comment.SendToBack();
            btn_emoji.Location = new Point(815, 725);
            fpl_Emoji.Location = new Point(810, 560);


            Button Send = new Button();
            Panel_Article.Controls.Add(Send);
            Send.Text = "Gửi";
            Send.Location = new Point(850,725);
            Send.Size = new Size(70, 40);
            Send.Font = new Font("Arial", 13);
            Send.TextAlign=ContentAlignment.MiddleCenter;
            Send.Click += Add_user_comment;

            #endregion


            #region Load comment cũ
            foreach (DataRow dr in Main.Table_Comment_stored.Rows)
            {
                if (dr["titles"].ToString() == lbl_Title.Text)
                {
                    user_comment user = new user_comment();
                    Panel_Article.Controls.Add(user);
                    user.lbl_content.Text = dr["content"].ToString();
                    user.lbl_UserID.Text = dr["UserID"].ToString();

                    user.Size = new Size(750, 90);
                    user.Location = new Point(Location_X, Location_Y + 70);

                    Location_Y += 100;
                }
            }

            #endregion
        }
        RichTextBox comment = new RichTextBox();
        
        int Location_Y = 700;
        int Location_X = 92;

        private void Add_user_comment(object sender, EventArgs e)
        {
            Random rd = new Random();
            int ID = rd.Next(999999, 999999999);
            user_comment user = new user_comment();
            Panel_Article.Controls.Add(user);
            user.lbl_content.Text = comment.Text;
            user.lbl_UserID.Text = "UserID" + ID.ToString();

            user.Size = new Size(750, 90);
            user.Location = new Point(Location_X, Location_Y);

            comment.Text = "";
            Location_Y += 100;


            #region Lưu comment 
            DataRow r = Main.Table_Comment_stored.NewRow();
            r["titles"] = lbl_Title.Text;
            r["UserID"] = user.lbl_UserID.Text;
            r["content"] = user.lbl_content.Text;
            Main.Table_Comment_stored.Rows.Add(r);
            #endregion
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static string subject;
        private void btn_Share_by_Gmail_Click(object sender, EventArgs e)
        {
            foreach(DataRow r in Main.table_All.Rows) {
                if (r["titles"].ToString() == Article.choosen.title)
                {
                    subject = r["descriptions"].ToString();
                    string link = r["links"].ToString();
                    Share s = new Share(link);  // truyền vô string link 
                    s.Show();
                    break;
                }
            }
        }
        private int imageNumber = 1;
        private void LoadNextImage()
        {
            if (imageNumber == 6)
            {
                imageNumber = 1;
            }
            Pic_ads.ImageLocation = string.Format("P:\\CS511\\Final_Project\\CS511---Newsapp\\Newsapp\\Newsapp\\Image\\Ads\\{0}.jpg", imageNumber);
            imageNumber++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }

        private void slidePic_Click(object sender, EventArgs e)
        {
            if (Pic_ads.ImageLocation == "P:\\CS511\\Final_Project\\CS511---Newsapp\\Newsapp\\Newsapp\\Image\\Ads\\1.jpg")
            {
                System.Diagnostics.Process.Start("https://sapuwa.com/?gclid=EAIaIQobChMIqOjnj--q_AIVnL2WCh00ZAAWEAAYASAAEgIMqPD_BwE&gidzl=Xh9qHuAi0Ks4hN90XR07I8AeSa6QlmaRoVOg59teK4wUz2SKaBW06vMb9qQHl5DBngPqHpWsBq8xWQa1Jm");
            }
            else if (Pic_ads.ImageLocation == "P:\\CS511\\Final_Project\\CS511---Newsapp\\Newsapp\\Newsapp\\Image\\Ads\\2.jpg")
            {
                System.Diagnostics.Process.Start("https://benhvienanviet.com/vi/tham-kham-mien-phi-giam-chi-phi-dieu-tri-tai-benh-vien-an-viet-n1232");
            }
            else if (Pic_ads.ImageLocation == "P:\\CS511\\Final_Project\\CS511---Newsapp\\Newsapp\\Newsapp\\Image\\Ads\\3.jpg")
            {
                System.Diagnostics.Process.Start("https://rosamiahotel.com/");
            }
            else if (Pic_ads.ImageLocation == "P:\\CS511\\Final_Project\\CS511---Newsapp\\Newsapp\\Newsapp\\Image\\Ads\\4.jpg")
            {
                System.Diagnostics.Process.Start("https://www.vinamilk.com.vn/vi");
            }
            else if (Pic_ads.ImageLocation == "P:\\CS511\\Final_Project\\CS511---Newsapp\\Newsapp\\Newsapp\\Image\\Ads\\5.jpg")
            {
                System.Diagnostics.Process.Start("https://www.sabeco.com.vn/truyen-thong/tin-tuc-su-kien/huyen-thoai-bia-saigon-special-tai-xuat");
            }
        }

        private void Pic_ads_Click(object sender, EventArgs e)
        {
            slidePic_Click(sender, e);
        }
        bool a = false;
        private void btn_emoji_Click(object sender, EventArgs e)
        {
            if (a == false)
            {
                fpl_Emoji.Visible = true;
                btn_Share_by_Gmail.SendToBack();
                lbl_share.SendToBack();
                a = true;
            }
            else
            {
                fpl_Emoji.Visible = false;
                a = false;
            }
        }




        private void ptb_Kiss_Click(object sender, EventArgs e)
        {
            comment.Text = comment.Text.Trim() + Emoji.Kissing_Heart;
        }

        private void ptb_ClosedEye_Click(object sender, EventArgs e)
        {
            comment.Text = comment.Text.Trim() + Emoji.Stuck_Out_Tongue_Closed_Eyes;
        }

        private void ptb_Joy_Click(object sender, EventArgs e)
        {
            comment.Text = comment.Text.Trim() + Emoji.Joy;
        }

        private void ptb_Sweat_Smile_Click(object sender, EventArgs e)
        {
            comment.Text = comment.Text.Trim() + Emoji.Sweat_Smile;
        }

        private void ptb_smile_Click(object sender, EventArgs e)
        {
            comment.Text = comment.Text.Trim() + Emoji.Smile;
        }

        private void ptb_HeartEyes_Click(object sender, EventArgs e)
        {
            comment.Text = comment.Text.Trim() + Emoji.Heart_Eyes;
        }

        private void ptb_Cry_Click(object sender, EventArgs e)
        {
            comment.Text = comment.Text.Trim() + Emoji.Cry;
        }

        private void ptb_Unamused_Click(object sender, EventArgs e)
        {
            comment.Text = comment.Text.Trim() + Emoji.Unamused;
        }

        private void ptb_Angry_Click(object sender, EventArgs e)
        {
            comment.Text = comment.Text.Trim() + Emoji.Angry;
        }

        private void ptb_dissappointed_Click(object sender, EventArgs e)
        {
            comment.Text = comment.Text.Trim() + Emoji.Disappointed;
        }


        private void ptb_Triumph_Click(object sender, EventArgs e)
        {
            comment.Text = comment.Text.Trim() + Emoji.Triumph;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
