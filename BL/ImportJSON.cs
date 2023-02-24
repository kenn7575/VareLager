using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;

namespace BL
{
    internal class ImportJSON
    {
        public Pluklist Read(string path)
        {
            using (FileStream fileStream = File.OpenRead(path))
            {
                Pluklist pluklist = JsonSerializer.Deserialize<Pluklist>(fileStream);
                return pluklist;
            }
        }
    }
}
