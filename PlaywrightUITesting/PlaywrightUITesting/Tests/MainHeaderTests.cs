using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightUITesting.Pages;

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
        public async Task CheckMainHeader()
        {
            await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var page = await browser.NewPageAsync();

            await Page.GotoAsync("https://ecommerce-playground.lambdatest.io/");

            MainHeader mh = new MainHeader(page);
            Assert.AreEqual(6, mh.CheckElementsAreAvailable().Count);

        }
    }
}