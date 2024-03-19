using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Constraints;

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

        public NavigationHeader(IPage Page)
        {
            Home = Page.Locator(".navbar-collapse .horizontal .nav-item").Nth(0);
            Special = Page.Locator(".navbar-collapse .horizontal .nav-item").Nth(1);
            Blog = Page.Locator(".navbar-collapse .horizontal .nav-item").Nth(2);
            MegaMenu = Page.Locator(".mega-menu");
            AddOns = Page.GetByText("AddOns");
            ShopByCategory = Page.GetByLabel("Shop By Category").Nth(1);
            MyAccount = Page.GetByTitle("My account");

        }

        public Dictionary<string, ILocator> AddElementsAreAvailableToBeClicked()
        {
            Dictionary<string, ILocator> items = new Dictionary<string, ILocator>
            {
                    { "Home", Home },
                    { "Special", Special },
                    { "Blog", Blog }
            };

            return items;
        }
    }
}
