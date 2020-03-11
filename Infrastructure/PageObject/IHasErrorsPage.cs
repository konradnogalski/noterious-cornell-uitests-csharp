using OpenQA.Selenium;
using System.Collections.Generic;

namespace Infrastructure.PageObject
{
    public interface IHasErrorsPage
    {
        List<string> Errors { get; }
    }
}
