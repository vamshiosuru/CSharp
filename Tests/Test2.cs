using Framework.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Tests
{
    [Parallelizable(ParallelScope.Self)]
    internal class Test2 :Base
    {
       // public IWebDriver driver;
        [Test]
        public void Alert()
        {
            //driver = getdriver();
            driver.Value.Url = "https://www.rahulshettyacademy.com/AutomationPractice/";
            driver.Value.FindElement(By.CssSelector("input[name='enter-name']")).SendKeys("vamshi");
            driver.Value.FindElement(By.CssSelector("input#confirmbtn")).Click();
            String text = driver.Value.SwitchTo().Alert().Text;
            driver.Value.SwitchTo().Alert().Accept();
            Assert.IsTrue(text.Contains("vamshi"));
            StringAssert.Contains("vamshi", text);

        }
    }
}
