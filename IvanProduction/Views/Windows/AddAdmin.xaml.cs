using IvanProduction.Model;
using IvanProduction.Model.ModelsStatic;
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
using System.Windows.Shapes;

namespace IvanProduction.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddAdmin.xaml
    /// </summary>
    public partial class AddAdmin : Window
    {
        public AddAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (String.IsNullOrWhiteSpace(Password.Text)
                    || String.IsNullOrWhiteSpace(Username.Text)
                      || String.IsNullOrWhiteSpace(Name.Text)
                        || String.IsNullOrWhiteSpace(Surname.Text)
                          || String.IsNullOrWhiteSpace(Email.Text)
                           || String.IsNullOrWhiteSpace(JobPosition.Text)
                    )
                {

                    MessageBox.Show("Обязательные поля не заполнены!");
                }
                else
                {
                    Admin admin = new Admin { Email = Email.Text, JobPosition = JobPosition.Text, Surname = Surname.Text, Name = Name.Text, Password = Password.Text, Username = Username.Text };
                    Elements.AdminsElements.Create(admin);
                    MessageBox.Show("Успешно добавлен!");
                    this.Close();

                }
            }
            catch
            {
                MessageBox.Show("Обязательные поля не заполнены!");

            }
        }
    }
}
