using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Item
    {
        public string ProductID  { get; set; } 
        public string Title { get; set; }
        public ItemType Type { get; set; }
        public int Amount { get; set; }
        public override string ToString()
        {
            return $"<tr><td>{Title}</td><td>{Amount}</td></tr>";
        }
    }
}
