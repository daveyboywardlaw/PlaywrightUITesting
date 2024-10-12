using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightUITesting.Pages
{
    internal class RegisterAccount
    {
        public ILocator FirstName;
        public ILocator LastName;
        public ILocator EMail;
        public ILocator Telephone;
        public ILocator Password;
        public ILocator PasswordConfirm;
        public ILocator NewsletterSubscribeYes;
        public ILocator NewsletterSubscribeNo;
        public ILocator CheckAgreePrivacyPolicy;
        public ILocator Continue;

        public RegisterAccount(IPage Page)
        {
            FirstName = Page.Locator("id=input-firstname");
            LastName = Page.Locator("id=input-lastname");
            EMail = Page.Locator("id=input-email");
            Telephone = Page.Locator("id=input-telephone");
            Password = Page.Locator("id=input-password");
            PasswordConfirm = Page.Locator("id=input-confirm");         
            Continue = Page.Locator("css=.btn-primary").Nth(1);
            CheckAgreePrivacyPolicy = Page.GetByText("I have read and agree to the ");
         }
    }
}
