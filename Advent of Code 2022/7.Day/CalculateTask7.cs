using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._7.Day
{
    internal class CalculateTask7
    {
        public long CalculatePart1(string FileName)
        {
            No_Space_Left_On_Device_Part1 part1 = new();
            string[] info = part1.GetDriveInfo(FileName);
            long result = part1.GetFileSystemSum(info);
            return result;

        }

        public long CalculatePart2(string FileName)
        {
            No_Space_Left_On_Device_Part1 part1 = new();
            No_Space_Left_On_Device_Part2 part2 = new();

            long result = part2.GetFolderToDeleteSize(part1, FileName);
            return result;

        }
    }
}
