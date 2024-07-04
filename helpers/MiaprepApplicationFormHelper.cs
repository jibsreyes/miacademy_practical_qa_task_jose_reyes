using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V124.FedCm;

namespace miacademy_practical_qa_task_jose_reyes.helpers
{
    public static class MiaprepApplicationFormHelper
    {

        // Tab Title
        public static string tabTitle = "MOHS Initial Application";

        // Application fields / dropdowns
        public static By FirstNameFieldLocator()
        {
            return By.CssSelector("input[name='Name'][elname='First']");
        }

        public static By LastNameFieldLocator()
        {
            return By.CssSelector("input[name='Name'][elname='Last']");
        }

        public static By EmailFieldLocator()
        {
            return By.CssSelector("input[id='Email-arialabel'][name='Email']");
        }

        public static By CountryCodeDropdown()
        {
            return By.CssSelector(".selected-flag");
        }

        public static By PhoneFieldLocator()
        {
            return By.CssSelector("input[id='PhoneNumber'][name='PhoneNumber']");
        }

        public static By SecondParentOrGuardianDropDown()
        {
            return By.CssSelector("[aria-labelledby='select2-Dropdown-arialabel-container']");
        }
        public static By SecondParentOrGuardianDropDownOptions(string answer)
        {
            return By.XPath($"//li[@class='select2-results__option' and text()='{answer}']");
        }

        public static By FirstName1FieldLocator()
        {
            return By.CssSelector("input[name='Name1'][elname='First']");
        }

        public static By LastName1FieldLocator()
        {
            return By.CssSelector("input[name='Name1'][elname='Last']");
        }

        public static By Email1FieldLocator()
        {
            return By.CssSelector("input[id='Email1-arialabel'][name='Email1']");
        }
        public static By Phone1FieldLocator()
        {
            return By.Id("PhoneNumber1");
        }

        public static By CountryListLocator()
        {
            return By.ClassName("country-list");
        }

        public static By StartDateFieldLocator()
        {
            return By.Id("Date-date");
        }

        // Method to generate a random future date within the next three months
        public static string GenerateRandomFutureDate()
        {
            Random random = new Random();
            int daysInFuture = random.Next(14, 60);
            DateTime futureDate = DateTime.Today.AddDays(daysInFuture);
            return futureDate.ToString("dd-MMM-yyyy");
        }

        public static By NextButtonPage2()
        {
            return By.XPath("//button[@aria-label='Next\nNavigates to page 2 out of 3']");
        }

        // Application test data
        public static string firstName = "Jose";
        public static string lastName = "Reyes";
        public static string email = "jibsreyes@gmail.com";
        public static string defaultCountry = "United States";
        public static string countryName = "Philippines";
        public static string phoneNumber = "9682105650";

        public static string secondParentOrGuardianDropDownValue = "Yes";

        public static string firstName1 = "Contessa";
        public static string lastName1 = "Reyes";
        public static string email1 = "contessareyes@gmail.com";
        public static string phoneNumber1 = "9366996261";
    }
}
