using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseKaroDemo.PageObjects
{
    internal class CasekaroHomePage
    {
        IWebDriver driver;

        public CasekaroHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.LinkText,Using = "Mobile Covers")]
        private IWebElement Mobile { get; set; }
        public SearchResult ClickMobile()
        {
            Mobile.Click();
            return new SearchResult(driver);
        }
        [FindsBy(How=How.XPath,Using = "//button/span[text()='Search']")]
        private IWebElement SearchButton { get; set; }
        public void ClickSearchButton()
        {
            SearchButton.Click();
            Thread.Sleep(3000);
        }
        
        [FindsBy(How=How.XPath,Using = "(//form[@role='search']/input[@name='q'])[position()=1]")]
        private IWebElement InputBox { get; set; }

        public NewPage ClickInputBox(string input)
        {
            InputBox.SendKeys(input);
            Thread.Sleep(1000);
            InputBox.SendKeys(Keys.Enter);
            return new NewPage(driver);
        }
    }
}
