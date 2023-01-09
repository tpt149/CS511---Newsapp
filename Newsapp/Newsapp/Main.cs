using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Net;


namespace Newsapp
{
    public partial class Main : Form
    {
        string str_connect = @"Data Source=DESKTOP-JMN4VSF\SQLEXPRESS;Initial Catalog=Newsapp;Integrated Security=True";
        SqlConnection conn = null;
        public static DataTable Table_News_Entertain = new DataTable();
        public static DataTable Table_News_Travel = new DataTable();
        public static DataTable Table_News_Sport = new DataTable();
        public static DataTable table_All = new DataTable();
        public static DataTable table_All_Sort_By_Date = new DataTable();
        public static DataTable table_All_Sort_By_View = new DataTable();

        public Main()
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
                //pic_Icon.ImageLocation = "https://openweathermap.org/img/w" + Info.weather[0].icon + ".png";
                //lab_condition.Text = Info.weather[0].main;
                //lab_detail.Text = Info.weather[0].description;
                //lab_sunset.Text = convertDateTime(Info.sys.sunset).ToString();
                lab_sunrise.Text = convertDateTime(Info.sys.sunset).ToString();
                //lab_windspeed.Text = Info.wind.speed.ToString();
                //lab_pressure.Text = Info.main.pressure.ToString();
                lblTemp.Text = (Info.main.temp - 273.15).ToString();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getWeather();
        }

        DateTime convertDateTime(long millisec)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            day = day.AddSeconds(millisec).ToLocalTime();

            return day;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            #region Connect to database & Load film to dataTable
            string query_Entertain = "SELECT * FROM Entertain$";
            string query_Travel = "SELECT * FROM Travel$";
            string query_Sport = "SELECT * FROM Sport$";

            conn = new SqlConnection(str_connect);
            SqlCommand cmd_Entertain = new SqlCommand(query_Entertain, conn);
            SqlCommand cmd_Travel = new SqlCommand(query_Travel, conn);
            SqlCommand cmd_Sport = new SqlCommand(query_Sport, conn);
            conn.Open();
            SqlDataAdapter da_Entertain = new SqlDataAdapter(cmd_Entertain);
            SqlDataAdapter da_Travel = new SqlDataAdapter(cmd_Travel);
            SqlDataAdapter da_Sport = new SqlDataAdapter(cmd_Sport);

            da_Entertain.Fill(Table_News_Entertain);
            da_Travel.Fill(Table_News_Travel);
            da_Sport.Fill(Table_News_Sport);

            conn.Close();
            da_Entertain.Dispose();
            da_Travel.Dispose();
            da_Sport.Dispose();
            #endregion
            #region Display News into Main UI
            Display_News(Table_News_Entertain, flp_News);
            Display_News(Table_News_Sport, flp_News);
            Display_News(Table_News_Travel, flp_News);
            #endregion
            #region Merge 3 table lại
            table_All = Table_News_Travel.Copy();
            table_All.Merge(Table_News_Sport);
            table_All.Merge(Table_News_Entertain);
            #endregion
            #region Tạo 2 bảo sort theo thời gian và theo lượt xem
            table_All_Sort_By_View = resort(table_All, "View", "desc");// Table sort theo lượt xem
            table_All_Sort_By_Date = resort(table_All, "Date", "desc");// Table sort theo thời gian
            Display_high_view_News(table_All_Sort_By_View, flp_TinXemNhieuNhat);
            #endregion
            #region Hiển thị 4 bài báo mới nhất
            #region Bài báo 1
            DataRow dr1 = table_All_Sort_By_Date.Rows[0];
            Pic_hot_1.ImageLocation= dr1["Represent"].ToString();
            lbl_Date1.Text = dr1["Date"].ToString();
            lbl_Title1.Text = dr1["titles"].ToString();
            Pic_hot_1.Show();

            var ar1_title = Pic_hot_1.PointToScreen(lbl_Title1.Location);
            ar1_title = lbl_Title1.PointToClient(ar1_title);
            lbl_Title1.Parent = Pic_hot_1;
            lbl_Title1.Location = ar1_title;
            lbl_Title1.BackColor = Color.Transparent;


            var ar1_author = Pic_hot_1.PointToScreen(lbl_Author1.Location);
            ar1_author = Pic_hot_1.PointToClient(ar1_author);
            lbl_Author1.Parent = Pic_hot_1;
            lbl_Author1.Location = ar1_author;
            lbl_Author1.BackColor = Color.Transparent;

            //var ar1_Date = Pic_hot_1.PointToScreen(lbl_Date1.Location);
            //ar1_Date = Pic_hot_1.PointToClient(ar1_Date);
            //lbl_Date1.Parent = Pic_hot_1;
            //lbl_Date1.Location = ar1_Date;
            //lbl_Date1.BackColor = Color.Transparent;


