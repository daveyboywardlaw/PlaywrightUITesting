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
using VerifyNUnit;

namespace PlaywrightUITesting.Tests
{
    public class NavigationHeaderTests : PageTest
    {    
        CommonActions actions = new CommonActions();
        private static string url;

        [SetUp]
        public void SetupAsync()
        {
            url = TestContext.Parameters["WebAppUrl"]
                  ?? throw new Exception("Web url not configured");
        }

        [Test]
        public async Task NavigateLinks()
        {
            await Page.GotoAsync(url);

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
        public async Task NavigateLinksWithDropDowns()
        {
            await Page.GotoAsync(url);

            NavigationHeader nh = new NavigationHeader(Page);

            await nh.MegaMenu.ClickAsync();
            var currentScreenShot = await Page.ScreenshotAsync();
            


            await Expect(Page)
                .ToHaveURLAsync("https://ecommerce-playground.lambdatest.io/index.php?route=extension/maza/blog/home");

        }
    }
}
