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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IvanProduction.Contols
{
    /// <summary>
    /// Логика взаимодействия для BookCardEdit.xaml
    /// </summary>
    public partial class BookCardEdit : UserControl
    {
        public Book b { get; set; }
        public BookCardEdit()
        {
             InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            b = (Book)this.DataContext;
            if (String.IsNullOrWhiteSpace(tboxA.Text) || String.IsNullOrWhiteSpace(tboxC.Text) || String.IsNullOrWhiteSpace(tboxD.Text))
                MessageBox.Show("Поля не заполнены!");
            else
            {
                b.Count = Convert.ToInt32(tboxC.Text);
                b.Author = tboxA.Text;
                b.Description = tboxD.Text;
                Elements.BooksElements.Update(b.Id, b);
                MessageBox.Show("Элемент изменен!");

            }

        }
        
    }
}
