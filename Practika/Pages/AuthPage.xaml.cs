using Practika.Components;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void EntrBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = DBConnect.db.User.FirstOrDefault(x => x.Login == LoginTb.Text.Trim() && x.Password == PasswordTb.Text.Trim());
            
            if (user == null)
            {
                MessageBox.Show("Логин или пароль неверный");
                return;
            }

            Navigation.User = user;

            Navigation.NextPage(new Nav("Продукты", new ProductsListPage()));
        }

        private void RegisBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new Nav("Регистрация", new RegPage()));
        }
    }
}
