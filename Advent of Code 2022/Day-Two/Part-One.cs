using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Day_Two
{
    internal class Part_One
    {
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
