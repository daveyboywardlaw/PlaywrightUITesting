using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightUITesting.Pages
{
    public class MainHeader : PageTest
    {
            private IPage _page;
            private readonly ILocator _logo;
            private readonly ILocator _categoryDropdown;
            private readonly ILocator _search;
            private readonly ILocator _searchButton;
            private readonly ILocator _compare;
            private readonly ILocator _like;

            public MainHeader(IPage page)
            {
                _page = page;
                _logo = _page.GetByLabel("Poco Electro");
                _categoryDropdown = _page.GetByLabel("All Categories");
                _search = _page.GetByLabel("Search for Products");
                _searchButton = _page.GetByRole(AriaRole.Button, new() { Name = "Search" });
                _compare = _page.GetByTitle("Compare");
                _like= _page.GetByTitle("Wishlist");
            }

            public List<ILocator> CheckElementsAreAvailable()
            {
                List<ILocator> items = new List<ILocator>();
                items.Add(_logo);
                items.Add(_categoryDropdown);
                items.Add(_search);
                items.Add(_searchButton);
                items.Add(_compare);
                items.Add(_like);

                return items;
            }

            //public async Task ClickSearch() => await _search.ClickAsync();
    }
}
