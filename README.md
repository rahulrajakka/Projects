1. Install Your Chosen ID, I installed VS Code.
2. Open VS Code.
3. Go to the Extensions
4. Search for "C# for Visual Studio Code" and install the extension provided
5. Install the .NET SDK -> navigate to https://dotnet.microsoft.com/en-us/download.
6. Once installed, confirm by running the following command = dotnet --version


**For selenium testing install the following dependecies.** 
**NUnit framework for testing**
dotnet add package NUnit

**NUnit Test Adapter for discovering tests in VSCode**
dotnet add package NUnit3TestAdapter

**Selenium WebDriver package for controlling browsers**
dotnet add package Selenium.WebDriver

**Selenium Support package (provides WebDriverWait, ExpectedConditions, etc.)**
dotnet add package Selenium.Support

**Chrome WebDriver package for driving Chrome browser**
dotnet add package Selenium.WebDriver.ChromeDriver
