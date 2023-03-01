using Shared;

namespace BL
{
    public class Product : DataTracking
    {
        public string? ProductId { get; set; }
        public string? Title { get; set; }
        public int? QuantityInStock { get; set; }
        public string? Location { get; set; }
        public float? Price { get; set; }
        public string? Description { get; set; }
        public ItemType Type { get; set; }
        public bool IsValid => Validate();

        //validate
        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(ProductId)) return false;
            if (string.IsNullOrWhiteSpace(Title)) return false;
            if (string.IsNullOrWhiteSpace(Location)) return false;
            if (string.IsNullOrWhiteSpace(Description)) return false;
            if (Type != ItemType.Print || Type != ItemType.Fysisk) return false;
            if (QuantityInStock == null) return false;
            if (Price == null) return false;
            return true;
        }
    }
}
