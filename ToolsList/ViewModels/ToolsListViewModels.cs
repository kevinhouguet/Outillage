using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsList.Models;

namespace ToolsList.ViewModels
{
    public class ToolsListViewModels
    {
        public ObservableCollection<Tools> OutilsListItems = new ObservableCollection<Tools>();
        public ToolsListViewModels() 
        {
            OutilsListItems.Add(new Tools("Perceuse", "15", "R/5/R"));
            OutilsListItems.Add(new Tools("Tourneuse", "1", "E/4/R"));
            OutilsListItems.Add(new Tools("Broyeuse", "3", "W/5/R"));
            OutilsListItems.Add(new Tools("Tournevis", "50", "A/5/R"));
            OutilsListItems.Add(new Tools("Couteau", "12", "R/5/T"));
        }
    }
}
