using Advent_of_Code_2022._1.Day;
using Advent_of_Code_2022._2.Day;
using Advent_of_Code_2022._3.Day;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
{
    internal class TaskOrganizer
    {
        /// <summary>
        /// see method title
        /// </summary>
        /// <returns>see method title minus get</returns>
        public string GetUserInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }

        /// <summary>
        /// Controls which CalculateTask will be called
        /// </summary>
        public void ChooseTask()
        {

            Console.WriteLine("Please choose which day to test. (1-25)");

            int taskNumber;
            bool parseResult = int.TryParse(GetUserInput(), out taskNumber);

            if (parseResult == true && taskNumber < 26 && taskNumber > 0)
            {
                Console.WriteLine($"Testing Tasks of Day {taskNumber} \nPlease enter the path to your Task Input File:");
                ExecuteTask(taskNumber, GetUserInput());
            }
            else
            {
                if (parseResult != true)
                {
                    Console.WriteLine("You didn't enter a number.");
                    ChooseTask();

                }
                else
                {
                    Console.WriteLine("Your number was not in range.");
                    ChooseTask();
                }
            }
        }

        /// <summary>
        /// executes choosen Task
        /// </summary>
        /// <param name="taskNumber"></param>
        /// <param name="userInputFileLink"></param>
        public void ExecuteTask(int taskNumber, string userInputFileLink)
        {
            switch (taskNumber)
            {
                case 1:
                    CalculateTask1 task1 = new();
                    Console.WriteLine("The results are:");
                    Console.WriteLine("Part 1: " + task1.CalculatePart1(userInputFileLink));
                    Console.WriteLine("Part 2: " + task1.CalculatePart2(userInputFileLink));
                    break;
                case 2:
                    CalculateTask2 task2 = new();
                    Console.WriteLine("The results are:");
                    Console.WriteLine("Part 1: " + task2.CalculatePart1(userInputFileLink));
                    Console.WriteLine("Part 2: " + task2.CalculatePart2(userInputFileLink));
                    break;
                case 3:
                    CalculateTask3 task3 = new();
                    Console.WriteLine("The results are:");
                    Console.WriteLine("Part 1: " + task3.CalculatePart1(userInputFileLink));
                    Console.WriteLine("Part 2: " + task3.CalculatePart2(userInputFileLink));
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                case 16:
                    break;
                case 17:
                    break;
                case 18:
                    break;
                case 19:
                    break;
                case 20:
                    break;
                case 21:
                    break;
                case 22:
                    break;
                case 23:
                    break;
                case 24:
                    break;
                case 25:
                    break;

            }
        }

    }
}
