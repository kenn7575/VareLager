using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Product : DataTracking
    {
        public string ProductId { get; set; }
        public string Title { get; set; }
        public int? QuantityInStock { get; set; }
        public string Location { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        //validate
        public override bool Validate()
        {
            //validate all fields are filled in
            
            if (string.IsNullOrWhiteSpace(ProductId)) return false;
            if (string.IsNullOrWhiteSpace(Title)) return false;
            if (string.IsNullOrWhiteSpace(Location)) return false;
            if (string.IsNullOrWhiteSpace(Description)) return false;
            if (string.IsNullOrWhiteSpace(Type)) return false;
            if (QuantityInStock == null) return false;
            if (Price == null) return false;
            return true;

        }
    }
}
