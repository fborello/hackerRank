using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcs_Cakewalk
{
    class Program
    {
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] calories_temp = Console.ReadLine().Split(' ');
            int[] calories = Array.ConvertAll(calories_temp, Int32.Parse);
            // your code goes here
            List<int> list = calories.ToList();
            list.Sort();
            decimal Calories = 0;
            decimal Miles = 0;
            for (int i = n-1, j=0; i >= 0; i--)
            {
                Calories += list[i];
                Miles += (decimal)(list[i] * Math.Pow(2, j));
                j++;
            }
            Console.WriteLine(Miles.ToString());
            Console.ReadLine();
        }
    }
}
