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
    public partial class Article : UserControl
    {
        public Article()
        {
            InitializeComponent();
        }
        private void pic_Article_Click(object sender, EventArgs e)
        {


        }
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


        private void Article_Load(object sender, EventArgs e)
        {

        }
    }
}
