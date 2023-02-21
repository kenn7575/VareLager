using Microsoft.AspNetCore.Mvc;
using BL;
using UI.Models;
using DA;

namespace UI.Controllers
{
    public class ProduktController : Controller
    {
        // GET: ProduktController
        public ActionResult Index()
        { 
            ProduktRepository repo = new ProduktRepository();
            List<BL.Produkt> produkts = repo.Retrieve().ToList();
            List<ProduktModel> produktModels = new List<ProduktModel>();
            
            foreach (BL.Produkt product in produkts)
            {
                // Try autoparser en anden gang
                ProduktModel produktModel = new();
                produktModel.ProduktID = product.ProduktID;
                produktModel.Title = product.Title;
                produktModel.Description = product.Description;
                produktModel.Price = product.Price;
                produktModel.QuantityInStock = product.QuantityInStock;
                produktModel.Location = product.Location;
                produktModels.Add(produktModel);

            }
            return View(produktModels);
        }

        // GET: ProduktController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProduktController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProduktController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ProduktController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProduktController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ProduktController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProduktController/Delete/5
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
