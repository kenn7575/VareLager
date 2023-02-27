using BL;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class ViewPluklistController : Controller
    {
        public IActionResult Index()
        {
            BL.Files Files = new("filesToImport", "export");
            Files.ImportFiles();

            List<PluklistModel> pluklister = new();
            foreach (var pluklist in Files.Pluklists)
            {
                List<ItemModel> itemModels = new();
                foreach(var item in pluklist.Lines)
                {
                    ItemModel im = new ItemModel
                    {
                        ProductID = item.ProductID,
                        Amount = item.Amount,
                        Title = item.Title,
                        Type = item.Type
                    };
                    itemModels.Add(im);
                }
                PluklistModel pm = new PluklistModel
                {
                    Name = pluklist.Name,
                    Adresse = pluklist.Adresse,
                    Forsendelse = pluklist.Forsendelse,
                    Lines = itemModels
                };
                pluklister.Add(pm);

            }

            //View takes IEnumerable<PluklistModel> as input
            return View(pluklister.AsEnumerable());
        }
    }
}
