using System;
using System.Collections.Generic;

namespace Test_1494
{
    class Program
    {
        static int N;
        static int[] b_ball;
        static int state;
        static int min = 0;
        static Stack<int> Pocket = new Stack<int>();

        static void Check(int ball)
        {
            if (ball > min)
            {
                for (int i = min + 1; i <= ball; i++)
                {
                    Pocket.Push(i);
                }
                min = ball;
                Pocket.Pop();
            }
            else if (ball < min && ball == Pocket.Peek()) Pocket.Pop();
            else state = 1;
        }

        public static void Main()
        {
            N = int.Parse(Console.ReadLine());
            b_ball = new int[N];

            for (int i = 0; i < N; i++)
            {
                b_ball[i] = int.Parse(Console.ReadLine());
                Check(b_ball[i]);
            }

            switch (state)
            {
                case 0:
                    {
                        Console.WriteLine("Not a proof");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Cheater");
                        break;
                    }
            }
        }
    }
}
