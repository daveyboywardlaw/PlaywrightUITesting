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
        public async Task RegisterAlreadyRegisteredAccount()
        {
            RegisterAccount regAccount = new RegisterAccount(Page);
            List<String> guidanceMessages = guidance.GenerateGuidanceForRegisterAccount();

            await GoToRegisterAccount();

            await PopulateFields("Bob", "Bill", "dave@dave.com", "678789", "password", "password");
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

        public async Task PopulateFields(string FirstName = "", string LastName = "", String Email = "",
            string Phone = "", String Password = "", string PasswordConfirm = "")
        {
           Dictionary<String,String> fieldsToPopulate = new Dictionary<string, string>();

            fieldsToPopulate.Add("FirstName", FirstName);
            fieldsToPopulate.Add("LastName", LastName);
            fieldsToPopulate.Add("EMail", Email);
            fieldsToPopulate.Add("Phone", Phone);
            fieldsToPopulate.Add("Password", Password);
            fieldsToPopulate.Add("ConfirmPassword", PasswordConfirm);

            foreach (var item in fieldsToPopulate)
            {
                if (item.Value == "")
                {
                    fieldsToPopulate.Remove(item.Key);
                }                  
            }

            RegisterAccount regAccount = new RegisterAccount(Page);

            foreach (var item in fieldsToPopulate)
            {
                if (item.Key == "FirstName")
                    await regAccount.FirstName.FillAsync(item.Value);
                if (item.Key == "LastName")
                    await regAccount.LastName.FillAsync(item.Value);
                if (item.Key == "EMail")
                    await regAccount.EMail.FillAsync(item.Value);
                if (item.Key == "Phone")
                    await regAccount.Telephone.FillAsync(item.Value);
                if (item.Key == "Password")
                    await regAccount.Password.FillAsync(item.Value);
                if (item.Key == "ConfirmPassword")
                    await regAccount.PasswordConfirm.FillAsync(item.Value);
            } 

        }

    }
}
