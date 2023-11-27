# Evaluation Exercise

## Introduction
This project is a Selenium-based test automation framework developed in C#.
It is designed to automate a series of actions on YouTube, primarily focusing on searching for a specific video,
handling filters, and extracting information from video metadata.

## Prerequisites
- .NET Core SDK (version specified in the project)
- A compatible web browser (e.g., Chrome, Firefox) and its corresponding WebDriver
- Visual Studio or a similar IDE that supports C# projects

## Setup
1. Clone the project from the repository:
2. git clone https://github.com/Becky5706627/TibaEvaluationExercise.git
3. Open the solution file (`*.sln`) in Visual Studio.
4. Restore NuGet packages to resolve any dependencies.

## Running the Tests
To execute the tests, follow these steps:
1. Open the Test Explorer in Visual Studio.
2. Build the solution to compile the test cases.
3. Run the tests via the Test Explorer. You can run all tests or select specific ones.

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