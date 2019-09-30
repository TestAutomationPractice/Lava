using Autothon.Core.RunManager;
using NDesk.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Autothon.Core.Enums;
using Autothon.Core.Logger;
using Autothon.Core.Helpers.Common;

namespace Autothon.Start
{
    public class Start
    {
        public static readonly List<TestTypeEnum> testToRun = new List<TestTypeEnum>();
        public static readonly string RunUniqueId = Guid.NewGuid().ToString();
        public static readonly RunManagerNunit runManager = new RunManagerNunit();
        public List<string> testTorun = new List<string>();
        public List<string> _testDlls = new List<string>();
        public static string _category,_environment;

        
        public static string _testToRun;
        public static List<string> projectAssemblies = new List<string>();
        public static List<string> AllFeatureProjectFolders = new List<string>();
        public static string console_logger_path;
        //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //ConsoleLogger consoleLogger = new ConsoleLogger();
        

        public static void Main(string[] args)
        {
            ConsoleLogger.Information("--------------------------------------------------");
            
            string solutionName = CommonHelpers.getSolutionDirectory()+ "\\";
            AllFeatureProjectFolders = System.IO.Directory.GetDirectories(System.IO.Path.GetDirectoryName(solutionName)).ToList().Where(x=>x.Contains(".Feature")).ToList();
            GetAllTestProjectsDll();
            BuildStartUpArguments(args.ToList());
            ValidateArguments();            
            Dictionary<string, string> runWith = new Dictionary<string, string>();
            
            runWith["RunUniqueId"] = RunUniqueId;
            if (args.Length < 3 || args.Length > 5)
            {
                throw new ArgumentException("Invalid Start up Arguments.");
            }
            CreateDirectory();
            ConsoleLogger.Information("Starting Test Run");
            XmlNode result = RunManagerNunit.FullRun(projectAssemblies,_category);
            ConsoleLogger.Information("Ending Test Run");
            Console.ReadKey();

        }

        private static void ValidateArguments()
        {
            var _testAssembly = _testToRun.Split(',');
            foreach(string type in _testAssembly)
            {
                bool status = Enum.TryParse(type, out TestTypeEnum val);
                if (!status)
                    throw new ArgumentException("Invalid Test Type.Test type should be Web,Mobile or API");
                switch(val)
                {
                    case TestTypeEnum.API:
                         projectAssemblies.RemoveAll(x=>x.Contains("Web"));
                        break;
                    case TestTypeEnum.Web:
                        projectAssemblies.RemoveAll(x => x.Contains("API") || x.Contains("Mobile"));
                        break;
                    case TestTypeEnum.Mobile:
                        projectAssemblies.RemoveAll(x => x.Contains("API") || x.Contains("Web"));
                        break;
                }
            }

        }

        private static void CreateDirectory()
        {
           // throw new NotImplementedException();
        }

        private static void GetAllTestProjectsDll()
        {
            foreach(var item in AllFeatureProjectFolders)
            {
                var projectdllFullPath = item + "\\bin\\Debug" + item.Substring(item.LastIndexOf("\\"))+".dll";
                projectAssemblies.Add(projectdllFullPath);
            }

        }

        private static void BuildStartUpArguments(List<string> list)
        {        
            Dictionary<string, string> parsedValues = new Dictionary<string, string>();
            ConsoleLogger.Information("Start Up Arguments");
             OptionSet options = new OptionSet()
                {
                   {"testCategoryToRun=", v=>_testToRun=v},
                    {"environment=", v=>_environment=v},
                    {"SpecflowTagToRun=", v=>_category=v},

                 };
             options.Parse(list);
            ConsoleLogger.Information($"Test Category To Run  {_testToRun}");
            ConsoleLogger.Information($"Test Environment To Run  {_environment}");
            ConsoleLogger.Information($"Test Category To Run  {_environment}");
        }


    }

}
