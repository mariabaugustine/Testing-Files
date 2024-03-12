using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herokuapp.PageObjects
{
    internal class Details
    {
        IWebDriver driver;

        public Details(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How=How.Id,Using = "delete")]
        private IWebElement DeleteContact {  get; set; }

        public  CreateContact clickDelete()
        {
            DeleteContact.Click();
            return new CreateContact(driver);
        }
    }
}
