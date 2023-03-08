using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace BL
{
    public class PageRepository
    {
        public Page Retrieve(string id)
        {
            

            //page 
            PageDataAccess PageDataAccess = new PageDataAccess();
            string json = PageDataAccess.Retrieve(id);
            Page page = JsonSerializer.Deserialize<Page>(json);
            return page;
        }
    }
}
