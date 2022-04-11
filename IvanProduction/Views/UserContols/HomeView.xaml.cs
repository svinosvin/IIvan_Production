using IvanProduction.Model;
using IvanProduction.Model.ModelsStatic;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

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
            listviewUsers.SelectedIndex = 0;
        }
        public void UpdateTable()
        {
            Book = Elements.BooksElements.GetAll().Result.Where(x=>x.Count>=1).ToList();
            listviewUsers.ItemsSource = Book;
        }
    }
}
