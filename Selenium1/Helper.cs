using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Selenium1
{
    public class Helper
    {
        static List<string> GetPageLinks(HtmlAgilityPack.HtmlDocument doc)
        {
            return doc.DocumentNode.SelectNodes("//a")
                .Where(x => x.Attributes.Contains("href") &&
                 x.Attributes["href"].Value.Contains("cars/used/sale/"))
                 .Select(x => x.Attributes["href"].Value)
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
                x.InnerText != "…").Select(x => int.Parse(x.InnerText)).ToList();

            return list.Max();
        }

        public static HtmlAgilityPack.HtmlDocument GetDocument(string html)
        {
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            return document;
        }

        public static void ParseAndSaveCarLinks(string path, string fileExp, HtmlAgilityPack.HtmlDocument document, int page)
        {
            var links = GetPageLinks(document);

            var filename = string.Format("{0}{1}{2}", path, page, fileExp);

            System.IO.File.WriteAllLines(filename, links);
        }

        public static bool CheckingWordinHtml(string row, string html)
        {
            return html.IndexOf(row, StringComparison.OrdinalIgnoreCase) > -1;
        }

        public static string ToUtf(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Encoding.UTF8.GetString(bytes);
        }


        public static CarModel GetCarModel(HtmlAgilityPack.HtmlDocument document)
        {
            var cm = new CarModel();

            var allDiv = document.DocumentNode.SelectNodes("//div");

            cm.Title = GetClassinHtmlNodes(allDiv, "CardHead-module__title").First().InnerText;


            var divList = GetClassinHtmlNodes(allDiv, "CardInfo-module__CardInfo").ToList();

            var list = divList.ToList()
                .SelectMany(x => x.ChildNodes)
                .Select(x => string.Join(",", x.ChildNodes.Select(y => y.InnerText).ToList())).ToList();

            var parameters = list.Select(x => x.Split(',')).Where(x => x.Length > 1).ToList();

            cm.CreateYear = parameters.FirstOrDefault(x => x[0].Equals("Год выпуска", StringComparison.OrdinalIgnoreCase))?[1] ?? "";
            cm.Mileage = parameters.FirstOrDefault(x => x[0].Equals("Пробег", StringComparison.OrdinalIgnoreCase))?[1] ?? "";
            cm.Body = parameters.FirstOrDefault(x => x[0].Equals("Кузов", StringComparison.OrdinalIgnoreCase))?[1] ?? "";
            cm.Color= parameters.FirstOrDefault(x => x[0].Equals("Цвет", StringComparison.OrdinalIgnoreCase))?[1] ?? "";
            cm.Engine = parameters.FirstOrDefault(x => x[0].Equals("Двигатель", StringComparison.OrdinalIgnoreCase))?[1] ?? "";
            cm.Transmission = parameters.FirstOrDefault(x => x[0].Equals("Коробка", StringComparison.OrdinalIgnoreCase))?[1] ?? "";
            cm.DriveUnit = parameters.FirstOrDefault(x => x[0].Equals("Привод", StringComparison.OrdinalIgnoreCase))?[1] ?? "";
            cm.SteeringWheel= parameters.FirstOrDefault(x => x[0].Equals("Руль", StringComparison.OrdinalIgnoreCase))?[1] ?? "";
            cm.Condition= parameters.FirstOrDefault(x => x[0].Equals("Состояние", StringComparison.OrdinalIgnoreCase))?[1] ?? "";




            //"CardInfo-module__CardInfo__cell"
            //"CardInfo-module__CardInfo__cell CardInfo-module__CardInfo__cell_right"

            //"CardInfo-module__CardInfo__row"




            return cm;
        }

        public static List<HtmlNode> GetClassinHtmlNodes(HtmlNodeCollection htmlNode, string classAttribute)
        {
            return htmlNode.Where(x => x.Attributes.Contains("class")
               && x.Attributes["class"].Value.Contains(classAttribute) ).ToList();

        }

        public static List<HtmlNode> GetClassinHtmlNodes(HtmlNodeCollection htmlNode, List<string> classAttributes)
        {
            var list = new List<HtmlNode>();

            list= htmlNode.Where(x => x.Attributes.Contains("class")
               && classAttributes.Contains(x.Attributes["class"].Value)).ToList();

            return list;
        }

        public static string GetNameAttribute<T>()
        {
            MemberInfo property = typeof(T).GetProperty("Name");
            var attribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                .Cast<DisplayNameAttribute>().Single();
            return attribute.DisplayName;
        }

        

    }
}
