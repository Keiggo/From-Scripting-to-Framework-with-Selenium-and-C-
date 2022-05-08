using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Royale.Tests
{
    public class CardTests
    {
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        }

        [TearDown]
        public void AfterEach()
        {
            driver.Quit();
        }

        [Test]
        public void Ice_Spirit_is_on_Cards_Page()
        {
            // go to statsroyale.com
            driver.Url = "https://statsroyale.com/";
            driver.Manage().Window.Maximize();
            // driver.FindElement(By.CssSelector("'button[title=Accept]'")).Click();
            //click on cards link in header nav
            driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            //assert ice spirit is displayed
            var iceSpirit = driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));
            Assert.That(iceSpirit.Displayed);
        }

        [Test]
        public void Ice_Spirit_headers_are_correct_on_Card_Details_Page()
        {
            // go to statsroyale.com
            driver.Url = "statsroyale.com";
            //click on cards link in header nav
            driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            //go to Ice Spirit
            driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']")).Click();
            //Assert basic header stats
            var cardName = driver.FindElement(By.CssSelector("[class*='cardName']")).Text;
            var cardCategories = driver.FindElement(By.CssSelector(".card_rarity")).Text.Split(", ");
            var cardType = cardCategories[0];
            var cardArena = cardCategories[1];
            var cardRarity = driver.FindElement(By.CssSelector(".card__common")).Text;
            
            Assert.AreEqual("Ice Spirit", cardName);
            Assert.AreEqual("Troop",cardType);
            Assert.AreEqual("Arena 8", cardArena);
            Assert.AreEqual("Common", cardRarity);
        }
    }
}