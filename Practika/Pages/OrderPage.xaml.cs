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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {


        public Order order { get; set; }
        public List<OrderStatus> OrderStatuses { get; set; }


        public OrderPage(Order _order)
        {
            DBConnect.db.OrderStatus.Load();
            OrderStatuses = DBConnect.db.OrderStatus.Local.ToList();
            order = _order;
            InitializeComponent();
        }

        private void StatusCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Navigation.User.RoleId == 1)
            {
                StatusCb.SelectedIndex = 0;
            }
        }

        private void SaveOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            DBConnect.db.Order.Local.Add(order);
            DBConnect.db.SaveChanges();
            MessageBox.Show("Сохранено");
        }
    }
}
