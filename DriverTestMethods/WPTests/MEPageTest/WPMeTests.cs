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
                Assert.IsTrue(WPWPMe.aMySite.Displayed);
                Assert.IsTrue(WPWPMe.aReader.Displayed);
                Assert.IsTrue(WPWPMe.aMyProfile.Displayed);
                Assert.IsTrue(driver.Title.ToString().Contains("My Profile"));
                Assert.IsTrue(WPWPMe.lblusername.Text.Contains(username));
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
                        Assert.IsTrue(WPMe.alertSave.Displayed);

                        ///Assertion for saved records
                        ///
                        Assert.IsTrue(WPMe.txtFirstName.GetAttribute("value").Contains(firstname));
                        Assert.IsTrue(WPMe.txtLastName.GetAttribute("value").Contains(lastname));
                        Assert.IsTrue(WPMe.txtDescription.GetAttribute("value").Contains(description));

                        break;

                    case "delete":
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                        //WPMe.txtFirstName.Clear();
                        WPMe.txtFirstName.SendKeys(Keys.Control + "a" + Keys.Delete);
                        Thread.Sleep(1000);

                        //wAIT().Until(ExpectedConditions.ElementToBeClickable(WPMe.btnSaveProfile));
                        WPMe.txtLastName.Clear();
                        WPMe.txtLastName.SendKeys(Keys.Control + "a" + Keys.Delete);
                        Thread.Sleep(1000);

//                        wAIT().Until(ExpectedConditions.ElementToBeClickable(WPMe.btnSaveProfile));
                    //    WPMe.txtDescription.Clear();
                        WPMe.txtDescription.SendKeys(Keys.Control + "a" + Keys.Delete);
                        Thread.Sleep(1000);

                        WPMe.btnSaveProfile.Click();

                        //wAIT().Until(ExpectedConditions.ElementToBeClickable(WPMe.btnAddSite));
                        Thread.Sleep(2000);

                        Assert.IsTrue(WPMe.alertSave.Displayed);

                        ///Assertion for saved records
                        Assert.IsTrue(WPMe.txtFirstName.GetAttribute("value").Contains(firstname));
                        Assert.IsTrue(WPMe.txtLastName.GetAttribute("value").Contains(lastname));
                        Assert.IsFalse(WPMe.txtDescription.GetAttribute("value").Contains(description));

                        break;
                }
            }
            catch (System.Exception e)
            {
                extest.Log(Status.Pass, MethodBase.GetCurrentMethod().Name + " -- FAILED");

                throw;
            }

        }

        [Category("USERPROFILE")]
        [Author("RudraPatel")]
        public void AddProfileLinksSITE()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var WPMe = new WPMe(driver);
            js.ExecuteScript("window.scrollBy(0,1000)");
            WPMe.btnAdd.Click();
            Thread.Sleep(1000);

            WPMe.lnkAddWPSite.Click();                    
            Assert.IsTrue(WPMe.chkAddSitecheckbox.Displayed);
            Assert.IsFalse(WPMe.btnAddSites.Enabled);

            WPMe.chkAddSitecheckbox.Click();
            Assert.IsTrue(WPMe.btnAddSite.Enabled);
            WPMe.btnCancel.Click();
        }

        [Category("USERPROFILE")]
        [Author("RudraPatel")]
        [TestCase("invalidURL","Testurl","Test")]
        [TestCase("invalidURL", " ", " ")]
        [TestCase("invalidURL", "Testurl.com", "Test")]
        [TestCase("validURL", "https://Testurl.com", "Test")]
        [TestCase("validURL", "https://Testurl.org", "Test")]
        [TestCase("validURL", "https://Testurl.org", "        ")]
        public void AddProfileURL(string urltype, string urlstring, string urldescription)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var WPMe = new WPMe(driver);
            js.ExecuteScript("window.scrollBy(0,1000)");
            WPMe.btnAdd.Click();
            Thread.Sleep(1000);
            WPMe.lnkAddURL.Click();

            switch (urltype)
            {
                case "invalidURL":
                    WPMe.txtEnterURL.SendKeys(urlstring);
                    WPMe.txtEnterURL.SendKeys(urldescription);
                    Assert.IsFalse(WPMe.btnAddSite.Enabled);
                    Assert.IsTrue(WPMe.btnCancel.Enabled);
                    break;

                case "validURL":
                    Uri uriResult;
                    bool URLresult = Uri.TryCreate(urlstring, UriKind.Absolute, out uriResult)
                        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                    if (URLresult)
                    {
                        if (urldescription is null)
                        {
                            WPMe.txtEnterURL.SendKeys(urlstring);
                            WPMe.txtEnterDescription.SendKeys(urldescription);
                            Assert.IsFalse(WPMe.btnAddSite.Enabled);
                            Assert.IsTrue(WPMe.btnCancel.Enabled);
                        }
                        else if ((urldescription).Trim().Length > 0)
                        {
                            WPMe.txtEnterURL.SendKeys(urlstring);
                            WPMe.txtEnterDescription.SendKeys(urldescription);
                            Assert.IsTrue(WPMe.btnAddSite.Enabled);
                        }
                    }
                    else
                    {
                        WPMe.txtEnterURL.SendKeys(urlstring);
                        WPMe.txtEnterDescription.SendKeys(urldescription);
                        Assert.IsFalse(WPMe.btnAddSite.Enabled);
                        Assert.IsTrue(WPMe.btnCancel.Enabled);
                    }
                    break;
            }
        }
        [Test]
        public void Yourprofilelink()
        {
            var WPMe = new WPMe(driver);
            WPMe.ayourprofile.Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            var newtab = driver.Title;
            Assert.IsTrue(newtab.Contains("rudrapatel32 - Gravatar Profile"));
            driver.SwitchTo().Window(driver.WindowHandles[0]);

        }
        [Test]
        public void GravatarHoverBoards()
        {
            var WPMe = new WPMe(driver);
            WPMe.agravatar.Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            var newtab = driver.Title;

            Assert.IsTrue(newtab.Contains("Gravatar - Globally Recognized Avatars"));
            driver.SwitchTo().Window(driver.WindowHandles[0]);

        }
    }
}
