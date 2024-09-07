using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        CommonActions actions = new CommonActions();
        private static string url;

        [SetUp]
        public void SetupAsync()
        {
            url = TestContext.Parameters["WebAppUrl"]
                  ?? throw new Exception("Web url not configured");

            Page.GotoAsync(url);
        }

        [Test]
        public async Task SearchAllCategories()
        {
            //await Page.GotoAsync(url);
            actions.ClickButton(Page, "Search");
         
            //Assertion
            await Expect(Page)
                .ToHaveURLAsync("https://ecommerce-playground.lambdatest.io/index.php?route=product%2Fsearch&search=");
        }

        [Test]
        public async Task SearchPhones()
        {
            SearchHeader searchHeader = new SearchHeader(Page);
            await Page.GotoAsync(url);

            actions.PopulateField(searchHeader.SearchText, "Phones");
            actions.ClickButton(Page, "Search");

            //Assertion
            await Expect(Page)
                .ToHaveURLAsync("https://ecommerce-playground.lambdatest.io/index.php?route=product%2Fsearch&search=Phones");
        }
    }
}
