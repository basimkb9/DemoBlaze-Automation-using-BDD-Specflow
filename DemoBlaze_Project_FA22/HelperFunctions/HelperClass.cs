using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit;
using NUnit.Framework;


namespace DemoBlaze_Project_FA22;
public class HelperClass
{

    public static ChromeDriver driver;
    public void initializeDriver()
    {
        driver = new ChromeDriver();
    }

    public void GoTo(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    public IAlert switchToAlert()
    {
        return driver.SwitchTo().Alert();
    }

    public void ClickOn(By reference)
    {
        driver.FindElement(reference).Click();
    }

    public string getText(By reference)
    {
        return driver.FindElement(reference).Text;
    }

    public void maximizeWindow()
    {
        driver.Manage().Window.Maximize();
    }

    public void closeDriver()
    {
    }

    public void disposeDriver()
    {
    }


    public void endTest()
    {
        driver.Close();
        driver.Dispose();
    }
}
