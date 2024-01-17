using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightUITesting
{
    public class CommonActions : PageTest
    {
        public void ClickButton(IPage page,  string buttonText)
        {
            var button =  page.GetByRole(AriaRole.Button, new() { Name = buttonText }).ClickAsync();
        }

        public ILocator FindButton(IPage page, string buttonText)
        {
            return page.GetByRole(AriaRole.Button, new() { Name = buttonText });
        }

        public void SelectCategory(string category)
        {
            // Method to select a dropdown value
        }

        public void PopulateField(ILocator locator, string value)
        {
            locator.FillAsync(value);
        }

    }
}
