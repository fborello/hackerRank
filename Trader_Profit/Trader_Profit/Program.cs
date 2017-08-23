using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trader_Profit
{
    class Program
    {
        static int traderProfit(int k, int n, int[] A)
        {
            // Complete this function
            int sum = 0;
            List<int> list = A.ToList();
            int max = list.Max();            
            int indexOfMax = list.IndexOf(max);

            int min = list.Min();            
            int indexOfMin = list.IndexOf(min);



            return sum;
        }

        static void Main(String[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                int k = Convert.ToInt32(Console.ReadLine());
                int n = Convert.ToInt32(Console.ReadLine());
                string[] arr_temp = Console.ReadLine().Split(' ');
                int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
                int result = traderProfit(k, n, arr);
                Console.WriteLine(result);
            }
        }
    }
}
