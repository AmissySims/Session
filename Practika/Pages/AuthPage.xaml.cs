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
using System.Windows.Threading;

namespace Practika.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        public AuthPage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Login != null)
                LoginTb.Text = Properties.Settings.Default.Login;
            if (Properties.Settings.Default.Password != null)
                PasswordTb.Text = Properties.Settings.Default.Password;
        }

        private void EntrBtn_Click(object sender, RoutedEventArgs e)
        {
            int countAuto = Properties.Settings.Default.CountAuth;
            if(countAuto < 3) 
            { 
                User user = DBConnect.db.User.FirstOrDefault(x => x.Login == LoginTb.Text.Trim() && x.Password == PasswordTb.Text.Trim());

                if (user == null)
                {
                    MessageBox.Show("Логин или пароль неверный");
                    return;
                }
                else
                {




                    if (SaveCb.IsChecked == true)
                    {
                        Properties.Settings.Default.Login = LoginTb.Text;
                        Properties.Settings.Default.Password = PasswordTb.Text;
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
            else
            {
                MessageBox.Show("Вы ввели 3 раза неправильный пароль\nВход заблокировани на 1 минуту", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                countAuto = 0;
                EntrBtn.IsEnabled = false;
                RegisBtn.IsEnabled = false;
                timer.Interval = new TimeSpan(0, 1, 0);
                //timer.Tick += new EventHandler(isVisibleBTN);
                timer.Start();
            }
        }
        private void RegisBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new Nav("Регистрация", new RegPage()));
        }
    }
}

