using Practika.Components;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Practika.Windows
{
    /// <summary>
    /// Логика взаимодействия для SelectProductWindow.xaml
    /// </summary>
    public partial class SelectProductWindow : Window
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Product> SelectedProducts => ProductList.SelectedItems.Cast<Product>();

        public SelectProductWindow(IEnumerable<Product> products)
        {
            Products = DBConnect.db.Product.Local.Except(products);

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) =>
            Close();

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) =>
            DialogResult = true;
    }
}
