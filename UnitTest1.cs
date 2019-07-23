using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Subscription_Test.Lib;
using Subscription_Test.Pages;

namespace Subscription_Test
{
    [TestClass]
    public class UnitTest1
    {
       
        OpenBrowser _test;
        Fitness_Subscription _fs;
       
        [TestInitialize]
        public void setup()
        {
            _test = new OpenBrowser();
            _fs = new Fitness_Subscription(_test);
            
        }
        
        [TestMethod]
        public void FitnessSub()
        {
    
            _test.InitializeBrowse();
            Thread.Sleep(3000);
            _fs.FitnessHeaderValidation();
            _fs.FitnessHeaderInvalid();
            _fs.FitnessHeaderNewEmail();
            
        }
    }
}

