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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {

            Navigation.BackPage();
        }

        private void RegistBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Text.Trim();
            string firstname = FirstNameTb.Text.Trim();
            string lastname = LastNameTb.Text.Trim();
            string patronymic = PatronymicTb.Text.Trim();
            string phone = PhoneTb.Text.Trim();
            string email = EmailTb.Text.Trim();

            char[] chars = { '!', '@', '#', '$', '%', '^' };
            var check = DBConnect.db.User.Where(x => x.Login == login).FirstOrDefault();
            if (check == null)
            {
                if (password.Length > 5 && password.Any(ch => Char.IsUpper(ch)) && password.Any(ch => Char.IsLower(ch)) && password.Any(ch => Char.IsDigit(ch)) && password.Any(ch => chars.Contains(ch)))
                {
                    DBConnect.db.User.Add(new User
                    {
                        Login = login,
                        Password = password,
                        FirstName = firstname,
                        LastName = lastname,
                        Patronymic = patronymic,
                        Phone = phone,
                        Email = email,
                        GenderId = GenderCb.SelectedIndex + 1,
                        RoleId = 1
                    });
                    
                    MessageBox.Show("Сохранено!");
                    DBConnect.db.SaveChanges();
                    Navigation.BackPage();
                }
                else
                {
                    MessageBox.Show("Проверьте на правильность заполнения.\n" +
                        " Пароль должен содержать 6 символов, хотя бы 1 прописную букву," +
                        " хотя бы 1 цифру и хотя бы 1 из этих символов ! @ # $ % ^");
                }
            }
            else
            {
                MessageBox.Show("Такой пользователь уже существует");
            }

            
            


        }
    }
}
