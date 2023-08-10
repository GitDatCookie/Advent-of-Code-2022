using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._5.Day
{
    internal class Supply_Stacks_Part2
    {

        /// </summary>
        /// <param name="fileLink"></param>
        /// <param name="part1"></param>
        /// <returns>
        /// A list of string[]
        /// [0] holds the row number
        /// [1] holds the cratesupply in stacking order ,leftmost is bottom / rightmost is top
        /// </returns>
        public (List<string[]>, string?) GetAppliedSupplyStackList(string fileLink ,Supply_Stacks_Part1 part1)
        {
            string[] supplyStackList = part1.GetSupplyStackList(fileLink);
            
            List<List<char>> supplyPositionList = part1.GetSupplyPositionList(supplyStackList);

            List<string> _supplyPositionList = new();
            //changes List<List<char>> to List<string> for easier accessabillity
            foreach (var charArray in supplyPositionList)
            {
                string supply = new string(charArray.ToArray());
                _supplyPositionList.Add(supply);
            }

            List<int[]> supplyMovementList = part1.GetSupplyMovementList(supplyStackList);
            //moves [0] crates of [1] stack to [2] stack, all together
            foreach (var line in supplyMovementList)
            {
                
                string fullCache = _supplyPositionList[line[2] - 1];
                string cache = _supplyPositionList[line[1] - 1].Substring(_supplyPositionList[line[1]-1].Length - line[0]);
                _supplyPositionList[line[2]-1] = string.Concat(fullCache, cache);
                _supplyPositionList[line[1] - 1] = _supplyPositionList[line[1] - 1][..^(cache.Length)];
            }


            List<string[]> stackedSupplyPositionList = part1.GetHumanEyePleasingList(_supplyPositionList);

            string? answer = null;
            //creates string holding the letters of each topmost crate
            foreach (var list in stackedSupplyPositionList)
            {
                answer = answer + list[1][list[1].Length - 2].ToString();
            }

            return (stackedSupplyPositionList, answer);
        }
    }

}
