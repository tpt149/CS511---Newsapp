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
            Paper choose = new Paper();
            choose.title = this.lbl_Title.Text;
           foreach(Paper p in Main.List_Article_Sort_By_View)
           {
                if (p.title == this.lbl_Title.Text)
                    p.view += 1;
           }

            List<Paper> List_sort_by_view = Sort_By_View(Main.List_Article_Sort_By_View);
            //List<Paper> List_sort_by_date = Sort_By_Date(Main.List_Article_Sort_By_View);

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

        public List<Paper> Sort_By_View(List<Paper> p)
        {
            p.Sort((p1,p2)=>p1.view.CompareTo(p2.view));
            return p;
        }
        public List<Paper> Sort_By_Date(List<Paper> p)
        {
            p.Sort((p1,p2)=>p1.date.CompareTo(p2.date));
            return p;
        }
        private void Article_Load(object sender, EventArgs e)
        {
            //sort theo date
            //sort theo view
        }
    }
}
