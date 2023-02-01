using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit;

namespace DemoBlaze_Project_FA22
{
    public class MethodsImplementation : HelperClass
    {
        By UserName = By.Id("sign-username");
        By Password = By.Id("sign-password");
        By LoginUserName = By.Id("loginusername");
        By LoginPassword = By.Id("loginpassword");
        By ProceedSignUpBtn = By.CssSelector("#signInModal > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > button:nth-child(2)");
        By ProceedLoginBtn = By.CssSelector("#logInModal > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > button:nth-child(2)");
        By EmailID = By.Id("recipient-email");
        By Name = By.Id("recipient-name");
        By Message = By.Id("message-text");


        #region sign up method
        public void signUp(string username, string password)
        {
            driver.FindElement(UserName).SendKeys(username);
            Thread.Sleep(500);

            driver.FindElement(Password).SendKeys(password);
            Thread.Sleep(1000);

            ClickOn(ProceedSignUpBtn);

        }
        #endregion


        #region login method
        public void login(string username, string password)
        {
            driver.FindElement(LoginUserName).SendKeys(username);
            Thread.Sleep(500);

            driver.FindElement(LoginPassword).SendKeys(password);
            Thread.Sleep(1000);

            ClickOn(ProceedLoginBtn);

        }
        #endregion

        #region Landing on mainpage
        public void initializeAndGoTo(string url)
        {
            initializeDriver();
            maximizeWindow();
            GoTo(url);

        }
        #endregion

        #region Adding item to cart
        public void AddToCart(By ItemReference)
        {
            string pageText = "Product description";
            By AddtoCartBtn = By.CssSelector("a.btn");

            ClickOn(ItemReference);
            Thread.Sleep(3000);

            if(getText(By.CssSelector("#more-information > strong:nth-child(2)")) == pageText){
                ClickOn(AddtoCartBtn);
                Thread.Sleep(1000);
            }
        }
        #endregion

        #region Alert Handling
        public void CheckAlert()
        {
            IAlert alert = switchToAlert();
            string alertText = alert.Text;

            if(String.Equals(alertText, "Product added"))
            {
                alert.Accept();
            }

            else
            {
                endTest();
            }
        }

        #endregion

        #region Contact Message passer
        public void contactMessage(string email, string name, string message)
        {
            driver.FindElement(EmailID).SendKeys(email);
            Thread.Sleep(1000);
            driver.FindElement(Name).SendKeys(name);
            Thread.Sleep(1000);
            driver.FindElement(Message).SendKeys(message);
            Thread.Sleep(2000);
        }
        #endregion

    }
}
