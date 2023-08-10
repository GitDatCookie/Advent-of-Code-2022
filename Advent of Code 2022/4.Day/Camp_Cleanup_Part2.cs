using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._4.Day
{
    internal class Camp_Cleanup_Part2
    {
        /// <summary>
        /// checks if any of the number ranges are overlapping at all with another
        /// </summary>
        /// <param name="campSectionList"></param>
        /// <param name="campCleanupPart1"></param>
        /// <returns> the number of overlapping pairs </returns>
        public int ReturnSum(string[] campSectionList, Camp_Cleanup_Part1 campCleanupPart1)
        {
            List<int[]> firstElfSectionList = campCleanupPart1.GetFirstElfSectionList(campSectionList);
            List<int[]> secondElfSectionList = campCleanupPart1.GetSecondElfSectionList(campSectionList);
            int overlappingSectionNumber = 0;
            int number1 = 0;
            int number2 = 0;
            int number3 = 0;
            int number4 = 0;
            for (int sectionNumber = 0; sectionNumber < firstElfSectionList.Count; sectionNumber++)
            {
                number1 = firstElfSectionList[sectionNumber][0];
                number2 = firstElfSectionList[sectionNumber][1];
                number3 = secondElfSectionList[sectionNumber][0];
                number4 = secondElfSectionList[sectionNumber][1];

                if ((firstElfSectionList[sectionNumber][0] <= secondElfSectionList[sectionNumber][1] && firstElfSectionList[sectionNumber][1] >= secondElfSectionList[sectionNumber][0])
                    || (firstElfSectionList[sectionNumber][1] <= secondElfSectionList[sectionNumber][1] && firstElfSectionList[sectionNumber][1] >= secondElfSectionList[sectionNumber][0])
                    || (secondElfSectionList[sectionNumber][0] <= firstElfSectionList[sectionNumber][1] && secondElfSectionList[sectionNumber][1] >= firstElfSectionList[sectionNumber][0])
                    || (secondElfSectionList[sectionNumber][1] <= firstElfSectionList[sectionNumber][1] && secondElfSectionList[sectionNumber][1] >= firstElfSectionList[sectionNumber][0]))
                {
                    overlappingSectionNumber += 1;
                }
            }
            return overlappingSectionNumber;
        }
    }
}
