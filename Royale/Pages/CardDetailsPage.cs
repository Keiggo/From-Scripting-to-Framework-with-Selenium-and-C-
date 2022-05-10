using OpenQA.Selenium;

namespace Royale.Pages
{
    public class CardDetailsPage : PageBase
    {
        public readonly CardDetailsPageMap Map;

        public CardDetailsPage(IWebDriver driver) : base(driver)
        {
            Map = new CardDetailsPageMap(driver);
        }
    }

    public class CardDetailsPageMap
    {
        IWebDriver _driver;

        public CardDetailsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}