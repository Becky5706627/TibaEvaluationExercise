# TibaEvaluationExercise

This project is an automation framework designed for testing YouTube's video playback functionality using Selenium WebDriver with C#. It includes a custom logger for recording actions and results, and a series of automated tests that simulate user interactions with YouTube.

## Project Structure

The project is structured as follows:

- **`Components`**: Reusable components that interact with web elements, such as headers and filters.
- **`Config`**: Configuration files and classes for managing settings and test data.
- **`logs`**: Log files generated during test executions.
- **`Managers`**: Management of WebDriver instances.
- **`Pages`**: Page objects representing pages within the YouTube application.
- **`TestData`**: Test data in JSON format.
- **`Tests`**: Test cases and suites.
- **`Utilities`**: Helper classes and methods for logging, assertions, etc.
- **`NLog.config`**: Configuration for the NLog logger.
- **`README.md`**: Documentation for the project (this file).

## Prerequisites
- .NET Core SDK (version specified in the project)
- A compatible web browser (e.g., Chrome, Firefox) and its corresponding WebDriver
- Visual Studio or a similar IDE that supports C# projects

## Setup
1. Clone the project from the repository: git clone https://github.com/Becky5706627/TibaEvaluationExercise.git
2. Open the solution file (`*.sln`) in Visual Studio.
3. Restore NuGet packages to resolve any dependencies:
	```sh
	dotnet restore
	```

## Running the Tests
To execute the tests, you can either use the built-in test runner in Visual Studio or run them via the command line: 
```sh
dotnet test
```

## Test Flow Description
The automated test performs the following actions:
1. **Navigate to YouTube**: Opens the YouTube homepage.
2. **Search for Video**: Searches for "I Will Survive - Alien song".
3. **Apply Filters**: Utilizes the 'FILTERS' option to refine search results.
- Sets 'TYPE' as 'Video'.
- Orders results by 'View count'.
4. **Select Video**: Finds and selects the video with the specified URL.
5. **Extract Channel Name**: Retrieves the name of the user/channel that posted the video and logs it.
6. **Play Video**: Initiates video playback.
7. **Handle Ads**: Skips ads if present before the video starts.
8. **Expand Video Description**: Clicks the ‘…more’ button to reveal additional details.
9. **Log Artist's Name**: Extracts and logs the artist’s name from the video description.

## Notes
- The project includes a logger to document key steps and results.
- For detailed explanations of specific code segments, refer to the inline comments within the source files.



