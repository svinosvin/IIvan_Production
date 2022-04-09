using IvanProduction.Model;
using IvanProduction.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanProduction.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        public List<Book> Book { get; set; } = new List<Book>();
        public HomeViewModel()
        {
            Book.Add(new Book { Author = "dsa", Count = 5, Id = 1, Name = "dsada" });
            Book.Add(new Book { Author = "dsa", Count = 5, Id = 1, Name = "dsada" });
            Book.Add(new Book { Author = "dsa", Count = 5, Id = 1, Name = "dsada" });
            Book.Add(new Book { Author = "dsa", Count = 5, Id = 1, Name = "dsada" });
        }
    }

}
