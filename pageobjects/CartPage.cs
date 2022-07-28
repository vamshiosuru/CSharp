using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.pageobjects
{
    internal class CartPage
    {
        private IWebDriver driver;
        public CartPage(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//h4[@class='media-heading']//a")]
        IList<IWebElement> productsincartpage;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-success']")]
        IWebElement submitincartspage;

        public IList<IWebElement> getproductsincartpage()
        {
            return productsincartpage;
        }

        public PurchasePage clickcheckoutincartspage()
        {
            submitincartspage.Click();
            return new PurchasePage(driver);
        }
    }
}
