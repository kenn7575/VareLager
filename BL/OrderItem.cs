using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace BL
{
    public class OrderItem : DataTracking
    {
        public string? ProductId { get; set; }
        public string? PluklistId { get; set; }
        public string? Title { get; set; }
        public int? Type { get; set; }
        public int? Amount { get; set; }
        public double? Price { get; set; }
        public double? SalesPrice { get; set; }
        public string? Description { get; set; }
        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(ProductId)) return false;
            if (string.IsNullOrWhiteSpace(Title)) return false;
            if (string.IsNullOrWhiteSpace(Description)) return false;
            if (Type == null) return false;
            if (Type <0 || Type > 1) return false;
            if (Price == null) return false;
            if (Amount == null) return false;
            return true;
        }
    }
}
