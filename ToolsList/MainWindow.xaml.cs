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
using ToolsList.Models;
using ToolsList.ViewModels;
using ToolsList.Views;

namespace ToolsList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ToolsListViewModels ToolsListViewModels = new ToolsListViewModels();

        ToolDbContext context;
        Tool NewTool = new Tool();
        Tool selectedTool = new Tool();

        public MainWindow(ToolDbContext context)
        {
            /*this.DataContext = this;*/
            this.context = context;
            InitializeComponent();
            GetTools();
            AddLayout.DataContext = NewTool;
        }

        private void OutilsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
             * https://wpf-tutorial.com/list-controls/combobox-control/
             */
            selectedTool = (OutilsList.SelectedValue as Tool);
            /*Debug.WriteLine((OutilsList.SelectedValue as Tool).Name);*/
            DetailsContent.DataContext = selectedTool;
            EditLayout.DataContext = selectedTool;
            /*this.RenderView();*/
        }

        private void RenderView()
        {
            /*Debug.WriteLine("Attempt to Render The View !!");*/
            if (selectedTool != null)
            {
                /*Debug.WriteLine("Render The View !!");*/
                DetailsName.Text = selectedTool.Name;
                DetailsStock.Text = selectedTool.Stock;
                DetailsPlace.Text = selectedTool.Place;

                EditName.Text = selectedTool.Name;
                EditStock.Text = selectedTool.Stock;
                EditPlace.Text = selectedTool.Place;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            context.Tools.Add(NewTool);
            context.SaveChanges();
            GetTools();
            NewTool = new Tool();
            AddLayout.DataContext = NewTool;
            /*NewToolGrid.DataContext = NewTool;*/

            /*ToolsListViewModels.OutilsListItems.Add(new Tools(AddName.Text, AddStock.Text, AddPlace.Text));*/
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Edit Click");
            context.Update(selectedTool);
            Debug.WriteLine(selectedTool.Name);
            context.SaveChanges();
            GetTools(); // update the tools list

            if (this.selectedTool != null)
            {
                /*ToolsListViewModels.OutilsListItems.Remove(this.selectedTools);
                ToolsListViewModels.OutilsListItems.Add(new Tools(EditName.Text, EditStock.Text, EditPlace.Text));*/
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            context.Tools.Remove(selectedTool);
            context.SaveChanges();
            GetTools();

            if (this.selectedTool != null)
            {
                /*ToolsListViewModels.OutilsListItems.Remove(this.selectedTools);*/
            }
        }

        private void GetTools()
        {
            /*ToolDG.ItemsSource = context.Tools.ToList();*/
            OutilsList.ItemsSource = context.Tools.ToList();
        }
    }
}
