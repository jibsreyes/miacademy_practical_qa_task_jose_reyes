using NUnit.Framework;
using OpenQA.Selenium;

namespace miacademy_practical_qa_task_jose_reyes.pages
{
    public class BasePage
    {
        private IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AssertTabTitle(string tabTitle)
        {
            Assert.That(tabTitle, Is.EqualTo(driver.Title));
            Console.WriteLine($"Successfully asserted tab title: {tabTitle}");
        }

        public void Click(By locator)
        {
            driver.FindElement(locator).Click();
            Console.WriteLine($"Successfully clicked {locator}.");
        }
    }
}
