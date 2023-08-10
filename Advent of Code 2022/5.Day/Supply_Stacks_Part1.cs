using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._5.Day
{
    internal class Supply_Stacks_Part1
    {
        /// <summary>
        /// Provides basic list from stream for further use in other methods
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns></returns>
        public string[] GetSupplyStackList(string fileLink)
        {
            string[] supplyStackList = System.IO.File.ReadAllLines(fileLink);
            return supplyStackList;
        }


        /// <summary>
        /// Returns List for basic lineup of  crates
        /// </summary>
        /// <param name="supplyStackList"></param>
        /// <returns>A ordered List of List<char> , last entry of each line is top most crate 
        /// </returns>
        public List<List<char>> GetSupplyPositionList(string[] supplyStackList) 
        {
            
            List<string> verticalIndex = new();
            //fills verticalIndex with all lines which contain crate information
            foreach (var line in supplyStackList)
            {
                if (!line.Contains("move") && String.IsNullOrWhiteSpace(line) == false)
                {
                    verticalIndex.Add(line);
                }

            }

            List<int> horizontalIndex = new();
            //fills horizontalIndex with information to pinpoint each crate
            string digitLine = verticalIndex[verticalIndex.Count - 1];
            for(int i = 0; i< digitLine.Length; i++)
            {
                if (Char.IsDigit(digitLine[i]))
                {
                    horizontalIndex.Add(i);
                }
            }

            //removes horizontal information from vertical index
            verticalIndex.RemoveAt(verticalIndex.Count-1);

            List<List<char>> supplyMatrix = new();
            //fills supplyMatrix with horizontal andd vertikal information to create a 2D array
            foreach(var supplyLine in verticalIndex)
            {
                List<char> supplyContentList = new List<char>();
                foreach (var supplyContent in horizontalIndex)
                {
                    supplyContentList.Add(supplyLine[supplyContent]);
                }
                supplyMatrix.Add(supplyContentList);
            }

            List<List<char>> supplyPositionList = new();
            //removes all whitespace in matrix to easier change char within
            for (int i = 0; i < horizontalIndex.Count(); i++) 
            {
                List<char> containerList = new();
                
                foreach (var line in supplyMatrix)
                {
                    containerList.Add(line[i]);
                }
                containerList.RemoveAll(Char.IsWhiteSpace);
                containerList.Reverse();

                supplyPositionList.Add(containerList);
            }
            return supplyPositionList;
        }


        /// <summary>
        /// See return value
        /// </summary>
        /// <param name="supplyStackList"></param>
        /// <returns>
        /// A list of int[] which holds all information for moving the crates
        /// [0] how many crates should be moved 
        /// [1] from which crate stack will it be taken
        /// [2] which stack will get the crates
        /// </returns>
        public List<int[]> GetSupplyMovementList(string[] supplyStackList) 
        {
            List<int[]> supplyMovementList = new List<int[]>();
            foreach(var line in supplyStackList)
            {
                if (line.Contains("move"))
                {
                    int[] moveFromToInt = new int[3];
                    moveFromToInt = new Regex(@"\d+").Matches(line)
                                                      .Cast<Match>()
                                                      .Select(m => Int32.Parse(m.Value))
                                                      .ToArray();

                    supplyMovementList.Add(moveFromToInt);
                }

            }

            return supplyMovementList;
        }


        /// <summary>
        /// Using the supplyMovementList on the supplyPositionList to get the ordered list after all sorting actions
        /// </summary>
        /// <param name="supplyPositionList"></param>
        /// <param name="supplyMovementList"></param>
        /// <returns>
        /// A list of string[]
        /// [0] holds the row number
        /// [1] holds the cratesupply in stacking order ,leftmost is bottom / rightmost is top
        /// </returns>
        public (List<string[]>, string?) GetAppliedSupplyStackList(List<List<char>> supplyPositionList, List<int[]> supplyMovementList)
        {
            List<List<char>> _supplyPositionList = supplyPositionList;
            //moves [0] crates of [1] stack to [2] stack, 1 at a time
            foreach(var line in supplyMovementList)
            {
                for (int i = 0; i < line[0];  i++)
                {
                    char cache = new();
                    cache = _supplyPositionList[line[1] - 1].Last();
                    int cacheIndex = _supplyPositionList[line[1] - 1].LastIndexOf(cache);
                    _supplyPositionList[line[1] - 1].RemoveAt(cacheIndex);
                    _supplyPositionList[line[2] -1].Add(cache);
                }
            }

            List<string[]> stackedSupplyPositionList = GetHumanEyePleasingList(supplyPositionList);

            string? answer = null;
            //creates string holding the letters of each topmost crate
            foreach (var list in stackedSupplyPositionList)
            {
                answer = answer + list[1][list[1].Length-2].ToString();
            }

            return (stackedSupplyPositionList, answer);
        }

        /// <summary>
        /// Creates a more pleasing List, 
        /// instead of e.g.: CHDNFE \n JUEKFLE 
        /// will show: 1 [C][H][D][N][F][E] \n  2 [J][U][E][K][F][L][E] 
        /// </summary>
        /// <param name="supplyPositionList"></param>
        /// <returns>aforementioned List</returns>
        public List<string[]> GetHumanEyePleasingList(List<List<char>> supplyPositionList)
        {
            //mostly optional code, changes the endresult to be more pleasing for the human eye
            List<List<char>> _supplyPositionList = supplyPositionList;
            int stackNumber = 0;
            List<string[]> stackedSupplyPositionList = new();
            foreach (var list in _supplyPositionList)
            {
                string[] result = new string[2];
                result[0] = stackNumber.ToString();
                string cache = new string(list.ToArray());
                string supplyCache = null; ;
                foreach (var character in cache)
                {
                    supplyCache += "[" + character + "]";
                }
                result[1] = supplyCache;
                stackedSupplyPositionList.Add(result);
                stackNumber++;
            }

            return stackedSupplyPositionList;
        }

        /// <summary>
        /// overloaded method mostly same as above but changed for use in part 2
        /// </summary>
        /// <param name="supplyPositionList"></param>
        /// <returns>List for use in part 2</returns>
        public List<string[]> GetHumanEyePleasingList(List<string> supplyPositionList)
        {
            //mostly optional code, changes the endresult to be more pleasing for the human eye
            List<string> _supplyPositionList = supplyPositionList;
            int stackNumber = 0;
            List<string[]> stackedSupplyPositionList = new();
            foreach (var list in _supplyPositionList)
            {
                string[] result = new string[2];
                result[0] = stackNumber.ToString();
                string cache = new string(list.ToArray());
                string supplyCache = null; ;
                foreach (var character in cache)
                {
                    supplyCache += "[" + character + "]";
                }
                result[1] = supplyCache;
                stackedSupplyPositionList.Add(result);
                stackNumber++;
            }

            return stackedSupplyPositionList;
        }

    }
}
