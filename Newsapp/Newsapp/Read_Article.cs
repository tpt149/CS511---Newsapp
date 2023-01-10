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
                    lbl_content.Text = dr["articles"].ToString();
                    
                }
            }
        }


    }
}
