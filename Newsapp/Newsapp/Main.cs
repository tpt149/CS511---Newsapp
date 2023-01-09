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
        public Main()
        {
            InitializeComponent();

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
            #region Load Tin xem nhiều nhất
            table_All = resort(table_All, "View", "desc");
            Display_high_view_News(table_All, flp_TinXemNhieuNhat);
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
        private void btn_TinMoi_Click(object sender, EventArgs e)
        {
            flp_News.Controls.Clear();
            //trộn 3 bảng sau đó sẽ xuất theo thứ tự titles trong List_Article_Sort_By_view
            // Như vậy là hiện ra tin mới
            table_All = resort(table_All,"Date","desc");
            #region Xuất theo thứ tự date
            Display_News(table_All, flp_News);
            #endregion
        }
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
                DataRow[] filteredRows = new DataRow[table_All.Rows.Count];
                filteredRows = table_All.Select("titles LIKE '%" + txt_Search.Text.Trim() + "%'");
                foreach (DataRow row in filteredRows)
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
    }
}
