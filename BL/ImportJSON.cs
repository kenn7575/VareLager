using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.VisualBasic;

namespace BL
{
    public class ImportJSON : IImportFile
    {
        public Pluklist Read(string path)
        {
            using (FileStream fileStream = File.OpenRead(path))
            {
                string data = "";
                using (var sr = new StreamReader(fileStream))
                {
                    data = sr.ReadToEnd();
                }

                Pluklist pluklist = JsonConvert.DeserializeObject<Pluklist>(data);
                return pluklist;
            }
        }
    }
    
    
}
