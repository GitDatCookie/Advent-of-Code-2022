using Advent_of_Code_2022._7.Day.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._7.Day
{
    internal class No_Space_Left_On_Device_Part1
    {
        public string[] GetDriveInfo(string fileLink)
        {
            string[] driveInfo = System.IO.File.ReadAllLines(fileLink);
            return driveInfo;
        }

        public long GetFileSystemSum(string[] driveInfo)
        {
            DirectoryModel root = BuildFileSystem(driveInfo);
            List<DirectoryModel> directories = FindAllDirectories(root);
            long sum = 0;
            foreach (DirectoryModel dir in directories)
            {
                long size = dir.Size();
                if (size <= 100_000)
                {
                    sum += size;
                }
            }
            return sum;
        }

        internal DirectoryModel BuildFileSystem(string[] driveInfo)
        {
            DirectoryModel root = new("/", null);
            DirectoryModel currentDirectoryModel = root;
            foreach (var info in driveInfo)
            {
                string[] token = info.Split(' ');
                if (long.TryParse(token[0], out long _) == true)
                {
                    currentDirectoryModel = AddFile(currentDirectoryModel, info);
                }
                if (info.StartsWith("dir"))
                {
                    currentDirectoryModel = AddParent(currentDirectoryModel, token);
                }
                if (token[0] == "$" && token[1] == "cd")
                {
                    currentDirectoryModel = ChangeDirectory(currentDirectoryModel, token);
                }
            }
            return root;
        }


        internal List<DirectoryModel> FindAllDirectories(DirectoryModel rootSearchDirectory)
        {
            List<DirectoryModel> allDirectories = new();
            allDirectories.Add(rootSearchDirectory);
            foreach (DirectoryModel child in rootSearchDirectory.Children())
            {
                allDirectories.AddRange(FindAllDirectories(child));
            }
            return allDirectories;
        }




        DirectoryModel AddFile(DirectoryModel currentDirectoryModel, string fileinfo)
        {
            FileModel file = FileModel.Parse(fileinfo);
            currentDirectoryModel.AddFileToList(file);
            return currentDirectoryModel;
        }

        DirectoryModel AddParent(DirectoryModel currentDirectoryModel, string[] tokenInfo)
        {
            new DirectoryModel(tokenInfo[1], currentDirectoryModel);
            return currentDirectoryModel;

        }


        DirectoryModel ChangeDirectory(DirectoryModel currentDirectoryModel, string[] tokenInfo) 
        { 
            string childName = tokenInfo[2];
            switch(childName)
            {
                case "..": return currentDirectoryModel.ParentDirectory;
                case "/": return currentDirectoryModel;
                default: return currentDirectoryModel.FindChildModel(childName);
            }
        }




    }
}


