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
            List<BL.Product> produkts = repo.Retrieve().ToList();
            List<ProduktModel> produktModels = new List<ProduktModel>();
            
            foreach (BL.Product product in produkts)
            {
                
                ProduktModel produktModel = new();
                produktModel.ProductId = product.ProductId;
                produktModel.Title = product.Title;
                produktModel.Description = product.Description;
                produktModel.Price = product.Price;
                produktModel.QuantityInStock = product.QuantityInStock;
                produktModel.Location = product.Location;
                produktModels.Add(produktModel);

            }
            return View(produktModels);
        }

        // GET: ProduktController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProduktController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProduktModel produkt)
        {
            try
            {
                //save product to database
                ProduktRepository repo = new ProduktRepository();
                BL.Product productToSave = new BL.Product()
                {
                    ProductId = produkt.ProductId,
                    Title = produkt.Title,
                    Description = produkt.Description,
                    Price = produkt.Price,
                    QuantityInStock = produkt.QuantityInStock,
                    Location = produkt.Location,
                    HasChanges = true,
                    IsNew = true,
                };
                repo.Save(productToSave);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduktController/Edit/5
        public ActionResult Edit(string id)
        {
            ProduktRepository repo = new ProduktRepository();
            List<BL.Product> products = repo.Retrieve(id);

            if (products.Count > 0)
            {
                ProduktModel produktModel = new();
                produktModel.ProductId = products[0].ProductId;
                produktModel.Title = products[0].Title;
                produktModel.Description = products[0].Description;
                produktModel.Price = products[0].Price;
                produktModel.QuantityInStock = products[0].QuantityInStock;
                produktModel.Location = products[0].Location;
                return View(produktModel);
            }
            return (NotFound());
        }

        // POST: ProduktController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, ProduktModel produkt)
        {
            try
            {
                //save product to database
                ProduktRepository repo = new ProduktRepository();
                BL.Product productToSave = new BL.Product()
                {
                    ProductId = id,
                    Title = produkt.Title,
                    Description = produkt.Description,
                    Price = produkt.Price,
                    QuantityInStock = produkt.QuantityInStock,
                    Location = produkt.Location,
                    HasChanges = true,
                };
                repo.Save(productToSave);
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
            return RedirectToAction(nameof(Index));
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
