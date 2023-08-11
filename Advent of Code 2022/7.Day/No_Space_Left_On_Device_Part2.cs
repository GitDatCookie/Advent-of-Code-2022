using Advent_of_Code_2022._7.Day.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._7.Day
{
    internal class No_Space_Left_On_Device_Part2
    {
        static long systemSize = 70_000_000;
        public long GetFolderToDeleteSize(No_Space_Left_On_Device_Part1 part1, string fileLink)
        {
            string[] driveInfo = part1.GetDriveInfo(fileLink);

            DirectoryModel root = part1.BuildFileSystem(driveInfo);
            List<DirectoryModel> directories = part1.FindAllDirectories(root);
            List<long> directoriesBySize = new();
            long result = 0;
            long biggestDirectory = 0;
            long freeSpace = 0;
            foreach (DirectoryModel dir in directories) 
            {
                long size = dir.Size();
                directoriesBySize.Add(size);
            }
            directoriesBySize.Sort();
            biggestDirectory = directoriesBySize.Last();
            freeSpace = systemSize - biggestDirectory;
            foreach (long directorySize in  directoriesBySize)
            {
                if((directorySize + freeSpace) > 30_000_000)                                 
                {
                    result = directorySize;
                    break;
                }
            }
            return result;
        }


    }
}
