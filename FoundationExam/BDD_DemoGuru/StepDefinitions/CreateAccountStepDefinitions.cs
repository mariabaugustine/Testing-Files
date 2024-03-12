//using AventStack.ExtentReports.Model;
using BDD_DemoGuru.Hooks;
using BDD_DemoGuru.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Drawing.Text;
using TechTalk.SpecFlow;

namespace BDD_DemoGuru.StepDefinitions
{
    [Binding]
    public class CreateAccountStepDefinitions:CoreCodes
    {
        IWebDriver driver = AllHooks.driver;
        [When(@"User clicks on the registration link")]
        public void WhenUserClicksOnTheRegistrationLink()
        {
            AllHooks.test = AllHooks.extent.CreateTest("Create Account Test");
            IWebElement Registration = driver.FindElement(By.LinkText("REGISTER"));
            Registration.Click();
            Log.Information("User Click on registration button");
            AllHooks.test.Info("user click on registration button");
            
            
        }

        [Then(@"Create account page is loaded with url contains register")]
        public void ThenCreateAccountPageIsLoadedWithUrlContainsRegister()
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("register"));
                Log.Information("user successfully click on registration link");
                AllHooks.test.Info("user successfully click on registration link");
                var screenshot= ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                AllHooks.test.AddScreenCaptureFromBase64String(screenshot);

            }
            catch(AssertionException ex)
            {
                Log.Error($"Test failed for Clicking on Register Button. \n Exception: {ex.Message}");
                var ss = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                AllHooks.test.AddScreenCaptureFromBase64String(ss);
                Log.Information("Registration link clicking failed");
                AllHooks.test.Info("Registration link clicking Failed");
            }


        }
        [When(@"user types'([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)'")]
        public void WhenUserTypes(string fname, string lname, string phone, string email, string city, string state, string postalcode, string address, string username, string password, string confirmpassword)
        {
            IWebElement FirstName = driver.FindElement(By.Name("firstName"));
            FirstName.SendKeys(fname);
            Log.Information("User Type First name");
            AllHooks.test.Info("User Type First name");
            IWebElement LastName = driver.FindElement(By.Name("lastName"));
            LastName.SendKeys(lname);
            Log.Information("User Type Last name");
            AllHooks.test.Info("User Type Last name");
            IWebElement Phone = driver.FindElement(By.Name("phone"));
            Phone.SendKeys(phone);
            Log.Information("User Type Phonenumber");
            AllHooks.test.Info("User Type Phonenumber");
            IWebElement Email = driver.FindElement(By.Name("userName"));
            Email.SendKeys(email);
            Log.Information("User Type Email");
            AllHooks.test.Info("User Type Password");
            IWebElement Addres = driver.FindElement(By.Name("address1"));
            Addres.SendKeys(address);
            Log.Information("User type address");
            AllHooks.test.Info("User type address");
            IWebElement City = driver.FindElement(By.Name("city"));
            City.SendKeys(city);
            Log.Information("User type city");
            AllHooks.test.Info("User type city");
            IWebElement State=driver.FindElement(By.Name("state"));
            State.SendKeys(state);
            Log.Information("User type state");
            AllHooks.test.Info("User type State");
            IWebElement PostalCode = driver.FindElement(By.Name("postalCode"));
            PostalCode.SendKeys(postalcode);
            Log.Information("User type postalcode");
            AllHooks.test.Info("User type postalcode");
            IWebElement UserName=driver.FindElement(By.Name("email"));
            UserName.SendKeys(username);
            Log.Information("User type username");
            AllHooks.test.Info("User type username");
            IWebElement Password=driver.FindElement(By.Name("password"));
            Password.SendKeys(password);
            Log.Information("User type password");
            AllHooks.test.Info("User type password");
            IWebElement country = driver.FindElement(By.XPath("//select/option[@value='INDIA']"));
            IWebElement ConfirmPassword = driver.FindElement(By.Name("confirmPassword"));
            ConfirmPassword.SendKeys(confirmpassword);
            Log.Information("User type confirmpassword");
            AllHooks.test.Info("User type confirmpassword");
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            AllHooks.test.AddScreenCaptureFromBase64String(screenshot);
        }
        [When(@"User clicks on submit button")]
        public void WhenUserClicksOnSubmitButton()
        {
            TakeScreenShot(driver);
            IWebElement submit = driver.FindElement(By.Name("submit"));
            submit.Click();
            Log.Information("User clicked submit buuton");
            AllHooks.test.Info("User clicked submit button");
        }
        [Then(@"User navigate to new page with url conains register_sucess")]
        public void ThenUserNavigateToNewPageWithUrlConainsRegister_Sucess()
        {
            try
            {
                TakeScreenShot(driver);
                Assert.That(driver.Url.Contains("register_sucess"));
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                AllHooks.test.AddScreenCaptureFromBase64String(screenshot);
                Log.Information("User registered successfully");
                AllHooks.test.Info("User registered successfully");
                AllHooks.test.Pass("Create Account Test");
            }
            catch(AssertionException ex)
            {
                LogTestResult("Create Account Test", " Test Failed", ex.Message);
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                AllHooks.test.AddScreenCaptureFromBase64String(screenshot);
                AllHooks.test.Fail("Create Account Test");
                AllHooks.test.Info("Create Account Test Failed");
            }
        }






    }
}
