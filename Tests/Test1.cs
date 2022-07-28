using Framework.pageobjects;
using Framework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Tests
{

    //command line execution
    //dotnet test Farmework(Projectname).csproj
    // with category options :  dotnet test Farmework(Projectname).csproj --filter TestCategory=Smoke

    //with providing browser value during run time :dotnet test Framework.csproj      --filter TestCategory=Regression -- TestRunParameters.Parameter(name=\"browserName\",value=\"Edge\")
    [Parallelizable(ParallelScope.Self)]
    //[Parallelizable(ParallelScope.Children)] // all test method of a class in parallel
    internal class Test1 :Base
    {
        public IWebDriver driver ;


        //all test data of a test case in parallel
        // all test method of a class in parallel
        //all test method of different classes in a project in parallel
        [Test,Category("Smoke")]
        public void anotherTest()
        {
            driver = getdriver();
            driver.Url = "https://www.scoopwhoop.com/Celebrities-Who-Talked-About-Mental-Illnesses/#.ho37kc70o";
        }
        [Test,Category("Regression")]
        //below are N Unit features
        //[TestCase("rahulshettyacademy", "learning")]
        //[TestCase("rahulshettyacademy1", "learning1")] -this test cases executes 2 times
        [TestCaseSource("Addtestdata")]// takes parameters from mentioned method and executes test case one at a time with
        [Parallelizable(ParallelScope.All)]//all test data of a test case in parallel
        public void EndToEnd(String username,String password, String[] items)
        {
            driver = getdriver();
            
            LoginPage login = new LoginPage(driver);
            Console.WriteLine(username+" ***** "+password);
            ProductPage productPage= login.validLogin(username, password);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            /* login.getUsername().SendKeys("rahulshettyacademy");
             login.getPassword().SendKeys("learning");
            // driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
             //driver.FindElement(By.CssSelector("input#password")).SendKeys("learning");

             IList<IWebElement> radio = driver.FindElements(By.CssSelector("input[type='radio']"));
             //IList<IWebElement> radio = login.getRadio();

             foreach (IWebElement radioElement in radio)
             {
                 if (radioElement.GetAttribute("value").Equals("user"))
                 {
                     radioElement.Click();


                     wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='okayBtn']")));
                     driver.FindElement(By.XPath("//button[@id='okayBtn']")).Click();
                     break;
                 }

             }

             //IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
             IWebElement dropdown = login.getDropDown();
             SelectElement select = new SelectElement(dropdown);
             select.SelectByText("Teacher");


           //  driver.FindElement(By.CssSelector("div[class='form-group'] label span:nth-child(1) input")).Click();
             login.getcheckbox().Click();
             //driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
             login.getsignIn().Click();*/


           // IWebElement checkout = driver.FindElement(By.XPath("//a[@class='nav-link btn btn-primary']"));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(productPage.getcheckoutlocator()));
            //String[] items = { "iphone X", "Blackberry" };


            IList<IWebElement> products = productPage.getproducts();
            //Thread.Sleep(5000);
            // IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("window.scroll(0,600)");
            foreach (IWebElement product in products)
            {
                // Console.WriteLine(product.Text);
                //String itemtext = product.Text;
                String itemtext = product.FindElement(By.XPath("div//h4/a")).Text;
                Console.WriteLine(itemtext);
                foreach (String item in items)
                {
                    if (itemtext.Equals(item))
                    {
                        product.FindElement(productPage.getAddtocartlocator()).Click();
                    }

                }

            }
            CartPage cart=productPage.clickcheckout();
            Thread.Sleep(3000);
            //  IList<IWebElement> cartpage = driver.FindElements(By.XPath("//h4[@class='media-heading']//a"));
            IList<IWebElement> cartpage= cart.getproductsincartpage();
            ArrayList a = new ArrayList();
            foreach (IWebElement c in cartpage)
            {
                a.Add(c.Text);
            }
            //a.Add("ff");
            //String[] b=a.ToArray(new String[a.Count]);
            //ArrayList d=items.ToList();
            // object[] o=a.ToArray();
            string[] arr = a.ToArray(typeof(String)) as String[];
            Assert.AreEqual(items, arr);

            //driver.FindElement(By.XPath("//button[@class='btn btn-success']")).Click();
            //Assert.IsTrue(arr.Equals(items));
           PurchasePage purchase= cart.clickcheckoutincartspage();
         purchase.getcountryfield().SendKeys("Ind");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click();

            Thread.Sleep(3000);
            purchase.getcheckbox().Click();
            purchase.getpurchaseelement().Click();
            

           // driver.FindElement(By.XPath("//label[@for='checkbox2']")).Click();
           // driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            Console.WriteLine(purchase.getsuccesselement().Text);

        }

        public static IEnumerable<TestCaseData> Addtestdata()
        {
            JsonReader json = new JsonReader();
/*
            yield return new TestCaseData("rahulshettyacademy", "learning");
            yield return new TestCaseData("rahulshettyacademy1", "learning1");
            yield return new TestCaseData("rahulshettyacademy2", "learning2");*/

            yield return new TestCaseData(json.extractdata("username"), json.extractdata("password"),json.extractdataArray("products"));
           yield return new TestCaseData(json.extractdata("username_invalid"), json.extractdata("password_invalid"), json.extractdataArray("products"));

        }
    }
}
