using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Serilog;
using TechTalk.SpecFlow;

namespace BDD_herokuapp.Hooks
{
    [Binding]
    public sealed class AllHooks
    {
        public static IWebDriver driver;
        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();
        }
        [BeforeFeature]
        public static void LogFileCreation()
        {
            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            string path = currentDirectory + "/Screenshot/screenshot_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(path, rollingInterval: RollingInterval.Day).CreateLogger();

        }
        [AfterFeature]
        public static void CleanUp()
        {
            driver.Quit();

        }
        [AfterScenario]
        public static void NavigateToHomePage()
        {
            driver.Navigate().GoToUrl("https://www.bunnycart.com/");
        }
    }
}