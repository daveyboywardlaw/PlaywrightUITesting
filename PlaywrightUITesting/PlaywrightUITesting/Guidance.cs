using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightUITesting
{
    public class Guidance : PageTest
    {
        public Guidance()
        {

        }

        public List<String> GenerateGuidanceForRegisterAccount()
        {
            List<String> RegisterAccountGuidance = new List<String>();

            RegisterAccountGuidance.Add("Warning: You must agree to the Privacy Policy!");
            RegisterAccountGuidance.Add("First Name must be between 1 and 32 characters!");
            RegisterAccountGuidance.Add("Last Name must be between 1 and 32 characters!");
            RegisterAccountGuidance.Add("E-Mail Address does not appear to be valid!");
            RegisterAccountGuidance.Add("Telephone must be between 3 and 32 characters!");
            RegisterAccountGuidance.Add("Password must be between 4 and 20 characters!");

            return RegisterAccountGuidance;
        }

        public string DuplicateAccountGuidance
        {
            get
            {
                return "Warning: E-Mail Address is already registered!";
            }
            set 
            { }
        }

    }
}
