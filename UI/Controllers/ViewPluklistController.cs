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
            BL.Files files = new("filesToImport", "export");
            files.ImportFiles();
            
            List<PluklistModel> pluklister = new();
            int index = 0;
            foreach (var pluklist in files.Pluklists)
            {

                List<ItemModel> itemModels = new();
                foreach (var item in pluklist.Lines)
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
                var fileName = files.Files[index];
                index++;
                PluklistModel pm = PluklistModel.GetInstance();
                
                    pm.Name = pluklist.Name;
                    pm.Adresse = pluklist.Adresse;
                    pm.Forsendelse = pluklist.Forsendelse;
                    pm.Lines = itemModels;
                    pm.FileName = fileName;

                pluklister.Add(pm);

            }

            //View takes IEnumerable<PluklistModel> as input
            return View(pluklister.AsEnumerable());
        }
        [HttpPost]
        public IActionResult Afslut(PluklistModel pluklistModel)
        {
            List<Item> items = new();
            foreach (var itemModel in pluklistModel.Lines)
            {
                Item item = new()
                {
                    ProductID = itemModel.ProductID,
                    Amount = itemModel.Amount,
                    Title = itemModel.Title,
                    Type = itemModel.Type
                };
                items.Add(item);
            }
            Pluklist pluklist = new()
            {
                Name = pluklistModel.Name,
                Adresse = pluklistModel.Adresse,
                Forsendelse = pluklistModel.Forsendelse,
                Lines = items
            };
            BL.Files files = new("filesToImport", "export");
            files.Pluklists.Add(pluklist);
            files.Files.Add(pluklistModel.FileName);

            files.ExportFiles(1);
            return View();
        }
    }
}
