// Practical Task

// Automate the following flows using the C# programming language and any automation framework:

// 1. navigate to https://miacademy.co/#/
// 2. navigate to MiaPrep Online High School through the link on banner
// 3. apply to MOHS
// 4. fill in the Parent Information
// 5. proceed to Student Information page
// STOP YOUR TEST HERE

using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using miacademy_practical_qa_task_jose_reyes.pages;
using miacademy_practical_qa_task_jose_reyes.helpers;

namespace miacademy_practical_qa_task_jose_reyes.tests
{
    [TestFixture]
    public class Apply
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void ApplyTest()
        {
            var Miacademy = new Miacademy(driver);

            // 1. navigate to https://miacademy.co/#/
            Miacademy.Navigate(MiacademyHelper.baseUrl);
            Miacademy.AssertTabTitle(MiacademyHelper.tabTitle);

            // 2. navigate to MiaPrep Online High School through the link on banner
            Miacademy.Click(MiacademyHelper.miaPrepLinkLocator());

            var Miaprep = new Miaprep(driver);
            Miaprep.AssertTabTitle(MiaprepHelper.tabTitle);

            // 3. apply to MOHS
            Miaprep.Click(MiaprepHelper.applyLinkLocator());

            // 4. fill in the Parent Information
            var MiaprepApplicationForm = new MiaprepApplicationForm(driver);
            System.Threading.Thread.Sleep(500);
            MiaprepApplicationForm.AssertTabTitle(MiaprepApplicationFormHelper.tabTitle);
            System.Threading.Thread.Sleep(500);
            MiaprepApplicationForm.EnterFieldValue(MiaprepApplicationFormHelper.FirstNameFieldLocator(), MiaprepApplicationFormHelper.firstName);
            System.Threading.Thread.Sleep(500);
            MiaprepApplicationForm.EnterFieldValue(MiaprepApplicationFormHelper.LastNameFieldLocator(), MiaprepApplicationFormHelper.lastName);
            System.Threading.Thread.Sleep(500);
            MiaprepApplicationForm.EnterFieldValue(MiaprepApplicationFormHelper.EmailFieldLocator(), MiaprepApplicationFormHelper.email);
            System.Threading.Thread.Sleep(500);
            MiaprepApplicationForm.Click(MiaprepApplicationFormHelper.CountryCodeDropdown());
            System.Threading.Thread.Sleep(500);
            MiaprepApplicationForm.ScrollToAndSelectCountryCode(MiaprepApplicationFormHelper.defaultCountry, MiaprepApplicationFormHelper.countryName);
            System.Threading.Thread.Sleep(500);
            MiaprepApplicationForm.EnterFieldValue(MiaprepApplicationFormHelper.PhoneFieldLocator(), MiaprepApplicationFormHelper.phoneNumber);
            MiaprepApplicationForm.Click(MiaprepApplicationFormHelper.SecondParentOrGuardianDropDown());
            System.Threading.Thread.Sleep(500);
            MiaprepApplicationForm.Click(MiaprepApplicationFormHelper.SecondParentOrGuardianDropDownOptions(MiaprepApplicationFormHelper.secondParentOrGuardianDropDownValue));
            if (MiaprepApplicationFormHelper.secondParentOrGuardianDropDownValue == "Yes") {
              MiaprepApplicationForm.EnterFieldValue(MiaprepApplicationFormHelper.FirstName1FieldLocator(), MiaprepApplicationFormHelper.firstName1);
              MiaprepApplicationForm.EnterFieldValue(MiaprepApplicationFormHelper.LastName1FieldLocator(), MiaprepApplicationFormHelper.lastName1);
              MiaprepApplicationForm.EnterFieldValue(MiaprepApplicationFormHelper.Email1FieldLocator(), MiaprepApplicationFormHelper.email1);
              MiaprepApplicationForm.EnterFieldValue(MiaprepApplicationFormHelper.Phone1FieldLocator(), MiaprepApplicationFormHelper.phoneNumber1);
            }
            else if (MiaprepApplicationFormHelper.secondParentOrGuardianDropDownValue == "No") {
              Console.WriteLine("Option selected: No. No additional fields to populate.");
            }
            MiaprepApplicationForm.SelectAllCheckboxes();
            System.Threading.Thread.Sleep(500);
            MiaprepApplicationForm.EnterFieldValue(MiaprepApplicationFormHelper.StartDateFieldLocator(), MiaprepApplicationFormHelper.GenerateRandomFutureDate());
            // 5. proceed to Student Information page
            System.Threading.Thread.Sleep(500);
            MiaprepApplicationForm.Click(MiaprepApplicationFormHelper.NextButtonPage2());
            System.Threading.Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
