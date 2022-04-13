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

namespace IvanProduction.Views.AdminControls
{
    /// <summary>
    /// Логика взаимодействия для AdminUsersView.xaml
    /// </summary>
    public partial class AdminUsersView : UserControl
    {
        public List<Account> accounts { get; set; }
        public AdminUsersView()
        {
            InitializeComponent();
            UpdateTable();

        }
        public void UpdateTable()
        {
            accounts = Elements.AccountElements.GetAll().Result.ToList();
            foreach (var item in accounts)
            {
                item.historyTransactions = Elements.HistoryElements.GetAll().Result.Where(x => x.Account.Id == item.Id).ToList();
            }
            listviewUsers.ItemsSource = accounts;
        }



        private void listviewUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listviewHistory.ItemsSource = ((listviewUsers.SelectedItem) as Account).historyTransactions;
        }
    }
}
