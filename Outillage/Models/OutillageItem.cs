using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;

namespace Outillage.Models
{
    internal class OutillageItem
    {
        public string Name { get; }
        public int Stock { get; }
        public string Place { get; }

        public OutillageItem(string name, int stock, string place)
        {
            Name = name;
            Stock = stock;
            Place = place;
        }
    }
}
