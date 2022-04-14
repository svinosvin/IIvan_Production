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
    /// Логика взаимодействия для BookCardAdd.xaml
    /// </summary>
    public partial class BookCardAdd : UserControl
    {
        public BookCardAdd()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (String.IsNullOrWhiteSpace(tboxA.Text) || String.IsNullOrWhiteSpace(tboxN.Text) || String.IsNullOrWhiteSpace(tboxC.Text))
                {
                    MessageBox.Show("Поля не заполнены или некорректны!");
                }
                else
                {
                    Book b = new Book
                    {
                        Author = tboxA.Text,
                        Count = Convert.ToInt32(tboxC.Text),
                        Description = tboxD.Text,
                        Name = tboxN.Text
                    };
                    Elements.BooksElements.Create(b);
                    MessageBox.Show("Книга добавлена, Обновите!");
                    tboxA.Text = "";
                    tboxC.Text = "";
                    tboxD.Text = "";
                    tboxN.Text = "";

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Поля не заполнены или некорректны!");
            }
        
           



        }
    }
}
