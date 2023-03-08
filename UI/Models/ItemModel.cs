using Shared;

namespace UI.Models
{
    public class ItemModel
    {
        public string? ProductId { get; set; }
        public int? PluklistId { get; set; }
        public string? Title { get; set; }
        public int? Type { get; set; }
        public int? Amount { get; set; }
        public double? Price { get; set; }
        public double? SalesPrice { get; set; }
        public string? Description { get; set; }
        public bool HasChanced { get; set; }

    }
}
