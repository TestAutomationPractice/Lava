using NUnit.Engine;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using static Autothon.Core.SerializationHelper.DeSerializeTestRunHelperModel;

namespace Autothon.Core.RunManager
{
    public class RunManagerNunit
    {
        private static ITestEngine engine = null;
        private static TestEventListner testEventListner = new TestEventListner();
        public static TestRun DeserializeTestRun(XmlNode node)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TestRun));
            TestRun testRun;
            using (XmlReader testrunReader = new XmlNodeReader(node))
            {
                testRun = (TestRun)xmlSerializer.Deserialize(testrunReader);
            }
            return testRun;
        }

        public static TestSuite DeserializeTestSuite(XmlNode node)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TestRun));
            TestSuite testSuite;
            using (XmlReader testrunReader = new XmlNodeReader(node))
            {
                testSuite = (TestSuite)xmlSerializer.Deserialize(testrunReader);
            }
            return testSuite;
        }

        public static TestCase DeserializeTestCase(XmlNode node)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TestRun));
            TestCase testCase;
            using (XmlReader testrunReader = new XmlNodeReader(node))
            {
                testCase = (TestCase)xmlSerializer.Deserialize(testrunReader);
            }
            return testCase;
        }

        public static XmlNode FullRun(List<string> projectAssemblies, string category)
        {
            XmlNode node = null;
            foreach (string assemblyPath in projectAssemblies)
            {
                if (engine == null)
                    engine = TestEngineActivator.CreateInstance();
                TestPackage testPackage = new TestPackage(assemblyPath);
                var filterService = engine.Services.GetService<ITestFilterService>();
                var builder = filterService.GetTestFilterBuilder();
                builder.SelectWhere(category);
                TestFilter filter = builder.GetFilter();

                ITestRunner runner = engine.GetRunner(testPackage);
                var y = runner.CountTestCases(filter);
                node = runner.Run(testEventListner, filter);
                //TestRun testRun = RunManagerNunit.DeserializeTestRun(node);
            }
            return node;

        }
    }
}
