using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._3.Day
{
    internal class Rucksack_Organization_Part1
    {
        /// <summary>
        /// gets a list of string variables,
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>list of rucksacks</returns>
        public string[] GetRucksackList(string fileLink)
        {
            string[] rucksackList = System.IO.File.ReadAllLines(fileLink);
            return rucksackList;
        }

        /// <summary>
        /// gets first half of rucksack items from rucksackList
        /// </summary>
        /// <param name="rucksackList"></param>
        /// <returns>first half of each item in rucksackList as new List</returns>
        public List<string> GetFirstCompartmentList(string[] rucksackList)
        {
            List<string> firstCompartmentList = new();
            string rucksackCompartment;
            int rucksackCompartmentItems;

            foreach(var rucksack in rucksackList)
            {
                rucksackCompartmentItems = (rucksack.Length/2);
                rucksackCompartment = rucksack.Substring(0, rucksackCompartmentItems);
                firstCompartmentList.Add(rucksackCompartment);
            }

            return firstCompartmentList;
        }

        /// <summary>
        /// gets second half of rucksack items from rucksackList
        /// </summary>
        /// <param name="rucksackList"></param>
        /// <returns>second half of each item in rucksackList as new List</returns>
        public List<string> GetSecondCompartmentList(string[] rucksackList)
        {
            List<string> secondCompartmentList = new();
            string rucksackCompartment;
            int rucksackCompartmentItems;

            foreach (var rucksack in rucksackList)
            {
                rucksackCompartmentItems = (rucksack.Length / 2);
                rucksackCompartment = rucksack[^rucksackCompartmentItems..];
                secondCompartmentList.Add(rucksackCompartment);
            }

            return secondCompartmentList;
        }

        /// <summary>
        /// Checks which char is the one, that is contained in both, first compartment and second compartment
        /// then gets the priority Value of the char and returns it as sum of priority Values
        /// </summary>
        /// <param name="firstCompartmentList"></param>
        /// <param name="secondCompartmentList"></param>
        /// <returns> see summary </returns>
        public int GetSumOfItemTypePriority(List<string> firstCompartmentList, List<string> secondCompartmentList)
        {
            int prioritySum = 0;

            char priorityItemChar = new();

            string priorityConversationChart = "0abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int listCount = 0; listCount < firstCompartmentList.Count; listCount++)
            {
                for (int firstCompartment = 0; firstCompartment < firstCompartmentList[listCount].Length; firstCompartment++)
                {
                    for (int secondCompartment = 0; secondCompartment < secondCompartmentList[listCount].Length; secondCompartment++)
                    {
                        char firstCompartmentItem = firstCompartmentList[listCount][firstCompartment];
                        char secondCompartmentItem = secondCompartmentList[listCount][secondCompartment];

                        if (firstCompartmentItem == secondCompartmentItem)
                        {
                            priorityItemChar = firstCompartmentItem;
                        }
                    }
                }

                for (int priority = 0; priority < priorityConversationChart.Length; priority++)
                {
                    if (priorityConversationChart[priority] == priorityItemChar)
                    {
                        prioritySum += priority;
                    }
                }
            }

            return prioritySum;
        }
    }
}
