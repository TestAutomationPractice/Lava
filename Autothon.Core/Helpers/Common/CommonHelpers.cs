using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Autothon.Core.Helpers.Common
{
    public static class CommonHelpers
    {
        
        public static string getSolutionDirectory()
        {
            string projectName = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToString().Replace("\\bin","").Replace("\\Debug","");
            string solutionFullPath = projectName.Substring(0, projectName.LastIndexOf("\\")) ;
            return solutionFullPath;
        }
        public static bool DirectoryExists(string fullPathOfFolder)
        {
            return System.IO.Directory.Exists(fullPathOfFolder);
        }
        public static void createDirectory(string parentFolder,string dirNameToCreate)
        {
            string fullDirName = string.Join(parentFolder, "\\", dirNameToCreate);
            if (!DirectoryExists(fullDirName))
                try
                {
                    System.IO.Directory.CreateDirectory(fullDirName);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
        }
    }
}
