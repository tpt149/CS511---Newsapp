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
            #region Tạo List Article để phục vụ cho việc sort theo view và date
            Add_List_Article(List_Article_Sort_By_View, Table_News_Sport);
            Add_List_Article(List_Article_Sort_By_View, Table_News_Entertain);
            Add_List_Article(List_Article_Sort_By_View, Table_News_Travel);
            #endregion
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
        public void Add_Article(List<Paper> l, Paper f)
        {
            int index = 0;
            if (l.Count == 0)
            {
                l.Add(f);
                index++;
            }
            else
            {
                foreach (Paper fi in l.ToList())
                {
                    if (fi.title == f.title)
                        continue;
                    else if (fi.title != f.title && index == l.Count - 1)
                    {
                        l.Add(f);
                    }
                    index++;
                }
            }
        }
        public void Add_List_Article(List<Paper> p, DataTable dt)
        {
            Paper choose = new Paper();
            foreach (DataRow dr in dt.Rows)
            {
                choose.title = dr["titles"].ToString();
                choose.view = 0; // Dùng view để sắp xếp và rank theo lượt xem
                choose.date = (DateTime)dr["Date"]; //Dùng date để sắp xếp và rank theo độ mới
                Add_Article(p, choose);
                choose = new Paper();
            }
        }
        public static List<Paper> List_Article_Sort_By_View = new List<Paper>();
        private void btn_TinMoi_Click(object sender, EventArgs e)
        {
            List_Article_Sort_By_View.Sort((p1, p2) => p1.date.CompareTo(p2.date));
            flp_News.Controls.Clear();
            //trộn 3 bảng sau đó sẽ xuất theo thứ tự titles trong List_Article_Sort_By_view
            // Như vậy là hiện ra tin mới
        }

        private void btn_KhuyenMai_Click(object sender, EventArgs e)
        {
            //Phải có dữ liệu về các bài báo có khuyến mãi --> thu thập thêm dữ liệu
        }
    }
}
