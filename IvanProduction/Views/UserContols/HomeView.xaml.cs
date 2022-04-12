using IvanProduction.Model;
using IvanProduction.Model.ModelsStatic;
using IvanProduction.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
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

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            int id = Convert.ToInt32(((Button)sender).DataContext.ToString());
            listviewUsers.SelectedIndex = Book.FirstOrDefault(x => x.Id == id).Id - 1;
            Book b = Book.FirstOrDefault(x => x.Id == Convert.ToInt32(id));
            b.Count = b.Count - 1;
            HistoryTransactions historyTransactions = new HistoryTransactions
            {
                
              
                TakeTime = System.DateTime.Now,
                ReturnTime = System.DateTime.Now.AddDays(30),
                ActiveTransaction = true,
                
            };


            Elements.HistoryElements.AddGoodTransaction(b, UserMainWindowView.ActiveUser, historyTransactions);
            UserMainWindowView.UpdateBook(b, Convert.ToInt32(id));
            UpdateTable();

        }
    }
}
