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
    public class PluklistRepository
    {
        public BL.Pluklist Retrieve(string Id)
        {
            BL.Pluklist pluklist = new();
            PluklistDataAccess da = new();
            string json = da.Retrieve(Id);
            pluklist = JsonSerializer.Deserialize<BL.Pluklist>(json);
            
            return pluklist;
        }
        public List<BL.Pluklist> Retrieve()
        {
            List<BL.Pluklist> pluklists = new();
            PluklistDataAccess da = new();
            string json = da.Retrieve();
            pluklists = JsonSerializer.Deserialize<List<BL.Pluklist>>(json);

            return pluklists;
        }
    }
}
