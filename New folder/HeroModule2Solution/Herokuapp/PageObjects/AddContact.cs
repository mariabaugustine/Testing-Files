using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herokuapp.PageObjects
{
    internal class AddContact
    {
        IWebDriver driver;

        public AddContact(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How=How.Id,Using = "firstName")]
        private IWebElement FirstName { get; set; }
        [FindsBy(How=How.XPath,Using = "//*[@id=\"lastName\"]")]
        private IWebElement LastName { get; set; }
        [FindsBy(How=How.Id,Using = "birthdate")]
        private IWebElement Dob { get; set; }
        [FindsBy(How=How.Id,Using ="email")]
        private IWebElement Email { get; set; }
        [FindsBy(How =How.Id,Using ="phone")]
        private IWebElement Phone { get; set; }
        [FindsBy(How =How.Id,Using ="street1")]
        private IWebElement Street1 {  get; set; }
        [FindsBy(How =How.Id,Using ="street2")]
        private IWebElement Street2 {  get; set; }
        [FindsBy(How =How.Id,Using ="city")]
        private IWebElement City { get; set; }
        [FindsBy(How =How.Id,Using = "stateProvince")]
        private IWebElement State { get; set; }
        [FindsBy(How =How.Id,Using = "postalCode")]
        private IWebElement PostalCode { get; set; }
        [FindsBy(How=How.Id,Using = "country")]
        private IWebElement Country { get; set; }
        [FindsBy(How =How.Id,Using = "submit")]
        private IWebElement Submit { get; set; }
        public void AddUser(string firstname, string lastname,string dob,string email,string phone,string street1,string street2,
            string city,string state,string postalCode,string country)
        {
            FirstName.SendKeys(firstname);
            LastName.SendKeys(lastname);
            Email.SendKeys(email);
            Dob.SendKeys(dob);
            Phone.SendKeys(phone);
            Street1.SendKeys(street1);
            Street2.SendKeys(street2);
            City.SendKeys(city);
            State.SendKeys(state);
            PostalCode.SendKeys(postalCode);
            Country.SendKeys(country);
        }
        public LastPage clickSubmit()
        {
            Submit.Click();
            return new LastPage(driver);
        }

    }
}
