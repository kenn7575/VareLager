
namespace DA
{
    public class Pluklist
    {
        //constructor
        public Pluklist() {
         Items = new List<Item>();
        }
        
        //properties
        public string? PluklistId { get; set; }
        public string? Name { get; set; }
        public string? shipping { get; set; }
        public string? address { get; set; }
        public string? PluklistStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? FinishedDateDate { get; set; }
        public string? OrderItemId { get; set; }
        public List<Item>? Items { get; set;}

    }
}
