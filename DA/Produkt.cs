using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DA
{
    public class Produkt : DatabaseAccess
    {
        //fields
        public int? ProductID;
        public string? Title;
        public int? QuantityInStock;
        public string? Location;
        public double? Price;
        public string? Description;
    }
}
