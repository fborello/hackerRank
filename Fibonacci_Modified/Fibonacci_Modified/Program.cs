using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_Modified
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            string[] str = Console.ReadLine().Split(' ');

            List<decimal> list = new List<decimal>();
            list.Add(decimal.Parse(str[0]));
            list.Add(decimal.Parse(str[1]));
            decimal m = decimal.Parse(str[2]);

            for (int i = 2; i < m; i++)
            {
                decimal next = list[i - 2] + (list[i - 1] * list[i - 1]);
                list.Add(next);
            }

            Console.WriteLine(list[list.Count - 1].ToString());
            Console.ReadLine();
        }
    }
}
