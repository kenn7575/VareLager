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
        public void Save(BL.Pluklist pluklist)
        {
            if (!pluklist.IsValid) return;
            if (!pluklist.HasChanges) return;

            List<DA.Item> orderItems= new();
            foreach (var item in pluklist.Items)
            {
                DA.Item orderItem = new()
                {
                    PluklistId = item.PluklistId,
                    Amount = item.Amount,
                    ProductId = item.ProductId,
                    SalesPrice = item.SalesPrice,
                    Type= item.Type,
                    Title= item.Title,
                    Description= item.Description,
                    Price= item.Price,
                };
                orderItems.Add(orderItem);
            }

            PluklistDataAccess pluklistDataAccess = new ();
            DA.Pluklist DA_Pluklist = new()
            {

                PluklistId= pluklist.PluklistId,
                Name = pluklist.Name,
                Shipping = pluklist.Shipping,
                Items= orderItems,
                DateCreated = pluklist.DateCreated,
                DateFinished= pluklist.DateFinished,
                Address = pluklist.Address,
                PluklistStatus = pluklist.PluklistStatus,
            };
            if (pluklist.IsNew)
            {
                pluklistDataAccess.Create(DA_Pluklist);
            }
            else
            {
                pluklistDataAccess.Update(DA_Pluklist);
            }
        }
    }
}
