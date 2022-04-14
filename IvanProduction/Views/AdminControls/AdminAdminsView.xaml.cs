using IvanProduction.Model.ModelsStatic;
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

namespace IvanProduction.Views.AdminControls
{
    /// <summary>
    /// Логика взаимодействия для AdminAdminsView.xaml
    /// </summary>
    public partial class AdminAdminsView : UserControl
    {
        public AdminAdminsView()
        {
            InitializeComponent();
            Update();
        }
        public void Update()
        {
            this.listviewUsers.ItemsSource = Elements.AdminsElements.GetAll().Result.ToList();
        } 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window f = new AddAdmin();   
            f.Show();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
