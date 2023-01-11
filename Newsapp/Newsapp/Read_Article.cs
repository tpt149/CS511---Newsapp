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
            Panel_Article.Controls.Add(YKien);
            YKien.Location = new Point(92, 700);


            Panel_Article.Controls.Add(comment);
            comment.Size = new Size(750,35);
            comment.Location = new Point(92,725);
            

            Button Send = new Button();
            Panel_Article.Controls.Add(Send);
            Send.Text = "Gửi";
            Send.Location = new Point(850,725);
            Send.Size = new Size(70, 60);
            Send.TextAlign=ContentAlignment.MiddleCenter;
            Send.Click += Add_user_comment;

            #endregion
        }
        RichTextBox comment = new RichTextBox();
        int Location_Y = 700;
        int Location_X = 92;
        DataTable Comment_Stored = new DataTable();
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
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Share_by_Gmail_Click(object sender, EventArgs e)
        {
        //    string from, pass, content;
        //    from = txtSender.Text.Trim();
        //    pass = txtPass.Text.Trim();
        //    content = txtContent.Text;

        //    MailMessage message = new MailMessage();
        //    message.From = new MailAddress(from);
        //    message.Subject = "Newsapp C#";
        //    message.To.Add(new MailAddress("newsapp1201@gmail.com"));
        //    message.Body = "<html><body>" + content + " </body></html>";
        //    message.IsBodyHtml = true;

        //    var smtpClient = new SmtpClient("smtp.gmail.com")
        //    {
        //        Port = 587,
        //        Credentials = new NetworkCredential(from, pass),
        //        EnableSsl = true,
        //    };
        //    try
        //    {
        //        smtpClient.Send(message);
        //        MessageBox.Show("Mail sent successfully.", "Email.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        }
    }
}
