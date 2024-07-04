using miacademy_practical_qa_task_jose_reyes.helpers;
using OpenQA.Selenium;

namespace miacademy_practical_qa_task_jose_reyes.pages
{
    public class Miacademy : BasePage
    {
        private IWebDriver driver;

        public Miacademy(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void Navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
            Console.WriteLine($"Successfully opened browser and accessed: {MiacademyHelper.baseUrl}");
        }
    }
}
