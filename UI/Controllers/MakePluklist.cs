using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class MakePluklist : Controller
    {
        // GET: MakePluklist
        public ActionResult Index()
        {
            PluklistModel pluklistModel =  PluklistModel.GetInstance();
            return View(pluklistModel);
        }


       
        public ActionResult CreatePluklist()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePluklist(Pluklist pluklist)
        {
            try
            {
                PluklistModel.Reset();
                PluklistModel pluklistModel = PluklistModel.GetInstance();
                pluklistModel.Name = pluklist.Name;
                pluklistModel.Adresse = pluklist.Adresse;
                pluklistModel.Forsendelse = pluklist.Forsendelse;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        
        public ActionResult EditPluklist()
        {
            PluklistModel pluklistModel = PluklistModel.GetInstance();

            return View(pluklistModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPluklist(int id, Pluklist pluklist)
        {
            try
            {
                PluklistModel pluklistModel = PluklistModel.GetInstance();
                pluklistModel.Name = pluklist.Name;
                pluklistModel.Adresse = pluklist.Adresse;
                pluklistModel.Forsendelse = pluklist.Forsendelse;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditPluklistLine()
        {
            PluklistModel pluklistModel = PluklistModel.GetInstance();
            ItemModel item = pluklistModel.Lines.Find(x => x.HasChanced == true);
            return View(item);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPluklistLine(ItemModel itemModel)
        {
            try
            {
                
                PluklistModel pluklistModel = PluklistModel.GetInstance();
                pluklistModel.Lines.Remove(pluklistModel.Lines.Find(x => x.HasChanced == true));
                pluklistModel.AddItem(itemModel);
                pluklistModel.Lines.Find(x => x.ProductID == itemModel.ProductID);
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
                PluklistModel pluklist = PluklistModel.GetInstance();
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
                PluklistModel pluklistModel = PluklistModel.GetInstance();
                pluklistModel.Lines.Remove(pluklistModel.Lines.Find(x => x.HasChanced == true));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
