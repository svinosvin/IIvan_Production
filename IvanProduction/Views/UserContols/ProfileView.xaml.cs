using IvanProduction.Model;
using IvanProduction.Model.ModelsStatic;
using IvanProduction.ViewModels;
using IvanProduction.Views.Windows;
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
            try
            {
                if (!Regex.IsMatch(Surname.Text, RegularExp.SurnameExp)
                              || !Regex.IsMatch(Name.Text, RegularExp.NameExp)
                                 || !Regex.IsMatch(Email.Text, RegularExp.EmailExp)
                                 || !Regex.IsMatch(Password.Text, RegularExp.PasswordExp)
                                 || !Regex.IsMatch(Username.Text, RegularExp.UsernameExp))
                {
                    if (String.IsNullOrWhiteSpace(Password.Text)
                     || String.IsNullOrWhiteSpace(Username.Text)
                     || String.IsNullOrWhiteSpace(Name.Text)
                     || String.IsNullOrWhiteSpace(Surname.Text)
                     || String.IsNullOrWhiteSpace(Email.Text))
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
                    User user = new User
                    {
                        Id = Account.AccountHolder.Id,
                        Email = Email.Text.ToString(),
                        Name = Name.Text.ToString(),
                        Password = Password.Text.ToString(),
                        Username = Username.Text.ToString(),
                        Surname = Surname.Text.ToString()
                    };
                    UserMainWindowView.UpdateAccount(user);
                    MessageBox.Show("Данные были изменены");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!");
            }
            
            
          } 
         
        }
    }

