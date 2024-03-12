using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseKaroDemo.PageObjects
{
    internal class FilterPage
    {
        IWebDriver driver;

        public FilterPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.XPath,Using = "//*[@id=\"MainContent\"]/div/div/div/div[2]/div[2]/button/a")]
        private IWebElement First {  get; set; }
        public void ClickFirst()
        {
            First.Click();
            Thread.Sleep(1000);
        }
    }
}
