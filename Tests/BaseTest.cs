using NUnit.Framework;
using TibaEvaluationExercise.Config;
using TibaEvaluationExercise.Managers;
using OpenQA.Selenium;
using TibaEvaluationExercise.Utilities;

namespace TibaEvaluationExercise.Tests
{


    public abstract class BaseTest
    {
        protected IWebDriver Driver;
        protected TestConfig Config;

        [OneTimeSetUp]
        public void BaseSetUp()
        {
            Config = ConfigLoader.LoadTestConfig();

            Driver = BrowserDriverManager.Instance.GetDriver(Config.Browser);
            Logger.InitializeSession();
        }

        [OneTimeTearDown]
        public void BaseTearDown()
        {
            BrowserDriverManager.Instance.CloseDriver();
        }

    }
}