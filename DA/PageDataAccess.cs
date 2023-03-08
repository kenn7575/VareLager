using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DA
{
    public class PageDataAccess : DatabaseAccess
    {
        public string Retrieve(string id)
        {
            Page page = new();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string Query = "SELECT * FROM Pages WHERE ProductId = '" + id + "';";
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            page.ProductId = reader["ProductId"] as string;
                            page.InnerHTML = reader["InnerHTML"] as string;
                        }
                    }
                }
            }
            return JsonSerializer.Serialize(page);
        }
    }
}
