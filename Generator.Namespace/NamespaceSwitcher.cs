using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Namespace
{
    public static class NamespaceSwitcher
    {
        public static void SwitchNamespace(string folderPath, string projectName)
        {
            string[] files = Directory.GetFiles(folderPath, "*.cs", SearchOption.AllDirectories);
            string[] filesCsproj = Directory.GetFiles(folderPath, "*.csproj", SearchOption.AllDirectories);
            string[] filesSln = Directory.GetFiles(folderPath, "*.sln", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                ReplaceText(file, "UmbracoStarter", projectName);
            }
            foreach (string file in filesCsproj)
            {
                char[] delimeter = { '.' };
                ReplaceText(file, "UmbracoStarter", projectName);
                FileInfo fileInfo = new FileInfo(file);
                fileInfo.Rename(projectName + "." + file.Split(delimeter)[file.Split(delimeter).Length - 2] + ".csproj");
            }
            foreach (string file in filesSln)
            {
                ReplaceText(file, "UmbracoStarter", projectName);
                FileInfo fileInfo = new FileInfo(file);
                fileInfo.Rename(projectName + ".sln");
            }

            string[] foldersStarter = System.IO.Directory.GetDirectories(folderPath, "UmbracoStarter", System.IO.SearchOption.AllDirectories);
            string[] foldersComon = System.IO.Directory.GetDirectories(folderPath, "UmbracoStarter.Common", System.IO.SearchOption.AllDirectories);
            string[] foldersCore = System.IO.Directory.GetDirectories(folderPath, "UmbracoStarter.Core", System.IO.SearchOption.AllDirectories);
            string[] foldersModels = System.IO.Directory.GetDirectories(folderPath, "UmbracoStarter.Models", System.IO.SearchOption.AllDirectories);
            string[] foldersWeb = System.IO.Directory.GetDirectories(folderPath, "UmbracoStarter.Web", System.IO.SearchOption.AllDirectories);
       
            foreach (var item in foldersComon)
            {
                FileInfo fileInfo = new FileInfo(item);
                fileInfo.Rename(projectName + ".Common");
            }
            foreach (var item in foldersCore)
            {
                FileInfo fileInfo = new FileInfo(item);
                fileInfo.Rename(projectName + ".Core");
            }
            foreach (var item in foldersModels)
            {
                FileInfo fileInfo = new FileInfo(item);
                fileInfo.Rename(projectName + ".Models");
            }
            foreach (var item in foldersWeb)
            {
                FileInfo fileInfo = new FileInfo(item);
                fileInfo.Rename(projectName + ".Web");
            }
            foreach (var item in foldersStarter)
            {
                FileInfo fileInfo = new FileInfo(item);
                fileInfo.Rename(projectName);
            }
        }



        public static void ReplaceText(string filePath, string oldString, string newString)
        {
            string text = File.ReadAllText(filePath);
            text = text.Replace(oldString, newString);
            File.WriteAllText(filePath, text);
        }

        public static void Rename(this FileInfo fileInfo, string newName)
        {
            fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + newName);
        }
     
    }
}
