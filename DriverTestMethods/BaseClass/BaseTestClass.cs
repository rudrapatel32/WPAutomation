using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace DriverTestMethods.BaseClass
{
  public class BaseTestClass
    {
        public static IWebDriver driver;
        public static WebDriverWait wait;
        
        // public IWebDriver webDriver { get; set; }
        // public BrowserType Browsertyp;
        public string Browsername { get; set; }
        public string username { get; set; }
        public string pwd { get; set; }

        public BaseTestClass()
        {
            this.Browsername = TestContext.Parameters["browser"].ToString();
            this.username = TestContext.Parameters["username"].ToString();
            this.pwd = TestContext.Parameters["pwd"].ToString();
        }

        [OneTimeSetUp]
        public void OpenBrowser()
        {
            string pathh, x;
            pathh = System.IO.Path.GetFullPath(".");
            switch (Browsername)
            {
                case "Chrome":
                    //String path= @"D:\WordPressAutomation\Drivers";
                    driver = new ChromeDriver(pathh);
                    break;
                case "InternetExplorer":
                    break;
                case "FireFox":
                    break;
                default:
                    driver = new ChromeDriver(pathh);
                    break;
            }
           driver.Manage().Window.Maximize();
           driver.Navigate().GoToUrl(TestContext.Parameters["url"].ToString());
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
          //  GetDriver(driver);
        }

       // public IWebDriver GetDriver
        //{
         //   get { return this.driver; }
//            dd = this.driver;  
  //          return dd;
        //}
        //}}}}}}}}}}}}}}}}}}
        public string GetURL()
        {
            return driver.Url;
        }

        public WebDriverWait wAIT()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return wait;
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
    public class TestClass1:BaseTestClass
    {
        public void GOTOURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }
        
    }

}
