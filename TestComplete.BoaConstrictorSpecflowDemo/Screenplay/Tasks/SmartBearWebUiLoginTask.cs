using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using System;
using System.Collections.Generic;
using System.Text;
using TestComplete.BoaConstrictorSpecflowDemo.Pages;

namespace TestComplete.BoaConstrictorSpecflowDemo.Screenplay.Tasks
{
    public class SmartBearWebUiLoginTask : ITask
    {
        private readonly LoginBuilder _loginBuilder;

        private SmartBearWebUiLoginTask(LoginBuilder loginBuilder)
        {
            _loginBuilder = loginBuilder;
        }

        public static LoginBuilder Login()
        {
            return new LoginBuilder();
        }

        public class LoginBuilder
        {
            public ILoginPage LoginPage { get; private set; }
            public string UserName { get; private set; }
            public string Password { get; private set; }
            public string Url { get; private set; }

            public LoginBuilder As(string userName)
            {
                UserName = userName;
                return this;
            }

            public LoginBuilder WithPassword(string password)
            {
                Password = password;
                return this;
            }

            public LoginBuilder To(string url)
            {
                Url = url;
                return this;
            }

            public SmartBearWebUiLoginTask From(ILoginPage loginPage)
            {
                LoginPage = loginPage;
                return new SmartBearWebUiLoginTask(this);
            }
        }

        public void PerformAs(IActor actor)
        {
            actor.AttemptsTo(
                Navigate.ToUrl(_loginBuilder.Url),
                SendKeys.To(_loginBuilder.LoginPage.UserNameField, _loginBuilder.UserName),
                SendKeys.To(_loginBuilder.LoginPage.PasswordField, _loginBuilder.Password),
                Click.On(_loginBuilder.LoginPage.LoginButton)
                );
        }

        public override string ToString() => $"Login to {_loginBuilder.Url} as {_loginBuilder.UserName}";

    }
}
