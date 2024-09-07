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
        CommonActions util = new CommonActions();
        private static string url;

        [SetUp]
        public async Task Setup()
        {
            url = TestContext.Parameters["WebAppUrl"]
                 ?? throw new Exception("Web url not configured");
            
            await Page.GotoAsync(url);
        }

        [Test]
        public async Task CheckMainHeaderNonDropDownElements()
        {      
            MainHeader mh = new MainHeader(Page);
            var nonSearchElements = mh.AddElementsAreAvailableToBeClicked();

            foreach (var item in nonSearchElements)
            {
                await item.Value.ClickAsync();

                if (item.Key == "logo")
                {
                    await Expect(Page)
                        .ToHaveURLAsync("https://ecommerce-playground.lambdatest.io/index.php?route=common/home");
                }
                if (item.Key == "compare")
                {
                    await Expect(Page)
                        .ToHaveURLAsync("https://ecommerce-playground.lambdatest.io/index.php?route=product/compare");
                }
                if (item.Key == "like")
                {
                    await Expect(Page)
                        .ToHaveURLAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/login");
                }
                if (item.Key == "cart")
                {
                    await Expect(Page.GetByText("Your shopping cart is empty")).ToBeAttachedAsync();
                }
            } 
        }
    }
}