            //lbl_Author1
            //lbl_Category1
            #endregion
            #region Bài báo 2
            DataRow dr2 = table_All_Sort_By_Date.Rows[1];
            pic_hot_2.ImageLocation = dr2["Represent"].ToString();
            pic_hot_2.Show();
            lbl_Date2.Text = dr2["Date"].ToString();
            lbl_Title2.Text = dr2["titles"].ToString();
            //lbl_Author2
            //lbl_Category2

            //var ar2_title = pic_hot_2.PointToScreen(lbl_Title2.Location);
            //ar2_title = pic_hot_2.PointToClient(ar2_title);
            //lbl_Title2.Parent = pic_hot_2;
            //lbl_Title2.Location = ar2_title;
            //lbl_Title2.BackColor = Color.Transparent;

            //var ar2_Author = pic_hot_2.PointToScreen(lbl_author2.Location);
            //ar2_Author = pic_hot_2.PointToClient(ar2_Author);
            //lbl_author2.Parent = pic_hot_2;
            //lbl_author2.Location = ar2_Author;
            //lbl_author2.BackColor = Color.Transparent;

            //var ar2_Date = pic_hot_2.PointToScreen(lbl_Date2.Location);
            //ar2_Date = pic_hot_2.PointToClient(ar2_Date);
            //lbl_Date2.Parent = pic_hot_2;
            //lbl_Date2.Location = ar2_Date;
            //lbl_Date2.BackColor = Color.Transparent;
            #endregion
            #region Bài báo 3
            DataRow dr3 = table_All_Sort_By_Date.Rows[2];
            pic_hot_3.ImageLocation = dr3["Represent"].ToString();
            pic_hot_3.Show();
            lbl_Date3.Text = dr3["Date"].ToString();
            lbl_Title3.Text = dr3["titles"].ToString();
            //lbl_Author3
            //lbl_Category3
            #endregion
            #region Bài báo 4
            DataRow dr4 = table_All_Sort_By_Date.Rows[3];
            pic_hot_4.ImageLocation = dr4["Represent"].ToString();
            pic_hot_4.Show();
            lbl_Date4.Text = dr4["Date"].ToString();
            lbl_Title4.Text = dr4["titles"].ToString();
            //lbl_Author4
            //lbl_Category4
            #endregion
            #endregion
        }
        public static DataTable resort(DataTable dt, string colName, string direction)
        {
            DataTable dtOut = null;
            dt.DefaultView.Sort = colName + " " + direction;
            dtOut = dt.DefaultView.ToTable();
            return dtOut;
        }
        public void Display_News(DataTable dt,FlowLayoutPanel fl)
        {
            foreach(DataRow dr in dt.Rows)
            {
                Article article = new Article();
                fl.Controls.Add(article);
                article.lbl_Title.Text = dr["titles"].ToString();
                article.lbl_date.Text = dr["Date"].ToString();
                article.pic_Article.ImageLocation = dr["Represent"].ToString();
                article.pic_Article.SizeMode = PictureBoxSizeMode.StretchImage;
                article.pic_Article.Show();
            }
        }
        public void Display_high_view_News(DataTable dt, FlowLayoutPanel fl)
        {
            foreach (DataRow dr in dt.Rows)
            {
                high_view_Article article = new high_view_Article();
                fl.Controls.Add(article);
                article.lbl_title.Text = dr["titles"].ToString();
                article.lbl_view.Text = dr["View"].ToString();
                article.pic_hight_view_Article.ImageLocation = dr["Represent"].ToString();
                article.pic_hight_view_Article.SizeMode = PictureBoxSizeMode.StretchImage;
                article.pic_hight_view_Article.Show();
            }
        }
        private void btn_Travel_Click(object sender, EventArgs e)
        {
            flp_News.Controls.Clear();
            Display_News(Table_News_Travel, flp_News);
        }
        private void btn_Sport_Click(object sender, EventArgs e)
        {
            flp_News.Controls.Clear();
            Display_News(Table_News_Sport, flp_News);
        }
        private void btn_Entertain_Click(object sender, EventArgs e)
        {
            btn_Entertain.BackColor = Color.YellowGreen;
            flp_News.Controls.Clear();
            Display_News(Table_News_Entertain, flp_News);
        }
        private void btn_Home_Click(object sender, EventArgs e)
        {
            flp_News.Controls.Clear();
            Display_News(Table_News_Entertain, flp_News);
            Display_News(Table_News_Sport, flp_News);
            Display_News(Table_News_Travel, flp_News);
        }
        #region MouseMove_MouseLeave
        private void btn_Home_MouseMove(object sender, MouseEventArgs e)
        {
            btn_Home.BackColor = Color.YellowGreen;
        }
        private void btn_Home_MouseLeave(object sender, EventArgs e)
        {
            btn_Home.BackColor = Color.FromArgb(30, 40, 45);
        }
        private void btn_Travel_MouseMove(object sender, MouseEventArgs e)
        {
            btn_Travel.BackColor = Color.YellowGreen;
        }
        private void btn_Travel_MouseLeave(object sender, EventArgs e)
        {
            btn_Travel.BackColor = Color.FromArgb(30,40,45);
        }
        private void btn_Sport_MouseMove(object sender, MouseEventArgs e)
        {
            btn_Sport.BackColor = Color.YellowGreen;

        }
        private void btn_Sport_MouseLeave(object sender, EventArgs e)
        {
            btn_Sport.BackColor = Color.FromArgb(30, 40, 45);
        }
        private void btn_Entertain_MouseMove(object sender, MouseEventArgs e)
        {
            btn_Entertain.BackColor = Color.YellowGreen;

        }
        private void btn_Entertain_MouseLeave(object sender, EventArgs e)
        {
            btn_Entertain.BackColor = Color.FromArgb(30, 40, 45);

        }
        private void btn_KhuyenMai_MouseMove(object sender, MouseEventArgs e)
        {
            btn_KhuyenMai.BackColor = Color.YellowGreen;

        }
        private void btn_KhuyenMai_MouseLeave(object sender, EventArgs e)
        {
            btn_KhuyenMai.BackColor = Color.FromArgb(30, 40, 45);
        }
        private void btn_DangBaiBao_MouseMove(object sender, MouseEventArgs e)
        {
            btn_DangBaiBao.BackColor = Color.YellowGreen;

        }
        private void btn_DangBaiBao_MouseLeave(object sender, EventArgs e)
        {
            btn_DangBaiBao.BackColor = Color.FromArgb(30, 40, 45);
        }
        #endregion
        //public static List<Paper> List_Article_Sort_By_View = new List<Paper>();
        private void btn_KhuyenMai_Click(object sender, EventArgs e)
        {


            //Phải có dữ liệu về các bài báo có khuyến mãi --> thu thập thêm dữ liệu
        }
        private void txt_Search_Enter(object sender, EventArgs e)
        {
            if(txt_Search.Text== "Nhập từ khóa...")
            {
                txt_Search.Text = "";
                txt_Search.ForeColor = Color.Black;
            }
        }
        private void txt_Search_Leave(object sender, EventArgs e)
        {
            if (txt_Search.Text == "")
            {
                txt_Search.Text = "Nhập từ khóa...";
                txt_Search.ForeColor = Color.Silver;
            }
        }

        private void txt_Search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                flp_News.Controls.Clear();
                DataRow[] filteredRows_by_title = new DataRow[table_All.Rows.Count];
                filteredRows_by_title = table_All.Select("titles LIKE '%" + txt_Search.Text.Trim() + "%'");
                foreach (DataRow row in filteredRows_by_title)
                {
                    Article a = new Article();
                    flp_News.Controls.Add(a);
                    a.lbl_date.Text = row["Date"].ToString();
                    a.lbl_Title.Text = row["titles"].ToString();
                    a.pic_Article.ImageLocation = row["Represent"].ToString();
                    a.pic_Article.SizeMode = PictureBoxSizeMode.StretchImage;
                    a.pic_Article.Show();
                }
                DataRow[] filteredRows_By_description = new DataRow[table_All.Rows.Count];
                filteredRows_By_description = table_All.Select("descriptions LIKE '%" + txt_Search.Text.Trim() + "%'");
                foreach (DataRow row in filteredRows_By_description)
                {
                    Article a = new Article();
                    flp_News.Controls.Add(a);
                    a.lbl_date.Text = row["Date"].ToString();
                    a.lbl_Title.Text = row["titles"].ToString();
                    a.pic_Article.ImageLocation = row["Represent"].ToString();
                    a.pic_Article.SizeMode = PictureBoxSizeMode.StretchImage;
                    a.pic_Article.Show();
                }
                DataRow[] filteredRows_By_aritcles = new DataRow[table_All.Rows.Count];
                filteredRows_By_aritcles = table_All.Select("articles LIKE '%" + txt_Search.Text.Trim() + "%'");
                foreach (DataRow row in filteredRows_By_aritcles)
                {
                    Article a = new Article();
                    flp_News.Controls.Add(a);
                    a.lbl_date.Text = row["Date"].ToString();
                    a.lbl_Title.Text = row["titles"].ToString();
                    a.pic_Article.ImageLocation = row["Represent"].ToString();
                    a.pic_Article.SizeMode = PictureBoxSizeMode.StretchImage;
                    a.pic_Article.Show();
                }
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void lbl_email_Click(object sender, EventArgs e)
        {
            Mail m = new Mail();
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
