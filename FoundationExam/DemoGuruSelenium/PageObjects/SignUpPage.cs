using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGuruSelenium.PageObjects
{
    internal class SignUpPage
    {
        IWebDriver driver;

        public SignUpPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //Different selecters are used
        [FindsBy(How =How.Name,Using = "firstName")]
        private IWebElement FirstName { get; set; }
        [FindsBy(How=How.Name,Using ="lastName")]
        private IWebElement LastName { get; set; }
        [FindsBy(How=How.Name,Using="phone")]
        private IWebElement Phone { get; set; }
        [FindsBy(How=How.Id,Using = "userName")]
        private IWebElement Email { get; set; }
        [FindsBy(How =How.Name,Using = "address1")]
        private IWebElement Address{ get; set; }
        [FindsBy(How =How.Name,Using ="city")]
        private IWebElement City { get; set; }
        [FindsBy(How=How.Name,Using = "postalCode")]
        private IWebElement PostalCode { get; set; }
        [FindsBy(How = How.Name, Using = "state")]
        private IWebElement State {  get; set; }
        [FindsBy(How =How.XPath,Using = "//select/option[@value='INDIA']")]
        private IWebElement Country { get; set; }
        [FindsBy(How =How.Id,Using = "email")]
        private IWebElement UserName{ get; set;}
        [FindsBy(How =How.Name,Using = "password")]
        private IWebElement Password { get; set; }
        [FindsBy(How =How.Name,Using = "confirmPassword")]
        private IWebElement ConfirmPassword { get; set; }
        [FindsBy(How =How.Name,Using = "submit")]
        private IWebElement SubmitButton { get; set; }

        public void SubmitForm(string fname, string lname, string phone, string email, string address, string city,
            string postalcode, string state, string username, string password, string confirmpassword)
        {
            FirstName.SendKeys(fname);
            LastName.SendKeys(lname);
            Phone.SendKeys(phone);
            Email.SendKeys(email);
            Address.SendKeys(address);
            City.SendKeys(city);
            PostalCode.SendKeys(postalcode);
            State.SendKeys(state);
            UserName.SendKeys(username);
            Password.SendKeys(password);
            ConfirmPassword.SendKeys(confirmpassword);
            Country.Click();


        }
        public SignIn ClickSubmitButton()
        {
            SubmitButton.Click();
            return new SignIn(driver);
        }

    }
}
