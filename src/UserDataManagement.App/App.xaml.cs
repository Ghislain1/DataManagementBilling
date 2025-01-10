using MaterialDesignThemes.Wpf;
using System.Configuration;
using System.Data;
using System.Windows;
using UserDataManagement.Database;

namespace UserDataManagement.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal string? StartupPage { get; set; }
        internal FlowDirection InitialFlowDirection { get; set; }
        internal BaseTheme InitialTheme { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                // Data base initialization
                DatabaseHelper.InitializeDatabase();
            }
            catch (Exception)
            {

                throw;
            }
            base.OnStartup(e);

            (StartupPage, InitialFlowDirection, InitialTheme) = ("Dashbord", FlowDirection.LeftToRight, BaseTheme.Light);


        }
    }

}
