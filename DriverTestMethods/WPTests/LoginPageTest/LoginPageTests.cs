using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DriverTestMethods.BaseClass;
using OpenQA.Selenium;
using DriverTestMethods.WPPages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Configuration;
using System.Reflection;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace DriverTestMethods.WPTests.LoginPageTest
{
    [TestFixture]
    class LoginPageTests : BaseTestClass
    {
        ExtentReports extentrpt = null;
       
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
        //t
        //tttttttttt

        [Test]
        [Category("Smoke")]
        [Author("RudraPatel")]
        [Order(1)]
        public void PageChecks()
        {
            var WP = new WPLoginPage(driver);
            ExtentTest extest = null;
            try
            {
                extest = extentrpt.CreateTest(MethodBase.GetCurrentMethod().Name).Info(MethodBase.GetCurrentMethod().Name + "-- Started Execution");
                Assert.IsTrue(WP.lblFormHeader.Displayed);
                Assert.IsTrue(WP.lblEmailAddUserr.Displayed);
                Assert.IsTrue(WP.txtUserNameOrEmail.Enabled);
                Assert.IsTrue(driver.Title.ToString().Contains("WordPress"));
            }
            catch (System.Exception e)
            {
                extest.Log(Status.Pass, MethodBase.GetCurrentMethod().Name + " -- FAILED");

                throw;
            }

        }
        [Test]
        [Category("Smoke")]
        [Author("RudraPatel")]
        [Order(2)]
        public void PageCheckWarning()
        {
            ExtentTest extest = null;
            var WP = new WPLoginPage(driver);
            var tt = WP.lblWarning.GetAttribute("By");

            try
            {
                extest = extentrpt.CreateTest(MethodBase.GetCurrentMethod().Name).Info(MethodBase.GetCurrentMethod().Name + "-- Started Execution");
                WP.btnContinue.Click();
                wAIT().Until(ExpectedConditions.ElementToBeClickable(WP.btnContinue));
                Assert.IsTrue(WP.lblWarning.Displayed);
            }
            catch (System.Exception e)
            {
                extest.Log(Status.Pass, MethodBase.GetCurrentMethod().Name + " -- FAILED");

                throw;
            }

        }

        [Test]
        public void ValidUserLogin()
        {
            var WP = new WPLoginPage(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //Thread.Sleep(2000);
            WP.txtUserNameOrEmail.Clear();
            Thread.Sleep(1000);
            WP.txtUserNameOrEmail.SendKeys(username);
            wAIT().Until(ExpectedConditions.ElementToBeClickable(WP.btnContinue));

            WP.btnContinue.Click();
            wAIT().Until(ExpectedConditions.ElementToBeClickable(WP.btnLogin));
            WP.txtPassword.Clear();
            WP.txtPassword.SendKeys(pwd);
            WP.btnLogin.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Thread.Sleep(1000);
        }

        [TestCase("rpppeere",userlogin.INVALIDUSER)]
        [TestCase(" ", userlogin.BLANKUSER)]
        [TestCase(" ", userlogin.BLANKPWD)]
        [TestCase("rpppeere", userlogin.INVALIDPWD)]
        public void UserLoginScenario(string teststring,userlogin userlogin)
        {
            var WP = new WPLoginPage(driver);
            switch (userlogin)
            {
                case userlogin.INVALIDUSER:
                    WP.txtUserNameOrEmail.SendKeys(teststring);
                    WP.btnContinue.Click();
                    Assert.IsTrue(WP.lblInvalidUserWarning.Displayed);
                    break;

                case userlogin.BLANKUSER:
                    WP.btnContinue.Click();
                    Thread.Sleep(1000);
                    Assert.IsTrue(WP.lblEnteruserwarn.Displayed);
                    break;

                case userlogin.INVALIDPWD:
                    break;
                case userlogin.BLANKPWD:
                    break;
                default:
                    break;
            }

        }

        public enum userlogin
        {
            INVALIDUSER,
            BLANKUSER,
            INVALIDPWD,
            BLANKPWD
        }

    }
}
