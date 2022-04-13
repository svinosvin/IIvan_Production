using IvanProduction.Model;
using IvanProduction.Model.ModelsStatic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для AdminBooksView.xaml
    /// </summary>
    public partial class AdminBooksView : UserControl
    {
        private List<Book> Book { get; set; }
        public AdminBooksView()
        {
            InitializeComponent();
            UpdateTable();
            listviewUsers.SelectedIndex = 0;

        }
        public void UpdateTable()
        {
            
            Book = Elements.BooksElements.GetAll().Result.ToList();
            listviewUsers.ItemsSource = Book;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listviewUsers.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Author", ListSortDirection.Ascending));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).DataContext.ToString());
            Elements.BooksElements.Delete(id);
            UpdateTable();
            MessageBox.Show("Успешно удалено!");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateTable();

        }
    }
}
