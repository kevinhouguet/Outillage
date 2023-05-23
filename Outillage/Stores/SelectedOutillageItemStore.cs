using Outillage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outillage.Stores
{
    internal class SelectedOutillageItemStore
    {
        private OutillageItem _selectedOutillageItem;
        public OutillageItem SelectedOutillageItem
        {
            get { return _selectedOutillageItem;}
            set
            {
                _selectedOutillageItem = value;
                SelectedOutillageItemChanged?.Invoke();
            }
        }

        public event Action SelectedOutillageItemChanged;
    }
}
