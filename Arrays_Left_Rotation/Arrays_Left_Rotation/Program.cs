using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Left_Rotation
{
    class Program
    {
        static void Main(String[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);

            string s = Console.ReadLine();
            string[] a_temp = s.Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            
            
            string str = "";
            
            int pos = 0;
            for(int i=0;i<k;i++)
            {
                pos += a[i].ToString().Length + 1;
            }

            str = s.Substring(pos) +" ";
            str += s.Substring(0, pos-1);
            
            Console.WriteLine(str);
            Console.ReadLine();

        }
    }
}

