using Microsoft.VisualBasic;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public abstract class FileHandler
    {
        //constructor
        public FileHandler(string importPath, string exportPath)
        {
            Files = new List<string>();
            ImportPath = importPath;
            ExportPath = exportPath;
        }

        //fields
        public string? ImportPath { get; set; }
        public string? ExportPath { get; set; }
        public List<string> Files { get; set; }

        public bool IsValid => Validate();

        //methods
        public abstract bool Validate();
        public virtual void ImportFiles()
        {

            if (this.IsValid)
            {
                List<string> filesNames = Directory.EnumerateFiles(ImportPath).ToList();
                if (filesNames.Count == 0)
                {
                    Console.WriteLine("Folder is empty.");
                    return;
                }
                foreach (var fileName in filesNames)
                {
                    var file = File.ReadAllText(fileName);

                    Files.Add(file);
                }
            }
        }
    }
}
