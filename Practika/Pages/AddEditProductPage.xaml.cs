using Microsoft.Win32;
using Practika.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.IO;
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
    /// Логика взаимодействия для AddEditProductPage.xaml
    /// </summary>
    public partial class AddEditProductPage : Page
    {
        public Product product { get; set; }
        //public ProductsCountries productCountry { get; set; }
        public List<UnitOfMeansurement> MeasureUnits { get; set; }
        //public List<SuppliersCountry> Country { get; set; }
        //public static int countryId;



        public ObservableCollection<SuppliersCountry> SuppliersCountriis
        {
            get { return (ObservableCollection<SuppliersCountry>)GetValue(SuppliersCountriisProperty); }
            set { SetValue(SuppliersCountriisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for > SuppliersCountriis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SuppliersCountriisProperty =
            DependencyProperty.Register("SuppliersCountriis", typeof(ObservableCollection<SuppliersCountry>), typeof(AddEditProductPage));


        public ObservableCollection<SuppliersCountry> SuppliersCountriisAll
        {
            get { return (ObservableCollection<SuppliersCountry>)GetValue(SuppliersCountriisAllProperty); }
            set { SetValue(SuppliersCountriisAllProperty, value); }
        }

        // Using a DependencyProperty as the backing store for > SuppliersCountriis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SuppliersCountriisAllProperty =
            DependencyProperty.Register("SuppliersCountriisAll", typeof(ObservableCollection<SuppliersCountry>), typeof(AddEditProductPage));




        public AddEditProductPage(Product _product)
        {
            product = _product;
            DBConnect.db.UnitOfMeansurement.Load();
            MeasureUnits = DBConnect.db.UnitOfMeansurement.Local.ToList();

            SuppliersCountriis = new ObservableCollection<SuppliersCountry>(DBConnect.db.SuppliersCountry.Local.Where(x => x.ProductsCountries == product.ProductsCountries).Select(s => s).Distinct());
            SuppliersCountriisAll = new ObservableCollection<SuppliersCountry>(DBConnect.db.SuppliersCountry.Local.Where(x => x.ProductsCountries != product.ProductsCountries).Select(s => s).Distinct());

            InitializeComponent();

        }


        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg",
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                product.Photo = File.ReadAllBytes(openFile.FileName);
                ProductImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            DBConnect.db.Product.Local.Add(product);
            DBConnect.db.SaveChanges();
            MessageBox.Show("Сохранено");



            Navigation.NextPage(new Nav("Продукты", new ProductsListPage()));
        }

        private void FilterProduct_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (EditUnitOfMeansurement.SelectedItem == null)
                return;

            product.UnitOfMeansurement = EditUnitOfMeansurement.SelectedItem as UnitOfMeansurement;
        }

        private void AddCountryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CountryListCb.SelectedItem == null)
                return;

            SuppliersCountriis.Add(CountryListCb.SelectedItem as SuppliersCountry);
            SuppliersCountriisAll.Remove(CountryListCb.SelectedItem as SuppliersCountry);

        }

        private void DeleteCountryBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CountryListCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //private void AddCountryBtn_Click(object sender, RoutedEventArgs e)
        //{

        //if( CountriesList.SelectedItem == null )
        //    return;
        //List<SuppliersCountry> country = new List<SuppliersCountry>();
        //List<SuppliersCountry> countryRemoves = new List<SuppliersCountry>();
        //foreach( var item in CountriesList.SelectedItems )
        //{
        //    country.Add(item as SuppliersCountry);
        //    countryRemoves.Add(item as SuppliersCountry);
        //    DBConnect.db.ProductsCountries(new ProductsCountries
        //    {
        //        Country = item as SuppliersCountry,
        //        Product = product
        //    });
        //}
        //if(CountryListCb.SelectedItem != null)
        //{
        //    var itemCountry = CountryListCb.SelectedItem as SuppliersCountry;
        //    ProductsCountries productsCountries = new ProductsCountries
        //    {
        //        Country = itemCountry,
        //        Product = product,
        //    };
        //    DBConnect.db.ProductsCountries.Local.Add(productsCountries);
        //    MessageBox.Show("hkh");

    }

    //private void DeleteCountryBtn_Click(object sender, RoutedEventArgs e)
    //{

    //}

    //private void CountryListCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    CountryCb.ItemsSource = DBConnect.db.SuppliersCountry.ToList();

    //}

}


