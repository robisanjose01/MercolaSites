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
            public IAlert HeaderAlert1;
            public String HeaderAlert2;
            public String HeaderAlert3;
            public String invalid1 = " ";
            public String invalid2 = "asdasdawd@#$.com";
            public String invalid3 = "#$@yahoo.com";
            public String invalid4 = "asdawdawd@yahoo.gom";
            public String valid1 = "fhtest10@yahoo.com";
            public String valid2 = "roberts@mercola.com";

            public By sub_header = By.Id("NLSubscriptionTop_NewsletterSubscriptionTop_emailAddress");
            public By sub_header_button = By.Id("NLSubscriptionTop_NewsletterSubscriptionTop_Subscribe");
        
        public void FitnessHeader_Invalid()
        {
            list.Add(invalid1);
            list.Add(invalid2);
            list.Add(invalid3);
            list.Add(invalid4);
            
         foreach (var fitinvalid in list)
         {
             IWebDriver driver = _test.driver;
             driver.FindElement(sub_header).SendKeys(fitinvalid);
             driver.FindElement(sub_header_button).Click();
             Thread.Sleep(3000);
             HeaderAlert1 = driver.SwitchTo().Alert();
             HeaderAlert2 = HeaderAlert1.Text;
             HeaderAlert1.Accept();
             Thread.Sleep(500);
             IWebElement clear = driver.FindElement(sub_header);
             clear.Clear();

             HeaderAlert3 = HeaderAlert2;
             Assert.AreEqual(HeaderAlert3, HeaderAlert2);
             Console.WriteLine("Email Address: " + fitinvalid + "Message: " + HeaderAlert2);
             
          }
          }

         public void FitnessHeaderNewEmail()
          {
            IWebDriver driver = _test.driver;
            driver.FindElement(sub_header).SendKeys(valid1);
            driver.FindElement(sub_header_button).Click();
            Thread.Sleep(3000);
            

          }
      }
  }


