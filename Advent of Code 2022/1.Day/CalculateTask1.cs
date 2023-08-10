using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._1.Day
{
    internal class CalculateTask1
    {       
        /// <summary>
        /// Calculates Part 1 of 1.Day Task
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>result of Part 1 of 1.Day Task</returns>
        public int CalculatePart1(string fileLink)
        {
            Calories_Part1 part1 = new();
            List<int> elfCaloriesList = part1.GetElfCaloriesList(fileLink);
            int result = part1.GetElfWithMostCalories(elfCaloriesList);

            return result;
        }

        /// <summary>
        /// Calculates Part 2 of 1.Day Task
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>result of Part 2 of 1.Day Task</returns>
        public int CalculatePart2(string fileLink)
        {
            Calories_Part2 part2 = new();
            Calories_Part1 part1 = new();
            List<int> elfCaloriesList = part1.GetElfCaloriesList(fileLink);
            int result = part2.GetSumOfTop3ElfsWithHighestCalories(elfCaloriesList);

            return result;
        }
    }
}
