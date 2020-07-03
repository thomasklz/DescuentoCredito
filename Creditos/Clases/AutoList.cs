using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Creditos.Clases
{
    public class AutoList{
        
        static void Main(string[] args){
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://localhost:57466/ingresos");
            driver.Manage().Window.Maximize();




        }


    }
}