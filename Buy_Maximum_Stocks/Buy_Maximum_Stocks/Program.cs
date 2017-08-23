using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buy_Maximum_Stocks
{
    class Program
    {
        static long buyMaximumProducts(int n, ulong k, int[] a)
        {
            // Complete this function
            long count = 0;
            ulong money = k;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                dic.Add(a[i], i + 1);
            }
            List<int> l = a.OrderBy(p => p).ToList();
            for (int i = 0; i < n; i++)
            {
                ulong val = (ulong)l[i];
                int day = dic[l[i]];
                ulong max = (ulong)dic[l[i]] * val;
                if (max <= money)
                {
                    count += day;
                    money -= max;
                    if (money == 0)
                        return count;
                }
                else if(money >= val)
                {
                    decimal daysRet = Math.Truncate((decimal)money / val);
                    if (daysRet > 0)
                    {
                        ulong max2 = (ulong)daysRet * val;
                        if (max2 <= money)
                        {
                            count += (int)daysRet;
                            money -= max2;
                            if (money == 0)
                                return count;
                        }
                    }
                }
            }
            return count;
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Trim().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            ulong k = Convert.ToUInt64(Console.ReadLine());
            long result = buyMaximumProducts(n, k, arr);
            Console.WriteLine(result);
        }
    }
}
