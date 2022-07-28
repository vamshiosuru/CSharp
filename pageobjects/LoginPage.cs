using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.pageobjects
{
    internal class LoginPage
        
    {
       private  IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
        //driver.FindElement(By.CssSelector("input#password")).SendKeys("learning");
        // driver.FindElements(By.CssSelector("input[type='radio']"));
        //driver.FindElement(By.CssSelector("select.form-control"));
        // driver.FindElement(By.CssSelector("div[class='form-group'] label span:nth-child(1) input")).Click();
        //   driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();

        //Page factory
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.CssSelector, Using = "input#password")]
        private IWebElement password;

        [FindsBy(How = How.CssSelector, Using = "input[type='radio']")]
        private IList<IWebElement> radio;

        [FindsBy(How = How.CssSelector, Using = "select.form-control")]
        private IWebElement dropdown;

        [FindsBy(How = How.CssSelector, Using = "div[class='form-group'] label span:nth-child(1) input")]
        private IWebElement checkbox;

        [FindsBy(How = How.XPath, Using = "//input[@value='Sign In']")]
        private IWebElement signin;


        public IWebElement getPassword()
        {
            return password;
        }
        public IWebElement getUsername()
        {
            return username;
        }
       /* public List<IWebElement> getRadio()
        {
            return radio;
        }*/
        public IWebElement getDropDown()
        {
            return dropdown;
        }
        public IWebElement getcheckbox()
        {
            return checkbox;
        }
        public IWebElement getsignIn()
        {
            return signin;
        }
        public ProductPage validLogin(String userID,String pswd)
        {
            username.SendKeys(userID);
            password.SendKeys(pswd);
            checkbox.Click();
            signin.Click();
            return new ProductPage(driver);
        }
    }
}
