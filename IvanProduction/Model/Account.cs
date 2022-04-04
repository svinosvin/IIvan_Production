using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanProduction.Model
{
    public class Account
    {
        public int Id { get; set; }
        public User AccountHolder { get; set; }
        public Status Status { get; set; }       
        public IEnumerable<HistoryTransactions> historyTransactions { get; set; }

    }
}
