using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort_1_Partition
{
    class Program
    {
        static void partition(int[] ar)
        {
            int p = ar[0];
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            List<int> equal = new List<int>();

            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] == p)
                    equal.Add(ar[i]);
                else if (ar[i] > p)
                    right.Add(ar[i]);
                else if (ar[i] < p)
                    left.Add(ar[i]);
            }

            foreach (int item in left)
                Console.Write(item.ToString() + " ");
            foreach (int item in equal)
                Console.Write(item.ToString() + " ");
            foreach (int item in right)
                Console.Write(item.ToString() + " ");

        }
        /* Tail starts here */
        static void Main(String[] args)
        {

            int _ar_size;
            _ar_size = Convert.ToInt32(Console.ReadLine());
            int[] _ar = new int[_ar_size];
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
            {
                _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
            }

            partition(_ar);
        }
    }

}

