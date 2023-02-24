using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Diagnostics;

namespace BL
{
    public class GenerateJSON
    {
        public void Generate(Pluklist pluklist)
        {
            
            //string json = JsonSerializer.Serialize<Pluklist>(pluklist);
            string json2 = "{" +
                "\"Name\":\"" + pluklist.Name + "\"," +
                "\"Adresse\":\"" + pluklist.Adresse + "\"," +
                "\"Forsendelse\":\"" + pluklist.Forsendelse + "\"," +
                "\"Items\":" + JsonSerializer.Serialize<List<Item>>(pluklist.Lines)+
                "}";

            Directory.CreateDirectory("filesToImport");
            
            File.WriteAllText("filesToImport\\" + pluklist.Name + ".json", json2);
        }
    }
}
