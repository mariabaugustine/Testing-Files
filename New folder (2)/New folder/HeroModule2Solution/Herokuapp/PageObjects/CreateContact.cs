using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herokuapp.PageObjects
{
    internal class CreateContact
    {
        IWebDriver driver;

        public CreateContact(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.Id,Using = "add-contact")]
        private IWebElement addnewContact;
        [FindsBy(How =How.XPath,Using = "//*[@id=\"myTable\"]/tr[1]/td[4]")]
        private IWebElement selectContact;

        public AddContact ClickAddContact()
        {
            addnewContact.Click();
            return new AddContact(driver);
        }
        public Details Select()
        {
            selectContact.Click();
            return new Details(driver);
        }


    }
}
