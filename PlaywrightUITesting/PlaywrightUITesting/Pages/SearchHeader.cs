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
    internal class SearchHeader : PageTest
    {
        private IPage _page;
        private readonly ILocator _searchCategory;
        private readonly ILocator _searchText;
        private readonly ILocator _searchButton;
        
        public SearchHeader(IPage page)
        {
            _page = page;
            _searchCategory = _page.GetByText("All Categories");
            _searchText = _page.GetByLabel("Search For Products");
            _searchButton = _page.GetByRole(AriaRole.Button, new() { Name = "Search" });
        }
    }
}
