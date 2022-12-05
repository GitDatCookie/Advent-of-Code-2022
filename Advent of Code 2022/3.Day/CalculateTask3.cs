using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._3.Day
{
    internal class CalculateTask3
    {
        /// <summary>
        /// Calculates Part 1 of 3.Day Task
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>result of Part 1 of 3.Day Task</returns>
        public int CalculatePart1(string fileLink)
        {
            Rucksack_Organization_Part1 part1 = new();
            string[] rucksackList = part1.GetRucksackList(fileLink);
            List<string> firstCompartmentList = part1.GetFirstCompartmentList(rucksackList);
            List<string> secondCompartmentList = part1.GetSecondCompartmentList(rucksackList);
            int result = part1.GetSumOfItemTypePriority(firstCompartmentList, secondCompartmentList);

            return result;
        }

        /// <summary>
        /// Calculates Part 2 of 3.Day Task
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>result of Part 2 of 3.Day Task</returns>
        public int CalculatePart2(string fileLink)
        {
            Rucksack_Organization_Part1 part1 = new();
            Rucksack_Organization_Part2 part2 = new();

            string[] rucksackList = part1.GetRucksackList(fileLink);
            List<List<string>> elfGroupRucksackList = part2.GetElfGroupRucksackList(rucksackList);
            int result = part2.GetSumOfPriority(elfGroupRucksackList);

            return result;
        }
    }
}
