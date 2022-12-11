using Microsoft.Win32;
using Practika.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Practika.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductPage.xaml
    /// </summary>
    public partial class AddEditProductPage : Page, INotifyPropertyChanged
    {
        public Product Product { get; set; }
        //public ProductsCountries productCountry { get; set; }
        public List<UnitOfMeansurement> MeasureUnits { get; set; }
        //public List<SuppliersCountry> Country { get; set; }
        //public static int countryId;

        public IEnumerable<SuppliersCountry> ProductCountries => Product.SuppliersCountry.ToList();
        public IEnumerable<SuppliersCountry> OtherCountries => DBConnect.db.SuppliersCountry.Local.Except(ProductCountries);

        //public ObservableCollection<SuppliersCountry> SuppliersCountriis
        //{
        //    get { return (ObservableCollection<SuppliersCountry>)GetValue(SuppliersCountriisProperty); }
        //    set { SetValue(SuppliersCountriisProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for > SuppliersCountriis.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SuppliersCountriisProperty =
        //    DependencyProperty.Register("SuppliersCountriis", typeof(ObservableCollection<SuppliersCountry>), typeof(AddEditProductPage));


        //public ObservableCollection<SuppliersCountry> SuppliersCountriisAll
        //{
        //    get { return (ObservableCollection<SuppliersCountry>)GetValue(SuppliersCountriisAllProperty); }
        //    set { SetValue(SuppliersCountriisAllProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for > SuppliersCountriis.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SuppliersCountriisAllProperty =
        //    DependencyProperty.Register("SuppliersCountriisAll", typeof(ObservableCollection<SuppliersCountry>), typeof(AddEditProductPage));

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        public AddEditProductPage(Product _product = null)
        {
            DBConnect.db.UnitOfMeansurement.Load();
            DBConnect.db.SuppliersCountry.Load();
            Product = _product ?? new Product();
            MeasureUnits = DBConnect.db.UnitOfMeansurement.Local.ToList();

            //SuppliersCountriis = new ObservableCollection<SuppliersCountry>(Product.SuppliersCountry);
            //SuppliersCountriisAll = new ObservableCollection<SuppliersCountry>(DBConnect.db.SuppliersCountry.Local.Except(Product.SuppliersCountry));

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
                Product.Photo = File.ReadAllBytes(openFile.FileName);
                ProductImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!DBConnect.db.Product.Local.Any(product => product.Id == Product.Id))
                DBConnect.db.Product.Local.Add(Product);
            DBConnect.db.SaveChanges();
            MessageBox.Show("Сохранено");

            Navigation.NextPage(new Nav("Продукты", new ProductsListPage()));
        }

        private void FilterProduct_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (EditUnitOfMeansurement.SelectedItem == null)
                return;

            Product.UnitOfMeansurement = EditUnitOfMeansurement.SelectedItem as UnitOfMeansurement;
        }

        private void AddCountryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CountryListCb.SelectedItem == null)
                return;

            /*SuppliersCountriis.Add(CountryListCb.SelectedItem as SuppliersCountry);
            SuppliersCountriisAll.Remove(CountryListCb.SelectedItem as SuppliersCountry);*/
            Product.SuppliersCountry.Add(CountryListCb.SelectedItem as SuppliersCountry);
            UpdateProductCountries();
        }

        private void DeleteCountryBtn_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<SuppliersCountry> selectedCountries = CountriesList.SelectedItems.Cast<SuppliersCountry>();
            if (selectedCountries == null || selectedCountries.Count() == 0)
                return;

            foreach (var country in selectedCountries)
                Product.SuppliersCountry.Remove(country);

            UpdateProductCountries();
        }

        private void CountryListCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UpdateProductCountries()
        {
            OnPropertyChanged(nameof(ProductCountries));
            OnPropertyChanged(nameof(OtherCountries));
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