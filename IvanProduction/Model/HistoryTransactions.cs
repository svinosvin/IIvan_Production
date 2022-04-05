using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanProduction.Model
{
    public class HistoryTransactions:DomainObject
    {
 
        public Account Account { get; set; }
        public bool ActiveTransaction { get; set; }
        public Book Book { get; set; }
        public DateTime TakeTime { get; set; }
        public DateTime ReturnTime { get; set; }


    }
}
