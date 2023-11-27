using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace TibaEvaluationExercise.Managers
{

    public class BrowserDriverManager
    {
        private static BrowserDriverManager instance = null;
        private static IWebDriver driver = null;

        private BrowserDriverManager() { }

        public static BrowserDriverManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BrowserDriverManager();
                }
                return instance;
            }
        }
        public IWebDriver GetDriver(string browser)
        {
            if (driver == null)
            {
                switch (browser.ToLower())
                {
                    case "chrome":
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                    case "firefox":
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        break;
                    default:
                        throw new ArgumentException("Unsupported browser type");
                }
            }
            return driver;
        }

        public void CloseDriver()
        {
            driver?.Quit();
            driver = null;
        }
    }
}