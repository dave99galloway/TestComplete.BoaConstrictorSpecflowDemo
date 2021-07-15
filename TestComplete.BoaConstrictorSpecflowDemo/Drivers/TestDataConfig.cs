using DotNetEnv;
using System;

namespace TestComplete.BoaConstrictorSpecflowDemo.Drivers
{
    public class TestDataConfig
    {
        public TestDataConfig()
        {
            //todo - add logging for non screenplay activities
            Console.WriteLine(value: "Loading Config from TestCompleteTestDataConfig.env");
            Env.TraversePath().Load(path: "TestCompleteTestDataConfig.env");
        }

        public string DefaultPassword => Env.GetString(key: "PORTAL_DEFAULT_PASSWORD");
        public string DefaultUrl => Env.GetString(key: "PORTAL_DEFAULT_URL");
    }
}
