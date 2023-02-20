using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DA
{
    public class ProduktDataAccess : DatabaseAccess
    {
        public string Retrieve(int Id = 0)
        {
            var products = new List<Produkt>();
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string Query = "SELECT * FROM Product"; //TODO: Change to correct table name
                if (Id > 0)
                {
                    Query += " WHERE product_id = " + Id; //TODO: Change to correct location
                }
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Produkt();
                            product.ProductID = reader["productId"] as int?;
                            product.Title = reader["productName"] as string;
                            product.Description = reader["description"] as string;
                            product.Location = reader["current_price"] as string;
                            product.QuantityInStock = reader["QuantityInStock"] as int?;
                            product.Price = reader["Price"] as double?;

                            products.Add(product);
                        }
                    }
                }
            }
            return JsonSerializer.Serialize(products); 
        }
    }
}
