using System;
using System.Linq;


namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();

            int Width = data[0];
            int Height = data[1];
            int Player1_X = data[2];
            int Player1_Y = data[3];
            int Player2_X = data[4];
            int Player2_Y = data[5];

            int temp1 = Player1_X - Player2_X;
            int temp2 = Player1_Y - Player2_Y;

            if (temp1 == temp2 || temp1 == -temp2)
                Console.WriteLine("NO");
            else
                Console.WriteLine("YES");
        }
    }
}
