using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.pageobjects
{
    internal class PurchasePage
    {
        private IWebDriver driver;
        public PurchasePage(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //driver.FindElement(By.XPath("//label[@for='checkbox2']")).Click();
        //driver.FindElement(By.XPath("//input[@type='submit']")).Click();

        [FindsBy(How = How.Id, Using = "country")]
        IWebElement countryfield;

        [FindsBy(How = How.XPath, Using = "//label[@for='checkbox2']")]
        IWebElement checkbox;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        IWebElement purchase;

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-success alert-dismissible']")]
        IWebElement successmessage;

        public IWebElement getcountryfield()
        {
            return countryfield;
        }

        public IWebElement getcheckbox()
        {
            return checkbox;
        }

        public IWebElement getpurchaseelement()
        {
            return purchase;
        }

        public IWebElement getsuccesselement()
        {
            return successmessage;
        }

    }
}
