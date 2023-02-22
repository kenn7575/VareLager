using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using DA;

namespace BL
{
    public class ProduktRepository
    {
        //methods 
        public List<Produkt> Retrieve(string Id)
        {
            var products = new List<Produkt>();
            var da = new ProduktDataAccess();
            var json = da.Retrieve(Id);
            products = JsonSerializer.Deserialize<List<Produkt>>(json);
            return products;
        }
        //retreve all
        public List<Produkt> Retrieve()
        {
            var products = new List<Produkt>();
            var da = new ProduktDataAccess();
            string json = da.Retrieve(); //TODO: fix error
            products = JsonSerializer.Deserialize<List<Produkt>>(json); //TODO: fix error
            return products;
        }
        //update product
        public void Save(Produkt product)
        {
            if (!product.IsValid) return;
            if (!product.HasChanges) return;

            var da = new ProduktDataAccess();
            var productDa = new DA.Produkt()
            {

                ProduktID = product.ProduktID,
                Title = product.Title,
                Description = product.Description,
                Location = product.Location,
                QuantityInStock = product.QuantityInStock,
                Price = product.Price

            };
            if (product.IsNeW)
            {
                da.Create(productDa);
            }
            else
            {
                da.Update(productDa);
            }
            
           
           
        }
    }
}
