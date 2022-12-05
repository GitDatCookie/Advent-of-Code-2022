using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._3.Day
{
    internal class Rucksack_Organization_Part2
    {
        /// <summary>
        /// creates a list of a list which contains continous triples of strings 
        /// </summary>
        /// <param name="rucksackList"></param>
        /// <returns> aformentioned list</returns>
        public List<List<string>> GetElfGroupRucksackList(string[] rucksackList)
        {
            List<List<string>> elfGroupList = new();
            List<string> elfGroupRucksackList = new();
            string rucksackItems;

            int amountOfElfGroups = (rucksackList.Length / 3);

            for(int elfGroupCount = 0; elfGroupCount < amountOfElfGroups; elfGroupCount++)
            {
                elfGroupRucksackList = new();
                for(int rucksackCount = 0; rucksackCount < 3; rucksackCount++)
                {
                    rucksackItems = rucksackList[3 * elfGroupCount + rucksackCount];
                    elfGroupRucksackList.Add(rucksackItems);
                }
                elfGroupList.Add(elfGroupRucksackList);
            }

            return elfGroupList;
        }

        /// <summary>
        /// checks which item(char) is contained in each part of a tripple
        /// then gets the priority Value of the char and returns it as priority Value
        /// </summary>
        /// <param name="rucksack1"></param>
        /// <param name="rucksack2"></param>
        /// <param name="rucksack3"></param>
        /// <returns></returns>
        public int GetPriority(string rucksack1, string rucksack2, string rucksack3)
        {
            string priorityConversationChart = "0abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int priority = 0;

            for (int rucksackItem = 0; rucksackItem < priorityConversationChart.Length; rucksackItem++)
            {
                if (rucksack1.Contains(priorityConversationChart[rucksackItem])
                    && rucksack2.Contains(priorityConversationChart[rucksackItem])
                    && rucksack3.Contains(priorityConversationChart[rucksackItem]))
                {
                    priority = rucksackItem; ;
                }
            }

            return priority;
        }

        /// <summary>
        /// uses List created in GetElfGroupRucksackList to calculate sum of priority
        /// </summary>
        /// <param name="elfGroupList"></param>
        /// <returns>see summary</returns>
        public int GetSumOfPriority(List<List<string>> elfGroupList)
        {
            int prioritySum = 0;
            int elfGroupSize = 3;
            string? rucksack1 = null;
            string? rucksack2 = null;
            string? rucksack3= null;
            string currentRucksack = "empty";
            string previousRucksack = "empty";

            foreach (var elfgroup in elfGroupList)
            {
                for (int rucksackCount = 0; rucksackCount < elfGroupSize; rucksackCount++)
                {
                    currentRucksack = elfgroup[rucksackCount];

                    if (previousRucksack != rucksack1
                        && previousRucksack == rucksack2
                        && previousRucksack != rucksack3)
                    {
                        rucksack3 = currentRucksack;
                        previousRucksack = currentRucksack;
                    }

                    if (previousRucksack == rucksack1
                        && previousRucksack != rucksack2
                        && previousRucksack != rucksack3)
                    {
                        rucksack2 = currentRucksack;
                        previousRucksack = currentRucksack;
                    }

                    if (currentRucksack != rucksack1 
                        && currentRucksack != rucksack2 
                        && currentRucksack != rucksack3)
                    {
                        rucksack1 = currentRucksack;
                        previousRucksack = currentRucksack;
                        rucksack2 = null;
                        rucksack3 = null;
                    }

                    if(rucksack1 != null && rucksack2 != null && rucksack3 != null)
                    {
                        prioritySum += GetPriority(rucksack1, rucksack2, rucksack3);
                    }
                }
            }
            return prioritySum;
        }
    }
}
