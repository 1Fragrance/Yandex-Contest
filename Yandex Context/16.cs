using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] s = Console.ReadLine().Select(c => (int)Char.GetNumericValue(c)).ToArray();
            if (s.Length < 2)
            {
                Console.WriteLine("-1");
                return;
            }

            int firstPos = s.Length - 1;
            int secondPos =  s.Length - 2;

            for(int i = s.Length - 2; i > -2; i--)
            {
                if (i == -1)
                {
                    Console.WriteLine("-1");
                    return;
                }
                if (s[i] >= s[i + 1])
                {
                    continue;
                }
                else if(s[i] < s[i] + 1)
                {
                    firstPos = i;
                    break;
                }

            }

            for(int i = s.Length - 1; i > -1; i--)
            {
                if (s[i] <= s[firstPos])
                    continue;
                else
                {
                    secondPos = i;
                    int temp = s[secondPos];
                    s[secondPos] = s[firstPos];
                    s[firstPos] = temp;
                    break;
                }
            }

            secondPos = s.Length - 1;
            for(int i = firstPos + 1; i < secondPos; i++)
            {
                int temp = s[i];
                s[i] = s[secondPos];
                s[secondPos] = temp;
                secondPos--;
            }

            Console.WriteLine(String.Join("", s.Select(p => p.ToString()).ToArray()));
            Console.ReadKey();
        }


    }
}
