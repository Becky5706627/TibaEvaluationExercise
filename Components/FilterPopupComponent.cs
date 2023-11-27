using OpenQA.Selenium;
using TibaEvaluationExercise.Pages;

namespace TibaEvaluationExercise.Components
{
    public class FilterPopupComponent : BasePage
    {
        private By filterGroupsLocator = By.CssSelector("#options>ytd-search-filter-group-renderer");
        private By filterGroupNameLocator = By.CssSelector("h4 yt-formatted-string");
        private By filterOptionLocator = By.CssSelector("ytd-search-filter-renderer #endpoint #label yt-formatted-string");

        public FilterPopupComponent(IWebDriver driver) : base(driver) { }

        public void ApplyFilter(string groupName, string filterName)
        {
            // Find all filter groups
            var filterGroups = FindElements(filterGroupsLocator, 10);

            // Find the specific filter group
            var filterGroup = filterGroups.FirstOrDefault(group =>
                group.FindElement(filterGroupNameLocator).Text.Contains(groupName));

            if (filterGroup == null)
            {
                Utilities.Logger.Error("$Filter group '{groupName}' not found.");
                throw new NoSuchElementException($"Filter group '{groupName}' not found.");
            }

            // Find all filter options within the group
            var filterOptions = filterGroup.FindElements(filterOptionLocator);

            // Find the specific filter option
            var filterOption = filterOptions.FirstOrDefault(option =>
                option.Text.Contains(filterName));

            if (filterOption == null)
            {
                Utilities.Logger.Error($"Filter option '{filterName}' not found in group '{groupName}'.");
                throw new NoSuchElementException($"Filter option '{filterName}' not found in group '{groupName}'.");
            }

            filterOption.Click();
        }
    }
}