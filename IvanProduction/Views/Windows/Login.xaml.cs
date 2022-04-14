using IvanProduction.Model;
using IvanProduction.Model.ModelsStatic;
using IvanProduction.Services;
using IvanProduction.ViewModels;
using IvanProduction.ViewModels.AdminsViewModels;
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

namespace IvanProduction
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        private const string login = "Username";
        private const string password = "Password";
        public Login()
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

        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            RegBtn.Visibility = Visibility.Hidden;
        }

        private void checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            RegBtn.Visibility = Visibility.Visible;
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkbox.IsChecked == false)
                {
                    string pass = PasswordTB.Password;
                    string log = LoginTB.Text;
                    Account a = Elements.AccountElements.GetAll().Result.FirstOrDefault(x => x.AccountHolder.Password == pass && log == x.AccountHolder.Username);
                    if (a==null)
                    {
                        MessageBox.Show("Неверный логин или пароль!");
                    }
                    else
                    {
                        UserOrAdminActive.AdminActive = false;
                        UserMainWindowView.ActiveUser = a;
                        Window window = new UserMainWindow();
                        window.Owner = this;
                        this.Hide();
                        window.Show();
                    }
                }
                else
                {
                    string pass = PasswordTB.Password;
                    string log = LoginTB.Text;
                    Admin a = Elements.AdminsElements.GetAll().Result.FirstOrDefault(x => x.Password == pass && log == x.Username);
                    if (a==null)
                    
                    {
                        MessageBox.Show("Неверный логин или пароль!");
                    }
                    else
                    {
                        UserOrAdminActive.AdminActive = true;
                        AdminMainViewModel.ActiveAdmin = a;
                        Window window = new AdminMainWindow();
                        window.Owner = this;
                        this.Hide();
                        window.Show();
                    }
                }
                

            }
            catch
            {
                MessageBox.Show("Неверный логин или пароль!");
            }


        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            
            Window window = new RegistryWindow();
            window.Owner = this;
            this.Hide();
            window.Show();
        }
    }
}
