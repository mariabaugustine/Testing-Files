using CaseKaroDemo.PageObjects;
using CaseKaroDemo.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseKaroDemo.TestScripts
{
    internal class NewTest:CoreCodes
    {
        [Test]
        public void Test()
        {
            List<ExcelData> InputList;
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currDir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
           .WriteTo.Console()
           .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
           .CreateLogger();
            CasekaroHomePage homePage = new CasekaroHomePage(driver);
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string sheetName = "Sheet1";
            InputList =ExcelUtilities.ReadExcelData(excelFilePath, sheetName);
            IWebElement? element = driver.FindElement(By.XPath("//button/span[text()='Search']"));
            IJavaScriptExecutor? executor = (IJavaScriptExecutor)driver;
            executor?.ExecuteScript("arguments[0].click();", element);
            Thread.Sleep(5000);
            foreach (var cdata in InputList)
            {
                //homePage.ClickSearchButton();
                //Thread.Sleep(3000);
                homePage.ClickInputBox(cdata.Input);
                //Thread.Sleep(10000);
                Thread.Sleep(2000);

            }
        }
    }
}
