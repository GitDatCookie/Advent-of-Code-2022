using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Day_Three
{
    internal class Part_One
    {
        public string[] GetRucksackList(string fileLink)
        {
            string[] rucksackList = System.IO.File.ReadAllLines(fileLink);
            return rucksackList;
        }

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

        public int GetSumOfItemTypePriority(List<string> firstCompartmentList, List<string> secondCompartmentList)
        {
            int prioritySum = 0;

            char priorityItemChar = new();

            string priorityConversationChart = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

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
                    if (priority == priorityItemChar)
                    {
                        prioritySum += priority;
                    }
                }
            }

            return prioritySum;
        }
    }
}
