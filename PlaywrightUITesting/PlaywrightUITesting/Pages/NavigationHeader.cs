using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightUITesting.Pages
{
    internal class NavigationHeader : PageTest
    {
        public ILocator ShopByCategory;
        public ILocator Home;
        public ILocator Special;
        public ILocator Blog;
        public ILocator MegaMenu;
        public ILocator AddOns;
        public ILocator MyAccount;
        public NavigationHeader()
        {
            ShopByCategory = Page.GetByLabel("Shop by Category");
            Home = Page.GetByText("Home");
            Special = Page.GetByText("Special");
            Blog = Page.GetByText("Blog");
            MegaMenu = Page.GetByText("Mega Menu");
            AddOns = Page.GetByText("AddOns");
            MyAccount = Page.GetByText("My Account");
        }

        public Dictionary<string, ILocator> AddElementsAreAvailableToBeClicked()
        {
            Dictionary<string, ILocator> items = new Dictionary<string, ILocator>();
            items.Add("Shop By Category", ShopByCategory);
            items.Add("Home", Home);
            items.Add("Special", Special);
            items.Add("Blog", Blog);
            items.Add("Mega Menu", MegaMenu);
            items.Add("AddOns", AddOns);
            items.Add("My Account", MyAccount);

            return items;
        }
    }
}
