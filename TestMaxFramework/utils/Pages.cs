using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestMaxFramework.pages;
using TestMaxFramework.utils;
using NSelene;
using static NSelene.Selene;

namespace TestMaxFramework.utils
{
    public class Pages
    {
        private static T getPages<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(GetWebDriver(), page);
            return page;
        }

    }
}