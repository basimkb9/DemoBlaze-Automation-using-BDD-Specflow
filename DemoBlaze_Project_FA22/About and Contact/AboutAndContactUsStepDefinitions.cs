using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DemoBlaze_Project_FA22
{
    [Binding]
    public class AboutAndContactUsStepDefinitions : MethodsImplementation
    {
        By AboutUsBtn = By.CssSelector("li.nav-item:nth-child(3) > a:nth-child(1)");
        By ContactBtn = By.CssSelector("li.nav-item:nth-child(2) > a:nth-child(1)");
        By PlayVideo = By.XPath("/html/body/div[4]/div/div/div[2]/form/div/div/button");
        By AboutUsTitle = By.Id("videoModalLabel");
        By CloseBtn = By.CssSelector("#videoModal > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > button:nth-child(1)");
        By SendMessageBtn = By.CssSelector("#exampleModal > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > button:nth-child(2)");

        #region about us test
        [When(@"User clicks about us on navigation bar")]
        public void WhenUserClicksAboutUsOnNavigationBar()
        {
            ClickOn(AboutUsBtn);
            Thread.Sleep(1000);
        }

        [Then(@"About us Popup appears")]
        public void ThenAboutUsPopupAppears()
        {
            string expectedTitle = getText(AboutUsTitle);

            Assert.AreEqual(expectedTitle, "About us"); ;
            Thread.Sleep(1000);
        }

        [When(@"user clicks on play button")]
        public void WhenUserClicksOnPlayButton()
        {
            ClickOn(PlayVideo);
        }

        [Then(@"the video starts playing")]
        public void ThenTheVideoStartsPlaying()
        {
            Thread.Sleep(5000);
        }

        [Then(@"user clicks on close button")]
        public void ThenUserClicksOnCloseButton()
        {
            ClickOn(CloseBtn);
        }
        #endregion


        #region Contact Sending Message Test Case

        [When(@"User clicks contact on navigation bar")]
        public void WhenUserClicksContactOnNavigationBar()
        {
            ClickOn(ContactBtn);
            Thread.Sleep(1000);
        }

        [Then(@"contact Popup appears")]
        public void ThenContactPopupAppears()
        {
            string ContactLabel = getText(By.Id("exampleModalLabel"));
            Assert.AreEqual(ContactLabel, "New message");
        }

        [When(@"user enters information '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserEntersInformation(string email, string name, string message)
        {
            contactMessage(email, name, message);
        }


        [When(@"user clicks on Send Message")]
        public void WhenUserClicksOnSendMessage()
        {
            ClickOn(SendMessageBtn);
            Thread.Sleep(1000);
        }

        [Then(@"Alert appears with text ""([^""]*)""")]
        public void ThenAlertAppearsWithText(string actualText)
        {
            IAlert alert = switchToAlert();
            string alertText = alert.Text;

            Assert.AreEqual(alertText, actualText);
            alert.Accept();
            endTest();
        }


        #endregion



    }

}
