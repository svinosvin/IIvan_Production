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
    /// Логика взаимодействия для AdminHistoryView.xaml
    /// </summary>
    public partial class AdminHistoryView : UserControl
    {
        public List<Account> Accounts { get; set; }
        public List<HistoryTransactions> ht { get; set; } = new List<HistoryTransactions>();
        public AdminHistoryView()
        {
            InitializeComponent();
            UpdateTable();  
            
        }
        public void UpdateTable()
        {
            Accounts = Elements.AccountElements.GetAll().Result.ToList();

            foreach (var item in Accounts)
            {
                item.historyTransactions = Elements.HistoryElements.GetAll().Result.Where(x => x.Account.Id == item.Id).ToList();
                foreach (var item1 in item.historyTransactions)
                {
                    item1.Account.AccountHolder = item.AccountHolder;
                }
                ht.AddRange(item.historyTransactions.Where(x => x.ActiveTransaction == true).ToList());
            }
            listviewUsers.ItemsSource = ht;


        }


    }
}
