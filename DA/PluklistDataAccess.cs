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
                            pluklist.DateCreated = reader["DateCreated"] as string;
                            pluklist.DateCreated = reader["DateFinished"] as string;
                           
                        }
                    }
                }
                string Query2 = "SELECT * FROM OrderItem WHERE PluklistId = \'" + pluklist.PluklistId + "\'";
                List<OrderItem> orderItems = new();
                using (SqlCommand command = new SqlCommand(Query2, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderItem orderItem = new();
                            orderItem.PluklistId = reader["PluklistId"] as string;
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
                                DateCreated = reader["DateCreated"] as string,
                                DateFinished = reader["DateFinished"] as string,
                            };
                            pluklists.Add(pluklist);
                        }
                    }
                }
                foreach (Pluklist pluklist in pluklists)
                {
                    string Query2 = "SELECT * FROM OrderItem WHERE PluklistId = \'" + pluklist.PluklistId + "\'";
                    List<OrderItem> orderItems = new();
                    using (SqlCommand command = new SqlCommand(Query2, connection))
                    {
                        using (SqlDataReader reader1 = command.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                OrderItem orderItem = new();
                                orderItem.PluklistId = reader1["PluklistId"] as string;
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
                                item.SalesPrice = orderItem.SalesPrice;
                                item.Price = produkt.Price;
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
            //1: create Items in db for each item in pluklist.items with the same OrderItemId
            //2: create pluklist in db with the same OrderItemId


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                int pluklistId = 0;
                connection.Open();
                string Query1 = "INSERT INTO Pluklist (Name, Shipping, Address, PluklistStatus, DateCreated, DateFinished) output inserted.PluklistId" +
                    "VALUES (@Name, @Shipping, @Address, @PluklistStatus, @DateCreated, @DateFinished)";
                using (SqlCommand command = new SqlCommand(Query1, connection))
                {
                    command.Parameters.AddWithValue("@Name", pluklist.Name);
                    command.Parameters.AddWithValue("@Shipping", pluklist.shipping);
                    command.Parameters.AddWithValue("@Address", pluklist.address);
                    command.Parameters.AddWithValue("@PluklistStatus", pluklist.PluklistStatus);
                    command.Parameters.AddWithValue("@DateCreated", pluklist.DateCreated);
                    command.Parameters.AddWithValue("@DateFinished", pluklist.DateFinished);
                    pluklistId = (int)command.ExecuteScalar(); //TODO: Fix later
                }
                foreach (Item item in pluklist.Items)
                {

                    connection.Open();
                    string Query2 = "INSERT INTO OrderItem (ProductId, OrderItemId, Quantity, SalesPrice) " +
                        "VALUES (@ProductId, @OrderItemId, @Quantity, @SalesPrice)";
                    using (SqlCommand command = new SqlCommand(Query2, connection))
                    {
                        command.Parameters.AddWithValue("@ProductId", item.ProductId);
                        command.Parameters.AddWithValue("@OrderItemId", pluklistId);
                        command.Parameters.AddWithValue("@Quantity", item.Amount);
                        command.Parameters.AddWithValue("@SalesPrice", (float)item.SalesPrice);
                        int OrderItemId = (int)command.ExecuteScalar();
                    }
                }

            }


        }
    }

}
