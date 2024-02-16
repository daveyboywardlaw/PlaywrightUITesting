using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightUITesting.Interfaces
{
    internal interface ICommonActions
    {
        public void ClickButton(IPage page, string buttonText);
        public ILocator FindButton(IPage page, string buttonText);

        public void SelectCategory(string category);

        public void PopulateField(ILocator locator, string value, int elementNumber);
    }
}
