using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Practika.Components
{
    public partial class Product
    {
        public Visibility BtnVisible
        {
            get
            {
                if (Navigation.User.RoleId == 1) //Client
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }
        public string ColorDis
        {
            get
            {
                if (QuantityInStock == 0 || QuantityInStock == null)
                    return "#7d7f7d";
                else
                    return "#ffffff";



            }
        }
    }
}
