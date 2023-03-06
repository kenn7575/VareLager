using BL;
using Main_BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class MakePluklistController : Controller
    {
        // GET: MakePluklist
        public ActionResult Index()
        {
            PluklistModelSingleton pluklistModel =  PluklistModelSingleton.GetInstance();
            return View(pluklistModel);
        }


       
        public ActionResult CreatePluklist()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePluklist(PluklistModelSingleton pluklist)
        {
            try
            {
                PluklistModelSingleton.Reset();
                PluklistModelSingleton pluklistModel = PluklistModelSingleton.GetInstance();
                pluklistModel.Name = pluklist.Name;
                pluklistModel.Address = pluklist.Address;
                pluklistModel.Shipping = pluklist.Shipping;
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        
        public ActionResult EditPluklist()
        {
            PluklistModelSingleton pluklistModel = PluklistModelSingleton.GetInstance();

            return View(pluklistModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPluklist(int id, Pluklist pluklist)
        {
            try
            {
                PluklistModelSingleton pluklistModel = PluklistModelSingleton.GetInstance();
                pluklistModel.Name = pluklist.Name;
                pluklistModel.Address = pluklist.Address;
                pluklistModel.Shipping = pluklist.Shipping;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditPluklistLine()
        {
            PluklistModelSingleton pluklistModel = PluklistModelSingleton.GetInstance();
            ItemModel item = pluklistModel.Items.Find(x => x.HasChanced == true);
            return View(item);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPluklistLine(ItemModel itemModel)
        {
            try
            {
                
                PluklistModelSingleton pluklistModel = PluklistModelSingleton.GetInstance();
                pluklistModel.Items.Remove(pluklistModel.Items.Find(x => x.HasChanced == true));
                pluklistModel.AddItem(itemModel);
                pluklistModel.Items.Find(x => x.ProductId == itemModel.ProductId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddPluklistLine()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPluklistLine(ItemModel item)
        {
            try
            {
                PluklistModelSingleton pluklist = PluklistModelSingleton.GetInstance();
                pluklist.AddItem(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        public ActionResult DeletePluklistLine()
        {

            try
            {
                PluklistModelSingleton pluklistModel = PluklistModelSingleton.GetInstance();
                pluklistModel.Items.Remove(pluklistModel.Items.Find(x => x.HasChanced == true));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Save()
        {
            PluklistModelSingleton pluklistModel = PluklistModelSingleton.GetInstance();
            Pluklist pluklist = new Pluklist()
            {
                Name = pluklistModel.Name,
                Address = pluklistModel.Address,
                Shipping = pluklistModel.Shipping,
                PluklistStatus = "Aktiv",
                DateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                DateFinished = "",
                IsNew = true,
                HasChanges = true,
            };

            PluklistRepository pluklistRepository = new();
            pluklistRepository.Save(pluklist);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
