//Eksempel på funktionel kodning hvor der kun bliver brugt et model lag
using System;
using System.Drawing;
using System.IO;
using System.IO.Enumeration;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using BL;

namespace BL
{
    class PluklisteProgram
    {
        //app state
        public static char readKey = ' ';
        public static int CurrentFileIndex = 0;
        
        static void Main()
        {
            //pluklist
            Pluklist pluklist = new()
            {
                PluklistId = 12,
                Name = "Hans Hansen",
                Shipping = "GLS",
                Address = "hovedgaden 1",
                PluklistStatus = "Afsluttet",
                DateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                DateFinished = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            OrderItem item = new()
            {
                PluklistId = 2,
                Amount = 1,
                ProductId = "sosgisthsttf",
                SalesPrice = 100,
                Type = 0,
                Title = "Bog 1",
                Description = "Bog 1",
                Price = 100,
            };
            pluklist.Items.Add(item);


            PageRepository pageRepository = new();
            Page page = pageRepository.Retrieve("PRINT-WELCOME");
            string updated = page.Personalize(pluklist);
        }
            //    Files xmlFiles = new("filesToImport", "export");
            //    xmlFiles.ImportFiles();
            //    while (readKey != 'Q')
            //    {
            //        try
            //        {
            //        xmlFiles.DisplayOneFile(CurrentFileIndex);
            //        PrintOperationOptions(CurrentFileIndex, xmlFiles.Files);
            //        PerformOperation(xmlFiles.Pluklists[CurrentFileIndex], xmlFiles);
            //        }
            //        catch(Exception e)
            //        {
            //            Console.WriteLine(e);
            //            break;
            //        }
            //    }
            //}
            //public static void PerformOperation(Pluklist pluklist, /*Files*/ xmlFiles)
            //{
            //    readKey = Console.ReadKey().KeyChar;
            //    if (readKey >= 'a') readKey -= (char)('a' - 'A'); 
            //    Console.Clear();

            //    Console.ForegroundColor = ConsoleColor.Red;
            //    switch (readKey)
            //    {
            //        case 'G':
            //            CurrentFileIndex = 0;
            //            Console.WriteLine("Pluklister genindlæst");
            //            break;
            //        case 'F':
            //            if (CurrentFileIndex > 0) CurrentFileIndex--;
            //            break;
            //        case 'N':
            //            if (CurrentFileIndex < xmlFiles.Files.Count - 1) CurrentFileIndex++;
            //            break;
            //        case 'A':
            //            //Move files to import directory

            //            xmlFiles.ExportFiles(CurrentFileIndex); 
            //            if (CurrentFileIndex == xmlFiles.Files.Count) CurrentFileIndex--;
            //            break;
            //        case 'P':
            //            Html htmlFile = new("templates", "letters");
            //            htmlFile.Pluklist = pluklist;
            //            htmlFile.ImportFiles();
            //            htmlFile.UpdateFiles();
            //            foreach (var line in htmlFile.Pluklist.Lines)
            //            {
            //                if (line.Type == ItemType.Print)
            //                {
            //                    if (line.ProductID == "PRINT-OPGRADE")
            //                    {
            //                        htmlFile.ExportFiles(0);
            //                    }
            //                    if(line.ProductID == "PRINT-OPSIGELSE") { 
            //                        htmlFile.ExportFiles(1);

            //                    }
            //                    if (line.ProductID == "PRINT-WELCOME") { 
            //                        htmlFile.ExportFiles(2);

            //                    }
            //                }
            //            }

            //            break;
            //    }
            //}
            //public static void PrintOperationOptions(int CurrentFileIndex, List<string> files)
            //{
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.WriteLine("\n\nOptions:");
            //    PrintOption("Q", "uit");
            //    if (CurrentFileIndex >= 0)
            //    {
            //        PrintOption("A", "fslut plukseddel");
            //        PrintOption("P", "rint ordrebekræftelse");
            //    }
            //    if (CurrentFileIndex > 0)
            //    {
            //        PrintOption("F", "orrige plukseddel");
            //    }
            //    if (CurrentFileIndex < files.Count - 1)
            //    {
            //        PrintOption("N", "æste plukseddel");
            //    }
            //    PrintOption("g", "enindlæs pluksedler");
            //}
            //public static void PrintOption(string letter, string message)
            //{
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.Write(letter);
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.WriteLine(message);
        
    }
}


