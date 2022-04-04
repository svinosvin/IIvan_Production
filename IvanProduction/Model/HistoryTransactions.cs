using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanProduction.Model
{
    public class HistoryTransactions
    {
        public int Id { get; set; }
        public Account Account { get; set; }
        public bool ActiveTransaction { get; set; }
        public Book Book { get; set; }

    }
}
