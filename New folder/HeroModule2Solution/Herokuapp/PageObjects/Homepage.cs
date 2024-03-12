using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.Network;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herokuapp.PageObjects
{
    internal class Homepage
    {
        IWebDriver driver;

        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How =How.Id,Using = "email")]
        private IWebElement Email{ get; set; }
        [FindsBy(How=How.Id,Using = "password")]
        private IWebElement Password { get; set; }
        [FindsBy(How=How.Id,Using = "submit")]
        private IWebElement Submit { get; set; }
       
        public void Login(string username, string password)
        {
            Email.SendKeys(username);
            Password.SendKeys(password);
            
        }
        public CreateContact ClickLogin()
        {
            Submit.Click();
            return new CreateContact(driver);
        }








    }
}
