using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Outillage.ViewModels
{
    class OutillageViewModel : ViewModelBase
    {
        public OutillageListViewModel OutillageListViewModel { get; }
        public OutillageDetailsViewModel OutillageDetailsViewModel { get; }

        public ICommand AddOutillageCommand { get; }

        public OutillageViewModel()
        {
            OutillageDetailsViewModel = new OutillageDetailsViewModel();
            OutillageListViewModel = new OutillageListViewModel();
        }
    }
}
