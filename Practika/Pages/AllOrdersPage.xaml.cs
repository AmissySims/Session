using Practika.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practika.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllOrdersPage.xaml
    /// </summary>
    public partial class AllOrdersPage : Page
    {


        public ObservableCollection<Order> AllOrders
        {
            get { return (ObservableCollection<Order>)GetValue(AllOrdersProperty); }
            set { SetValue(AllOrdersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllOrdersProperty =
            DependencyProperty.Register("AllOrders", typeof(ObservableCollection<Order>), typeof(AllOrdersPage));


        public AllOrdersPage()
        {
            DBConnect.db.Order.Load();
            AllOrders = DBConnect.db.Order.Local;
            InitializeComponent();
        }
    }
}
