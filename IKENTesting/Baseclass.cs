using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKENTesting.Baseclass
{
    [TestClass]
    public class BaseClass
    {
        IWebDriver driver = new ChromeDriver();

        #region WebElement
        private By SDPLink = By.XPath("//span[@class='link_text' and text()='SDP']");
        private By Username = By.XPath("//input[@id='username']");
        private By Password = By.XPath("//input[@id='password']");
        private By Login = By.XPath("//input[@name='login']");
        private By TimeSheetLink = By.XPath("//a[@class='fa fa-clock-o timesheets df']");


        #endregion

        #region actions
       
        public void Actions()
        {

            driver.FindElement(Username).SendKeys("ee210668");
            driver.FindElement(Password).SendKeys("System210668");
            driver.FindElement(Login).Click();
            driver.FindElement(TimeSheetLink).Click();
        }
      #endregion
      #region Navigation
      [TestMethod]
        public void Navigation()
        {
           driver.Navigate().GoToUrl("https://iken.sasken.com/");
           driver.Manage().Window.Maximize();
           driver.FindElement(SDPLink).Click();
            var currentWindow = driver.CurrentWindowHandle;
            foreach (String winHandle in driver.WindowHandles)
            {
                if (winHandle != currentWindow)
                {
                    driver.SwitchTo().Window(winHandle);
                }
            }
            Actions();
            driver.Quit();
        }

        #endregion
        
       
    }
}
