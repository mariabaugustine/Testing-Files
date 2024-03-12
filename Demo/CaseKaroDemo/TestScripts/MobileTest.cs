using CaseKaroDemo.PageObjects;
using CaseKaroDemo.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseKaroDemo.TestScripts
{
    internal class MobileTest : CoreCodes
    {
        [Test]
        [TestCase("apple")]
        public void TestMobile(string name)
        {
           string? currDir = Directory.GetParent(@"../../../")?.FullName;
           string? logfilepath = currDir + "/Logs/log_" +
               DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
           Log.Logger = new LoggerConfiguration()
          .WriteTo.Console()
          .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
          .CreateLogger();
            CasekaroHomePage homePage = new CasekaroHomePage(driver);
            if (!driver.Url.Contains("https://casekaro.com/"))
            {
                driver.Navigate().GoToUrl("https://casekaro.com/");
            }
            Log.Information("Mobile Covers Clicked");
            var search = homePage.ClickMobile();
           
            try
            {
                TakeScreenShot();
                Assert.That(driver.Url.Contains("mobile-back-covers"));
                Log.Information("Test passed for clicking mobile cover");
                test=extent.CreateTest("Click Mobile Cover");
                test.Pass("Clicked Mobile Cover successfully");
            }
            catch(AssertionException ex)
            {
                Log.Error($"Test failed{ex.Message}");
                test = extent.CreateTest("Click Mobile Cover");
                test.Fail("Mobile cover clicking failed");

            }
            var filter=search.TypeSearch(name);
            Thread.Sleep(3000);
            filter.ClickFirst();
            List<string>nextWindow=driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextWindow[1]);
            Thread.Sleep(3000);
            FilterPageResult filterPage = new FilterPageResult(driver);
            var result=filterPage.ClickFirstProduct();
            Thread.Sleep(3000);

            
        }


    }

}

