using OpenQA.Selenium;

namespace miacademy_practical_qa_task_jose_reyes.helpers
{
    public static class MiacademyHelper
    {
        // Base URLs
        public static string baseUrl = "https://miacademy.co/#/";

        // Tab Title
        public static string tabTitle = "Miacademy - Engaging Online Curriculum";

        // Locator methods

        // MiaPrep Link
        public static By miaPrepLinkLocator()
        {
            return By.LinkText("Online High School");
        }
    }
}
