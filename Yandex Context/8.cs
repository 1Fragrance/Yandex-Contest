using System;

namespace Aisd
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			String S = Console.ReadLine();

			bool check2 = true;
			for (int i = 0, j = S.Length -1 ; i < j + 1 ;i++, j--) {
				if (S[i] != S[0] || S[j] != S[0])
					check2 = false;
			}
			if (check2)
			{
				Console.WriteLine("-1");
				return;
			}

			bool check = true;
			for (int i = 0, j = S.Length - 1; i < j+1; i++, j--) {
				if (S[i] != S[j])
					check = false;
			}
			Console.WriteLine(check ? S.Length - 1 : S.Length);

        }
    }
}
