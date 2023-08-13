using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._8.Day
{
    internal class Treetop_Tree_House_Part2
    {
        public int GetScenicScore(string fileLink)
        {
            Treetop_Tree_House_Part1 part1 = new();
            int[,] treeGrid = part1.GetTreeGrid(fileLink);
            List<int> scenicScoreList = new();
            int scenicScore = 0;
            for (int i = 0; i < treeGrid.GetLength(0); i++)
            {
                for (int j = 0; j < treeGrid.GetLength(1); j++)
                {
                    scenicScore = CalculateScenicScore(treeGrid, j, i);
                    scenicScoreList.Add(scenicScore);
                }
            }

            scenicScoreList.Sort();
            scenicScoreList.Reverse();
            scenicScore = scenicScoreList[0];

            return scenicScore;
        }

        public int CalculateScenicScore(int[,] treeGrid, int horizontal, int vertical)
        {
            int northScore = CalculateScenicScoreNorth(treeGrid, horizontal, vertical);
            int southScore = CalculateScenicScoreSouth(treeGrid, horizontal, vertical);
            int eastScore = CalculateScenicScoreEast(treeGrid, horizontal, vertical);
            int westScore = CalculateScenicScoreWest(treeGrid, horizontal, vertical);


            int scenicScore = northScore * southScore * eastScore * westScore;
            return scenicScore;


        }
        public int CalculateScenicScoreNorth(int[,] treeGrid, int horizontal, int vertical)
        {
            int treeSize = treeGrid[vertical, horizontal];
            int distanceNorth = 0;
            for (int n = vertical - 1; n >= 0; n--)
            {
                int comparisonTree = treeGrid[n, horizontal];
                if (comparisonTree >= treeSize)
                {
                    return distanceNorth = vertical - n;
                }
            }
            return distanceNorth = vertical;
        }
        public int CalculateScenicScoreSouth(int[,] treeGrid, int horizontal, int vertical)
        {
            int treeSize = treeGrid[vertical, horizontal];
            int distanceSouth = 0;
            for (int s = vertical + 1; s < treeGrid.GetLength(0); s++)
            {
                int comparisonTree = treeGrid[s, horizontal];
                if (comparisonTree >= treeSize)
                {
                    return distanceSouth = s  - vertical ;
                }
            }
            return distanceSouth = treeGrid.GetLength(1) - 1 - vertical ;
        }
        public int CalculateScenicScoreEast(int[,] treeGrid, int horizontal, int vertical)
        {
            int treeSize = treeGrid[vertical, horizontal];
            int distanceEast = 0;
            for (int e = horizontal + 1; e < treeGrid.GetLength(1); e++)
            {
                int comparisonTree = treeGrid[vertical, e];
                if (comparisonTree >= treeSize)
                {
                    return distanceEast = e - horizontal;
                }
            }
            return distanceEast =treeGrid.GetLength(0) - 1 - horizontal;
        }
        public int CalculateScenicScoreWest(int[,] treeGrid, int horizontal, int vertical)
        {
            int treeSize = treeGrid[vertical, horizontal];
            int distanceWest = 0;
            for (int w = horizontal - 1; w >= 0; w--)
            {
                int comparisonTree = treeGrid[vertical, w];
                if (comparisonTree >= treeSize)
                {
                    return distanceWest = horizontal - w;
                }
            }
            return distanceWest = horizontal;
        }
    }
}
