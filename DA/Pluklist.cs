using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class Pluklist
    {
        public Pluklist() {
         Items = new List<Item>();
        }


        public string PluklistId { get; set; }
        public string Name { get; set; }
        public string shipping { get; set; }
        public string address { get; set; }
        public string PluklistStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime FinishedDateDate { get; set; }
        public string OrderItemId { get; set; }
        public List<Item> Items { get; set;}

    }
}
