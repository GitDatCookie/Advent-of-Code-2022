using Advent_of_Code_2022._4.Day;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._5.Day
{
    internal class CalculateTask5
    {
        /// <summary>
        /// Calculates Part 1 of 5.Day Task
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>result of Part 1 of 5.Day Task</returns>
        public (List<string[]>, string?) CalculatePart1(string fileLink)
        {
            Supply_Stacks_Part1 part1 = new();
            string[] supplyStackList = part1.GetSupplyStackList(fileLink);
            List<int[]> supplyMovementList = part1.GetSupplyMovementList(supplyStackList);
            List<List<char>> supplyPositionList = part1.GetSupplyPositionList(supplyStackList);
            (List<string[]>,string?) stackedSupplyPositionList = part1.GetAppliedSupplyStackList(supplyPositionList, supplyMovementList);

            return stackedSupplyPositionList;
        }

        /// <summary>
        /// Calculates Part 2 of 5.Day Task
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>result of Part 2 of 5.Day Task</returns>
        public (List<string[]>,string?) CalculatePart2(string fileLink)
        {
            Supply_Stacks_Part1 part1= new();
            Supply_Stacks_Part2 part2= new();
            (List<string[]>, string?) stackedSupplyPositionList = part2.GetAppliedSupplyStackList(fileLink, part1);

            return stackedSupplyPositionList;

        }
    }
}
