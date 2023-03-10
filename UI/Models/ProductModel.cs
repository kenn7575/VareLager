namespace UI.Models
{
    public class ProductModel
    {

        public string ProductId { get; set; }
        public string Title { get; set; }
        public int? QuantityInStock { get; set; }
        public string Location { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public int? Type { get; set; }
    }
}
