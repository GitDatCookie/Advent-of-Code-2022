using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._4.Day
{
    internal class CalculateTask4
    {
        /// <summary>
        /// Calculates Part 1 of 4.Day Task
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>result of Part 1 of 4.Day Task</returns>
        public int CalculatePart1(string fileLink)
        {
            Camp_Cleanup_Part1 part1 = new();
            string[] campSectionList = part1.GetCampSectionList(fileLink);
            List<int[]> firstElfSectionList = part1.GetFirstElfSectionList(campSectionList);
            List<int[]> secondElfSectionList = part1.GetSecondElfSectionList(campSectionList);
            int result = part1.GetOverlappingSectionNumber(firstElfSectionList, secondElfSectionList);
            return result;
        }

        /// <summary>
        /// Calculates Part 2 of 4.Day Task
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>result of Part 2 of 4.Day Task</returns>
        public int CalculatePart2(string fileLink)
        {
            Camp_Cleanup_Part2 part2= new();
            Camp_Cleanup_Part1 part1 = new();
            string[] campSectionList = part1.GetCampSectionList(fileLink);
            int result = part2.ReturnSum(campSectionList, part1);
            return result;
        }
    }
}
