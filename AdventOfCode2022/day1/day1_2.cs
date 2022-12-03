using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2022.day1
{
    public static class day1_2
    {
        public static void Do()
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Projekty\Visual_Studio_2022\AdventOfCode2022\AdventOfCode2022\day1\data.txt");
            int sum = 0;
            int elves = 0;
            int actualElve = -1;
            foreach (string line in lines)
            {
                if (line == "") elves++;
            }
            int[] sumsOfElvesCalories = new int[elves];
            for (int i = 0; i < lines.Length; i++)
            {

                if (lines[i] != "")
                {
                    sum += int.Parse(lines[i]);
                }
                else
                {
                    actualElve++;
                    sumsOfElvesCalories[actualElve] = sum;
                    sum = 0;
                }

            }
            int first = sumsOfElvesCalories.Max();

            // Find second largest element
            int second = -int.MaxValue;
            for (int i = 0; i < sumsOfElvesCalories.Length; i++)
                if (sumsOfElvesCalories[i] > second && sumsOfElvesCalories[i] < first)
                    second = sumsOfElvesCalories[i];

            // Find third largest element
            int third = -int.MaxValue;
            for (int i = 0; i < sumsOfElvesCalories.Length; i++)
                if (sumsOfElvesCalories[i] > third && sumsOfElvesCalories[i] < second)
                    third = sumsOfElvesCalories[i];

            Console.WriteLine(first + second + third);

        }
    }
}
