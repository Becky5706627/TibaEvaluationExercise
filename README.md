# TibaEvaluationExercise Project Structure

This project is designed for QA Automation tasks using Selenium WebDriver with C#. 
It includes a logger for recording actions and results, and a series of automated tests for the YouTube platform.

## Project Directory Layout

Here's a high-level overview of the project's directory structure:
TibaEvaluationExercise/
|-- Components/
| |-- FilterPopupComponent.cs
| |-- HeaderComponent.cs
|-- Config/
| |-- config.json
| |-- TestConfig.cs
|-- logs/
| |-- log_2023-11-27.txt
|-- Managers/
| |-- WebDriverManager.cs
|-- Pages/
| |-- BasePage.cs
| |-- YoutubeMainPage.cs
| |-- YoutubeSearchResultsPage.cs
| |-- YoutubeVideoPage.cs
|-- TestData/
| |-- testDataEnglish.json
|-- Tests/
| |-- BaseTest.cs
| |-- YouTubeVideoPlaybackTests.cs
|-- Utilities/
| |-- Logger.cs
| |-- StringHelpers.cs
| |-- TestAssert.cs
|-- NLog.config
|-- README.md

## Components

Contains reusable components that interact with web elements, such as headers and pop-up filters.

## Config

Includes configuration files and classes to manage settings and test data.

## logs

Stores log files generated during test execution, which provide a detailed account of the automation process.

## Managers

Manages web driver instances, ensuring proper initialization and closure of browsers.

## Pages

Represents the pages within the YouTube application, encapsulating the page-specific elements and interactions.

## TestData

Holds test data in JSON format that can be loaded to drive tests with various inputs.

## Tests

Contains test classes that define the automated test cases to be run.

## Utilities

Provides helper classes and methods to support logging, assertions, and other common tasks.

## How to Run Tests

1. Ensure that you have the required version of .NET SDK installed.
2. Clone the project from the repository: git clone https://github.com/Becky5706627/TibaEvaluationExercise.git
3. Build the solution to restore NuGet packages and compile the project.
4. Run tests using the Test Explorer within Visual Studio or by using the dotnet CLI:



