using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGuruSelenium.PageObjects
{
    internal class SignIn
    {
        IWebDriver driver;

        public SignIn(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.LinkText,Using = "Flights")]
        private IWebElement SignOff {  get; set; }
        public  Homepage ClickSignOff()
        {
            SignOff.Click();
            return new Homepage(driver);
        }
    }
}
