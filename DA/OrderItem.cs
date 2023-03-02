using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class OrderItem
    {
        //properties
        public string? OrderItemId { get; set; }
        public int? Quantity { get; set; }
        public string? ProductId { get; set; }
        public double? SalesPrice { get; set; }
    }
}

