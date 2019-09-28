using Autothon.Core.Logger;
using NUnit.Engine;
using System;

namespace Autothon.Core.RunManager
{
    public class TestEventListner : ITestEventListener
    {
        public void OnTestEvent(string report)
        {
            ConsoleLogger.Information(report);
            //parse the xml <start-run count='0'/>
            switch (report)
            {

                case "start-run":
                    //Start of run
                    //ConsoleLogger.Information(report);
                    break;
                case "test-run":
                    //End of run
                    //Console.WriteLine("test");
                    break;
                case "start-suite":
                    //Start of a test suite
                    //Console.WriteLine("test");
                    break;
                case "test-suite":
                    //Console.WriteLine("test");
                    //End of a test suite
                    break;
                case "start-test":
                    //Start of a test case
                    //Console.WriteLine("test");
                    break;
                case "test-case.":
                    //End of a test case
                    //Console.WriteLine("test");
                    break;
            }
        }
    }
}
