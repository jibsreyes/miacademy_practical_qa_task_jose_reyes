using OpenQA.Selenium;

namespace miacademy_practical_qa_task_jose_reyes.pages
{
    public class Miaprep : BasePage
    {
        private IWebDriver driver;

        public Miaprep(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
    }
}
