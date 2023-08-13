using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._8.Day
{
    internal class CalculateTask8
    {
        public int CalculatePart1(string fileLink)
        {
            Treetop_Tree_House_Part1 part1 = new();
            int result  = part1.CheckTreeCount(part1.GetTreeGrid(fileLink));
            return result;
        }

        public int CalculatePart2(string fileLink)
        {
            Treetop_Tree_House_Part2 part2 = new();
            int result = part2.GetScenicScore(fileLink);
            return result;
        }
    }
}
