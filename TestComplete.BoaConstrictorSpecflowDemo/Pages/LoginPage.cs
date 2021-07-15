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
        public IWebLocator UserNameField => L(description: "User Name Field", query: By.CssSelector(cssSelectorToFind: "#UsernameOrEmail"));
        public IWebLocator PasswordField => L(description: "Password Field", query: By.CssSelector(cssSelectorToFind: "#Password"));
        public IWebLocator LoginButton => L(description: "Login Button", query: By.CssSelector(cssSelectorToFind: ".btn-login"));
    }
}
