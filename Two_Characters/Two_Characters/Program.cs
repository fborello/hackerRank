using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Characters
{
    class Program
    {
        static void Main(String[] args)
        {
            int len = Convert.ToInt32(Console.ReadLine());
            string s = Console.ReadLine();

            List<char> listChar = new List<char>();


            int max = 0;
            string newSTR = RemoveChar(s);

            foreach (char c in newSTR)
            {
                if (!listChar.Contains(c))
                    listChar.Add(c);
            }
            for (int i = 0; i < listChar.Count; i++)
            {
                for (int j = 1; j < listChar.Count; j++)
                {
                    string a = RemoveChars(newSTR, listChar[i], listChar[j]);
                    bool validated = Validate(a);
                    if (validated && a.Length > max)
                    {
                        max = a.Length;
                    }
                }
            }


            Console.WriteLine(max.ToString());
        }

        private static string RemoveChars(string s, char v1, char v2)
        {
            string aaa = s;

            foreach (char c in s)
            {
                if (c != v1 && c != v2)
                    aaa = aaa.Replace(c.ToString(), "");
            }
            return aaa;
        }

        static bool Validate(string str)
        {
            bool find = false;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == str[i - 1])
                {
                    find = true;
                    str = str.Replace(str[i].ToString(), "");
                    break;
                }
            }

            return !find;
        }

        static string RemoveChar(string str)
        {
            bool find = false;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == str[i - 1])
                {
                    find = true;
                    str = str.Replace(str[i].ToString(), "");
                    break;
                }
            }
            if (find)
                return RemoveChar(str);

            return str;
        }
    }
}
