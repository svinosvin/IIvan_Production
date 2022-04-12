using IvanProduction.Model;
using IvanProduction.ViewModels;
using IvanProduction.Views.Windows;
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

namespace IvanProduction.Views.UserContols
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        public Account Account { get; set; } = UserMainWindowView.ActiveUser;
        public ProfileView()
        {
            InitializeComponent();
            form1.DataContext = Account;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User { Id = Account.AccountHolder.Id, Email = Email.Text.ToString(),
                Name = Name.Text.ToString(),
                Password = Password.Text.ToString(),
                Username = Username.Text.ToString(),
                Surname = Surname.Text.ToString()
            };
            UserMainWindowView.UpdateAccount(user);
            MessageBox.Show("Данные были изменены");
            
          } 
         
        }
    }

