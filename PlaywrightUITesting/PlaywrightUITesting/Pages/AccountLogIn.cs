using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightUITesting.Pages
{
    internal class AccountLogIn
    {
        public ILocator NewCustomerContinue;

        public AccountLogIn(IPage Page)
        {
            NewCustomerContinue = Page.GetByText("Continue");
        }
    }
}
