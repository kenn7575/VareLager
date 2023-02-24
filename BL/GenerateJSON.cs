using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace BL
{
    internal class GenerateJSON
    {
        public void Generate(Pluklist pluklist)
        {
            string json = JsonSerializer.Serialize(pluklist);
            File.WriteAllText("filesToImport" + pluklist.Name + ".json", json);
        }
    }
}
