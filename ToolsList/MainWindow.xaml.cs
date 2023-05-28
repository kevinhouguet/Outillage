using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToolsList.Data;
using ToolsList.ViewModels;
using ToolsList.Views;

namespace ToolsList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ToolDbContext context;
        Tool NewTool = new Tool();
        Tool selectedTool = new Tool();

        public MainWindow(ToolDbContext context)
        {
            this.context = context;
            InitializeComponent();
            /*var mainView = new MainView("salut");*/
            GetTools();
            AddLayout.DataContext = NewTool;
        }

        private void OutilsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // https://wpf-tutorial.com/list-controls/combobox-control/
            selectedTool = (OutilsList.SelectedValue as Tool);
            DetailsContent.DataContext = selectedTool;
            EditLayout.DataContext = selectedTool;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(this.NewTool != null)
            {
                context.Tools.Add(NewTool);
                context.SaveChanges();
                GetTools();
                NewTool = new Tool();
                AddLayout.DataContext = NewTool;
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (this.selectedTool != null)
            {
                Debug.WriteLine("Edit Click");
                context.Update(selectedTool);
                Debug.WriteLine(selectedTool.Name);
                context.SaveChanges();
                GetTools(); // update the tools list
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (this.selectedTool != null)
            {
                context.Tools.Remove(selectedTool);
                context.SaveChanges();
                GetTools();
            }
        }

        private void GetTools()
        {
            OutilsList.ItemsSource = context.Tools.ToList();
        }
    }
}
