using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium1
{
    public class Helper
    {
        public static List<string> GetPageLinks(HtmlAgilityPack.HtmlDocument doc) 
        {    
            return doc.DocumentNode.SelectNodes("//a")
                .Where(x => x.Attributes.Contains("href") &&
                 x.Attributes["href"].Value.Contains("cars/used/sale/"))
                 .Select(x=>x.Attributes["href"].Value)
                 .ToList();


        }

        public static int GetCurrentPageNum(HtmlAgilityPack.HtmlDocument doc)
        {
            var span = doc.DocumentNode.SelectNodes("//span").First(x =>
             x.Attributes.Contains("class") &&
             x.Attributes["class"].Value.Contains("ListingPagination-module__pages"));

            var val = span.SelectNodes("a").First(x => !x.Attributes.Contains("href")).InnerText;
            return int.Parse(val.Trim());
        }

        public static int GetMaxPageNum(HtmlAgilityPack.HtmlDocument doc)
        {
            var span = doc.DocumentNode.SelectNodes("//span").First(x =>
             x.Attributes.Contains("class") &&
             x.Attributes["class"].Value.Contains("ListingPagination-module__pages"));

            var list = span.SelectNodes("a")
                .Where(x => x.Attributes.Contains("href") &&
                x.InnerText!= "…").Select(x=>int.Parse(x.InnerText)).ToList();
                
            return list.Max();
        }
    }
}
