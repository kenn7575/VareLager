using Shared;

namespace UI.Models
{
    public class ItemModel
    {
        public string ProductID { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public int Amount { get; set; }
        public bool HasChanced { get; set; }
    }
}
