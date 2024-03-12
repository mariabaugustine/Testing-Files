using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using Serilog;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BDD_DemoGuru.Utilities;

namespace BDD_DemoGuru.Hooks
{
    [Binding]
    public sealed class AllHooks
    {
        public static IWebDriver? driver;
        public static ExtentReports extent;
        static ExtentSparkReporter sparkReporter;
        public static ExtentTest test;


        [BeforeFeature]
        public static void InitializeBrowser()
        {
            //ReadConfigFile.ReadConfigSettings();
            ReadConfigSettings.ReadConfigurationSettings();
            string currDir = Directory.GetParent(@"../../../").FullName;

            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currDir + "/ExtentReports/extent-report"
                + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");
            extent.AttachReporter(sparkReporter);


            if (ReadConfigSettings.properties["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (ReadConfigSettings.properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }

            driver.Url = ReadConfigSettings.properties["baseUrl"];
            driver.Manage().Window.Maximize();
        }
        [BeforeScenario]
        public static void CreateLogFile()
        {
            string? curDir = Directory.GetParent(@"../../../").FullName;
            string? fileName = curDir + "/Logs/log_" +
                DateTime.Now.ToString("ddMMyyyy-hhmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(fileName, rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }

        [AfterScenario]
        public static void NavigateBack()
        {
            driver.Navigate().GoToUrl(ReadConfigSettings.properties["baseUrl"]);
            Log.CloseAndFlush();
        }
        [AfterFeature]
        public static void CloseBrowser()
        {
            driver?.Close();
            extent.Flush();
        }
    }
}