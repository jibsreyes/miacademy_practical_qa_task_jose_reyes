using miacademy_practical_qa_task_jose_reyes.helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace miacademy_practical_qa_task_jose_reyes.pages
{
    public class MiaprepApplicationForm : BasePage
    {
        private IWebDriver driver;

        public MiaprepApplicationForm(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void EnterFieldValue(By locator, string value)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(value);
            Console.WriteLine($"Successfully entered value '{value}' into the {locator}.");
        }

        // Method to select a country via xpath
        public void SelectCountry(string countryName)
        {
            // Find the country list element
            IWebElement countryList = driver.FindElement(MiaprepApplicationFormHelper.CountryListLocator());

            // Find the selected country option to scroll to
            IWebElement selectedCountryOption = countryList.FindElement(By.XPath($"//span[@class='country-name' and text()='{countryName}']"));

            // Click on the selected country to choose it
            selectedCountryOption.Click();
            Console.WriteLine($"Successfully changed dropdown value to: '{countryName}'.");
        }

        // Method to select a country via javascript (scroll)
        public void ScrollToAndSelectCountryCode(string defaultCountry, string selectedCountry)
        {
            // Find the country list element
            IWebElement countryList = driver.FindElement(By.ClassName("country-list"));

            // Find the default country option (United States) to determine scrolling direction
            IWebElement defaultCountryOption = countryList.FindElement(By.XPath($"//span[@class='country-name' and text()='{defaultCountry}']"));

            bool countryFound = false;
            int maxScrollAttempts = 50; // Adjust the max attempts as needed
            int scrollAttempts = 0;

            while (!countryFound && scrollAttempts < maxScrollAttempts)
            {
                try
                {
                    // Try to find the selected country option
                    IWebElement selectedCountryOption = countryList.FindElement(By.XPath($"//span[@class='country-name' and text()='{selectedCountry}']"));

                    if (selectedCountryOption.Displayed)
                    {
                        // Click on the selected country to choose it
                        selectedCountryOption.Click();
                        countryFound = true;
                        Console.WriteLine($"Successfully selected the country: {selectedCountry}");
                    }
                }
                catch (NoSuchElementException)
                {
                    // Get the location (Y-coordinate) of the default country option
                    int defaultCountryY = defaultCountryOption.Location.Y;
                    
                    // Scroll the country list element up or down based on the position of the default country
                    string script;
                    if (defaultCountry.CompareTo(selectedCountry) < 0)
                    {
                        // Scroll down
                        script = "arguments[0].scrollTop += 50;"; // Adjust the scroll amount as needed
                    }
                    else
                    {
                        // Scroll up
                        script = "arguments[0].scrollTop -= 50;"; // Adjust the scroll amount as needed
                    }
                    ((IJavaScriptExecutor)driver).ExecuteScript(script, countryList);

                    // Wait for a short moment before re-checking
                    System.Threading.Thread.Sleep(5000);
                    scrollAttempts++;
                }
            }

            if (!countryFound)
            {
                Console.WriteLine($"Failed to find the country: {selectedCountry} after {scrollAttempts} scroll attempts.");
            }
        }

        // Method to get the total number of checkboxes
        public void SelectAllCheckboxes()
        {
            // Locate the checkboxes
            IList<IWebElement> checkboxes = driver.FindElements(By.CssSelector("#Checkbox-li .cusChoiceSpan input[type='checkbox']"));

            // Iterate through each checkbox and click it
            foreach (IWebElement checkbox in checkboxes)
            {
                // work around to bypass ElementClickInterceptedException
                ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].click();", checkbox);
            }
        }
    }
}
