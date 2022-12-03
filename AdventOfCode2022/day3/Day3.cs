using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.day3
{
    public static class Day3
    {
        public static void Part1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Projekty\Visual_Studio_2022\AdventOfCode2022\AdventOfCode2022\day3\data.txt");

            int sharedItemValueSum = 0;
            int groupSharedItemValueSum = 0;
            foreach (string line in lines)
            {
                //part 1
                int[] firstCompartment = new int[line.Length / 2];
                int[] secondCompartment = new int[line.Length / 2];
                for (int i = 0; i < line.Length; i++)
                {
                    var offSet = (Char.IsLower(line[i])) ? 96 : 38;
                    if (i < line.Length / 2)
                    {

                        firstCompartment[i] = (int)Convert.ToChar(line[i]) - offSet;
                    }
                    else
                    {
                        secondCompartment[i - line.Length / 2] = (int)Convert.ToChar(line[i]) - offSet;
                    }
                }
                List<int> usedChars = new List<int>();
                for (int i = 1; i < 53; i++)
                {
                    usedChars.Add(i);
                }
                for (var first = 0; first < firstCompartment.Length; first++)
                {
                    for (var second = 0; second < secondCompartment.Length; second++)
                    {
                        if (firstCompartment[first] == secondCompartment[second])
                        {
                            if (usedChars.Contains(firstCompartment[first]))
                            {
                                sharedItemValueSum += secondCompartment[second];
                                usedChars.Remove(firstCompartment[first]);
                            }
                        }
                    }
                }


            }

            Console.WriteLine(sharedItemValueSum);

        }
        public static void Part2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Projekty\Visual_Studio_2022\AdventOfCode2022\AdventOfCode2022\day3\data.txt");

            int groupSharedItemValueSum = 0;


            for (int l = 0; l < lines.Length; l += 3)
            {
                var a = lineToCharArray(lines[l]);
                var b = lineToCharArray(lines[l + 1]);
                var c = lineToCharArray(lines[l + 2]);
                groupSharedItemValueSum += a.Intersect(b).Intersect(c).Single();
            }

            Console.WriteLine(groupSharedItemValueSum);
        }
        public static int[] lineToCharArray(string line)
        {

            var newArr = new int[line.Length];
            for (int i = 0; i < line.Length; i++)
            {
                var offSet = (Char.IsLower(line[i])) ? 96 : 38;
                newArr[i] = (int)Convert.ToChar(line[i]) - offSet;
            }
            return newArr;
        }
    }
}
