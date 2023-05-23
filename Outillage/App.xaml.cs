using Outillage.Stores;
using Outillage.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Outillage
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedOutillageItemStore _selectedOutillageItemStore;

        public App()
        {
            _selectedOutillageItemStore = new SelectedOutillageItemStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new OutillageViewModel()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
