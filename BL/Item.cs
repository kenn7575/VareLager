using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace BL
{
    public class Item : DataTracking
    {
        public string? ProductId { get; set; }
        public string? Title { get; set; }
        public ItemType Type { get; set; }
        public int? Amount { get; set; }
        public float? Price { get; set; }
        public string? Description { get; set; }
        public bool IsValid => Validate();
        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(ProductId)) return false;
            if (string.IsNullOrWhiteSpace(Title)) return false;
            if (string.IsNullOrWhiteSpace(Description)) return false;
            if (Type != ItemType.Print || Type != ItemType.Fysisk) return false;
            if (Price == null) return false;
            if (Amount == null) return false;
            return true;
        }
    }
}
