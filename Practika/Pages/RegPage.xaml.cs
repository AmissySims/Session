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
            var check = DBConnect.db.User.Where(x => x.Login == login).FirstOrDefault();
            if (check == null)
            {
                if (login.Length > 0 && password.Length > 0 && firstname.Length > 0 && lastname.Length > 0 && email.Length > 0)
                {
                    if (DBConnect.db.User.Local.Any(x => x.Login == login && x.Email == email && x.Phone == phone))
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
                            Phone = phone,
                            Email = email,
                            GenderId = GenderCb.SelectedIndex + 1,
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
                            MessageBox.Show("Пароль слишком короткий, требуется минимум 6 символов!");
                            return;
                        }

                        
                    }
                    
                }
                else
                {
                    MessageBox.Show("Заполните поля");
                    return;
                }
                
            }

            DBConnect.db.SaveChanges();
            Navigation.BackPage();
        }
    }
}
