using Herokuapp.PageObjects;
using Herokuapp.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herokuapp.TestScripts
{
    internal class HerokuAppTest:CoreCodes
    {
        [Test]
        
        
        public void CreateAccountAndLogoutTest()
        {
             List<SignIn> SignupList;
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            string? currentDirectory = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currentDirectory + "/Logs/log_" +
            DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
              .WriteTo.Console()
              .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
              .CreateLogger();
           
            if (!driver.Url.Contains("https://thinking-tester-contact-list.herokuapp.com/"))
            {
                driver.Navigate().GoToUrl("https://thinking-tester-contact-list.herokuapp.com/");

            }
            Homepage homepage = new Homepage(driver);
            string excelFilePath = currentDirectory + "/TestData/InputData.xlsx";
            string sheetname = "signup";
            SignupList = ExcelUtilities.ReadExcelData(excelFilePath, sheetname);
            Log.Information("Input fields filling started");
            foreach(var sheet in SignupList) 
            {
                string? email = sheet.Email;
                string? password = sheet.Password;
                homepage.Login(email, password);
            }
            Log.Information("All the fields are filled");
            var create = homepage.ClickLogin();
            Thread.Sleep(1000);
            TakeScreenShot();
            try
            {
                Assert.That(driver.Url.Contains("contactList"));
                Log.Information("Test Passed for Login");
                extent.CreateTest("Login");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for login Account{ex.Message}");
                test = extent.CreateTest("Login Account");
                test.Fail("Login Failed");
            }
            var add=create.ClickAddContact();
            Thread.Sleep(1000);
            try
            {
                Assert.That(driver.Url.Contains("addContact"));
                Log.Information("Test Passed for Clicking Add contact");
                extent.CreateTest("Click AddContact");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for click addcontact{ex.Message}");
                test = extent.CreateTest("Click Add Contact");
                test.Fail("Click Add Contact failed");
            }
            string sheetname2 = "addcontact";
            List<AddData> addList;
            addList=AddUtilities.ReadExcelData(excelFilePath, sheetname2);
            foreach(var sheet in addList) 
            {
                string firstname = sheet.FirstName;
                string lastname = sheet.LastName;
                string dob = "1999-03-30";
                string  email= sheet.Email;
                string phone= sheet.Phone;
                string city= sheet.City;
                string postal = sheet.PostalCode;
                string country = sheet.Country;
                string street1= sheet.Street1;
                string street2= sheet.Street2;
                string state= sheet.State;
                add.AddUser(firstname,lastname,dob,email,phone,street1,street2,city,state,postal,country); 

            }
            TakeScreenShot();
            var last = add.clickSubmit();
            Thread.Sleep(5000);
            try
            {
                Assert.That(driver.Url.Contains("contactList"));
                Log.Information("Test Passed for add user");
                extent.CreateTest("Add Contact");
            }
            catch(AssertionException ex)
            {
                Log.Error($"Test failed for click addcontact{ex.Message}");
                test = extent.CreateTest("Add Contact");
                test.Fail("Adding User failed");
            }


        }
    }
}

