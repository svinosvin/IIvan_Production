using IvanProduction.Model;
using IvanProduction.Model.ModelsStatic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IvanProduction.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistryWindow.xaml
    /// </summary>
    public partial class RegistryWindow : Window
    {
        
        public RegistryWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                if (

                       !Regex.IsMatch(Surname.Text, RegularExp.SurnameExp)
                          || !Regex.IsMatch(Name.Text, RegularExp.NameExp)
                             || !Regex.IsMatch(Email.Text, RegularExp.EmailExp)
                             || !Regex.IsMatch(Password.Text, RegularExp.PasswordExp)
                             || !Regex.IsMatch(Username.Text, RegularExp.UsernameExp) )
                {
                    if (String.IsNullOrWhiteSpace(Password.Text)
                     || String.IsNullOrWhiteSpace(Username.Text)
                     || String.IsNullOrWhiteSpace(Name.Text)
                     || String.IsNullOrWhiteSpace(Surname.Text)
                     || String.IsNullOrWhiteSpace(Email.Text) )
                        MessageBox.Show("Обязательные поля не заполнены!");

                    else
                    {
                        if (!Regex.IsMatch(Email.Text, RegularExp.EmailExp))
                            MessageBox.Show("Email не подходит по шаблону");
                        if (!Regex.IsMatch(Surname.Text, RegularExp.SurnameExp))
                            MessageBox.Show("Surname принимает только алфавитные символы! ");
                        if (!Regex.IsMatch(Password.Text, RegularExp.PasswordExp))
                            MessageBox.Show("Пароль от 3 алфавитно-цифровых символов!");
                        if (!Regex.IsMatch(Username.Text, RegularExp.UsernameExp))
                            MessageBox.Show("Username не меньше 3 и не больше 13 символов!");
                        if (!Regex.IsMatch(Name.Text, RegularExp.NameExp))
                            MessageBox.Show("Name принимает только алфавитные символы!");
                    }
          

                }
                else
                {
                    Account account = new Account
                    {
                        AccountHolder = new User
                        {
                            Email = Email.Text,
                            Name = Name.Text,
                            Password = Password.Text,
                            Surname = Surname.Text,
                            Username = Username.Text
                        },
                        Status = new Status { Name = "Новичок", Score = 0 }

                    };
                    Elements.AccountElements.Create(account);
                    MessageBox.Show("Успешно зарегистрировались!");
                    this.Close();

                }
            }
            catch
            {
                MessageBox.Show("Обязательные поля не заполнены!");

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
        }
    }
}
