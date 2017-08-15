using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Maximize
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            int T = int.Parse(Console.ReadLine());
            List<long> returnList = new List<long>();
            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(Console.ReadLine());
                long[] array = new long[N];
                string[] item = Console.ReadLine().ToString().Split(' ').ToArray();
                for (int j=0;j<N;j++)
                {
                    long l = long.Parse(item[j]);
                    array[j] = l;
                }
                Console.WriteLine(gain(array));
                
            }

            Console.ReadLine();
        }

        public static long gain(long[] li)
        {
            long gain = 0;
            long max = 0;
            for(int i = li.Length-1;i>=0;i--)
            {
                if (li[i] > max)
                    max = li[i];
                gain += max - li[i];
            }

            return gain;
        }
        
    }

}
