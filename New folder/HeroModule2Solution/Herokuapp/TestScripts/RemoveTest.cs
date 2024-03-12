using Herokuapp.PageObjects;
using Herokuapp.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herokuapp.TestScripts
{
    internal class RemoveTest:CoreCodes
    {
        [Test]
        public void  RemoveUserTest()
        {
            List<SignIn> signin;
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
            Homepage homepage=new Homepage(driver);
            string excelFilePath = currentDirectory + "/TestData/InputData.xlsx";
            string sheetname = "signup";
            signin = ExcelUtilities.ReadExcelData(excelFilePath, sheetname);
            Log.Information("Input fields filling started");
            foreach (var sheet in signin)
            {
                string? email = sheet.Email;
                string? password = sheet.Password;
                homepage.Login(email, password);
            }
            Log.Information("All the fields are filled");
            TakeScreenShot();
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
            
            var details=create.Select();
            TakeScreenShot();
            try
            {
                Assert.That(driver.Url.Contains("contactDetails"));
                Log.Information("Test Passed for selecting first user");
                extent.CreateTest("selecting user");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for selecting user{ex.Message}");
                test = extent.CreateTest("selecting user");
                test.Fail("select user failed");
            }


            //details.clickDelete();
            TakeScreenShot() ;
            






        }
    }
}
