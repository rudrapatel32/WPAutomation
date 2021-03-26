using System;
using System.Collections.Generic;
using System.Text;
using DriverTestMethods.BaseClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DriverTestMethods.Webelements
{
    class Button : BaseTestClass
    {
        public string id;

        public Button(string id)
        {
            this.id = id;
        }
  
        public void FindElement()
        {

        }
    
        public void Click(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }
    }
}
