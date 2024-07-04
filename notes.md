# Assuming local env is configured for C# development 
1. Create a new project
  - dotnet new -n miacademy_practical_qa_task_jose_reyes

2. Install necessary packages:
  * dotnet add package NUnit
  * dotnet add package NUnit3TestAdapter
  * dotnet add package Selenium.WebDriver 
  * dotnet add package Selenium.WebDriver.ChromeDriver
  * dotnet add package Microsoft.NET.Test.Sdk
  * dotnet add package Selenium.Support

3. Create project structuring:
  - helpers: contains helper classes for constants, locator methods, etc.
      - Page1Helper.cs
      - ...
      - PageXHelper.cs
  - pages: contains page object classes
      - BasePage.cs: contains common methods for reusability.
      - Page1.cs: contains methods specific to Page1.
      - ...
      - PageX.cs: contains methods specific to PageX.
  - tests
      - Apply.cs: Example test script.

4. Run the automated test
  - execute `dotnet test`
