using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outillage.ViewModels
{
    class OutillageListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<String> _outillageItemName;

        public IEnumerable<String> OutillageItemName => _outillageItemName;

        public OutillageListViewModel()
        {
            _outillageItemName = new ObservableCollection<String>();

            _outillageItemName.Add("Perceuse");
            _outillageItemName.Add("Meuleuse");
            _outillageItemName.Add("Tourneuse");
            _outillageItemName.Add("Tournevis");
            _outillageItemName.Add("Echelle");
        }

    }
}
