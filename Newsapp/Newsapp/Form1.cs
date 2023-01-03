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
    public partial class Form1 : Form
    {
        bool sidebarExpand;
        bool homeCollapsed;
        public Form1()
        {
            InitializeComponent();
        }

        private void sidebarTime_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if(sidebar.Width==sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTime.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTime.Stop();
                }
            }

        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTime.Start();
        }

        private void homeTime_Tick(object sender, EventArgs e)
        {
            if (homeCollapsed)
            {
                homeContainer.Height += 10;
                if (homeContainer.Height == homeContainer.MaximumSize.Height)
                {
                    homeCollapsed = false;
                    homeTime.Stop();
                }
            }
            else
            {
                homeContainer.Height -= 10;
                if (homeContainer.Height == homeContainer.MinimumSize.Height)
                {
                    homeCollapsed = true;
                    homeTime.Stop();
                }
            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            homeTime.Start();
        }
    }
}
