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

namespace IvanProduction
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string login = "Username";
        private const string password = "Password";
        public MainWindow()
        {
            InitializeComponent();
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(LoginTB.Text == login)
            LoginTB.Text = "";           
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(LoginTB.Text))
            {
                LoginTB.Text = login;
            }
        }

        private void PasswordTB_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTB.Password == password)
                PasswordTB.Password = "";
        }

        private void PasswordTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(PasswordTB.Password))
            {
                PasswordTB.Password = password;
            }
        }
    }
}
