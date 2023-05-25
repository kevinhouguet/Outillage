using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsList.Models
{
    
    public class Tools
    {
        public string Name { get; set; }
        public string Stock { get; set; }
        public string Place { get; set; }

        public Tools(string name, string stock, string place)
        {
            Name = name;
            Stock = stock;
            Place = place;
        }
    }
}
