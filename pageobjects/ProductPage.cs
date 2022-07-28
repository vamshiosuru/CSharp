using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.pageobjects
{
    internal class ProductPage
    {
        private IWebDriver driver;
        public ProductPage(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        By checkoutlocator = By.XPath("//a[@class='nav-link btn btn-primary']");
        By AddtoCardlocator = By.XPath("div/button");

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'card h-100')]")]
        IList<IWebElement> products;

        [FindsBy(How = How.XPath, Using = "//a[@class='nav-link btn btn-primary']")]
        IWebElement checkout;

        public void waitforpagedisplay()
        {
            //IWebElement checkout = driver.FindElement(By.XPath("//a[@class='nav-link btn btn-primary']"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='nav-link btn btn-primary']")));
        }

        public By getcheckoutlocator()
        {
            return checkoutlocator;
        }
        public IList<IWebElement> getproducts()
        {
            return products;
        }
        public IWebElement getcheckout()
        {
            return checkout;
        }
        public By getAddtocartlocator()

        {
            return AddtoCardlocator;
        }
        public CartPage clickcheckout()
        {
            checkout.Click();
            return new CartPage(driver);
        }

    }
}
