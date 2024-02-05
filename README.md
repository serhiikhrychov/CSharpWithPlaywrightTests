# CSharpWithPlaywrightTests
Playwright automation framework with C# .Net, Tests are part of CI\CD on GitHub Actions.

```
CSharpWithPlaywrightTests
├───PlaywrightCSharp.Infrastructure
	├───Config
	├───Pages
	├───ResourceProviders
	└───TestData
└───PlaywrightCSharp.Tests
	└───Tests
```

## Prerequisite:
1. [Microsoft Visual Studio 2022 IDE](https://visualstudio.microsoft.com/).
2. [Git](https://git-scm.com/download/).

## Local Setup:
1. ```git clone https://github.com/serhiikhrychov/CSharpWithPlaywrightTests.git``` or download `master` branch zip and extract code.
2. Open project with VS.
3. Restore all packages.
4. Build project.
5. Run `pwsh bin\Debug\netX\playwright.ps1 install` command from your project bin directory. Ignore if already done.
6. Run test.

## Framework Overview:

Solution contains two projects:

 - PlaywrightCSharp.Infrastructure - with tests infrastructure

 - PlaywrightCSharp.Tests - with UI tests for google maps

 
 ### PlaywrightCSharp.Tests

  #### Context class

 Purpose:

    - Sets up and configures shared resources for the test suite.
    - Manages dependency injection.

 Key Points:

    - SetUpFixture Attribute: Marks the class as a setup fixture, indicating it runs once before all tests.
    - OneTimeSetUp Method:
        Builds a ServiceProvider from ServiceCollection using configuration from "config.json". Configures Logging.
    - Get Method: Retrieves instances of registered services using the ServiceProvider.
    - OneTimeTearDownAsync Method: Disposes of the ServiceProvider after all tests have run.

 
  #### SearchPanelTests class

 Key Points:

    - The tests focus on the search functionality and route building within the application.
    - They use the MainPage object (injected via dependency injection) to interact with the page elements.
    - They utilize test data from PlaywrightCSharp.Infrastructure.TestData for input values and expected results.
    - The tests are asynchronous due to the nature of Playwright interactions.
    - The Parallelizable attribute allows for potential performance gains through parallel test execution.

  #### config.json

 Key Points:

    - Allows customization of test execution without modifying code.
    - Controls essential aspects of the testing environment.
    - Facilitates debugging and analysis through screenshot capture.

 ### PlaywrightCSharp.Infrastructure

  #### ServiceCollectionExtensions class

 Purpose:

    - Provides extension methods to simplify the registration of infrastructure services within the dependency injection container.

 Key Points:

    - Encapsulates registration logic for infrastructure services.
    - Ensures consistent configuration and service lifecycle management.
    - Simplifies test code by providing convenient access to shared resources.
    - Promotes code maintainability and testability.

  #### ResourceProviders folder

    1. PlaywrightResourceProvider:
    Purpose: 
    - Base class for managing Playwright-related resources.
    Key Features:
    - Implements IAsyncDisposable for proper cleanup.
    - Encapsulates the creation and disposal of resources.

    2. PlaywrightProvider:
    Purpose: 
    - Manages the Playwright instance itself.
    Key Features:
    - Creates a new Playwright instance asynchronously.
    - Disposes of the Playwright instance when required.

    3. BrowserProvider:
    Purpose: 
    - Manages browser instances.
    Key Features:
    - Launches the specified browser based on configuration.
    - Configures headless mode as needed.
    - Disposes of the browser instance when tests are complete.

    4. PageProvider:
    Purpose: 
    - Manages page instances within a browser.
    Key Features:
    - Creates a new page within the browser.
    - Sets the viewport size according to configuration.
    - Disposes of the page instance when tests move to a new page or finish.

 #### MainPage class

Purpose:

    - Represents the application's main page under test (Google Maps in this case).
    - Encapsulates page-specific interactions and assertions.

#### Config folder

1. PlaywrightConfigProvider:

Purpose:

    - Loads Playwright configuration from a JSON file.


2. PlaywrightConfig:

Purpose:

    - Represents the Playwright configuration settings.

