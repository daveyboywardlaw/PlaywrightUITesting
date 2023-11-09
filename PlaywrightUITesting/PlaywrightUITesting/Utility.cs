using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;

namespace PlaywrightUITesting
{
    internal class Utility : PageTest
    {
        public async Task OpenPage(string homePageUrl)
        {
            await Page.GotoAsync(homePageUrl);
        }
    }
}
