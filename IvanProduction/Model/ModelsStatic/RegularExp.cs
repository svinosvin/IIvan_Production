using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanProduction.Model.ModelsStatic
{
    public class RegularExp
    {
        static public string EmailExp =>  @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";

        static public string UsernameExp => @"\w{3,13}";

        static public string PasswordExp => @"\w{3,32}";

        static public string NameExp => @"^([A-ЯЁ])[a-яё]{2,32}";
        
        static public string SurnameExp => @"^([A-ЯЁ])[a-яё]{2,32}";

    }
}
