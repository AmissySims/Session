using Practika.Components;
using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace Practika.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {

        public AuthPage()
        {
            LoadDBTables();

            InitializeComponent();
            if (Properties.Settings.Default.Login != null)
                LoginTb.Text = Properties.Settings.Default.Login;
            if (Properties.Settings.Default.Password != null)
                PasswordTb.Password = Properties.Settings.Default.Password;
        }

        private void LoadDBTables()
        {
            DBConnect.db.User.Load();
            DBConnect.db.Role.Load();
        }

        private void EntrBtn_Click(object sender, RoutedEventArgs e)
        {
            int countAuto = Properties.Settings.Default.CountAuth;
            User user = DBConnect.db.User.Local.FirstOrDefault(x => x.Login == LoginTb.Text.Trim() && x.Password == PasswordTb.Password.Trim());
            if (countAuto < 3)
            {
                

                if (user == null)
                {
                    MessageBox.Show("Логин или пароль неверный");
                    return;
                }
                else
                {




                    if (SaveCb.IsChecked == true)
                    {
                        Properties.Settings.Default.Login = LoginTb.Text.Trim();
                        Properties.Settings.Default.Password = PasswordTb.Password.Trim();
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.Login = null;
                        Properties.Settings.Default.Password = null;
                        Properties.Settings.Default.Save();
                    }
                    Navigation.User = user;

                    Navigation.NextPage(new Nav("Продукты", new ProductsListPage()));



                }
            }
       
        }
        private void RegisBtn_Click(object sender, RoutedEventArgs e)
            {
                Navigation.NextPage(new Nav("Регистрация", new RegPage()));
            }
    }
}
        


        
    


