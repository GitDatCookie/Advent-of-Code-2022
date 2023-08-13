using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._8.Day
{
    internal class Treetop_Tree_House_Part1
    {
        public int[,] GetTreeGrid(string fileLink)
        {
            string[] allLines = File.ReadAllLines(fileLink);
            int[,] treeGrid= new int[allLines[0].Length, allLines.Length];
            for(int i = 0; i < allLines.Length; i++)
            {
                string line = allLines[i];
                for (int j = 0; j < allLines[i].Length; j++)
                {
                    int test = line[j]-'0';
                    treeGrid[i,j] = test;
                }
            }
            return treeGrid;
        }

        public int CheckTreeCount(int[,] treeGrid)
        {
            int treeCounter = 0;

            for (int i = 0;i < treeGrid.GetLength(0); i++)
            {
                for(int j = 0;j < treeGrid.GetLength(1); j++)
                {
                    if(CheckVisibility(treeGrid, i, j)== true)
                    {
                        treeCounter++;
                    }
                }
            }
            return treeCounter;
        }

        public bool CheckVisibility(int[,] treeGrid, int horizontal, int vertical)
        {
            return CheckVisibilityNorth(treeGrid, horizontal, vertical) ||
                CheckVisibilitySouth(treeGrid, horizontal, vertical) ||
                CheckVisibilityWest(treeGrid, horizontal, vertical) ||
                CheckVisibilityEast(treeGrid, horizontal, vertical);
        }
        public bool CheckVisibilityNorth(int[,] treeGrid, int horizontal, int vertical)
        {
            int treeSize = treeGrid[vertical, horizontal];
            for(int n = vertical -1; n >= 0; n--)
            {
                int comparisonTree = treeGrid[n,horizontal];
                if(comparisonTree >= treeSize)
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckVisibilitySouth(int[,] treeGrid, int horizontal, int vertical)
        {
            int treeSize = treeGrid[vertical, horizontal];
            for (int s = vertical + 1; s < treeGrid.GetLength(0); s++)
            {
                int comparisonTree = treeGrid[s, horizontal];
                if (comparisonTree >= treeSize)
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckVisibilityEast(int[,] treeGrid, int horizontal, int vertical)
        {
            int treeSize = treeGrid[vertical, horizontal];
            for (int e = horizontal + 1; e < treeGrid.GetLength(1); e++)
            {
                int comparisonTree = treeGrid[vertical, e];
                if (comparisonTree >= treeSize)
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckVisibilityWest(int[,] treeGrid, int horizontal, int vertical)
        {
            int treeSize = treeGrid[vertical, horizontal];
            for (int w = horizontal - 1; w >= 0; w--)
            {
                int comparisonTree = treeGrid[vertical, w];
                if (comparisonTree >= treeSize)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
