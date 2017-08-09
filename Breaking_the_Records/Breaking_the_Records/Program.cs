using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breaking_the_Records
{
    class Program
    {
        static int[] getRecord(int[] s)
        {
            // Complete this function

            int min = s[0];
            int max = s[0];

            int countMin = 0;
            int countMax = 0;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] > max)
                {
                    countMax++;
                    max = s[i];
                }
                else if (s[i] < min)
                {
                    countMin++;
                    min = s[i];
                }
            }

            List<int> l = new List<int>();
            l.Add(countMax);
            l.Add(countMin);

            return l.ToArray();
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] s_temp = Console.ReadLine().Split(' ');
            int[] s = Array.ConvertAll(s_temp, Int32.Parse);
            int[] result = getRecord(s);
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
