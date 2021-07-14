using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using static Boa.Constrictor.WebDriver.WebLocator;

namespace TestComplete.BoaConstrictorSpecflowDemo.Pages
{
    public interface ILoginPage
    {
        IWebLocator LoginButton { get; }
        IWebLocator PasswordField { get; }
        IWebLocator UserNameField { get; }
    }

    public class LoginPage : ILoginPage
    {
        public IWebLocator UserNameField => L("User Name Field", By.CssSelector("#UsernameOrEmail"));
        public IWebLocator PasswordField => L("Password Field", By.CssSelector("#Password"));
        public IWebLocator LoginButton => L("Login Button", By.CssSelector(".btn-login"));
    }
}
