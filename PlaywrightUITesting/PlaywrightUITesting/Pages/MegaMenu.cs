using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightUITesting.Pages
{
    internal class MegaMenu : PageTest
    {


        private IPage _page;
        private readonly ILocator _megaMenu;

        public MegaMenu(IPage page)
        {
        }

        public async Task ClickMegaMenuItem(string menuItem)
        {
            var itemToClick = Page.GetByTitle(menuItem);
            await itemToClick.ClickAsync();
        }

    }
}
