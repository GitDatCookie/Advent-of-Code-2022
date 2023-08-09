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
        public string[] GetCampSectionList(string fileLink)
        {
            string[] campSectionList = System.IO.File.ReadAllLines(fileLink);
            return campSectionList;
        }

        public List<int[]> GetFirstElfSectionList(string[] campSectionList)
        {
            List<int[]> firstElfSectionList = new();

            string subString;
            int firstSection;
            int lastSection;
            int[] sections;

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

        public List<int[]> GetSecondElfSectionList(string[] campSectionList)
        {
            List<int[]> secondtElfSectionList = new();

            string subString;
            int firstSection;
            int lastSection;
            int[] sections;

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
