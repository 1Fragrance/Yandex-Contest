using System;
using System.Linq;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            string[] A = Console.ReadLine().Split(' ');
            long[] a = A.Select(long.Parse).ToArray();
            Array.Sort(a);

            if (N > 3) {
                if (a[N-1] * a[N-2] > a[0] * a[1] ) {
                    Console.WriteLine((a[N-1] * a[N-2]));
                }
                else {
                    Console.WriteLine((a[0] * a[1]));
                }
            }
            else if (N == 3){
                Console.WriteLine((Math.Max(a[0]*a[1],Math.Max(a[1]*a[2],a[0]*a[2]))));
            }
            else {
                Console.WriteLine((a[0]*a[1]));
            }

        }
    }
}
