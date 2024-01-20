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
            private readonly ILocator _compare;
            private readonly ILocator _like;
            private readonly ILocator _cart;
            
        public MainHeader(IPage page)
        {
            _page = page;
            _logo = _page.GetByRole(AriaRole.Link, new() { Name = "Poco Electro" });
            _compare  = _page.GetByLabel("Compare");
            _like = _page.GetByLabel("WishList");
            _cart = _page.GetByRole(AriaRole.Button, new() { Name = "0" });
            _search = _page.GetByLabel("Search For Products");
        }
        public Dictionary<string, ILocator> AddElementsAreAvailableToBeClicked()
        {
            Dictionary<string, ILocator> items = new Dictionary<string, ILocator>();
            items.Add("logo", _logo);
            items.Add("compare", _compare);
            items.Add("like", _like);
            items.Add("cart",_cart);

            return items;
        }
        //public async Task ClickSearch() => await _search.ClickAsync();
    }
}
