using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._2.Day
{
    internal class Rock_Paper_Scissor_Part1
    {
        /// <summary>
        /// See method title
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>A list of opponents rock paper scissor moves from file</returns>
        public List<char> GetRockPaperScissorOpponentList(string fileLink)
        {
            string[] rockPaperScissorList = System.IO.File.ReadAllLines(fileLink);
            List<char> opponentList = new List<char>();
            foreach(var line in rockPaperScissorList)
            {
                char opponent = line[0];
                opponentList.Add(opponent);
            }
            return opponentList;
        }

        /// <summary>
        /// See method title
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>A list of players rock paper scissor moves from file</returns>
        public List<char> GetRockPaperScissorPlayerList(string fileLink)
        {
            string[] rockPaperScissorList = System.IO.File.ReadAllLines(fileLink);
            List<char> playerList = new List<char>();
            foreach (var line in rockPaperScissorList)
            {
                char player = line[2];
                playerList.Add(player);
            }
            return playerList;
        }

        /// <summary>
        /// Calculates totalScore of rock paper scizzor 
        /// </summary>
        /// <param name="opponentList"></param>
        /// <param name="playerList"></param>
        /// <returns>totalScore of all played rounds of rock paper scissor</returns>
        public int GetTotalScore(List<char> opponentList, List<char> playerList)
        {
            int totalScore = 0;
            int roundScore = 0;
            int points = 0;

            for(int i = 0; i < playerList.Count; i++)
            {
                switch (playerList[i])
                {
                    case 'X':
                        points = 1;
                        break;
                    case 'Y':
                        points = 2;
                        break;
                    case 'Z':
                        points = 3;
                        break;
                }

                if ((opponentList[i] == 'A' && playerList[i] == 'X') || (opponentList[i] == 'B' && playerList[i] == 'Y') || (opponentList[i] == 'C' && playerList[i] == 'Z'))
                {
                    roundScore = 3 + points;
                }
                else if ((opponentList[i] == 'A' && playerList[i] == 'Z') || (opponentList[i] == 'B' && playerList[i] == 'X') || (opponentList[i] == 'C' && playerList[i] == 'Y'))
                {
                    roundScore = 0 + points;
                }
                else if ((opponentList[i] == 'A' && playerList[i] == 'Y') || (opponentList[i] == 'B' && playerList[i] == 'Z') || (opponentList[i] == 'C' && playerList[i] == 'X'))
                {
                    roundScore = 6 + points;
                }

                totalScore += roundScore;
            }

            return totalScore;
        }

    }
}
