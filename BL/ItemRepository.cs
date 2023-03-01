using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using BL;
using System.Reflection;

namespace Main_BL
{
    public class ItemRepository
    {
        public List<DA.Product> Retrieve(string Id)
        {
            DA.Pluklist DA_Pluklist = new();
            var da = new ProduktDataAccess();
            var json = da.Retrieve(Id);
            DA_Pluklist = JsonSerializer.Deserialize<DA.Pluklist>(json);
            
            if (DA_Pluklist.Type.ToLower() == "print")
            {
                BL_Pluklist.Type = ItemType.Print;
            }
            BL.ItemType f = (BL.ItemType)Enum.GetValues(f.GetType()).GetValue(1);
            else
            {

            }
            return product;
        }
    }
}
