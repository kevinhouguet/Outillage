using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ToolsList.Data;

namespace ToolsList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            // https://learn.microsoft.com/fr-fr/archive/msdn-magazine/2016/june/essential-net-dependency-injection-with-net-core
            ServiceCollection services = new ServiceCollection();

            // push a DbContext in services to have the app communicate with DB any time in the life of application
            services.AddDbContext<ToolDbContext>(options =>
            {
                options.UseSqlite("Data Source = Tool.db");
            });

            services.AddSingleton<MainWindow>(); // using of One instance of MainWindow
            serviceProvider = services.BuildServiceProvider(); // building services
        }

        private void OnStartup(object s, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>(); // retrieve MainWindow from the service provider
            mainWindow.Show(); // display the mainWindow.
        }
    }
}
