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
                            pluklist.PluklistId = reader["ProductId"] as string;
                            pluklist.Name = reader["Name"] as string;
                            pluklist.shipping = reader["Shipping"] as string;
                            pluklist.address = reader["Address"] as string;
                            pluklist.PluklistStatus = reader["PluklistStatus"] as string;
                            pluklist.CreateDate = (DateTime)reader["DateCreated"];
                            pluklist.FinishedDateDate = (DateTime)reader["DateFinished"];
                            pluklist.OrderItemId = reader["OrderItem"] as string;
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
                            orderItem.SalesPrice = (float)reader["SalesPrice"];
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
                                PluklistId = reader["ProductId"] as string,
                                Name = reader["Name"] as string,
                                shipping = reader["Shipping"] as string,
                                address = reader["Address"] as string,
                                PluklistStatus = reader["PluklistStatus"] as string,
                                CreateDate = (DateTime)reader["DateCreated"],
                                FinishedDateDate = (DateTime)reader["DateFinished"],
                                OrderItemId = reader["OrderItem"] as string,
                                
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
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrderItem orderItem = new();
                                orderItem.OrderItemId = reader["OrderItemId"] as string;
                                orderItem.Quantity = (int)reader["Quantity"];
                                orderItem.ProductId = reader["ProductId"] as string;
                                orderItem.SalesPrice = (float)reader["SalesPrice"];
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
                            pluklists.Add(pluklist);
                }
            }
            return JsonSerializer.Serialize(pluklists);
        }
    }
}
