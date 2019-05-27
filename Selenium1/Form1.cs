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
        int currentPage;
        int max;
        string pathForPages;
        string expForPages;
        string stopWord; 
        string containsWord;
        string chromeDriverPach;
        public Form1()
        {
            InitializeComponent();
            currentPage = 1;
            pathForPages = @"F:\auto\page";
            expForPages = ".txt";
            stopWord = "временно заблокировать доступ";
            containsWord = "Легковые автомобили";
            basePageUrl = "https://auto.ru/rossiya/cars/all/?sort=fresh_relevance_1-desc&output_type=table&page=";            
            max = currentPage + 1;
            chromeDriverPach = @"F:\web-driver\";
            ///initUi
            СurrentNum.Text = currentPage.ToString();
        }

        private void ParsePageButtom_Click(object sender, EventArgs e)
        {
            driver = new ChromeDriver(chromeDriverPach); //&lt;-Add your path
            
            start();
            СurrentNum.Enabled = false;
            //for (var i = currentPage; i < max; i++)
            //{
            //    start();
            //}
            СurrentNum.Enabled = true;
            StopBrowser();
        }

        void start()
        {
            var url = basePageUrl + currentPage.ToString();
            if (currentPage >= max)
            {
                StopBrowser();
                return;
            }

            var html = GetPageHtml(url);
            if (Helper.CheckingWordinHtml(stopWord, html) && !Helper.CheckingWordinHtml(containsWord,html))
            {
                //need proxy and re run;
                html = GetPageHtml(url);
            }
            else
            {
                var document = Helper.GetDocument(html);
                Helper.ParseAndSaveCarLinks(pathForPages, expForPages, document, currentPage);
                currentPage = Helper.GetCurrentPageNum(document) + 1;
                max = Helper.GetMaxPageNum(document);
            }
            return;
        }




        private string GetPageHtml(string url)
        {
            Thread.Sleep(new Random().Next(900, 3000));
            driver.Navigate().GoToUrl(url);
            var cc=driver.Manage().Cookies;
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(new Random().Next(150, 500));
            return Helper.ToUtf(driver.PageSource);
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            var html = System.IO.File.ReadAllText(@"F:\auto\123.txt",Encoding.UTF8);

            
                        var gg = Helper.CheckingWordinHtml(stopWord, html);
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
            currentPage = int.Parse(((TextBox)sender).Text);
        }



        private void StopBrowser()
        {
            driver.Quit();
            
            driver.Dispose();
        }

        private void parseCar_Click(object sender, EventArgs e)
        {

        }
    }
}
