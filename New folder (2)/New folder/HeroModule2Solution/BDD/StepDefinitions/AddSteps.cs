using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using SpecFlowProject1.utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class AddSteps : CoreCodes
    {
        IWebDriver? driver = Hooks.Hooks1.driver;

        [Given(@"User will be on the home page")]
        public void GivenUserWillBeOnTheHomePage()
        {
            driver.Url = "https://thinking-tester-contact-list.herokuapp.com/";
            driver.Manage().Window.Maximize();
        }

        [When(@"User login using valid '([^']*)' and '([^']*)'")]
        public void WhenUserLoginUsingValidAnd(string username, string password)
        {
            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys(username);
            IWebElement password1 = driver.FindElement(By.Id("password"));
            password1.SendKeys(password);
            IWebElement submitbutton = driver.FindElement(By.Id("submit"));
            submitbutton.Click();
        }

        [Then(@"Next page is loaded with url containing contactlist")]
        public void ThenNextPageIsLoadedWithUrlContainingContactlist()
        {
            TakeScreenSot(driver);
            Log.Information("User login to the system");
            try
            {
                Assert.That(driver.Url.Contains("contactList"));
                LogTestResult("Login test", "Login Test Success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Login Test", "Test Failed", ex.Message);
            }

        }

        [When(@"User clich on AddnewContact button")]
        public void WhenUserClichOnAddnewContactButton()
        {
            IWebElement submit = driver.FindElement(By.Id("add-contact"));
            submit.Click();
        }

        [Then(@"The resulting page is loaded with url containing addcontact")]
        public void ThenTheResultingPageIsLoadedWithUrlContainingAddcontact()
        {
            try
            {
                Assert.That(driver.Url.Contains("addContact"));
                LogTestResult("Add new contact test", "Test Success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Add new contact Test", "Test Failed", ex.Message);
            }
        }

        [When(@"User fill the fields of '([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)'")]
        public void WhenUserFillTheFieldsOf(string firstname, string lastname, string dob, string city, string postalcode, string address1, string address2, string phone, string country, string state, string email)
        {
            IWebElement? firstnamee = driver.FindElement(By.Id("firstName"));
            firstnamee.SendKeys(firstname);
            IWebElement? lastnamee = driver.FindElement(By.Id("lastname"));
            lastnamee.SendKeys(lastname);
            IWebElement dob1 = driver.FindElement(By.Id("birthdate"));
            dob1.SendKeys(dob);
            IWebElement email1 = driver.FindElement(By.Id("email"));
            email1.SendKeys(email);
            IWebElement phone1 = driver.FindElement(By.Id("phone"));
            phone1.SendKeys(phone);
            IWebElement street11 = driver.FindElement(By.Id("steet1"));
            street11.SendKeys(address1);
            IWebElement street2 = driver.FindElement(By.Id("street2"));
            street2.SendKeys(address2);
            IWebElement city1 = driver.FindElement(By.Id("city"));
            city1.SendKeys(city);
            IWebElement country1 = driver.FindElement(By.Id("country"));
            country1.SendKeys(country);
            IWebElement postalcode1 = driver.FindElement(By.Id("postalCode"));
            postalcode1.SendKeys(postalcode);
            IWebElement provision = driver.FindElement(By.Id("stateProvince"));
            provision.SendKeys(state);


        }

        [When(@"User will click on the submit button")]
        public void WhenUserWillClickOnTheSubmitButton()
        {
            IWebElement submit = driver.FindElement(By.Id("submit"));
            submit.Click();
        }
    }
}
