using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightUITesting.Pages;
using System.Threading.Tasks;

namespace PlaywrightUITesting.Tests
{
    internal class SearchHeaderTests : PageTest
    {
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public async Task TestSearchAllCategories()
        {
            await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://ecommerce-playground.lambdatest.io/");
            await page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();

            await Expect(page)
                .ToHaveURLAsync("https://ecommerce-playground.lambdatest.io/index.php?route=product%2Fsearch&search=");

        }
    }
}
