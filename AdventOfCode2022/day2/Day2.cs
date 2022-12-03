using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.day2
{
    public static class Day2
    {
        public static void Do()
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Projekty\Visual_Studio_2022\AdventOfCode2022\AdventOfCode2022\day2\data.txt");
            int myScore = 0;
            int wantedScore = 0;
            foreach (string line in lines)
            {
                char[] str = line.ToCharArray();
                string opponent = str[0].ToString();
                string player = str[2].ToString();
                int[] score = GetScore(opponent, player);
                
                if ((score[0] == 1 && score[1] == 2) || (score[0] == 2 && score[1] == 3) || (score[0] == 3 && score[1] == 1))
                {
                    score[1] += 6;
                }
                else if (score[0] == score[1])
                {
                    score[1] += 3; score[0] += 3;
                }
                myScore += score[1];
            }
            Console.WriteLine(myScore);
            foreach(var line in lines)
            {
                char[] str = line.ToCharArray();
                string opponent = str[0].ToString();
                string player = str[2].ToString();
                int[] score = GetScore(opponent, player);
                switch (score[1])
                {
                    case 1:
                        if (score[0] > 1) { wantedScore += score[0] - 1; }
                        if (score[0] == 1) { wantedScore += 3; }
                        break;
                    case 2:
                        wantedScore += score[0] + 3;
                        break;
                    case 3:
                        if (score[0] < 3) { wantedScore += score[0] + 7; }
                        if (score[0] == 3) { wantedScore += 7; }
                        break;
                }
            }
            Console.WriteLine(wantedScore);
        }
        public static int[] GetScore(string opponent, string player)
        {
            int op = 0;
            int pl = 0;
            switch (opponent)
            {
                case "A":
                    op = 1; break;

                case "B":
                    op = 2; break;

                case "C":
                    op = 3; break;
            }
            switch (player)
            {
                case "X":
                    pl = 1; break;

                case "Y":
                    pl = 2; break;

                case "Z":
                    pl = 3; break;
            }

            return new int[] { op, pl };
        }
        
    }
}
