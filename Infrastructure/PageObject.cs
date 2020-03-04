using System;
using OpenQA.Selenium;

namespace Infrastructure
{
    public abstract class PageObject
    {
        public abstract string Url {get; }
    }
}
