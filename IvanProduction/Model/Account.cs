using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanProduction.Model
{
    public class Account:DomainObject
    {
       
        public User AccountHolder { get; set; }
        public Status Status { get; set; }       
        public ICollection <HistoryTransactions> historyTransactions { get; set; }

    }
}
