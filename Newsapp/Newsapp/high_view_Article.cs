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
    public partial class high_view_Article : UserControl
    {
        public high_view_Article()
        {
            InitializeComponent();
        }

        private void lbl_title_Click(object sender, EventArgs e)
        {

        }

        private void lbl_view_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pic_hight_view_Article_Click(object sender, EventArgs e)
        {
            Article.choosen.title = lbl_title.Text;
            Article.choosen.Category = lbl_Category.Text;
            Read_Article read_Article = new Read_Article();
            read_Article.ShowDialog();
        }
    }
}
