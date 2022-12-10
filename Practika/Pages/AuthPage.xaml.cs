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
                PasswordTb.Password = Properties.Settings.Default.Password;
        }

        private void EntrBtn_Click(object sender, RoutedEventArgs e)
        {
            int countAuto = Properties.Settings.Default.CountAuth;
            User user = DBConnect.db.User.FirstOrDefault(x => x.Login == LoginTb.Text.Trim() && x.Password == PasswordTb.Password.Trim());
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
                        Properties.Settings.Default.Login = LoginTb.Text;
                        Properties.Settings.Default.Password = PasswordTb.Password;
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
                timer.Tick += new EventHandler(isVisibleBTN);
                timer.Start();
            }
            //    int CountAuto = Properties.Settings.Default.CountAuth;

            //    string login = LoginTb.Text.Trim();
            //    string password = PasswordTb.Password.Trim();

            //    if (CountAuto < 3)
            //    {
            //        if (LoginTb.Text != null || PasswordTb.Password != null)
            //        {
            //            User user = DBConnect.db.User.FirstOrDefault(x => x.Login == LoginTb.Text.Trim() && x.Password == PasswordTb.Password.Trim());
            //            if (user == null)
            //            {
            //                if (SaveCb.IsChecked == true)
            //                {
            //                    Properties.Settings.Default.Login = LoginTb.Text;
            //                    Properties.Settings.Default.Password = PasswordTb.Password;
            //                    Properties.Settings.Default.Save();
            //                }
            //                else
            //                {
            //                    Properties.Settings.Default.Login = null;
            //                    Properties.Settings.Default.Password = null;
            //                    Properties.Settings.Default.Save();
            //                }

            //                Navigation.User = user;
            //                Navigation.NextPage(new Nav("Продукты", new ProductsListPage()));
            //                CountAuto = 0;
            //            }
            //            else
            //            {
            //                CountAuto += 1;
            //                Properties.Settings.Default.CountAuth = CountAuto;
            //                MessageBox.Show("Такого пользователя нет", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Не заполнены поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Вы ввели 3 раза неправильный пароль\nВход заблокировани на 1 минуту", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            //        CountAuto = 0;
            //        EntrBtn.IsEnabled = false;
            //        RegisBtn.IsEnabled = false;
            //        timer.Interval = new TimeSpan(0, 1, 0);
            //        timer.Tick += new EventHandler(isVisibleBTN);
            //        timer.Start();
            //    }


            //    //}


            }
            private void isVisibleBTN(object sender, EventArgs e)
            {
                EntrBtn.IsEnabled = true;
                RegisBtn.IsEnabled = true;
                timer.Stop();
            }
        private void RegisBtn_Click(object sender, RoutedEventArgs e)
            {
                Navigation.NextPage(new Nav("Регистрация", new RegPage()));
            }
    }
}
        


        
    


