using OpenQA.Selenium;

namespace miacademy_practical_qa_task_jose_reyes.helpers
{
    public static class MiaprepHelper
    {
        // Tab Title
        public static string tabTitle = "MiaPrep Online High School - MiaPrep";

        // Locator method/s

        // Application Link
        public static By applyLinkLocator()
        {
            return By.CssSelector("div.wp-block-button a.wp-block-button__link");
        }
    }
}

