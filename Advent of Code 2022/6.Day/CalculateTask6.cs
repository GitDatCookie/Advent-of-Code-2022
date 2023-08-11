using Advent_of_Code_2022._5.Day;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._6.Day
{
    internal class CalculateTask6
    {
        /// <summary>
        /// Calculates Part 1 of 6.Day Task
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>result of Part 1 of 6.Day Task</returns>
        public int CalculatePart1(string fileLink)
        {
            Tuning_Trouble part1 = new();
            int distinctCharactersPartOne = 4;
            string tuningTroubleString = part1.GetTuningTroubleString(fileLink);
            int result = part1.GetStartOfPacketMarker(tuningTroubleString, distinctCharactersPartOne);

            return result;
        }

        /// <summary>
        /// Calculates Part 2 of 6.Day Task
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>result of Part 2 of 6.Day Task</returns>
        public int CalculatePart2(string fileLink)
        {
            Tuning_Trouble trouble = new();
            int distinctCharactersPartOne = 14;
            string tuningTroubleString = trouble.GetTuningTroubleString(fileLink);
            int result = trouble.GetStartOfPacketMarker(tuningTroubleString, distinctCharactersPartOne);

            return result;
        }
    }
}
