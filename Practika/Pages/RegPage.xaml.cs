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
            //if (DBConnect.db.User.Local.Any(x => x.Login == LoginTb.Text.Trim() &&
            //                                x.Email == EmailTb.Text.Trim() && 
            //                                x.Phone == PhoneTb.Text.Trim()))
            //{
            //    MessageBox.Show("Такой пользователь существует");
            //    return;
            //}
            //User user = new User()
            //{
            //    Login = LoginTb.Text.Trim(),
            //    Password = PasswordTb.Text.Trim(),
            //    Email = EmailTb.Text.Trim(),
            //    Phone = PhoneTb.Text.Trim(),
            //    FirstName = FirstNameTb.Text.Trim(),
            //    LastName = LastNameTb.Text.Trim(),
            //    Patronymic = PatronymicTb.Text.Trim(),
            //    GenderId = GenderCb.SelectedIndex + 1,
            //    RoleId = 1
            //};

            //DBConnect.db.User.Local.Add(user);

            //Navigation.User = user;

            //DBConnect.db.SaveChanges();
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Text.Trim();
            string firstname = FirstNameTb.Text.Trim();
            string lastname = LastNameTb.Text.Trim();
            string patronymic = PatronymicTb.Text.Trim();
            string email = EmailTb.Text.Trim();
            var check = DBConnect.db.User.Where(x => x.Login == login).FirstOrDefault();
            if (check == null)
            {
                if (login.Length > 0 && password.Length > 0 && firstname.Length > 0 && lastname.Length > 0 && email.Length > 0)
                {
                    if (DBConnect.db.User.Local.Any(x => x.Login == login))
                    {
                        MessageBox.Show("Tакой пользователь уже существует");
                        return;
                    }
                    else
                    {
                        DBConnect.db.User.Add(new User
                        {
                            Login = login,
                            Password = password,
                            FirstName = firstname,
                            LastName = lastname,
                            Patronymic = patronymic,
                            Email = email,
                            RoleId = 1
                        });
                        if (password.Length >= 6)
                        {
                            bool symbol = false;
                            bool number = false;
                            bool IsAllUpper = false;
                            for (int i = 0; i < password.Length; i++)
                            {
                                if (password[i] >= '0' && password[i] <= '9') number = true;
                                if (password[i] == '!' || password[i] == '@' || password[i] == '#' || password[i] == '%' || password[i] == '^') symbol = true;
                                if (Char.IsUpper(password[i])) IsAllUpper = true;
                            }
                            if (!symbol)
                            {
                                MessageBox.Show("Добавьте один из следующих символов: ! @ # $ % ^");
                                return;
                            }
                            else if (!number)
                            {
                                MessageBox.Show("Добавьте хотя бы одну цифру");
                                return;
                            }
                            else if (!IsAllUpper)
                            {
                                MessageBox.Show("Добавьте одну прописную букву");
                                return;
                            }

                            MessageBox.Show("Регистрация прошла успешно");
                        }
                        else
                        {
                            MessageBox.Show("пароль слишком короткий, требуется миниум 6 символов!");
                            return;
                        }

                        DBConnect.db.SaveChanges();
                        Navigation.BackPage();
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля");
                    return;
                }
            }
        }
    }
}
