using System;
using System.Collections.Generic;
using System.Text;

using DotNetEnv;

namespace TestComplete.BoaConstrictorSpecflowDemo.Drivers
{
    class TestDataConfig
    {
        private readonly Lazy<string> _defaultPassword;

        public TestDataConfig()
        {
            _defaultPassword = new Lazy<string>(() =>
            {
                return Env.GetString("portal.defaultPassword");
            });
        }

        public string DefaultPassword
        {
            get
            {
                return _defaultPassword.Value;
            }
        }
    }
}
