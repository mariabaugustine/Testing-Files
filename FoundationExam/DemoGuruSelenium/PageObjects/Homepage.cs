using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGuruSelenium.PageObjects
{
    internal class Homepage
    {
        IWebDriver driver;

        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.LinkText,Using = "REGISTER")]
        private IWebElement Register {  get; set; }
        public SignUpPage ClickRegister()
        {
            Register.Click();
            return new SignUpPage(driver);
        }
    }
}
