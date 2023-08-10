using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._4.Day
{
    internal class Camp_Cleanup_Part1
    {
        /// <summary>
        /// Gets a list of string variables
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns>Section pairs which need to be cleaned</returns>
        public string[] GetCampSectionList(string fileLink)
        {
            string[] campSectionList = System.IO.File.ReadAllLines(fileLink);
            return campSectionList;
        }

        /// <summary>
        /// Gets first half of campSectionList
        /// </summary>
        /// <param name="campSectionList"></param>
        /// <returns>A new List of the first half of campSectionList</returns>
        public List<int[]> GetFirstElfSectionList(string[] campSectionList)
        {
            List<int[]> firstElfSectionList = new();

            string subString;
            int firstSection;
            int lastSection;
            int[] sections;

            //splits each line in 2 and takes first half of line to get the range of 2 numbers connected with '-'
            //e.g. 5-7, 7-9 will add [5][7] to list
            foreach(var campSection in campSectionList)
            {
                subString = campSection.Substring(0, campSection.IndexOf(","));

                int.TryParse(subString.Substring(0, subString.IndexOf("-")), out firstSection);
                int.TryParse(subString.Substring(subString.IndexOf("-")+1), out lastSection);
                sections = new int[] { firstSection, lastSection };
                firstElfSectionList.Add(sections);
            }

            return firstElfSectionList;
        }

        /// <summary>
        /// Gets second half of campSectionList
        /// </summary>
        /// <param name="campSectionList"></param>
        /// <returns>A new List of the second half of campSectionList</returns>
        public List<int[]> GetSecondElfSectionList(string[] campSectionList)
        {
            List<int[]> secondtElfSectionList = new();

            string subString;
            int firstSection;
            int lastSection;
            int[] sections;

            //splits each line in 2 and takes second half of line to get the range of 2 numbers connected with '-'
            //e.g. 5-7, 7-9 will add [7][9] to list
            foreach (var campSection in campSectionList)
            {
                subString = campSection.Substring(campSection.IndexOf(",")+1);

                int.TryParse(subString.Substring(0, subString.IndexOf("-")), out firstSection);
                int.TryParse(subString.Substring(subString.IndexOf("-")+1), out lastSection);
                sections = new int[] { firstSection, lastSection };
                secondtElfSectionList.Add(sections);
            }

            return secondtElfSectionList;
        }

        /// <summary>
        /// checks if any of the number ranges are fully overlapping with another
        /// </summary>
        /// <param name="firstElfSectionList"></param>
        /// <param name="secondElfSectionList"></param>
        /// <returns> the number of overlapping pairs </returns>
        public int GetOverlappingSectionNumber(List<int[]> firstElfSectionList, List<int[]> secondElfSectionList)
        {
            int overlappingSectionNumber = 0; ;
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
                if ((firstElfSectionList[sectionNumber][0] >= secondElfSectionList[sectionNumber][0] && firstElfSectionList[sectionNumber][1] <= secondElfSectionList[sectionNumber][1]) 
                    || (secondElfSectionList[sectionNumber][0] >= firstElfSectionList[sectionNumber][0] && secondElfSectionList[sectionNumber][1] <= firstElfSectionList[sectionNumber][1]))
                {
                    overlappingSectionNumber += 1;
                }
            }
            return overlappingSectionNumber;
        }
    }
}
