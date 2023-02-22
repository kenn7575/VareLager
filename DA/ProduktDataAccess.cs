﻿using System;
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
        public string Retrieve(string Id)
        {
            var products = new List<Produkt>();
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string Query = "SELECT * FROM Products WHERE ProduktID = \'"+ Id+"\'";
                
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Produkt();
                            product.ProduktID = reader["ProduktID"] as string;
                            product.Title = reader["Title"] as string;
                            product.Description = reader["Description"] as string;
                            product.Location = reader["Location"] as string;
                            product.QuantityInStock = reader["QuantityInStock"] as int?;
                            product.Price = reader["Price"] as double?;

                            products.Add(product);
                        }
                    }
                }
            }
            return JsonSerializer.Serialize(products); 
        }
        //method that retreves all products from the database
        public string Retrieve()
        {
            var products = new List<Produkt>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string Query = "SELECT * FROM Products";
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produkt product = new Produkt();
                            product.ProduktID = reader["ProduktID"] as string;
                            product.Title = reader["Title"] as string;
                            product.Description = reader["Description"] as string;
                            product.Location = reader["Location"] as string;
                            product.QuantityInStock = reader["QuantityInStock"] as int?;
                            product.Price = reader["Price"] as double?;

                            products.Add(product);
                        }
                    }
                }
            }
          
            string s = JsonSerializer.Serialize(products);
            return s;
        }
        //method that updates a product in the database
        public void Update(Produkt product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string Query = "UPDATE Products SET" +
                    " Title = @Title," +
                    " Description = @Description," +
                    " QuantityInStock = @QuantityInStock," +
                    " Price = @Price," +
                    " Location = @Location"+
                    " WHERE ProduktID = @ProduktID";
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ProduktID", product.ProduktID);
                    command.Parameters.AddWithValue("@Title", product.Title);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Location", product.Location);
                    command.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);
                    command.Parameters.AddWithValue("@Price", (float)product.Price);
                    command.ExecuteNonQuery();
                }
            }
        }
        //method that creates a new product in the database
        public void Create(Produkt product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string Query = "INSERT INTO Products (ProduktID, Title, Description, Location, QuantityInStock, Price) " +
                    "VALUES (@ProduktID, @Title, @Description, @Location, @QuantityInStock, @Price)";
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ProduktID", product.ProduktID);
                    command.Parameters.AddWithValue("@Title", product.Title);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Location", product.Location);
                    command.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);
                    command.Parameters.AddWithValue("@Price", (float)product.Price);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
