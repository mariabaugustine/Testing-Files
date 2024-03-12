using DemoGuruSelenium.Helpers;
using DemoGuruSelenium.PageObjects;
using DemoGuruSelenium.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGuruSelenium.TestScripts
{
    [TestFixture]
    internal class DemoGuruTests:CoreCodes
    {
        [Test,Category("End to End")]
        [TestCase("Trivandrum")]
        public void CreateAccountTest( string city)
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            
            
            //creating log
            
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            
            
            //waits
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";


            
            
            Homepage homepage = new Homepage(driver);
            if (!driver.Url.Contains("https://demo.guru99.com/test/newtours/"))
            {
                driver.Navigate().GoToUrl("https://demo.guru99.com/test/newtours/");
            }


            //extent reports
            test = extent.CreateTest("Create Account Test");
            Log.Information("Create Account Test Started");
            test.Info("Create Account Test Started");
            


            var createpage = homepage.ClickRegister();
            Log.Information("Clicked on Register Button");
            test.Info("Clicked on Register Button");
            try
            {
                //For taking screenshot
                TakeScreenShot();
                Assert.That(driver.Url.Contains("register"));
                var extentScreenshot= ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                test.AddScreenCaptureFromBase64String(extentScreenshot);
                Log.Information("Register page loaded successfully");
                test.Info("Register page loaded successfully");
            }
            catch(AssertionException ex)
            {
                Log.Error($"Test failed for Clicking on Register Button. \n Exception: {ex.Message}");
                var extentScreenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                test.AddScreenCaptureFromBase64String(extentScreenshot);
                Log.Information("Register page loaded failed");
                test.Info("Register page loaded failed");
            }


            Log.Information("Filling Registration form started");
            test.Info("Filling Registration form started");
            //Reading from excel
            string? excelFilePath =currdir+ "/TestData/InputData.xlsx";
            string sheetName = "SignInDetails";
            List<ExcelData> excelDataList;
            excelDataList=ExcelUtilities.ReadExcelData(excelFilePath, sheetName);
            foreach(var data in excelDataList) 
            {
                string fname = data.FirstName;
                string lname = data.LastName;
                string phone = data.Phone;
                string email = data.Email;
                string address = data.Address;
                string cityy = city;
                string state = data.State;
                string postalCode = data.PostalCode;
                string username = data.UserName;
                string password = data.Password;
                string confirmPassword = data.ConfirmPassword;
                createpage.SubmitForm(fname, lname, phone, email, address, cityy, postalCode, state, username, password, confirmPassword);
                var extentScreenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                test.AddScreenCaptureFromBase64String(extentScreenshot);
                TakeScreenShot();
                
            }


            Log.Information("Form Filled Successfully");
            test.Info("Form filled Successfully");
            fluentWait.Until(d=>d.FindElements(By.Name("submit")));
            var newpage = createpage.ClickSubmitButton();
            try
            {
                TakeScreenShot();
                string value = "https://demo.guru99.com/test/newtours/register_sucess.php";
                Assert.AreEqual(value, driver.Url);
                var extentScreenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                test.AddScreenCaptureFromBase64String(extentScreenshot);
                Log.Information("User Registered Successfully");
                test.Info("User Registered Successfully");
                test.Pass("Registraion Successfull");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for User Registration. \n Exception: {ex.Message}");
                var extentScreenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                test.AddScreenCaptureFromBase64String(extentScreenshot);
                Log.Information("Registration failed");
                test.Info("Registration failed");
                test.Fail("Registration failed");

            }
           
        }
    }
}
