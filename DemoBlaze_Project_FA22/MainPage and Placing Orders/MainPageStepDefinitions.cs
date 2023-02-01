using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit;
using NUnit.Framework;
using TechTalk.SpecFlow;


namespace DemoBlaze_Project_FA22
{
    [Binding]
    public class MainPageStepDefinitions : MethodsImplementation
    {
        By HomeNavLink = By.CssSelector("li.nav-item:nth-child(1) > a:nth-child(1)");
        By CartNavLink = By.Id("cartur");
        By PlaceOrderBtn = By.CssSelector("button.btn:nth-child(3)");
        By PhoneSection = By.CssSelector("a.list-group-item:nth-child(2)");
        By LaptopSection = By.CssSelector("a.list-group-item:nth-child(3)");
        By MonitorSection = By.CssSelector("a.list-group-item:nth-child(4)");
        By PhoneItem = By.CssSelector("div.col-lg-4:nth-child(5) > div:nth-child(1) > div:nth-child(2) > h4:nth-child(1) > a:nth-child(1)");
        By LaptopItem = By.CssSelector("div.col-lg-4:nth-child(6) > div:nth-child(1) > div:nth-child(2) > h4:nth-child(1) > a:nth-child(1)");
        By MonitorItem = By.CssSelector("div.col-md-6:nth-child(1) > div:nth-child(1) > div:nth-child(2) > h4:nth-child(1) > a:nth-child(1)");
        By CustomerName = By.Id("name");
        By Country = By.Id("country");
        By City = By.Id("city");
        By CreditCardNo = By.Id("card");
        By Month = By.Id("month");
        By Year = By.Id("year");
        By PurchaseBtn = By.CssSelector("#orderModal > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > button:nth-child(2)");


        #region Adding an Item to cart TestCase
        [Given(@"User will be at homepage")]
        public void GivenUserWillBeAtHomepage()
        {
            initializeAndGoTo("https://www.demoblaze.com/index.html");
            Thread.Sleep(3000);
        }

        [When(@"user clicks an item")]
        public void WhenUserClicksAnItem()
        {
            ClickOn(PhoneItem);
            Thread.Sleep(3000);
        }

        [Then(@"user will be redirected to the product details")]
        public void ThenUserWillBeRedirectedToTheProductDetails()
        {
            string pageText = "Product description";

            Assert.AreEqual(getText(By.CssSelector("#more-information > strong:nth-child(2)")), pageText);
        }

        [When(@"user clicks Add to Cat")]
        public void WhenUserClicksAddToCat()
        {
            ClickOn(By.CssSelector("a.btn"));
            Thread.Sleep(1000);
        }

        [Then(@"User sees the message '([^']*)'")]
        public void ThenUserSeesTheMessage(string actualText)
        {
            IAlert alert = switchToAlert();
            string alertText = alert.Text;

            Assert.AreEqual(alertText, actualText);
            alert.Accept();
            endTest();
        }
        #endregion


        #region Adding Multiple Items Testcase

        [When(@"user adds a phone to cart")]
        public void WhenUserAddsAPhoneToCart()
        {
            AddToCart(PhoneItem);
            Thread.Sleep(1000);
        }

        [Then(@"User sees the message '([^']*)' and clicks ok")]
        public void ThenUserSeesTheMessageAndClicksOk(string actualText)
        {
            IAlert alert = switchToAlert();
            string alertText = alert.Text;

            Assert.AreEqual(alertText, actualText);
            alert.Accept();
        }


        [When(@"User Goes back to homepage")]
        public void WhenUserGoesBackToHomepage()
        {
            ClickOn(HomeNavLink);
            Thread.Sleep(1000);
        }

        [When(@"User choses Laptop category")]
        public void WhenUserChosesLaptopCategory()
        {
            ClickOn(LaptopSection);
            Thread.Sleep(1000);
        }

        [When(@"user adds Laptop to cart")]
        public void WhenUserAddsLaptopToCart()
        {
            AddToCart(LaptopItem);
            Thread.Sleep(1000);
        }
        #endregion


        #region Placing A Complete Order
        [When(@"user adds items to cart")]
        public void WhenUserAddsItemsToCart()
        {

            AddToCart(PhoneItem);
            Thread.Sleep(2000);
            CheckAlert();
            Thread.Sleep(1000);
        }

        [When(@"user clicks on Cart on the navigation")]
        public void WhenUserClicksOnCartOnTheNavigation()
        {
            ClickOn(CartNavLink);
            Thread.Sleep(2000);
        }

        [Then(@"user is directed to Cart page")]
        public void ThenUserIsDirectedToCartPage()
        {
            Assert.AreEqual(getText(By.CssSelector(".col-lg-1 > h2:nth-child(1)")), "Total");
        }

        [When(@"user clicks on '([^']*)'")]
        public void WhenUserClicksOn(string p0)
        {
            ClickOn(PlaceOrderBtn);
            Thread.Sleep(1000);
        }

        [Then(@"user sees a Popup of customer details")]
        public void ThenUserSeesAPopupOfCustomerDetails()
        {
            Assert.AreEqual(getText(By.Id("orderModalLabel")), "Place order");
        }

        [When(@"user enters ""([^""]*)"" ""([^""]*)"" ""([^""]*)"" ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        public void WhenUserEnters(string name, string country, string city, string creditCardNo, string month, string year)
        {
            driver.FindElement(CustomerName).SendKeys(name);
            Thread.Sleep(500);
            driver.FindElement(Country).SendKeys(country);
            Thread.Sleep(500);
            driver.FindElement(City).SendKeys(city);
            Thread.Sleep(500);
            driver.FindElement(CreditCardNo).SendKeys(creditCardNo);
            Thread.Sleep(500);
            driver.FindElement(Month).SendKeys(month);
            Thread.Sleep(500);
            driver.FindElement(Year).SendKeys(year);
            Thread.Sleep(1000);
        }

        [When(@"user clicks on Purchase")]
        public void WhenUserClicksOnPurchase()
        {
            ClickOn(PurchaseBtn);
            Thread.Sleep(1000);
        }

        [Then(@"user sees a the message '([^']*)'")]
        public void ThenUserSeesATheMessage(string thankMessage)
        {

            Assert.AreEqual(getText(By.CssSelector(".sweet-alert > h2:nth-child(6)")), thankMessage);
            endTest();
        }

        #endregion
    }
}
