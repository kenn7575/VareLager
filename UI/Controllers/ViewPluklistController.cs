using BL;
using BL;
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
        [HttpGet]
        public IActionResult Print(string id)
        {
                      //retreve pluklist from database by id
            PluklistRepository pluklistRepository = new();
            Pluklist pluklist = pluklistRepository.Retrieve(id);

            string printType = "";
            foreach (var item in pluklist.Items)
            {
                if (item.ProductId == "PRINT_OPGRADE") { printType = "PRINT_OPGRADE"; continue; }
                else if (item.ProductId == "PRINT-OPSIGELSE"){ printType = "PRINT-OPSIGELSE"; continue; }
                else if (item.ProductId == "PRINT-WELCOME") { printType = "PRINT-WELCOME"; continue; }
            }

            if (printType == null) return RedirectToAction(nameof(Index));
            PageRepository pageRepo = new();
            Page page = pageRepo.Retrieve(printType);

            string htmlToPrint = page.Personalize(pluklist);

            PageModel pageModel = new()
            {
                InnerHTML = htmlToPrint
            };
            return View(pageModel);
        }
    }
}
