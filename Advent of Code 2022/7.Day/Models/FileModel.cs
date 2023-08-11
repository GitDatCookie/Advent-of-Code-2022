using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._7.Day.Objects
{
    public record FileModel(string Name, long Size)
    {
        public static FileModel Parse(string input)
        {

            string[] tokens = input.Split();
            return new FileModel(tokens[1], long.Parse(tokens[0]));
        }
    }
}
