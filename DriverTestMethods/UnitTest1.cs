using NUnit.Framework;
using DriverTestMethods.BaseClass;
using OpenQA.Selenium;
using DriverTestMethods.WPPages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Configuration;
using System.Reflection;

namespace DriverTestMethods
{
    [TestFixture]
    public class TestClass :BaseTestClass
    {
        TestClass1 tt = new TestClass1();
        ExtentReports extentrpt = null;
        ExtentTest extest = null;

        [OneTimeSetUp]
        public void InitExtentReport()
        {
            var spath = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName + @"\Reports\" + this.GetType().Name + ".html";
            extentrpt = new ExtentReports();
            
            var htmlrpt = new ExtentHtmlReporter("D:\\WordPressAutomation\\DriverTestMethods\\Reports\\TestClass.html");
            extentrpt.AttachReporter(htmlrpt);
        }

        [OneTimeTearDown]
        public void CloseExtentReport()
        {
            extentrpt.Flush();
        }
        
        [SetUp]
        public void Setup()
        {
            //if have database access we can add here sql query which creates user from backend so that we dont have to 
            //create user everytime to test any functionilty and in teardown delete same user from backend
            
        }

        [Test]
        public void Test1()
        {
            extest = extentrpt.CreateTest(MethodBase.GetCurrentMethod().Name).Info(MethodBase.GetCurrentMethod().Name + "-- Started Execution");
            extest.Log(Status.Pass, MethodBase.GetCurrentMethod().Name + " -- PASSED");

            string uu = driver.Url;
            uu = tt.GetURL();
            tt.GOTOURL("https:\\gmail.com");

            driver.Navigate().GoToUrl("https:\\youtube.com");
            //Assert.Pass();
            string title = tt.GetPageTitle();
            uu = tt.GetURL();
        }
        [Test]
        public void Test2()
        {
            try
            {
                driver.Navigate().GoToUrl("https://wordpress.com/log-in");
                extest = extentrpt.CreateTest(MethodBase.GetCurrentMethod().Name).Info(MethodBase.GetCurrentMethod().Name + "-- Started Execution");
                var wploginpage = new WPLoginPage(driver);
                wploginpage.btnContinue.Click();
                extest.Log(Status.Pass, MethodBase.GetCurrentMethod().Name+" -- PASSED");
            }
            catch (System.Exception e)
            {
                extest.Log(Status.Fail, MethodBase.GetCurrentMethod().Name + "-- FAILED: " +e.ToString());
                throw;
            }

        }
        [TearDown]
        public void Close()
        {
            //baseTestClass.CloseBrowser();
        }
    }
}