using System;
using System.Linq;
namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1087388483 = 1021·1031·1033 = 1052651 * 1033 = 1021 * 1065023 = 1054693 * 1031
            int N = Convert.ToInt32(Console.ReadLine());
            string[] str = new string[N];

            for(int i = 0; i < N; i++) {
                 str[i] = Console.ReadLine();
            }

            if((str.Contains("1021") && str.Contains("1031") && str.Contains("1033"))
               || (str.Contains("1052651") && str.Contains("1033"))
               || (str.Contains("1065023") && str.Contains("1021"))
               || (str.Contains("1054693") && str.Contains("1031"))
               || (str.Contains("1087388483")))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}
