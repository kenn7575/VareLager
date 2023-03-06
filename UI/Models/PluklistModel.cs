namespace UI.Models
{
    public class PluklistModel
    {
        public int? PluklistId { get; set; }
        public string? Name { get; set; }
        public string? Shipping { get; set; }
        public string? Address { get; set; }
        public string? PluklistStatus { get; set; }
        public string? DateCreated { get; set; }
        public string? DateFinished { get; set; }
        public List<ItemModel>? Items { get; set; }

    }
}
