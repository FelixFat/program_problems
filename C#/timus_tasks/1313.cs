using System;

namespace Test_1313
{
    class Program
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            if (N >= 1 && N <= 100) { }
            else return;

            int[,] m = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                var s = Console.ReadLine().Split(' ');
                for (int j = 0; j < N; j++)
                {
                    m[i, j] = int.Parse(s[j]);
                }
            }

            for (int i = 0; i < N; i++)
            {
                int x = i;
                int y = 0;
                while (x >= 0)
                {
                    Console.WriteLine(m[x, y] + " ");
                    x--;
                    y++;
                }
            }

            for (int i = 0; i < N; i++)
            {
                int x = N - 1;
                int y = i + 1;
                while (y < N)
                {
                    Console.WriteLine(m[x, y] + " ");
                    x--;
                    y++;
                }
            }
        }
    }
}
