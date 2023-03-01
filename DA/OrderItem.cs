using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class OrderItem
    {
        public string OrderItemId { get; set; }
        public int Quantity { get; set; }
        public string ProductId { get; set; }
        public float SalesPrice { get; set; }
    }
}
