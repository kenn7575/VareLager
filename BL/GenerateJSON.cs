using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace BL
{
    public class GenerateJSON
    {
        public void Generate(Pluklist pluklist)
        {

            string json = JsonConvert.SerializeObject(pluklist);
            
            
            Directory.CreateDirectory("filesToImport");
            
            File.WriteAllText("filesToImport\\" + pluklist.Name + ".json", json);
        }
    }
}
