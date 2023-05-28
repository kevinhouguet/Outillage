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
        ToolDbContext context; // Declare a var of type : ToolDbContext to use DbContext methods

        // instanciation of 2 var of type Tool.
        Tool NewTool = new Tool();
        Tool selectedTool = new Tool();

        public MainWindow(ToolDbContext context)
        {
            this.context = context; // retrieve of DbContext
            InitializeComponent();
            /*var mainView = new MainView("test");*/
            PutItemsInView();
            AddLayout.DataContext = NewTool; // declare the add layout data context of Tool type and bind to NewTool var
        }

        /**
         * Function which update views by the user selection 
         * **/
        private void OutilsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // https://wpf-tutorial.com/list-controls/combobox-control/
            selectedTool = (OutilsList.SelectedValue as Tool); // using of reflection / binding of SelectedValue and selected Tool var.

            // update the data context of part of view to have the user selection item
            DetailsContent.DataContext = selectedTool;
            EditLayout.DataContext = selectedTool;
        }

        /**
         * Function which add the new item in db 
         * **/
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(this.NewTool != null)
            {
                context.Tools.Add(NewTool); // add layout data context was bind to NewTool, so this add the add layout data context to dbcontext.
                context.SaveChanges(); // save the changes of context into db/
                PutItemsInView(); // update the list with the new context data

                // reset the declaration of NewTool and binding to AddLayout data context
                NewTool = new Tool(); 
                AddLayout.DataContext = NewTool;
            }
        }

        /**
         * Function which update the user selected item in db
         * **/
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (this.selectedTool != null)
            {
                Debug.WriteLine("Edit Click");
                context.Update(selectedTool); // update the context with the new informations of selectedTool
                Debug.WriteLine(selectedTool.Name);
                context.SaveChanges();
                PutItemsInView();
            }
        }

        /**
         * Function which delete the item in db 
         * **/
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (this.selectedTool != null)
            {
                context.Tools.Remove(selectedTool); // remove selectedTool in Tools DbSet Collection from Dbcontext
                context.SaveChanges();
                PutItemsInView();
            }
        }

        private void PutItemsInView()
        {
            // get the items from DbContext and put in data ressources in view
            OutilsList.ItemsSource = context.Tools.ToList();
        }
    }
}
