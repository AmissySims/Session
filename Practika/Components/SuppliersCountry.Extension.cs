using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Practika.Components
{
    public partial class SuppliersCountry
    {
        private static BrushConverter _brushConverter = new BrushConverter();   

        private Brush _brush;
        public Brush Brush
        {
            get
            {
                if (_brush == null)
                    _brush = (SolidColorBrush)_brushConverter.ConvertFrom($"#{ColorHex}");
                return _brush;
            }
        }


        public Visibility BtnVisible
        {
            get
            {
                if (Navigation.User.RoleId == 1) 
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }

        //public string ColorDis
        //{
        //    get
        //    {
        //        if (QuanityInStock == 0 || QuanityInStock == null)
        //            return "#ffffff";
        //        else
        //            return "#D1FFD1";
        //    }
        //}
    }
}
