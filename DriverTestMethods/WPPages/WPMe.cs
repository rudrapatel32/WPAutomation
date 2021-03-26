using DriverTestMethods.BaseClass;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace DriverTestMethods.WPPages
{
    class WPMe
    {
        IWebDriver driver;
        public WPMe(IWebDriver driver)
        {
            this.driver = driver;
        }
        //[FindsBy(How=How.ClassName,Using= "form-label")]
        public IWebElement aMySite => driver.FindElement(By.CssSelector("*[class='masterbar__item-content']"));

        public IWebElement btnLogOut => driver.FindElement(By.CssSelector("*[class='button sidebar__me-signout-button is-compact']"));

        public IWebElement txtFirstName => driver.FindElement(By.Id("first_name"));
        public IWebElement txtLastName => driver.FindElement(By.Id("last_name"));
        public IWebElement txtDisplayName => driver.FindElement(By.Id("display_name"));
        public IWebElement txtDescription => driver.FindElement(By.Id("description"));

        public IWebElement aMyProfile => driver.FindElement(By.CssSelector("*[class='sidebar__menu-link-text menu-link-text']"));

        public IWebElement btnSaveProfile => driver.FindElement(By.CssSelector("*[class='button form-button is-primary']"));
        public IWebElement alertSave => driver.FindElement(By.CssSelector("*[class='notice__text']"));

        public IWebElement btnAdd => driver.FindElement(By.XPath("//span[text()='Add']"));
        public IWebElement lnkAddWPSite => driver.FindElement(By.XPath("//button[text()='Add WordPress Site']"));
        public IWebElement lnkAddURL => driver.FindElement(By.XPath("//button[text()='Add URL']"));

        public IWebElement lblSiteTitle => driver.FindElement(By.XPath("//div[@class='site__title']"));
        public IWebElement btnAddSite => driver.FindElement(By.XPath("//button[text()='Add Site']"));
        public IWebElement btnCancel => driver.FindElement(By.XPath("//button[text()='Cancel']"));
        public IWebElement chkAddSitecheckbox => driver.FindElement(By.Name("site-191111456"));

        public IWebElement lblDisplaymsg => driver.FindElement(By.XPath("//*[text()='Please enter the URL and description of the site you want to add to your profile.']"));
        public IWebElement txtEnterURL => driver.FindElement(By.XPath("//input[@name='value']"));
        public IWebElement txtEnterDescription => driver.FindElement(By.XPath("//input[@name='title']"));
        ////[FindsBy(How = How.ClassName, Using = "login__form-header")]
        //public IWebElement lblEmailAddUserr => driver.FindElement(By.XPath("//button[text()='Continue']"));

        ////[FindsBy(How = How.Id, Using = "usernameOrEmail")]
        //public IWebElement txtUserNameOrEmail => driver.FindElement(By.XPath("//button[text()='Continue']"));
        ////[FindsBy(How = How.XPath, Using = "//span[text()='Please enter a username or email address.']")]
        //public IWebElement lblWarning => driver.FindElement(By.XPath("//button[text()='Continue']"));
        //public IWebElement btnContinue => driver.FindElement(By.XPath("//button[text()='Continue']"));
        //public IWebElement lblInvalidUserWarning => driver.FindElement(By.XPath("//span[text()='User does not exist.']"));
        //public IWebElement lblOopsPasswordWarning => driver.FindElement(By.XPath("//span[text()='Oops, that's not the right password. Please try again!']"));
        //PPP

    }
}
