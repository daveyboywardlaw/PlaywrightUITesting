using Microsoft.Playwright;

namespace PlaywrightUITesting
{
    public class Utilities
    {
        public async Task<IPage> CreateNewPage()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Webkit.LaunchAsync();
            var page = await browser.NewPageAsync();
            return page;
        }
    }
}