using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._2.Day
{
    internal class CalculateTask2
    {
        /// <summary>
        /// Calculates Part 1 of 2.Day Task
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>result of Part 1 of 2.Day Task</returns>
        public int CalculatePart1(string fileLink)
        {
            Rock_Paper_Scissor_Part1 part1 = new();
            List<char> playerList = part1.GetRockPaperScissorPlayerList(fileLink);
            List<char> opponentList = part1.GetRockPaperScissorOpponentList(fileLink);
            int result = part1.GetTotalScore(opponentList, playerList);

            return result;
        }

        /// <summary>
        /// Calculates Part 2 of 2.Day Task
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>result of Part 2 of 2.Day Task</returns>
        public int CalculatePart2(string fileLink)
        {
            Rock_Paper_Scissor_Part2 part2 = new();
            Rock_Paper_Scissor_Part1 part1 = new();
            List<char> playerList = part1.GetRockPaperScissorPlayerList(fileLink);
            List<char> opponentList = part1.GetRockPaperScissorOpponentList(fileLink);
            int result = part2.GetTotalScore(opponentList, playerList);

            return result;
        }
    }
}
