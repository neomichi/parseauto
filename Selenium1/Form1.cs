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
        string basePageUrl;
        int current = 1;
        int max;
        string pathForPages = @"F:\auto\page";
        string expForPages = ".txt";
        string stopWord = "временно заблокировать доступ";
        public Form1()
        {
            InitializeComponent();
            basePageUrl = "https://auto.ru/rossiya/cars/all/?sort=fresh_relevance_1-desc&output_type=table&page=";
            СurrentNum.Text = current.ToString();
            max = current + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            driver = new ChromeDriver(@"F:\web-driver\"); //&lt;-Add your path

            start();
            СurrentNum.Enabled = false;
            for (var i = current; i < max; i++)
            {

                start();
            }

        }

        void start()
        {
            var url = basePageUrl + current.ToString();
            if (current >= max)
            {
                StopBrowser();
                return;
            }

            var html = GetPageHtml(url);
            if (Helper.CheckHtmlStopWord(stopWord, html))
            {
                //need proxy and re run;
                html = GetPageHtml(url);
            }
            else
            {
                var document = Helper.GetDocument(html);
                Helper.ParseAndSaveCarLinks(pathForPages, expForPages, document, current);
                current = Helper.GetCurrentPageNum(document) + 1;
                max = Helper.GetMaxPageNum(document);
            }
            return;
        }




        private string GetPageHtml(string url)
        {
            Thread.Sleep(new Random().Next(500, 3000));
            driver.Navigate().GoToUrl(url);
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(new Random().Next(150, 500));
            return driver.PageSource;
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            var html = System.IO.File.ReadAllText(@"F:\auto\error.html");
            var gg = Helper.CheckHtmlStopWord(stopWord, html);

            MessageBox.Show(gg.ToString());
        }

        private void StopBrowserButton_Click(object sender, EventArgs e)
        {
            StopBrowser();

        }

        private void СurentNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void СurentNum_TextChanged(object sender, EventArgs e)
        {
            current = int.Parse(((TextBox)sender).Text);
        }



        private void StopBrowser()
        {
            driver.Quit();
            driver.Close();
            driver.Dispose();
        }

        private void parseCar_Click(object sender, EventArgs e)
        {

        }
    }
}
