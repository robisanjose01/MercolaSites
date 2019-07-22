using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Subscription_Test.Lib
{

    public class OpenBrowser
    {
        public IWebDriver driver = new ChromeDriver();
        String FURL = "https://fitness.mercola.com/";

        public void InitializeBrowse()
        {
            driver.Navigate().GoToUrl(FURL);
            driver.Manage().Window.Maximize();
        }
    }
}