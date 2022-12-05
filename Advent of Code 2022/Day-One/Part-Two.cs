using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Day_One
{
    internal class Part_Two
    {
        /// <summary>
        /// Uses sorted and reversed list from Day-One, Part-One to get the top 3 elfs with highest calorie count
        /// </summary>
        /// <param name="elfList"></param>
        /// <returns>sum of calorie count of top 3 elfs</returns>
        public int GetSumOfTop3ElfsWithHighestCalories(List<int> elfList)
        {
            var top3List = elfList.Take(3);
            int calories = 0;

            foreach (var el in top3List)
            {
                calories += el;
            }

            return calories;
        }
    }
}
