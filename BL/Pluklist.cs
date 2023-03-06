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
        public string? Shipping { get; set; }
        public string? Address { get; set; }
        public string? PluklistStatus { get; set; }
        public string? DateCreated { get; set; }
        public string? DateFinished { get; set; }
        public List<OrderItem>? Items { get; set; }

        //methods
        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) return false;
            if (string.IsNullOrWhiteSpace(Shipping)) return false;
            if (string.IsNullOrWhiteSpace(Address)) return false;
            if (string.IsNullOrWhiteSpace(PluklistStatus)) return false;
            if (string.IsNullOrWhiteSpace(DateCreated)) return false;
            if (string.IsNullOrWhiteSpace(DateFinished) && IsNew == false) return false;
            if (PluklistId == null && IsNew == false) return false;
            
            
            if (Items == null) return false;
            return true;
        }
    }
}







