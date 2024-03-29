using System;

namespace Test_1025
{
    class Program
    {
        static void Selection_sort(ref int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i; j < a.Length; j++)
                {
                    if (a[j] < a[i])
                    {
                        int t = a[i];
                        a[i] = a[j];
                        a[j] = t;
                    }
                }
            }
        }

        public static void Main()
        {
            int K = int.Parse(Console.ReadLine());
            var S = Console.ReadLine().Split(' ');
            int[] group = new int[K];
            int[] people = new int[K];
            int result = 0;

            for (int i = 0; i < K; i++)
            {
                group[i] = int.Parse(S[i]);
            }

            Selection_sort(ref group);

            for(int i = 0; i < (Math.Ceiling((double)K / 2)) ; i++)
            {
                double h = Math.Ceiling((double)group[i] / 2);
                people[i] = (int)h;

                result += people[i];
            }

            Console.WriteLine(result);
        }
    }
}
