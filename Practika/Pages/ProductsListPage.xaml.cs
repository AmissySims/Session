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
    /// Логика взаимодействия для ProductsListPage.xaml
    /// </summary>
    public partial class ProductsListPage : Page

    {


        public ObservableCollection<Product> Products
        {
            get { return (ObservableCollection<Product>)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductsProperty =
            DependencyProperty.Register("Products", typeof(ObservableCollection<Product>), typeof(ProductsListPage));


        public ProductsListPage()
        {
            DBConnect.db.Product.Load();
            Products = DBConnect.db.Product.Local;
            InitializeComponent();
            
        }
        private void Refresh()
        {
            ObservableCollection<Product> products = Products;
            
            if(FilterCb.SelectedItem != null)
            {
                switch((FilterCb.SelectedItem as ComboBoxItem).Tag)
                {
                    case "1":
                        products = DBConnect.db.Product.Local;
                        break;
                        case "2":
                        products = new ObservableCollection<Product>(Products.Where(x => x.UnitOfMeansurementId == 1));
                        break;
                    case "3":
                        products = new ObservableCollection<Product>(Products.Where(x => x.UnitOfMeansurementId == 2));
                        break;
                    default:
                        break;
                }
            }
            if (SortCb.SelectedItem != null)
            {
                switch ((SortCb.SelectedItem as ComboBoxItem).Tag)
                {
                    case "1":
                        products = DBConnect.db.Product.Local;
                        break;
                    case "2":
                        products = new ObservableCollection<Product>(Products.OrderBy(x => x.Title));

                        break;
                    case "3":
                        products = new ObservableCollection<Product>(Products.OrderByDescending(x => x.Title));
                        break;
                    case "4":
                        products = new ObservableCollection<Product>(Products.OrderBy(x => x.DateOfAddition));
                        break;
                    case "5":
                        products = new ObservableCollection<Product>(Products.OrderByDescending(x => x.DateOfAddition));
                        break;
                    default :
                        break;
                }


            }

            if(FoundTb.Text.Length > 0)
            {
                products = new ObservableCollection<Product>(Products.Where(x => x.Title.ToLower().StartsWith(FoundTb.Text.ToLower()) || x.Description.ToLower().StartsWith(FoundTb.Text.ToLower())));
            }

            Products = products;
            FoundCount.Text = products.Count().ToString() + " из ";
        }

        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CountCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void FilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void FoundTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
