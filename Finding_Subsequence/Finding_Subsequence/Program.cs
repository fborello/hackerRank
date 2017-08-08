using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finding_Subsequence
{
    class Program
    {
        static string solve(string s, int k)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (dic.Keys.Contains(c))
                {
                    dic[c] = dic[c] + 1;
                }
                else
                    dic.Add(c, 1);
            }
            string newSTR = s;

            foreach (char c in dic.Keys)
            {
                if (dic[c] < k)
                    newSTR = newSTR.Replace(c.ToString(), "");
            }


            string abc = GetNextChar(newSTR);

            
            Dictionary<char, int> dicN = new Dictionary<char, int>();
            foreach (char c in abc)
            {
                if (dicN.Keys.Contains(c))
                {
                    dicN[c] = dicN[c] + 1;
                }
                else
                    dicN.Add(c, 1);
            }

            string newSTR2 = abc;

            foreach (char c in dicN.Keys)
            {
                if (dicN[c] < k)
                    newSTR2 = newSTR2.Replace(c.ToString(), "");
            }

            return newSTR2;

        }

        static string GetNextChar(string str)
        {
            if (str == String.Empty)
                return "";

            int index = 0;
            int MaxAsci = 0;
            int MaxIndex = 0;
            foreach (char c in str)
            {
                if ((int)c > MaxAsci)
                {
                    MaxIndex = index;
                    MaxAsci = (int)c;
                }
                index++;
            }



            int nextIndex = MaxIndex;
            if (MaxIndex < str.Length - 1)
                nextIndex = MaxIndex + 1;



            if (MaxIndex == str.Length - 1)
                return str[MaxIndex].ToString();


            string newSTR = str.Substring(MaxIndex, str.Length - MaxIndex);

            string SameText = SameNextLetter(newSTR);

            if (SameText != "")
            {
                nextIndex = SameText.Length + 1;
                newSTR = newSTR.Substring(nextIndex, newSTR.Length - nextIndex);
            }
            else
                newSTR = newSTR.Substring(1, newSTR.Length - 1);

            string Ret = str[MaxIndex].ToString() + SameText;

            return Ret + GetNextChar(newSTR);

        }

        static string SameNextLetter(string strNext)
        {
            if (strNext == String.Empty)
                return "";
            if (strNext.Length == 1)
                return "";

            if (strNext[0] == strNext[1])
                return strNext[1].ToString() + SameNextLetter(strNext.Substring(1, strNext.Length - 1));
            else
                return "";
        }

        static void Main(String[] args)
        {
            string s = Console.ReadLine();
            int k = Convert.ToInt32(Console.ReadLine());
            string result = solve(s, k);
            Console.WriteLine(result);
        }
    }
}
