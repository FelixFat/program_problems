using System;

namespace Test_2100
{
    class Program
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            if (N >= 1 && N <= 20) { }
            else return;

            int P = 200;

            string[] G = new string[N];
            for (int i = 0; i < N; i++)
            {
                G[i] = Console.ReadLine();

                bool End = G[i].EndsWith("+one");
                if (End == true) P += 200;
                else P += 100;
            }

            if (P == 1300) P += 100;

            Console.WriteLine(P);
        }
    }
}
