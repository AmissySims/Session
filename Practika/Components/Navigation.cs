using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Practika.Components
{
    internal class Navigation
    {
        public static User User { get; set; }
        public static MainWindow main;
        public static List<Nav> navs = new List<Nav>();

        public static void ChangePage(Nav nav)
        {

            navs.Add(nav);
            Update(nav);
            
        }
        
        private static void Update(Nav nav)
        {
            main.MainFrame.Navigate(nav.Page);
            main.TitlePage.Text = nav.Title;
        }
    }

    class Nav
    {
        public string Title { get; set; }
        public Page Page { get; set; }
        public Nav(string Title, Page Page)
        {
            this.Title = Title;
            this.Page = Page;
        }
    }
}
