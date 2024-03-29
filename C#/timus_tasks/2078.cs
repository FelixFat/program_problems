using System;

namespace Test_2078
{
    class Program
    {
        public static void Main()
        {
            int[] b = new int[10];
            var S = Console.ReadLine().Split(' ');
            for (int i = 0; i < 10; i++)
            {
                b[i] = int.Parse(S[i]);
            }

            int min = 0;
            int max = 0;
            for (int i = 0; i < 10; i++)
            {
                if (b[i] == 10 && i == 8)
                {
                    if (b[i + 1] > 20) min += b[i] + 10;
                    else if (b[i + 1] <= 20) min += b[i];
                }
                else min += b[i];

                if (b[i] == 10 && i < 7)
                {
                    if (b[i + 1] < 10) max += b[i] + b[i + 1];
                    else if (b[i + 1] == 10) max += b[i] + b[i + 1] + b[i + 2];
                }
                else if (b[i] == 10 && i == 7)
                {
                    if (b[i + 1] == 10 && b[i + 2] < 10) max += b[i] + b[i + 1] + b[i + 2];
                    else if (b[i + 1] == 10 && b[i + 2] >= 10) max += b[i] + b[i + 1] + 10;
                    else if (b[i + 1] != 10) max += b[i] + b[i + 1];
                }
                else if (b[i] == 10 && i == 8)
                {
                    if (b[i + 1] > 20) max += b[i] + 20;
                    else max += b[i] + b[i + 1];
                }
                else max += b[i];
            }

            Console.WriteLine("{0} {1}", min, max);
        }
    }
}
