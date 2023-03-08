using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Page : DataTracking
    {
        public string ProductId { get; set; }

        public string InnerHTML { get; set; }

        public override bool Validate()
        {

            if (string.IsNullOrWhiteSpace(ProductId)) return false;
            if (string.IsNullOrWhiteSpace(InnerHTML)) return false;

            return true;

        } 
        public string Personalize(Pluklist p)
        {
            string updatedInnerHTML = InnerHTML.Replace("[Name]", p.Name);
            updatedInnerHTML = updatedInnerHTML.Replace("[Adresse]", p.Address);

            string pluklistTable =
                "<h3>" +
                    "PluklistId" +
                "</h3> " +
                "<p>" +
                    p.PluklistId.ToString() +
                "</p>" +
                "<table>" +
                    "<thead>" +
                        "<tr>" +
                            "<th>" +
                                "ProductId" +
                            "</th>" +
                            "<th>" +
                                "Title" +
                            "</th>" +
                            "<th>" +
                                "Beskrivelse" +
                            "</th>" +
                            "<th>" +
                                "Type" +
                            "</th>" +
                            "<th>" +
                                "Antal" +
                            "</th>" +
                            "<th>" +
                                "Pris" +
                            "</th>" +
                        "</tr>";
            //row for each item in pluklist
            foreach (var item in p.Items)
            {
                pluklistTable +=
                    "<tr>" +
                        "<td>" +
                            item.ProductId +
                        "</td>" +
                        "<td>" +
                            item.Title +
                        "</td>" +
                        "<td>" +
                            item.Description +
                        "</td>" +
                        "<td>";
                string type = ""; 
                if (item.Type == 1){type= "Print";}
                else { type = "Fysisk"; }

                pluklistTable +=
                    //app type to table
                        type +
                        "</td>" +
                        "<td>" +
                            item.Amount.ToString() +
                        "</td>" +
                        "<td>" +
                        item.Price.ToString() +
                        "</td>"+
                    "</tr>";
            }

            pluklistTable += 
                    "</thead>" +
                "</table>";

            updatedInnerHTML = updatedInnerHTML.Replace("[Plukliste]", pluklistTable);
            return updatedInnerHTML;
        }
    }
}
