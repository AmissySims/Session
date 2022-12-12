using Practika.Components;
using Practika.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Practika.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page, INotifyPropertyChanged
    {
        public Order Order { get; set; }
        public ObservableCollection<OrderStatus> OrderStatuses { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public IEnumerable<User> Customers => DBConnect.db.User.Local.Where(user => user.RoleId == 1);
        public IEnumerable<User> Executors => DBConnect.db.User.Local.Where(user => user.RoleId == 3);
        public IEnumerable<ProductOrder> OrderProducts => Order.ProductOrders;

        public OrderPage(Order order)
        {
            InitializeOrderPage();

            InitializeOrder(order);
            InitializeComponent();
        }


        public OrderPage(IEnumerable<Product> addedProducts)
        {
            InitializeOrderPage();

            InitializeOrder();
            foreach (var product in addedProducts)
                DBConnect.db.ProductOrder.Local.Add(new ProductOrder()
                {
                    Order = Order,
                    Product = product,
                    PurchasePrice = product.Cost,
                    Quanity = 1
                });

            InitializeComponent();
        }


        private void InitializeOrder(Order order = null)
        {
            Order = order ?? new Order()
            {
                User = Navigation.User.RoleId == 3 ? Navigation.User : null,
                User1 = Navigation.User.RoleId == 1 ? Navigation.User : null,
                Date = DateTime.Now,
                OrderStatusId = 1
            };
        }

        private void InitializeOrderPage()
        {
            LoadDBTables();

            Users = DBConnect.db.User.Local;
            OrderStatuses = DBConnect.db.OrderStatus.Local;
            Products = DBConnect.db.Product.Local;
        }
        private static void LoadDBTables()
        {
            DBConnect.db.OrderStatus.Load();
            DBConnect.db.User.Load();
            DBConnect.db.Product.Load();
            DBConnect.db.ProductOrder.Load();
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
            DBConnect.db.Order.Local.Add(Order);
            DBConnect.db.SaveChanges();
            MessageBox.Show("Сохранено");
            if (Navigation.User.RoleId == 1)
                Navigation.NextPage(new Nav("Продукты", new ProductsListPage()));
            else
                Navigation.NextPage(new Nav("Заказы", new AllOrdersPage()));
        }

        

        private void AddProductInOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectProductWindow selectProduct = new SelectProductWindow(OrderProducts.Select(o => o.Product));
            selectProduct.ShowDialog();
            if (selectProduct.DialogResult == true)
            {
                foreach (var product in selectProduct.SelectedProducts)
                    DBConnect.db.ProductOrder.Local.Add(new ProductOrder()
                    {
                        Order = Order,
                        Product = product,
                        PurchasePrice = product.Cost,
                        Quanity = 1
                    });
                OnPropertyChanged(nameof(OrderProducts));
            }
        }

        private void DeleteProductInOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<ProductOrder> orderProducts = ProductsList.SelectedItems.Cast<ProductOrder>();
            if (orderProducts == null)
                return;

            foreach (var orderProduct in orderProducts)
                DBConnect.db.ProductOrder.Local.Remove(orderProduct);
            DBConnect.db.SaveChanges();
            OnPropertyChanged(nameof(OrderProducts));
        }



        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
