using System;
public class Program
{
	public static void Main()
	{
		int Y = Convert.ToInt32(Console.ReadLine());
		if(((Y % 4 == 0) && (Y % 100 != 0)) || (Y % 400 == 0)) {
			Console.WriteLine("YES");
		}
		else {
			Console.WriteLine("NO");
		}
	}
}
