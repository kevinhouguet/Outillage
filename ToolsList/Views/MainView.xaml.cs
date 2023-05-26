using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

namespace ToolsList.Views
{
    /// <summary>
    /// Logique d'interaction pour MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public ToolsListViewModels ToolsListViewModels = new ToolsListViewModels();
        public Tools selectedTools;

        ToolDbContext context;
        Tool NewTool = new Tool();
        Tool selectedTool = new Tool();

        public MainView(ToolDbContext context)
        {
            /*this.DataContext = this;*/
            this.context = context;
            InitializeComponent();
            GetTools();
            OutilsList.ItemsSource = ToolsListViewModels.OutilsListItems;
        }

        private void OutilsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
             * https://wpf-tutorial.com/list-controls/combobox-control/
             */
            selectedTools = (OutilsList.SelectedValue as Tools);
            this.RenderView();
        }

        private void RenderView()
        {
            if (selectedTools != null)
            {
                DetailsName.Text = selectedTools.Name;
                DetailsStock.Text = selectedTools.Stock;
                DetailsPlace.Text = selectedTools.Place;

                EditName.Text = selectedTools.Name;
                EditStock.Text = selectedTools.Stock;
                EditPlace.Text = selectedTools.Place;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ToolsListViewModels.OutilsListItems.Add(new Tools(AddName.Text, AddStock.Text, AddPlace.Text));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if(this.selectedTools != null)
            {
                ToolsListViewModels.OutilsListItems.Remove(this.selectedTools);
                ToolsListViewModels.OutilsListItems.Add(new Tools(EditName.Text, EditStock.Text, EditPlace.Text));
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (this.selectedTools != null)
            {
                ToolsListViewModels.OutilsListItems.Remove(this.selectedTools);
            }
        }

        private void GetTools()
        {
            /*ToolDG.ItemsSource = context.Tools.ToList();*/
        }

        private void AddItem(object s, RoutedEventArgs e)
        {
            /*context.Tools.Add(NewTool);
            context.SaveChanges();
            GetTools();
            NewTool = new Tool();
            NewToolGrid.DataContext = NewTool;*/
        }

        private void UpdateItem(object s, RoutedEventArgs e)
        {
            /*context.Update(selectedTool);
            context.SaveChanges();
            GetTools();*/
        }

        private void SelectToolToEdit(object s, RoutedEventArgs e)
        {
            /*selectedTool = (s as FrameworkElement).DataContext as Tool;
            UpdateToolGrid.DataContext = selectedTool;*/
        }

        private void DeleteTool(object s, RoutedEventArgs e)
        {
            /*var ToolToDelete = (s as FrameworkElement).DataContext as Tool;
            context.Tools.Remove(ToolToDelete);
            context.SaveChanges();
            GetTools();*/
        }
    }
}
