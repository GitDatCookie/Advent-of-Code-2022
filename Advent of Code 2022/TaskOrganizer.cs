using Advent_of_Code_2022._1.Day;
using Advent_of_Code_2022._2.Day;
using Advent_of_Code_2022._3.Day;
using Advent_of_Code_2022._4.Day;
using Advent_of_Code_2022._5.Day;
using Advent_of_Code_2022._6.Day;
using Advent_of_Code_2022._7.Day;
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
            userInput = userInput.Trim('"');
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
                    CalculateTask4 task4 = new();
                    Console.WriteLine("The results are:");
                    Console.WriteLine("Part 1: " + task4.CalculatePart1(userInputFileLink));
                    Console.WriteLine("Part 2: " + task4.CalculatePart2(userInputFileLink));
                    break;
                case 5:
                    CalculateTask5 task5 = new();
                    (List<string[]> task5ListPart1, string task5StringPart1) = (task5.CalculatePart1(userInputFileLink).Item1, task5.CalculatePart1(userInputFileLink).Item2);
                    Console.WriteLine("The results are:\n");
                    Console.WriteLine("Part1:\n________________\n");
                    foreach (var line in task5ListPart1)
                    {
                        Console.WriteLine(line[0] + " " + line[1]);
                    }
                    Console.WriteLine($"\nResult: {task5StringPart1} \n________________");

                    (List<string[]> task5ListPart2, string task5StringPart2) = (task5.CalculatePart2(userInputFileLink).Item1, task5.CalculatePart2(userInputFileLink).Item2);
                    Console.WriteLine("The results are:\n");
                    Console.WriteLine("Part2:\n________________\n");
                    foreach (var line in task5ListPart2)
                    {
                        Console.WriteLine(line[0] + " " + line[1]);
                    }
                    Console.WriteLine($"\nResult: {task5StringPart2} \n________________");
                    break;
                case 6:
                    CalculateTask6 task6 = new();
                    Console.WriteLine("The results are:");
                    Console.WriteLine("Part 1: " + task6.CalculatePart1(userInputFileLink));
                    Console.WriteLine("Part 2: " + task6.CalculatePart2(userInputFileLink));
                    break;
                case 7:
                    CalculateTask7 task7 = new();
                    Console.WriteLine("The results are :");
                    Console.WriteLine("Part 1: " + task7.CalculatePart1(userInputFileLink));
                    Console.WriteLine("Part 2: " + task7.CalculatePart2(userInputFileLink));
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
