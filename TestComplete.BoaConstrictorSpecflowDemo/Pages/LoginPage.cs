using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestComplete.BoaConstrictorSpecflowDemo.Pages
{
    public interface ILoginPage
    {
        By LoginButton { get; }
        By PasswordField { get; }
        By UserNameField { get; }
    }

    public class LoginPage : ILoginPage
    {
        public LoginPage()
        {
            Console.WriteLine("init LoginPage");
        }
        public By UserNameField => By.CssSelector("#UsernameOrEmail");
        public By PasswordField => By.CssSelector("#Password");
        public By LoginButton => By.CssSelector(".btn-login");
    }
}
