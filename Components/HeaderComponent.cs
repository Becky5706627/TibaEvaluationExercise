using OpenQA.Selenium;
using TibaEvaluationExercise.Pages;

namespace TibaEvaluationExercise.Components
{

    public class HeaderComponent : BasePage
    {
        private By searchFieldLocator = By.CssSelector("input#search");
        private By searchButtonLocator = By.Id("search-icon-legacy");

        public HeaderComponent(IWebDriver driver) : base(driver) { }

        public YoutubeSearchResultsPage Search(string text)
        {
            EnterText(searchFieldLocator, text, 5);
            Click(searchButtonLocator, 5);
            return new YoutubeSearchResultsPage(Driver);
        }
    }
}
