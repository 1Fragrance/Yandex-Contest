using System;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string X = Console.ReadLine();
			if (X[X.Length - 1] == '0') {
				Console.WriteLine("NO");
			}
			else {
				Console.WriteLine(X[X.Length -1]);
			}

        }
    }
}
