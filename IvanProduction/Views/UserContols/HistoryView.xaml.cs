using IvanProduction.Model;
using IvanProduction.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace IvanProduction.Views.UserContols
{
    /// <summary>
    /// Логика взаимодействия для HistoryView.xaml
    /// </summary>
    public partial class HistoryView : UserControl
    {
        private List<HistoryTransactions> historyTransactions = UserMainWindowView.ActiveUser.historyTransactions.ToList();
        public HistoryView()
        {
            InitializeComponent();
            UpdateTable();
            
        }
        public void UpdateTable()
        {

            listviewHistory.ItemsSource = historyTransactions;
        }
    }
}
