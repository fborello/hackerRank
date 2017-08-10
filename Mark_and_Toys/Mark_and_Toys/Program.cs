using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mark_and_Toys
{
    class Program
    {
        static int maximumToys(int[] prices, int k)
        {
            // Complete this function

            List<int> list = prices.ToList();
            list.Sort();

            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] <= k)
                {
                    k -= list[i];
                    count++;
                }
                else
                    break;
            }
            return count;
        }

        static void Main(String[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] prices_temp = Console.ReadLine().Split(' ');
            int[] prices = Array.ConvertAll(prices_temp, Int32.Parse);
            int result = maximumToys(prices, k);
            Console.WriteLine(result);

        }
    }
}
