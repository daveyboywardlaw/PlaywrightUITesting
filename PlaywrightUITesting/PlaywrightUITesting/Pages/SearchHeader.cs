using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightUITesting.Pages
{
    public class SearchHeader : PageTest
    {
        public IPage _page;
        public readonly ILocator SearchCategory;
        public readonly ILocator SearchText;
        public readonly ILocator SearchButton;

        public SearchHeader(IPage page)
        {
            SearchCategory = page.GetByText("All Categories");
            SearchText = page.GetByLabel("Search For Products");
            SearchButton = page.GetByRole(AriaRole.Button, new() { Name = "Search" });
        }


    }
}
