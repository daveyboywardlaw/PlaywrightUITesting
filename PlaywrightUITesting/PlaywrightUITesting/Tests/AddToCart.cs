using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightUITesting.Pages;

namespace PlaywrightUITesting.Tests
{
    internal class AddToCart : PageTest
    {
        private static string url;

        [SetUp]
        public async Task Setup()
        {
            url = TestContext.Parameters["WebAppUrl"]
                 ?? throw new Exception("Web url not configured");

            await Page.GotoAsync(url);
        }

        [Test]
        public async Task AddItemToCart()
        {
            NavigationHeader navHeader = new NavigationHeader(Page);
            MegaMenu mMenu = new MegaMenu(Page);
                        
            await navHeader.MegaMenu.HoverAsync();
            await Page.GetByRole(AriaRole.Link, new() { Name = "Apple", Exact = true }).ClickAsync();
            await Page.GetByText("iPod Nano").Nth(1).ClickAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Add to Cart" }).ClickAsync(); ;
            await Page.GetByText("View Cart").ClickAsync();

            await Expect(Page.Locator("table.table.table-bordered tr:nth-child(4) td:nth-child(1)")).ToContainTextAsync("Total");
        }
    }


   


}
