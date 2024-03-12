using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Serilog;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        public static IWebDriver? driver;

        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();

            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            string path = currentDirectory + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                //.WriteTo.Console()
                .WriteTo.File(path, rollingInterval: RollingInterval.Day).CreateLogger();

        }
        [AfterFeature]
        public static void CleanUp()
        {
            driver.Quit();

        }

    }
}