using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DriverTestMethods.BaseClass;
using DriverTestMethods.WPTests;
using OpenQA.Selenium;
using DriverTestMethods.WPPages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Configuration;
using System.Reflection;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace DriverTestMethods.WPTests.MEPageTest
{
    [TestFixture]
    class WPMeTests : BaseTestClass
    {
        ExtentReports extentrpt = null;
        LoginPageTest.LoginPageTests lg = new LoginPageTest.LoginPageTests();

        [OneTimeSetUp]
        public void InitExtentReport()
        {
            var spath = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName + @"\Reports\" + this.GetType().Name + ".html";
            extentrpt = new ExtentReports();

            var htmlrpt = new ExtentHtmlReporter(spath);
            extentrpt.AttachReporter(htmlrpt);
        }

        [OneTimeTearDown]
        public void CloseExtentReport()
        {
            extentrpt.Flush();
        }

        [SetUp]
        public void GotoME() {
            driver.Navigate().GoToUrl(TestContext.Parameters["urlMe"].ToString());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        
            lg.ValidUserLogin();
            //lg = new WPTests.LoginPageTest();
        }

        [TearDown]
        public void Logout()
        {
            var WPMe = new WPMe(driver);
            WPMe.btnLogOut.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Thread.Sleep(2000);
        }

        //t
        //tttttttttt

        [Test]
        [Category("USERPROFILE")]
        [Author("RudraPatel")]
        public void PageChecks()
        {
            var WPWPMe = new WPMe(driver);
            ExtentTest extest = null;
            try
            {
                extest = extentrpt.CreateTest(MethodBase.GetCurrentMethod().Name).Info(MethodBase.GetCurrentMethod().Name + "-- Started Execution");
               // Assert.IsTrue(WP.lblFormHeader.Displayed);
             //   Assert.IsTrue(WP.lblEmailAddUserr.Displayed);
               // Assert.IsTrue(WP.txtUserNameOrEmail.Enabled);
                //Assert.IsTrue(driver.Title.ToString().Contains("WordPress"));
            }
            catch (System.Exception e)
            {
                extest.Log(Status.Pass, MethodBase.GetCurrentMethod().Name + " -- FAILED");
                //Test Commit;

                throw;
            }

        }

        [Test]
        public void Navigation()
        {

        }


    }

    public class WPMEMyProfile : BaseTestClass
    {
        ExtentReports extentrpt = null;
        LoginPageTest.LoginPageTests lg = new LoginPageTest.LoginPageTests();

        [OneTimeSetUp]
        public void InitExtentReport()
        {
            var spath = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName + @"\Reports\" + this.GetType().Name + ".html";
            extentrpt = new ExtentReports();

            var htmlrpt = new ExtentHtmlReporter(spath);
            extentrpt.AttachReporter(htmlrpt);
        }

        [OneTimeTearDown]
        public void CloseExtentReport()
        {
            extentrpt.Flush();
        }

        [SetUp]
        public void GotoME()
        {
            driver.Navigate().GoToUrl(TestContext.Parameters["urlMe"].ToString());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            lg.ValidUserLogin();
            //lg = new WPTests.LoginPageTest();
            //lg = new WPTests.LoginPageTest();
            //lg = new WPTests.LoginPageTest();
            //lg = new WPTests.LoginPageTest();
        }

        [TearDown]
        public void Logout()
        {
            var WPMe = new WPMe(driver);
            WPMe.btnLogOut.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Thread.Sleep(2000);
        }
        [Test]
        [Category("USERPROFILE")]
        [Author("RudraPatel")]
        [TestCase("rudra","Patel","save")]
        [TestCase("", "", "delete")]
        public void SaveProfileDetails(string firstname,string lastname,string action)
        {
            var WPMe = new WPMe(driver);
            ExtentTest extest = null;
            try
            {
                string description = @"My Name is Rudra Patel I am a passionate QA Engineer who loves to automate Testcases";
                extest = extentrpt.CreateTest(MethodBase.GetCurrentMethod().Name).Info(MethodBase.GetCurrentMethod().Name + "-- Started Execution");

                switch (action)
                {
                    case "save":

                        WPMe.txtFirstName.Clear();
                        WPMe.txtFirstName.Click();
                        WPMe.txtFirstName.SendKeys(firstname);
                        wAIT().Until(ExpectedConditions.ElementToBeClickable(WPMe.btnSaveProfile));

                        WPMe.txtLastName.Clear();
                        WPMe.txtLastName.Click();
                        WPMe.txtLastName.SendKeys(lastname);
                        wAIT().Until(ExpectedConditions.ElementToBeClickable(WPMe.btnSaveProfile));


                        WPMe.txtDescription.Clear();
                        WPMe.txtDescription.Click();
                        WPMe.txtDescription.SendKeys(description);
                        wAIT().Until(ExpectedConditions.ElementToBeClickable(WPMe.btnSaveProfile));

                        WPMe.btnSaveProfile.Click();
                        //wAIT().Until(ExpectedConditions.ElementToBeClickable(WPMe.btnAddSite));
//                        wAIT().Until(ExpectedConditions.ElementToBeClickable(WPMe.btnSaveProfile));

                        Assert.IsTrue(WPMe.alertSave.Displayed);

                        ///Assertion for saved records
                        ///
                        Assert.IsTrue(WPMe.txtFirstName.GetAttribute("value").Contains(firstname));
                        Assert.IsTrue(WPMe.txtLastName.GetAttribute("value").Contains(lastname));
                        Assert.IsTrue(WPMe.txtDescription.GetAttribute("value").Contains(description));

                        break;

                    case "delete":
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                        WPMe.txtFirstName.Clear();
//                        WPMe.txtFirstName.SendKeys(Keys.Control + "a" + Keys.Backspace);
                        Thread.Sleep(1000);

                        //wAIT().Until(ExpectedConditions.ElementToBeClickable(WPMe.btnSaveProfile));
                        WPMe.txtLastName.Clear();
  //                      WPMe.txtFirstName.SendKeys(Keys.Control + "a" + Keys.Backspace);
                        Thread.Sleep(1000);

//                        wAIT().Until(ExpectedConditions.ElementToBeClickable(WPMe.btnSaveProfile));
                        WPMe.txtDescription.Clear();
    //                    WPMe.txtFirstName.SendKeys(Keys.Control + "a" + Keys.Backspace);
                        Thread.Sleep(1000);

                        WPMe.btnSaveProfile.Click();

                        //wAIT().Until(ExpectedConditions.ElementToBeClickable(WPMe.btnAddSite));
                        Thread.Sleep(2000);

                        Assert.IsTrue(WPMe.alertSave.Displayed);

                        ///Assertion for saved records
                        ///
                        Assert.IsFalse(WPMe.txtFirstName.GetAttribute("value").Contains(firstname));
                        Assert.IsFalse(WPMe.txtLastName.GetAttribute("value").Contains(lastname));
                        Assert.IsFalse(WPMe.txtDescription.GetAttribute("value").Contains(description));

                        break;
                }
                //   Assert.IsTrue(WP.lblEmailAddUserr.Displayed);
                // Assert.IsTrue(WP.txtUserNameOrEmail.Enabled);
                //Assert.IsTrue(driver.Title.ToString().Contains("WordPress"));
            }
            catch (System.Exception e)
            {
                extest.Log(Status.Pass, MethodBase.GetCurrentMethod().Name + " -- FAILED");

                throw;
            }

        }

        [Test]
        [Category("USERPROFILE")]
        [Author("RudraPatel")]
        public void AddProfileLinks()
        {

        }
    }
}
