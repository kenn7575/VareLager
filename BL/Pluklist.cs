using DA;

namespace BL
{
    public class Pluklist : DataTracking
    {
        //constructor
        public Pluklist() 
        {   
            Items = new List<BL.OrderItem>();
        }

        //properties
        public int? PluklistId { get; set; }
        public string? Name { get; set; }
        public string? shipping { get; set; }
        public string? address { get; set; }
        public string? PluklistStatus { get; set; }
        public string? CreateDate { get; set; }
        public string? FinishedDateDate { get; set; }
        public int? OrderItemId { get; set; }
        public List<OrderItem>? Items { get; set; }

        //methods
        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) return false;
            if (string.IsNullOrWhiteSpace(shipping)) return false;
            if (string.IsNullOrWhiteSpace(address)) return false;
            if (string.IsNullOrWhiteSpace(PluklistStatus)) return false;
            if (string.IsNullOrWhiteSpace(CreateDate)) return false;
            if (string.IsNullOrWhiteSpace(FinishedDateDate)) return false;
            if (PluklistId == null) return false;
            if (OrderItemId == null) return false;
            
            if (Items == null) return false;
            return true;
        }
    }
}







