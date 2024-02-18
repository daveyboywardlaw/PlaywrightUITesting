using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;

namespace PlaywrightUITesting.Tests
{
    internal class NavigationHeaderTests : PageTest
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
        public async Task SearchAllCategories()
        {
            await Page.GotoAsync(url);
            actions.ClickButton(Page, "Search");

            //Assertion
            await Expect(Page)
                .ToHaveURLAsync("https://ecommerce-playground.lambdatest.io/index.php?route=product%2Fsearch&search=");
        }
    }
}
