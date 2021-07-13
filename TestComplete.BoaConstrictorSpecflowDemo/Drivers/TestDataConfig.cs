using DotNetEnv;
using System;

namespace TestComplete.BoaConstrictorSpecflowDemo.Drivers
{
    public class TestDataConfig
    {

        public TestDataConfig()
        {
            //todo - add logging for non screenplay activities
            Console.WriteLine("Loading Config from TestCompleteTestDataConfig.env");
            Env.TraversePath().Load("TestCompleteTestDataConfig.env");
        }

        public string DefaultPassword => Env.GetString("PORTAL_DEFAULT_PASSWORD");
        public string DefaultUrl => Env.GetString("PORTAL_DEFAULT_URL");


    }
}
