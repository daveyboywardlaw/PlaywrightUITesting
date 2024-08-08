using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightUITesting.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using System.Security.Cryptography.X509Certificates;

namespace PlaywrightUITesting.Tests
{
    internal class RegisterAccountTest : PageTest
    {
        CommonActions actions = new CommonActions();
        private static string url;
        public Guidance guidance = new Guidance();
        public List<string> guidanceMessages;

        [SetUp]
        public void SetupAsync()
        {
            url = TestContext.Parameters["WebAppUrl"]
                  ?? throw new Exception("Web url not configured");

            Page.GotoAsync(url);

           
        }

        [Test]
        public async Task ClickContinueWIthNoData()
        {
            //NavigationHeader navHead = new NavigationHeader(Page);
            //RegisterAccount regAccount = new RegisterAccount(Page);
            //AccountLogIn accLogIn = new AccountLogIn(Page);
            //CommonActions commActions = new CommonActions();


            //await navHead.MyAccount.ClickAsync();
            //await accLogIn.NewCustomerContinue.ClickAsync();
            //await regAccount.Continue.ClickAsync();

            List<String> guidanceMessages = guidance.GenerateGuidanceForRegisterAccount();

            RegisterAccount regAccount = new RegisterAccount(Page);
            await regAccount.Continue.ClickAsync();
            
            await GoToRegisterAccount();

            foreach (var item in guidanceMessages)
            {
                var GuidanceMessage = Page.GetByText(item);

                await Expect(GuidanceMessage).ToHaveTextAsync(item);
            }                       
        }

        [Test]
        public async Task RegisterAccount()
        {
            RegisterAccount regAccount = new RegisterAccount(Page);
            List<String> guidanceMessages = guidance.GenerateGuidanceForRegisterAccount();

            await GoToRegisterAccount();
            await regAccount.FirstName.FillAsync("Bill");
            await regAccount.LastName.FillAsync("Smith");
            await regAccount.EMail.FillAsync("test@test.com");
            await regAccount.Telephone.FillAsync("123456");
            await regAccount.Password.FillAsync("password");
            await regAccount.PasswordConfirm.FillAsync("password");
            await regAccount.CheckAgreePrivacyPolicy.ClickAsync();

            await regAccount.Continue.ClickAsync();

        }



        public async Task GoToRegisterAccount()
        {
            NavigationHeader navHead = new NavigationHeader(Page);
            
            AccountLogIn accLogIn = new AccountLogIn(Page);
            CommonActions commActions = new CommonActions();

            await navHead.MyAccount.ClickAsync();
            await accLogIn.NewCustomerContinue.ClickAsync();
          

        }

    }
}
