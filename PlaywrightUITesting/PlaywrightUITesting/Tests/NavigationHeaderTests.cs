using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using PlaywrightUITesting.Pages;
using NUnit.Framework.Interfaces;
using System.Reflection.Metadata;
using System.Security.Principal;
using Microsoft.Playwright;
//using VerifyNUnit;

namespace PlaywrightUITesting.Tests
{
    public class NavigationHeaderTests : PageTest
    {
        private static string url;

        [SetUp]
        public void SetupAsync()
        {
            url = TestContext.Parameters["WebAppUrl"]
                  ?? throw new Exception("Web url not configured");

            Page.GotoAsync(url);
        }

        [Test]
        public async Task NavigateLinks()
        {
            NavigationHeader nh = new NavigationHeader(Page);
            var NavigationHeaderElements = nh.AddElementsAreAvailableToBeClicked();

            foreach (var elements in NavigationHeaderElements)
            {
                await elements.Value.ClickAsync();
                
                if (elements.Key == "Home")
                {
                    await Expect(Page)
                        .ToHaveURLAsync("https://ecommerce-playground.lambdatest.io/index.php?route=common/home");
                }
                if (elements.Key == "Special")
                {
                    await Expect(Page)
                        .ToHaveURLAsync("https://ecommerce-playground.lambdatest.io/index.php?route=product/special");
                }
                if (elements.Key == "Blog")
                {
                    await Expect(Page)
                        .ToHaveURLAsync("https://ecommerce-playground.lambdatest.io/index.php?route=extension/maza/blog/home");
                }
            }
        }

        [Test]
        public async Task NavigateLinksShopByCategory()
        {
            NavigationHeader nh = new NavigationHeader(Page);

            await nh.ShopByCategory.ClickAsync();

            await Expect(Page
                    .GetByRole(AriaRole.Heading, new() { Name = "Top Categories" }))
                .ToBeVisibleAsync();
        }

        [Test]
        public async Task NavigateLinksMegMenu()
        {
            NavigationHeader nh = new NavigationHeader(Page);

            await nh.MegaMenu.ClickAsync();

            Expect(Page.GetByTitle("Apple"));
        }


        [Test]
        public async Task NavigateAddOns()
        {
            NavigationHeader nh = new NavigationHeader(Page);

            await nh.AddOns.ClickAsync();

            Expect(Page.GetByTitle("Modules"));
        }
    }
}
