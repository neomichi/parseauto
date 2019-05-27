using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        IWebDriver driver;
        string baseUrl;
        int current = 17;
        int max;
        public Form1()
        {
            InitializeComponent();
            baseUrl = "https://auto.ru/rossiya/cars/all/?sort=fresh_relevance_1-desc&output_type=table&page=";
            max = current + 1;
        }

       






        private void button1_Click(object sender, EventArgs e)
        {
            driver = new ChromeDriver(@"F:\web-driver\"); //&lt;-Add your path
            
            start();
            СurentNum.Enabled = false;
            for (var i=current; i < max;i++) {

                start();
            }
            
        }

        void start()
        {  
            var url = baseUrl + current.ToString();
            if (current >= max)
            {
                driver.Close();
                driver.Dispose();
                return;
            }

            var html = GetPageHtml(url);
            var document = Helper.GetDocument(html);
            SaveLink(document, current);

            current = GetNextPage(document) + 1;
            max = GetMaxPage(document);
            return;
        }




        private string GetPageHtml(string url)
        {
            driver.Navigate().GoToUrl(url);
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(new Random().Next(150, 500));
            var html= driver.PageSource;
            Thread.Sleep(new Random().Next(500, 3000));

            return html;
        }

        private void button2_Click(object sender, EventArgs e)
        {
          var html=  System.IO.File.ReadAllText(@"F:\auto\test.html");
           
            GetMaxPage(Helper.GetDocument(html));
        }

        int GetNextPage(HtmlAgilityPack.HtmlDocument document)
        {
            return Helper.GetCurrentPageNum(document);             
        }
        void SaveLink(HtmlAgilityPack.HtmlDocument document,int page)
        {       

            var links = Helper.GetPageLinks(document);         

            System.IO.File.WriteAllLines(@"F:\auto\test"+page.ToString()+ ".html", links);           
           
        }
        int GetMaxPage(HtmlAgilityPack.HtmlDocument document)
        {
            return Helper.GetMaxPageNum(document);         

        }

        private void button3_Click(object sender, EventArgs e)
        {
            driver.Close();
            driver.Dispose();
        }

        private void СurentNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void СurentNum_TextChanged(object sender, EventArgs e)
        {
            current = int.Parse(((TextBox)sender).Text);
        }
    }
}
