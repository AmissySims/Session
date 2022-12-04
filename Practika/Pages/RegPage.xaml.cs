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
            if (DBConnect.db.User.Local.Any(x => x.Login == LoginTb.Text.Trim() &&
                                            x.Email == EmailTb.Text.Trim() && 
                                            x.Phone == PhoneTb.Text.Trim()))
            {
                MessageBox.Show("Такой пользователь существует");
                return;
            }
            User user = new User()
            {
                Login = LoginTb.Text.Trim(),
                Password = PasswordTb.Text.Trim(),
                Email = EmailTb.Text.Trim(),
                Phone = PhoneTb.Text.Trim(),
                FirstName = FirstNameTb.Text.Trim(),
                LastName = LastNameTb.Text.Trim(),
                Patronymic = PatronymicTb.Text.Trim(),
                GenderId = GenderCb.SelectedIndex + 1,
                RoleId = 1
            };

            DBConnect.db.User.Local.Add(user);

            Navigation.User = user;

            DBConnect.db.SaveChanges();
        }
    }
}
