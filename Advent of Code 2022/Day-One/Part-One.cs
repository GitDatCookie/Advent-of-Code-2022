using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Day_One
{
    internal class Part_One
    {
        /// <summary>
        /// Reads all lines from file and sums up calorie count per elf
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>a list of all elfs sorted from highest calorie count to lowest</returns>
        public List<int> GetElfList(string fileLink)
        {

            List<int> elfCaloriesList = new List<int>();
            string[] text = System.IO.File.ReadAllLines(fileLink);
            int elfCalories = 0;

            foreach (var line in text)
            {
                //resets elf after each empty line
                if (line == "")
                {
                    elfCaloriesList.Add(elfCalories);
                    elfCalories = 0;
                }

                else
                {
                    int number = Convert.ToInt32(line);
                    elfCalories = elfCalories + number;
                }

            }

            elfCaloriesList.Sort();
            elfCaloriesList.Reverse();

            return elfCaloriesList;
        }


        /// <summary>
        /// See method name
        /// </summary>
        /// <param name="elfList"></param>
        /// <returns>elf with highest calorie count</returns>
        public int GetElfWithMostCalories(List<int> elfList)
        {
            int elfWithMostCalories = elfList[0];
            return elfWithMostCalories;
        }
    }
}
