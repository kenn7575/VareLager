using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Html : FileHandler
    {
        
        public Html(string importPath, string exportPath) : base(importPath, exportPath)
        {
            Directory.CreateDirectory("letter");
        }
        //fields
        public Pluklist Pluklist { get; set; }
        
        //methods
        public override bool Validate()
        {
            if (Pluklist == null)
            {
                Console.WriteLine("Pluklist not set");
                return false;
            }
            if (!Directory.Exists("templates"))
            {
                Console.WriteLine("Directory \"templates\" not found");
                Console.ReadLine();
                return false;
            }
            if (string.IsNullOrEmpty(ImportPath))
            {
                Console.WriteLine("Import path not set");
                return false;
            }
            if (string.IsNullOrEmpty(ExportPath))
            {
                Console.WriteLine("Export path not set");
                return false;
            }
            return true;
        }
        public void UpdateFiles()
        {
            if (this.IsValid)
            {
                List<string> UpdateFiles = new List<string>();
                foreach (string file in Files)
                {
                    string updatedFile = file.Replace("[Adresse]", Pluklist.Adresse);
                    updatedFile = updatedFile.Replace("[Name]", Pluklist.Name);
                    updatedFile = updatedFile.Replace("<head>", "<head> <style>table, th, td{border: solid black 1px;}</style>");


                    string pluklist = "<table style=\"width:100%;\"> <tr> <th>Title</th> <th>Amount</th>";
                    foreach (var line in Pluklist.Lines)
                    {
                        pluklist += line.ToString() + "\n";
                    }
                    pluklist += "</table>";
                    updatedFile = updatedFile.Replace("[BL]", pluklist);

                    UpdateFiles.Add(updatedFile);
                }
                Files = UpdateFiles;
            }
        }
        public void ExportFiles(int type)
        {
            if (this.IsValid)
            {
            string path = Path.Combine("letter", $"{Pluklist.Name}.html");
            string html = Files[type];
            File.WriteAllText(path, html);
            Console.WriteLine("File was added to {0}", Path.Combine(Environment.CurrentDirectory, path));
            }
        }


    }
}