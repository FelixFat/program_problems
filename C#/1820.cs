using System;

namespace Test_1820
{
    class Program
    {
        public static void Main()
        {
            var S = Console.ReadLine().Split(' ');
            int N = int.Parse(S[0]);
            int K = int.Parse(S[1]);

            if ((N >= 1 && K >= 1) && (N <= 1000 && K <= 1000)) { }
            else return;

            int R = 0;
            if (N <= K) R = 2;
            else R = Convert.ToInt32(Math.Ceiling((double)N / (double)K * 2));

            Console.WriteLine(R);
        }
    }
}
