﻿using System;
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
        static List<string> GetPageLinks(HtmlDocument doc)
        {
            return GetTaginHtmlNodes(doc.DocumentNode
                .SelectNodes("//a"), "href", "cars/used/sale/")                
                 .Select(x => x.Attributes["href"].Value)
                 .ToList();           

        }

        public static int GetCurrentPageNum(HtmlDocument doc)
        {
            var span = GetTaginHtmlNodes(doc.DocumentNode.SelectNodes("//span"), "class", "ListingPagination-module__pages")
                .FirstOrDefault();

            var val = span.SelectNodes("a").First(x => !x.Attributes.Contains("href")).InnerText;
            return int.Parse(val.Trim());
        }

        public static int GetMaxPageNum(HtmlDocument doc)
        {
            var span = GetTaginHtmlNodes(doc.DocumentNode.SelectNodes("//span"), "class", "ListingPagination-module__pages").First();
             
            var list = span.SelectNodes("a")
                .Where(x => x.Attributes.Contains("href") &&
                x.InnerText != "…").Select(x => int.Parse(x.InnerText)).ToList();

            return list.Max();
        }

        public static HtmlDocument GetDocument(string html)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            return document;
        }

        public static void ParseAndSaveCarLinks(string path, string fileExp, HtmlDocument document, int page)
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


        public static CarModel GetCarModel(HtmlDocument document)
        {
            var cm = new CarModel();

            var allDiv = document.DocumentNode.SelectNodes("//div");

            cm.Title = GetTaginHtmlNodes(allDiv, "CardHead-module__title", "class").First().InnerText;


            var divList = GetTaginHtmlNodes(allDiv, "CardInfo-module__CardInfo","class").ToList();

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
                                                      
            return cm;
        }
        
        public static List<HtmlNode> GetTaginHtmlNodes(HtmlNodeCollection htmlNode,string tag, string attribute)
        {
            return htmlNode.Where(x => x.Attributes.Contains(tag)
               && x.Attributes[tag].Value.Contains(attribute)).ToList();

        }

        public static List<HtmlNode> GetClassinHtmlNodes(HtmlNodeCollection htmlNode, List<string> classAttributes)
        {
            var list = new List<HtmlNode>();

            list= htmlNode.Where(x => x.Attributes.Contains("class")
               && classAttributes.Contains(x.Attributes["class"].Value)).ToList();

            return list;
        }
    }
}
