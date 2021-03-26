using DriverTestMethods.BaseClass;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;


namespace DriverTestMethods.WPPages
{
    public class WPLoginPage
    {
        IWebDriver driver;
        public WPLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //[FindsBy(How=How.ClassName,Using= "form-label")]
        public IWebElement lblFormHeader => driver.FindElement(By.CssSelector("*[class='login__form-header']"));
        public IWebElement lblEnteruserwarn => driver.FindElement(By.CssSelector("*[class='gridicon gridicons-notice-outline']"));

        //[FindsBy(How = How.ClassName, Using = "login__form-header")]
        public IWebElement lblEmailAddUserr=> driver.FindElement(By.XPath("//button[text()='Continue']"));

        //[FindsBy(How = How.Id, Using = "usernameOrEmail")]
        public IWebElement txtUserNameOrEmail =>driver.FindElement(By.Id("usernameOrEmail"));
        //[FindsBy(How = How.XPath, Using = "//span[text()='Please enter a username or email address.']")]
        public IWebElement lblWarning => driver.FindElement(By.XPath("//button[text()='Continue']"));
        public IWebElement btnContinue => driver.FindElement(By.XPath("//button[text()='Continue']"));
        public IWebElement lblInvalidUserWarning => driver.FindElement(By.XPath("//span[text()='User does not exist.']"));
        public IWebElement lblOopsPasswordWarning => driver.FindElement(By.XPath("//span[text()='Oops, that's not the right password. Please try again!']"));
        //PPP
        public IWebElement btnLogin => driver.FindElement(By.CssSelector("*[class='login__form-action']"));
        public IWebElement txtPassword => driver.FindElement(By.Id("password"));
    }
}
