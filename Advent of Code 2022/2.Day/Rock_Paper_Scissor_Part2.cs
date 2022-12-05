using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._2.Day
{
    internal class Rock_Paper_Scissor_Part2
    {
        /// <summary>
        /// Calculates totalScore of rock paper scizzor 
        /// </summary>
        /// <param name="opponentList"></param>
        /// <param name="playerList"></param>
        /// <returns>totalScore of all played rounds of rock paper scissor</returns>
        public int GetTotalScore(List<char> opponentList, List<char> playerList)
        {
            int totalScore = 0;
            for (int i = 0; i < playerList.Count; i++)
            {
                int points = 0;

                if (opponentList[i] == 'A')
                {
                    switch (playerList[i])
                    {
                        case 'X':
                            points = 0 + 3;
                            break;
                        case 'Y':
                            points = 3 + 1;
                            break;
                        case 'Z':
                            points = 6 + 2;
                            break;
                    }
                }
                else if (opponentList[i] == 'B')
                {
                    switch (playerList[i])
                    {
                        case 'X':
                            points = 0 + 1;
                            break;
                        case 'Y':
                            points = 3 + 2;
                            break;
                        case 'Z':
                            points = 6 + 3;
                            break;
                    }
                }
                else if (opponentList[i] == 'C')
                {
                    switch (playerList[i])
                    {
                        case 'X':
                            points = 0 + 2;
                            break;
                        case 'Y':
                            points = 3 + 3;
                            break;
                        case 'Z':
                            points = 6 + 1;
                            break;
                    }
                }
                totalScore += points;
            }
            return totalScore;
        }
    }
}
