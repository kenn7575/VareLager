using Shared;


namespace DA
{
    public class Item
    {
        //properties
        public string ProductId { get; set; }
        public string Title { get; set; }
        public ItemType Type { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
    }
}
