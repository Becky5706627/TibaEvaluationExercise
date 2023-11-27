using OpenQA.Selenium;
using TibaEvaluationExercise.Components;
using TibaEvaluationExercise.Utilities;


namespace TibaEvaluationExercise.Pages
{

    public class YoutubeSearchResultsPage : BasePage
    {
        public HeaderComponent Header { get; private set; }
        public FilterPopupComponent Filter { get; private set; }

        private By fiterButton = By.CssSelector("#filter-button");
        private By videoResult = By.CssSelector("div>ytd-video-renderer");
        private By title = By.CssSelector("#title-wrapper #video-title");
        private By channelName = By.CssSelector("ytd-channel-name#channel-name");
        private By views = By.CssSelector("#metadata-line .inline-metadata-item");
        public YoutubeSearchResultsPage(IWebDriver driver) : base(driver)
        {
            this.Header = new HeaderComponent(driver);
            this.Filter = new FilterPopupComponent(driver);
        }

        public void OpenFilter()
        {
            Click(fiterButton,10);
        }

        public String GetChannelName(IWebElement video)
        {
            var channelNameElement = FindElementInElement(video, channelName, 60);
            return GetTextFromElement(channelNameElement);
        }

            public YoutubeVideoPage SelectVideoFromResultsByTitle(string videoTitle)
        {
            var videoElements = FindElements(videoResult, 5);
            foreach (var videoElement in videoElements)
            {
                var titleElement = FindElementInElement(videoElement, title, 60);
                Logger.Info($"titleElement: {titleElement.Text}");

                if (titleElement.Text.Equals(videoTitle))
                {
                    Logger.Info($"channelNameElement:{GetChannelName(videoElement)}");
                    titleElement.Click();
                    return new YoutubeVideoPage(Driver); 
                }
            }

            throw new NoSuchElementException($"Video with title '{videoTitle}' not found.");
        }


    }
}