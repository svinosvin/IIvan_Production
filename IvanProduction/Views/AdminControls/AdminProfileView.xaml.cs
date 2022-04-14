using IvanProduction.Model;
using IvanProduction.Model.ModelsStatic;
using IvanProduction.ViewModels.AdminsViewModels;
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

namespace IvanProduction.Views.AdminControls
{
    /// <summary>
    /// Логика взаимодействия для AdminProfileView.xaml
    /// </summary>
    public partial class AdminProfileView : UserControl
    {
        public Admin ActiveAdmin { get; set; } = AdminMainViewModel.ActiveAdmin;
        public AdminProfileView()
        {
            InitializeComponent();
            form1.DataContext = ActiveAdmin;
      
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(Username.Text) || String.IsNullOrWhiteSpace(Password.Text)) throw new Exception();
                ActiveAdmin.Email = Email.Text.ToString();
                ActiveAdmin.Name = Name.Text.ToString();
                ActiveAdmin.Password = Password.Text.ToString();
                ActiveAdmin.Username = Username.Text.ToString();
                ActiveAdmin.Surname = Surname.Text.ToString();        
                MessageBox.Show("Данные были изменены");
                Elements.AdminsElements.Update(ActiveAdmin.Id, ActiveAdmin);

            
            }
            catch(Exception)
            {
                MessageBox.Show("Неверные или пустые данные");
            }
        }
    }
}
