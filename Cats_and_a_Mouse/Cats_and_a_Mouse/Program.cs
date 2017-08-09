using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cats_and_a_Mouse
{
    class Program
    {
        static void Main(String[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                string[] tokens_x = Console.ReadLine().Split(' ');
                int x = Convert.ToInt32(tokens_x[0]);
                int y = Convert.ToInt32(tokens_x[1]);
                int z = Convert.ToInt32(tokens_x[2]);

                int CatA = x - z;
                int CatB = y - z;

                if (Math.Abs(CatA) == Math.Abs(CatB))
                    Console.WriteLine("Mouse C");
                else if (Math.Abs(CatA) < Math.Abs(CatB))
                    Console.WriteLine("Cat A");
                else
                    Console.WriteLine("Cat B");


            }

        }
    }
}
