using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseKaroDemo.PageObjects
{
    internal class SearchResult
    {
        IWebDriver driver;

        public SearchResult(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.Id,Using = "search-bar-cover-page")]
        private IWebElement SearchBox { get; set; }
        public FilterPage TypeSearch(string input)
        {
            SearchBox.SendKeys(input);
            SearchBox.SendKeys(Keys.Enter);
            return new FilterPage(driver);
        }
    }
}
