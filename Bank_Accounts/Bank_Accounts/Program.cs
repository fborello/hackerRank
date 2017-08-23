using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Accounts
{
    class Program
    {
        static string feeOrUpfront(int n, int k, int x, int d, int[] p)
        {
            // Complete this function
            if (n * k > d)
                return "upfront";
            float max = (float)d;
            for (int i = 0; i < n; i++)
            {
                float perc = ((float)x / 100) * p[i];
                perc = perc > k ? perc : k;
                max -= perc;
                if (max < 0)
                    return "upfront";
            }
            return "fee";
        }

        static void Main(String[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                int k = Convert.ToInt32(tokens_n[1]);
                int x = Convert.ToInt32(tokens_n[2]);
                int d = Convert.ToInt32(tokens_n[3]);
                string[] p_temp = Console.ReadLine().Split(' ');
                int[] p = Array.ConvertAll(p_temp, Int32.Parse);
                string result = feeOrUpfront(n, k, x, d, p);
                Console.WriteLine(result);
            }
        }
    }
}
