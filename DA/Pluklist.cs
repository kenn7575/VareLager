
namespace DA
{
    public class Pluklist
    {
        //constructor
        public Pluklist() {
         Items = new List<Item>();
        }
        
        //properties
        public int? PluklistId { get; set; }
        public string? Name { get; set; }
        public string? Shipping { get; set; }
        public string? Address { get; set; }
        public string? PluklistStatus { get; set; }
        public string? DateCreated { get; set; }
        public string? DateFinished { get; set; }

        public List<Item>? Items { get; set;}

    }
}
