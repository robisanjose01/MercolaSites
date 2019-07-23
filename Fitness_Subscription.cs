using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Subscription_Test.Lib;

namespace Subscription_Test.Pages
{
    public class Fitness_Subscription
    {
        private OpenBrowser _test;
        
        public Fitness_Subscription(OpenBrowser methods)
        {
            _test = methods;
        }
            List<String> list = new List<String>();
            public By sub_header = By.Id("NLSubscriptionTop_NewsletterSubscriptionTop_emailAddress");
            public By sub_footer = By.Id("NLSubscriptionBottom_emailAddress");
            public By sub_header_button = By.Id("NLSubscriptionTop_NewsletterSubscriptionTop_Subscribe");
            public By sub_footer_button = By.Id("NLSubscriptionBottom_Subscribe");
            public IAlert Alert1;
            public String Alert2;
            public String Alert3;
            public String invalid1 = " ";
            public String invalid2 = "asdasdawd@#$.com";
            public String invalid3 = "#$@yahoo.com";
            public String invalid4 = "asdawdawd@yahoo.gom";
            public String invalid5 = "adadasdadw@asdadw.com";
            public String invali = "You have entered an invalid email address. Please enter a valid email address.";
            public String suc_email = "You have successfully subscribed!";
            public String suc_existing = "Your subscription has been updated!";
            public String valid1 = "fhtest38@yahoo.com";
            public String valid2 = "fftest02@yahoo.com";
            public String valid3 = "roberts@mercola.com";

        public void FitnessHeaderValidation()
        {
            list.Add(invalid1);
            list.Add(invalid2);
            list.Add(invalid3);
            list.Add(invalid4);

            foreach (var fitvalidation in list)
            {
                IWebDriver driver = _test.driver;
                driver.FindElement(sub_header).SendKeys(fitvalidation);
                driver.FindElement(sub_header_button).Click();
                Thread.Sleep(3000);
                Alert1 = driver.SwitchTo().Alert();  
                Alert2 = Alert1.Text;
                Alert1.Accept();
                Thread.Sleep(500);
                IWebElement clear = driver.FindElement(sub_header);
                clear.Clear();
                
                Alert3 = Alert2;
                Assert.AreEqual(Alert2, Alert3);
             
            }
        }

        public void FitnessHeaderInvalid()
        {
            IWebDriver driver = _test.driver;
            driver.FindElement(sub_header).SendKeys(invalid5);
            driver.FindElement(sub_header_button).Click();
            var invalemail = driver.FindElement(By.XPath("//span[@id='SubscriptionHeader_contentArea_lblErrMsg']")).Text;
            Assert.AreEqual(invali, invalemail);
  
         }
         
         public void FitnessHeaderNewEmail()
         {
            
            _test.InitializeBrowse();
            IWebDriver driver = _test.driver;
            driver.FindElement(sub_header).SendKeys(valid1);
            driver.FindElement(sub_header_button).Click();
            Thread.Sleep(3000);
            var newemail1 = driver.FindElement(By.XPath("//h3[contains(text(),'You have successfully subscribed!')]")).Text;
            Assert.AreEqual(suc_email, newemail1);
            driver.Manage().Cookies.DeleteAllCookies();
            
         
         }
         public void FitnessHeaderExisting()
         {
             _test.InitializeBrowse();
             IWebDriver driver = _test.driver;
             driver.FindElement(sub_header).SendKeys(valid3);
             driver.FindElement(sub_header_button).Click();
             Thread.Sleep(5000);
             String existing = driver.FindElement(By.XPath("//span[@id='bcr_lblMsg']")).Text;
             Assert.AreEqual(suc_existing, existing);  
             driver.Manage().Cookies.DeleteAllCookies();

         }
         public void FitnessFooterValidation()
         {
             list.Add(invalid1);
             list.Add(invalid2);
             list.Add(invalid3);
             list.Add(invalid4);

             foreach (var fitvalidation in list)
             {
                 
                 IWebDriver driver = _test.driver;
                 driver.FindElement(sub_footer).SendKeys(fitvalidation);
                 driver.FindElement(sub_footer_button).Click();
                 Thread.Sleep(3000);
                 Alert1 = driver.SwitchTo().Alert();
                 Alert2 = Alert1.Text;
                 Alert1.Accept();
                 Thread.Sleep(500);
                 IWebElement clear = driver.FindElement(sub_footer);
                 clear.Clear();

                 Console.WriteLine("Email Address: " + fitvalidation);
                 Console.WriteLine("Message: " + Alert2);
                 Alert3 = Alert2;
                 Assert.AreEqual(Alert2, Alert3);

             }
         }

         public void FitnessFooterInvalid()
         {

             IWebDriver driver = _test.driver;
             driver.FindElement(sub_footer).SendKeys(invalid5);
             driver.FindElement(sub_footer_button).Click();
             var invalemail = driver.FindElement(By.XPath("//span[@id='SubscriptionHeader_contentArea_lblErrMsg']")).Text;
             Assert.AreEqual(invali, invalemail);

         }

         public void FitnessFooterNewEmail()
         {

             _test.InitializeBrowse();
             IWebDriver driver = _test.driver;
             driver.FindElement(sub_footer).SendKeys(valid2);
             driver.FindElement(sub_footer_button).Click();
             Thread.Sleep(3000);
             var newemail1 = driver.FindElement(By.XPath("//h3[contains(text(),'You have successfully subscribed!')]")).Text;
             Assert.AreEqual(suc_email, newemail1);
             driver.Manage().Cookies.DeleteAllCookies();


         }
         public void FitnessFooterExisting()
         {
             
             IWebDriver driver = _test.driver;
             driver.FindElement(sub_footer).SendKeys(valid3);
             driver.FindElement(sub_footer_button).Click();
             Thread.Sleep(5000);
             String existing = driver.FindElement(By.XPath("//span[@id='bcr_lblMsg']")).Text;
             Assert.AreEqual(suc_existing, existing);

         }
      }
  }


