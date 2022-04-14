using IvanProduction.Model;
using IvanProduction.Model.ModelsStatic;
using System.Linq;
using System.Windows;

namespace IvanProduction
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            //Window window = new MainWindow();
            //window.Show();
            if(Elements.AdminsElements.GetAll().Result.ToList().Capacity == 0)
            {
                Elements.AdminsElements.Create(new Admin { Username = "admin", Password = 1234.ToString() });
            }
            base.OnStartup(e);
        }

    }
}
