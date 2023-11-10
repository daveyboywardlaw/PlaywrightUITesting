using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightUITesting.Pages;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrightUITesting.Tests
{
    public class MainHeaderTests : PageTest
    {
        Utility util = new Utility();

        [SetUp]
        public async Task Setup()
        {
        }

        [Test]
        public async Task CheckMainHeaderNonSearchElements()
        {
            await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
               Headless = false
            });

            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://ecommerce-playground.lambdatest.io/");

            MainHeader mh = new MainHeader(page);
            var nonSearchElements = mh.AddElementsAreAvailableToBeClicked();

            foreach (var item in nonSearchElements)
            {
                await item.Value.ClickAsync();

                if (item.Key == "logo")
                {
                    await Expect(page)
                        .ToHaveURLAsync("https://ecommerce-playground.lambdatest.io/index.php?route=common/home");
                }
                if (item.Key == "compare")
                {
                    await Expect(page)
                        .ToHaveURLAsync("https://ecommerce-playground.lambdatest.io/index.php?route=product/compare");
                }
                if (item.Key == "like")
                {
                    await Expect(page)
                        .ToHaveURLAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/login");
                }
                if (item.Key == "cart")
                {
                    await Expect(page.GetByText("Your shopping is empty")).ToBeAttachedAsync();
                }
            } 
        }
    }
}