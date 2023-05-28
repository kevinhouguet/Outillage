using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsList.Data;

namespace ToolsList.ViewModels
{
    public class ToolsListViewModels
    {
        public ObservableCollection<Tool> OutilsListItems = new ObservableCollection<Tool>();
        public ToolsListViewModels() 
        {
            
        }
    }
}
