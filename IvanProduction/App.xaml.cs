using System.Windows;

namespace IvanProduction
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            Window window = new MainWindow();
            window.Show();
            base.OnStartup(e);
        }
    }
}
