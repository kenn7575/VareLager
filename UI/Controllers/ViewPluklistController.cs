using BL;
using Main_BL;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using UI.Models;

namespace UI.Controllers
{
    public class ViewPluklistController : Controller
    {
        public IActionResult Index()
        {
            PluklistRepository pluklistRepository = new();
            List<Pluklist> pluklists = pluklistRepository.Retrieve();

            List<PluklistModel> pluklister = new();
            
            foreach (Pluklist pluklist in pluklists)
            {

                List<ItemModel> itemModels = new();
                foreach (OrderItem item in pluklist.Items)
                {
                    ItemModel im = new ItemModel
                    {
                        ProductId = item.ProductId,
                        PluklistId= item.PluklistId,
                        Amount = item.Amount,
                        Title = item.Title,
                        Type = item.Type,
                        Price = item.Price,
                        SalesPrice = item.SalesPrice,
                        Description = item.Description,
                    };
                    itemModels.Add(im);
                }
                PluklistModel pm = new PluklistModel
                {
                    PluklistId = pluklist.PluklistId,
                    Name = pluklist.Name,
                    Shipping = pluklist.Shipping,
                    Address = pluklist.Address,
                    Items = itemModels,
                    PluklistStatus = pluklist.PluklistStatus,
                    DateCreated = pluklist.DateCreated,
                    DateFinished = pluklist.DateFinished,

                };
               

               

                pluklister.Add(pm);

            }

            //View takes IEnumerable<PluklistModel> as input
            return View(pluklister.AsEnumerable());
        }
        [HttpGet]
        public IActionResult Afslut(string id)
        {
            //retreve pluklist from database by id
            PluklistRepository pluklistRepository = new();
            Pluklist pluklist = pluklistRepository.Retrieve(id);

            //change status to "afsluttet"
            pluklist.PluklistStatus = "Afsluttet";
            pluklist.DateFinished = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            pluklist.HasChanges = true;


            //save pluklist to database
            pluklistRepository.Save(pluklist);
            return RedirectToAction(nameof(Index));
        }
    }
}
