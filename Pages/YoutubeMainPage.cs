using OpenQA.Selenium;
using TibaEvaluationExercise.Components;

namespace TibaEvaluationExercise.Pages
{


    public class YoutubeMainPage : BasePage
    {
        public HeaderComponent Header { get; private set; }

        public YoutubeMainPage(IWebDriver driver) : base(driver)
        {
            this.Header = new HeaderComponent(driver);
        }
    }
}
