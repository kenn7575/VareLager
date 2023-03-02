using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace DA
{
    public class PluklistDataAccess : DatabaseAccess
    {
        //retreve one pluklist
        public string Retrieve(string Id)
        {
            Pluklist pluklist = new();
            Item item = new();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string Query1 = "SELECT * FROM Pluklist WHERE PluklistId = \'" + Id + "\'";
                using (SqlCommand command = new SqlCommand(Query1, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pluklist.PluklistId = (int)reader["ProductId"];
                            pluklist.Name = reader["Name"] as string;
                            pluklist.shipping = reader["Shipping"] as string;
                            pluklist.address = reader["Address"] as string;
                            pluklist.PluklistStatus = reader["PluklistStatus"] as string;
                            pluklist.CreateDate = reader["DateCreated"] as string;
                            pluklist.FinishedDateDate = reader["DateFinished"] as string;
                            pluklist.OrderItemId = (int)reader["OrderItem"];
                        }
                    }
                }
                string Query2 = "SELECT * FROM OrderItem WHERE OrderItemId = \'" + pluklist.OrderItemId + "\'";
                List<OrderItem> orderItems = new();
                using (SqlCommand command = new SqlCommand(Query2, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderItem orderItem = new();
                            orderItem.OrderItemId = reader["OrderItemId"] as string;
                            orderItem.Quantity = (int)reader["Quantity"];
                            orderItem.ProductId = reader["ProductId"] as string;
                            orderItem.SalesPrice = (double)reader["SalesPrice"];
                            ProduktDataAccess produktDataAccess = new();
                            string serializedProdukt = produktDataAccess.Retrieve(orderItem.ProductId);
                            Product produkt = JsonSerializer.Deserialize<Product>(serializedProdukt);
                            item.ProductId = produkt.ProductId;
                            item.Title = produkt.Title;
                            item.Type = produkt.Type;
                            item.Amount = orderItem.Quantity;
                            item.Price = orderItem.SalesPrice;
                            item.Description = produkt.Description;
                            pluklist.Items.Add(item);
                        }
                    }
                }
            }
            return JsonSerializer.Serialize(pluklist);
        }

        //retreve all pluklists
        public string Retrieve()
        {
            List<Pluklist> pluklists = new();
            Item item = new();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string Query1 = "SELECT * FROM Pluklist";
                using (SqlCommand command = new SqlCommand(Query1, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pluklist pluklist = new()
                            {
                                PluklistId = (int)reader["PluklistId"],
                                Name = reader["Name"] as string,
                                shipping = reader["Shipping"] as string,
                                address = reader["Address"] as string,
                                PluklistStatus = reader["PluklistStatus"] as string,
                                CreateDate = reader["DateCreated"] as string,
                                FinishedDateDate = reader["DateFinished"] as string,
                                OrderItemId = (int)reader["OrderItem"],
                            };
                            pluklists.Add(pluklist);
                        }
                    }
                }
                foreach (Pluklist pluklist in pluklists)
                {
                    string Query2 = "SELECT * FROM OrderItem WHERE OrderItemId = \'" + pluklist.OrderItemId + "\'";
                    List<OrderItem> orderItems = new();
                    using (SqlCommand command = new SqlCommand(Query2, connection))
                    {
                        using (SqlDataReader reader1 = command.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                OrderItem orderItem = new();
                                orderItem.OrderItemId = reader1["OrderItemId"] as string;
                                orderItem.Quantity = (int)reader1["Quantity"];
                                orderItem.ProductId = reader1["ProductId"] as string;
                                orderItem.SalesPrice = (double)reader1["SalesPrice"];
                                ProduktDataAccess produktDataAccess = new();
                                string serializedProdukt = produktDataAccess.Retrieve(orderItem.ProductId);
                                Product produkt = JsonSerializer.Deserialize<Product>(serializedProdukt);
                                
                                item.ProductId = produkt.ProductId;
                                item.Title = produkt.Title;
                                item.Type = produkt.Type;
                                item.Amount = orderItem.Quantity;
                                item.Price = orderItem.SalesPrice;
                                item.Description = produkt.Description;
                                pluklist.Items.Add(item);
                            }
                        }
                    }
                   
                }
            }
            return JsonSerializer.Serialize(pluklists);
        }
        //create new pluklist
        public void Create(Pluklist pluklist)
        {
           //TODO'S
           //1: creaete Items in db for each item in pluklist.items with the same OrderItemId
           //2: 
            
        }
    }
        
}
