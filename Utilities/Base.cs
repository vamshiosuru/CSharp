using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace Framework.Utilities
{
    internal class Base
    {
        String browsername;

        //private IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        [SetUp]
        public void setup()
        {
            browsername= TestContext.Parameters["browserName"];
            if(browsername==null)
            {
                browsername = ConfigurationManager.AppSettings["browser"];


            }

           

            initbrowser(browsername);


            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://www.rahulshettyacademy.com/loginpagePractise/";
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public IWebDriver getdriver()
        {
            return driver.Value;
        }
            public void initbrowser(String browser)
        {
            switch (browser)
            {

                case  "Chrome" :
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value= new ChromeDriver();
                    break;

                case "FireFox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;
            
            }

        }
        [TearDown]
        public void teardown()
        {
            driver.Value.Close();
        }
    }
}
