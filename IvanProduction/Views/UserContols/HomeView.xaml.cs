using IvanProduction.Model;
using IvanProduction.Model.ModelsStatic;
using IvanProduction.Services;
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
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {

        private List< Book> Book { get; set; }
        
        public HomeView()
        {
            InitializeComponent();
            UpdateTable();  
        }
        public void UpdateTable()
        {
            Book = Elements.BooksElements.GetAll().Result.Where(x=>x.Count>=1).ToList();
            listviewUsers.ItemsSource = Book;
        }
    }
}
