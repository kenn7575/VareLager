using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BL
{
    public class Files : FileHandler
    {
        //constructor
        public Files(string importPath, string exportPath) : base(importPath, exportPath)
        {
            Directory.CreateDirectory(exportPath);

        }

        //fields
        public List<Pluklist> Pluklists = new List<Pluklist>();

        //methods
        //Extends the base class method and convert the files to objects
        public override void ImportFiles()
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
                    Files.Add(fileName);
                    IImportFile impoter = GetFileImporter(fileName);
                    Pluklists.Add(impoter.Read(fileName));
                }
            }
        }

        private IImportFile GetFileImporter(string filename)
        {
            switch (Path.GetExtension(filename).ToLower())
            {
                case ".xml":
                    return new ImportXML();
                case ".csv":
                    return new ImportCSV();
                default:
                    throw new Exception("Unknown file type");
            }
        }
        public void ExportFiles(int index)
        {
            foreach (var line in Pluklists[index].Lines)
            {
                string stock = GetProductStock(line.ProductID);
                if (!int.TryParse(stock, out _))
                {
                    Console.WriteLine("One or more products is not present in the database");
                }
                else
                {
                    if (int.Parse(stock) < line.Amount)
                    { 
                        Console.WriteLine("One or more products are not in stock.");
                        return;
                    }
                    else
                    {
                        //update stock
                        ProduktRepository pr = new ProduktRepository();
                        List<Produkt> p = pr.Retrieve(line.ProductID);
                        p[0].QuantityInStock -= line.Amount;
                        p[0].HasChanges= true;
                        pr.Save(p[0]);
                    }
                }


            }

            var fileName = Files[index];
            fileName.Substring(1);

            string exportPath = Path.Combine(Environment.CurrentDirectory, ExportPath, fileName.Substring(fileName.LastIndexOf("\\") + 1));



            File.Move(fileName, exportPath);
            Console.WriteLine("File moved to {0}", Path.Combine(Environment.CurrentDirectory, ExportPath, $"{Pluklists[index].Name}.xml"));
            Pluklists.RemoveAt(index);
            Files.RemoveAt(index);
            //TODO: this donsn't delete the file. only the variables.
            //the files should be deleated from Import 
        }
        public override bool Validate()
        {
            if (!Directory.Exists("filesToImport"))
            {
                Console.WriteLine("Directory \"filesToImport\" not found");
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
        public void DisplayOneFile(int index)
        {

            if (!this.IsValid)
            {
                return;
            }
            if (index > Files.Count - 1 || index < 0)
            {
                Console.WriteLine("Index out of range.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"BL {index + 1} af {Files.Count}");
            Console.WriteLine($"\nfile: {Files[index]}");
            Console.WriteLine("\n{0, -13}{1}", "Name:", Pluklists[index].Name);
            Console.WriteLine("{0, -13}{1}", "Forsendelse:", Pluklists[index].Forsendelse);
            Console.WriteLine("{0, -13}{1}", "Adresse:", Pluklists[index].Adresse);

           


            Console.WriteLine("\n{0,-7}{1,-9}{2,-20}{3, -30}{4} ", "Antal", "Type", "Produktnr.", "Navn", "Antal på lager.");
            foreach (var item in Pluklists[index].Lines)
            {
                string LagerStatus = GetProductStock(item.ProductID);
                
                Console.Write("{0,-7}{1,-9}{2,-20}{3, -30}", item.Amount, item.Type, item.ProductID, item.Title);
                if(int.TryParse(LagerStatus, out var status)) {
                    if (int.Parse(LagerStatus) < item.Amount)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (int.Parse(LagerStatus) >= item.Amount)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
                
                Console.WriteLine(LagerStatus);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public string GetProductStock(string ID) { 
        string output = "";
            ProduktRepository pr = new ProduktRepository();
            try
            {
            List<Produkt> produkt = pr.Retrieve(ID);
                output = produkt[0].QuantityInStock.ToString();
            }
            catch (Exception ex)
            {
                output = "Ukendt";
            }
        return output;
            
        }
       
    }
}
