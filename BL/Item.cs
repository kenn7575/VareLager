using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Item : DataTracking
    {
        /*public string ProductId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }*/
        public string ProductId { get; set; }
        public string Title { get; set; }
        public ItemType Type { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(ProductId)) return false;
            if (string.IsNullOrWhiteSpace(Title)) return false;
            if (string.IsNullOrWhiteSpace(Description)) return false;
            if (string.IsNullOrWhiteSpace(Type)) return false;
            if (Price == null) return false;
            return true;
        }

    }
}
