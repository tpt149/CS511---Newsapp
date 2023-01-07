using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newsapp
{
    public class Paper
    {
        public int view { get; set; }
        public string title { get; set; }
        public DateTime date { get; set; }

        public Paper()
        {
            title = "";
            view = 0;
            date = DateTime.Now;
        }
        public Paper(string title, int view,DateTime d)
        {
            this.title = title;
            this.view = view;
            this.date = d;
        }
    }
}
