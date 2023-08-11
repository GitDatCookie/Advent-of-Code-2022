using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._6.Day
{
    internal class Tuning_Trouble
    {
        /// <summary>
        /// Provides string of input stream
        /// </summary>
        /// <param name="fileLink"></param>
        /// <returns></returns>
        public string GetTuningTroubleString(string fileLink)
        {
            string tuningTroubleString = System.IO.File.ReadAllText(fileLink);
            return tuningTroubleString;
        }

        /// <summary>
        /// Gets last char index of string, where there are no dublicate chars in a range of int distinctCharacters
        /// </summary>
        /// <param name="tuningTroubleString"></param>
        /// <param name="distinctCharacters"></param>
        /// <returns>see Summary</returns>
        public int GetStartOfPacketMarker(string tuningTroubleString, int distinctCharacters)
        {
            int startingPosition = 0;
            int counter = 0;
            bool dublicate = false;
            int marker = 0;
            string tuningTroubleSubString = tuningTroubleString.Substring(0, distinctCharacters);
            
            for (int i = 0; i < tuningTroubleString.Length - distinctCharacters; i++)
            {
                //checking substring for dublicates
                for(int j = 0; j< tuningTroubleSubString.Length; j++)
                {
                    //get first instance of char
                    var firstIndexOfChar = tuningTroubleSubString.IndexOf(tuningTroubleSubString[j]);
                    //get last instance of same char
                    var lastIndexofChar = tuningTroubleSubString.LastIndexOf(tuningTroubleSubString[j]);
                    //checks if first and last instance are the same, meaning char is identical
                    dublicate = firstIndexOfChar != lastIndexofChar && firstIndexOfChar != -1;
                    if (dublicate == false)
                    {
                        // checks if there were enough unique chars in string to set marker
                        if(counter == distinctCharacters-1)
                        {
                            marker = startingPosition + distinctCharacters;
                            break;
                        }
                        counter++;
                    }

                }
                counter = 0;
                startingPosition = i;
                tuningTroubleSubString = tuningTroubleString.Substring(startingPosition, distinctCharacters);
                if(marker != 0)
                {
                    break;
                }

            }


            return marker;

        }
    }
}
