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


        // GET: MakePluklist/Create
        public ActionResult CreatePluklist()
        {
            return View();
        }

        // POST: MakePluklist/Create
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



        // GET: MakePluklist/Edit/5
        public ActionResult EditPluklist(Pluklist p)
        {
            PluklistModel pluklistModel = PluklistModel.GetInstance();

            return View(pluklistModel);
        }

        // POST: MakePluklist/Edit/5
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



        public ActionResult AddPluklistLine()
        {
            return View();
        }

        // POST: MakePluklist/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPluklistLine(Item item)
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




        // GET: MakePluklist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MakePluklist/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
