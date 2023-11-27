using OpenQA.Selenium;
using TibaEvaluationExercise.Components;
using TibaEvaluationExercise.Utilities;

namespace TibaEvaluationExercise.Pages
{

    public class YoutubeVideoPage : BasePage
    {
        public HeaderComponent Header { get; private set; }

        private By skipAdPreview = By.CssSelector("span.ytp-ad-preview-container");
        private By skipAdButton = By.CssSelector("button.ytp-ad-skip-button-modern");
        private By moreButton = By.CssSelector("tp-yt-paper-button#expand");
        private By videoArtistsName = By.CssSelector("div.yt-video-attribute-view-model__metadata>.yt-video-attribute-view-model__subtitle");

        public YoutubeVideoPage(IWebDriver driver) : base(driver)
        {
            this.Header = new HeaderComponent(driver);
        }

        public void SkipAdIfExists()
        {
            var skipButtonAdPreview = FindElement(skipAdPreview, 2,true);
            if (skipButtonAdPreview != null && skipButtonAdPreview.Displayed)
            {
                var waitTimeString = GetTextFromElement(skipButtonAdPreview);
                var waitTimeSeconds = StringHelpers.ExtractNumberFromString(waitTimeString);

                if (waitTimeSeconds > 0)
                {
                    WaitForElementToDisappear(skipAdPreview, waitTimeSeconds);
                }
            }

            var skipButton = FindElement(skipAdButton, 2,true);
            if (skipButton != null && skipButton.Displayed)
            {
                ClickElement(skipButton);
            }
        }

        public void ExpandVideoDescription()
        {
            Click(moreButton, 5);

        }

        public String GetArtistsNameFromVideoDescription()
        {
            return GetText(videoArtistsName, 2);    
        }
    }
}
