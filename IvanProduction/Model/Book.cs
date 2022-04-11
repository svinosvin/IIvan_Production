using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanProduction.Model
{
    public class Book:DomainObject
    {

        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        

    }
}
