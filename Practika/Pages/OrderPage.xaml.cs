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
        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }


        public OrderPage(Order _order)
        {
            DBConnect.db.OrderStatus.Load();
            OrderStatuses = DBConnect.db.OrderStatus.Local.ToList();
            DBConnect.db.User.Load();
            Users = DBConnect.db.User.Local.ToList();
            DBConnect.db.Product.Load();
            Products = DBConnect.db.Product.Local.ToList();
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

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteProductBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QuTb_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        //private void UserExCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    order.User = UserExCb.SelectedItem as User;
        //}

        //private void UserCuCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    order.User1 = UserCuCb.SelectedItem as User;
        //}
    }
}
