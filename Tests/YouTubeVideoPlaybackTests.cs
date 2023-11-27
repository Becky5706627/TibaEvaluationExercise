using NUnit.Framework;
using TibaEvaluationExercise.Config;
using TibaEvaluationExercise.Pages;
using TibaEvaluationExercise.Utilities;

namespace TibaEvaluationExercise.Tests
{
    [TestFixture]
    public class YouTubeVideoPlaybackTests : BaseTest
    {
        private YoutubeMainPage youtubeMainPage;
        private Dictionary<string, string> testData;

        [OneTimeSetUp]
        public void SetUpBeforeClass()
        {
            Driver.Navigate().GoToUrl(Config.Url);
            youtubeMainPage = new YoutubeMainPage(Driver);
            testData = ConfigLoader.LoadTestData(Config.Language);
        }

        [Test]
        public void SearchAndPlayVideoWithFiltersAndHandleAds()
        {
            var searchResultsPage = youtubeMainPage.Header.Search(testData["searchQuery"]);
            searchResultsPage.OpenFilter();
            searchResultsPage.Filter.ApplyFilter(testData["filterType"], testData["filterTypeBy"]);
            searchResultsPage.OpenFilter();
            searchResultsPage.Filter.ApplyFilter(testData["filterSort"], testData["filterSortBy"]);
            var video = searchResultsPage.SelectVideoFromResultsByTitle(testData["videoTitle"]);
            video.SkipAdIfExists();
            video.ExpandVideoDescription();
            TestAssert.AssertEqual(testData["artistsName"], video.GetArtistsNameFromVideoDescription());
        }
    }
}
