using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using ServiceStack;

namespace Selenium1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver(@"F:\web-driver\"); //&lt;-Add your path
            driver.Navigate().GoToUrl("https://auto.ru/rossiya/cars/all/?sort=fresh_relevance_1-desc&output_type=table&page=11");
            var js = (IJavaScriptExecutor)driver;            
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
           
            var html = driver.PageSource;
            

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);

            var current= GetNextPage(document);
            var max = GetMaxPage(document);
            if (max>current)
            {
                ///next
            }

            FillList(document, current);

            var url = "https://auto.ru/rossiya/cars/all/?sort=fresh_relevance_1-desc&output_type=table&page=" + (current+1).ToString();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
          var html=  System.IO.File.ReadAllText(@"F:\auto\test.html");
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            GetMaxPage(document);
        }

        private int GetNextPage(HtmlAgilityPack.HtmlDocument document)
        {
            return Helper.GetCurrentPageNum(document);
             
        }


        private  void FillList(HtmlAgilityPack.HtmlDocument document,int page)
        {       

            var links = Helper.GetPageLinks(document);          

            System.IO.File.WriteAllLines(@"F:\auto\test"+page.ToString()+ ".html", links);

           
           
        }

        private int GetMaxPage(HtmlAgilityPack.HtmlDocument document)
        {
            return Helper.GetMaxPageNum(document);         

        }
    }
}
