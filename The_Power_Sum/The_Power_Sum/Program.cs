using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Power_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int X = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());

            decimal first = 1;
            decimal v = first / N;

            double maxNum = Math.Pow(X, (double)v);

            double maxNum2 = Math.Truncate(maxNum);

            decimal count = 0;

            count += SumOrNot(maxNum2, X, N, v);

            Console.WriteLine(count.ToString());
            Console.ReadLine();
        }

        private static int SumOrNot(double maxNum2, int X, int N, decimal v)
        {
            int count = 0;
            double sum = 0;
            for (int i = (int)maxNum2; i > 0; i--)
            {
                sum += Math.Pow(i, N);
                if (sum == X)
                    count += 1 + SumOrNot(maxNum2 - 1, X, N, v);
                else if (sum > X)
                    count += SumOrNot(maxNum2 - 1, X, N, v);
                else
                {
                    double rest = X - sum;

                    double restNum = Math.Pow(rest, (double)v);

                    double restNum2 = Math.Truncate(restNum);
                    if (i != 1)
                        i = (int)restNum2 + 1;
                }

            }

            if(maxNum2 != 1)
                count += SumOrNot(maxNum2 - 1, X, N, v);

            return count;
        }
    }
}

