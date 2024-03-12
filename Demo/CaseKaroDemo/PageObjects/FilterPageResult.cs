using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseKaroDemo.PageObjects
{
    internal class FilterPageResult
    {
        IWebDriver driver;

        public FilterPageResult(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.XPath,Using = "//*[@id=\"MainContent\"]/div/div/div/div[2]/div[2]/div[1]/a")]
        private IWebElement FirstProduct {  get; set; }
        public Result ClickFirstProduct()
        {
        FirstProduct.Click();
            return new Result(driver);
        }
    }
}
