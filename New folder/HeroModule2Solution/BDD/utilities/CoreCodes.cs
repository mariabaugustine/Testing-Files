using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.utilities
{
    public class CoreCodes
    {
        public static void TakeScreenSot(IWebDriver driver)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            Screenshot ss = screenshot.GetScreenshot();
            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            string filePth = currentDirectory + "/Screenshot/screenshot_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") +
                ".png";
            ss.SaveAsFile(filePth);
        }
        public static void LogTestResult(string testName, string result, string errrorMessage = null)

        {
            Log.Information(result);
            if (errrorMessage == null)
            {
                Log.Information(testName + "passed");
            }
            else
            {
                Log.Information($"Test failed for {testName}\nException:{errrorMessage}");
            }
        }
    }
}
