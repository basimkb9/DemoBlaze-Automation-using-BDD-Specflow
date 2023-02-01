using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DemoBlaze_Project_FA22
{
    [Binding]
    public class RegisterAndLoginScenariosStepDefinitions : MethodsImplementation
    {
        By OpenSignUpBtn = By.Id("signin2");
        MethodsImplementation register = new MethodsImplementation();

        [Given(@"Goto Url https://www\.demoblaze\.com/index\.html")]
        public void GivenGotoUrlHttpsWww_Demoblaze_ComIndex_Html()
        {
            initializeDriver();
            maximizeWindow();
            GoTo("https://www.demoblaze.com/index.html");
        }

        [When(@"User clicks Sign Up")]
        public void WhenUserClicksSignUp()
        {
            ClickOn(OpenSignUpBtn);
            Thread.Sleep(1000);
        }

        [When(@"User enters the username ""([^""]*)"" and password ""([^""]*)"" and clicks Sign Up")]
        public void WhenUserEntersTheUsernameAndPasswordAndClicksSignUp(string test, string test1)
        {
            signUp(test, test1);
            Thread.Sleep(1000);
        }

        [Then(@"User sees the failed popup message")]
        public void ThenUserSeesTheFailedPopupMessage()
        {
            //switches driver from window to alert popup
            IAlert alert = switchToAlert();
            string alertText = alert.Text;
            string[] actualText = { "This user already exist.", "Please fill out Username and Password." };

            Assert.That(String.Equals(alertText, actualText[0]) || String.Equals(alertText, actualText[1]));
            alert.Accept();
            endTest();
        }

        [When(@"User will enter the username ""([^""]*)"" and password ""([^""]*)"" and click Sign Up")]
        public void WhenUserWillEnterTheUsernameAndPasswordAndClickSignUp(string basimTester, string p1)
        {
            signUp(basimTester, p1);
            Thread.Sleep(1000);
        }

        [Then(@"User sees the success popup message")]
        public void ThenUserSeesTheSuccessPopupMessage()
        {
            IAlert alert = switchToAlert();
            string alertText = alert.Text;

            Assert.AreEqual(alertText, "Sign up successful.");
            alert.Accept();
            endTest();
        }


        By LoginBtn = By.Id("login2");

        [When(@"User clicks Login")]
        public void WhenUserClicksLogin()
        {
            ClickOn(LoginBtn);
            Thread.Sleep(1000);
        }

        [When(@"User enters the username ""([^""]*)"" and password ""([^""]*)"" and clicks Login")]
        public void WhenUserEntersTheUsernameAndPasswordAndClicksLogin(string p0, string test)
        {
            login(p0, test);
            Thread.Sleep(1000);

        }

        [Then(@"User sees the failed login popup message")]
        public void ThenUserSeesTheFailedLoginPopupMessage()
        {

            IAlert alert = switchToAlert();
            string alertText = alert.Text;
            string[] actualText = { "Wrong password.", "User does not exist.", "Please fill out Username and Password." };

            Assert.That(String.Equals(alertText, actualText[0]) || String.Equals(alertText, actualText[1]) || String.Equals(alertText, actualText[2]));
            alert.Accept();
            endTest();
        }

        [When(@"User enters the username ""([^""]*)"" and password ""([^""]*)"" and click Login")]
        public void WhenUserEntersTheUsernameAndPasswordAndClickLogin(string p0, string test)
        {
            login(p0, test);
            Thread.Sleep(5000);
        }

        [Then(@"User gets redirected to homepage")]
        public void ThenUserGetsRedirectedToHomepage()
        {
            Assert.AreEqual(driver.FindElement(By.Id("logout2")).Text, "Log out");
            endTest();
        }



    }
}
