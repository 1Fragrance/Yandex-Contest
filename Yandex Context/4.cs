using System;
using System.Linq;
using System.Collections.Generic;

namespace _44
{
    class Program
    {
        static void MakeStep(int[] pos, bool[][] board, Queue<int[]> steps, int max_y, int max_x, ref int count)
        {
            // вверх 2 вправо 1
            if (((pos[0] + 1) < max_x && (pos[1] + 2) < max_y && !board[pos[0] + 1][pos[1] + 2]))
            {
                board[pos[0] + 1][pos[1] + 2] = true;
                steps.Enqueue(new int[] { pos[0] + 1, pos[1] + 2, pos[2] + 1 });
                count++;
            }
            // вверх 2 влево 1
            if ((pos[0] - 1) >= 0 && (pos[1] + 2) < max_y && (!board[pos[0] - 1][pos[1] + 2]))
            {
                board[pos[0] - 1][pos[1] + 2] = true;
                steps.Enqueue(new int[] { pos[0] - 1, pos[1] + 2, pos[2] + 1 });
                count++;
            }
            // вниз 2 влево 1
            if ((pos[0] - 1) >= 0 && (pos[1] - 2) >= 0 && (!board[pos[0] - 1][pos[1] - 2]))
            {
                board[pos[0] - 1][pos[1] - 2] = true;
                steps.Enqueue(new int[] { pos[0] - 1, pos[1] - 2, pos[2] + 1 });
                count++;
            }
            // вниз 2 вправо 1
            if ((pos[0] + 1) < max_x && (pos[1] - 2) >= 0 && (!board[pos[0] + 1][pos[1] - 2]))
            {
                board[pos[0] + 1][pos[1] - 2] = true;
                steps.Enqueue(new int[] { pos[0] + 1, pos[1] - 2, pos[2] + 1 });
                count++;
            }
            // вверх 1 вправо 2
            if ((pos[0] + 2) < max_x && (pos[1] + 1) < max_y && (!board[pos[0] + 2][pos[1] + 1]))
            {
                board[pos[0] + 2][pos[1] + 1] = true;
                steps.Enqueue(new int[] { pos[0] + 2, pos[1] + 1, pos[2] + 1 });
                count++;
            }
            // вниз 1 вправо 2
            if ((pos[0] + 2) < max_x && (pos[1] - 1) >= 0 && (!board[pos[0] + 2][pos[1] - 1]))
            {
                board[pos[0] + 2][pos[1] - 1] = true;
                steps.Enqueue(new int[] { pos[0] + 2, pos[1] - 1, pos[2] + 1 });
                count++;
            }
            // вверх 1 влево 2
            if ((pos[0] - 2) >= 0 && (pos[1] + 1) < max_y && (!board[pos[0] - 2][pos[1] + 1]))
            {
                board[pos[0] - 2][pos[1] + 1] = true;
                steps.Enqueue(new int[] { pos[0] - 2, pos[1] + 1, pos[2] + 1 });
                count++;
            }
            // вниз 1 влево 2
            if ((pos[0] - 2) >= 0 && (pos[1] - 1) >= 0 && (!board[pos[0] - 2][pos[1] - 1]))
            {
                board[pos[0] - 2][pos[1] - 1] = true;
                steps.Enqueue(new int[] { pos[0] - 2, pos[1] - 1, pos[2] + 1 });
                count++;
            }
        }

        static void Main(string[] args)
        {
            Queue<int[]> steps = new Queue<int[]>();
            steps.Enqueue(new int[]{0, 0, 0});
            int count = steps.Count();

            int[] data = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
            int max_x = data[0];
            int max_y = data[1];
            int find_x = data[2];
            int find_y = data[3];
            find_x--;
            find_y--;


            bool[][] board = new bool[max_x][];
            for(int i = 0; i < max_x; i++)
                board[i] = new bool[max_y];


            for(; steps.Count > 0;)
            {
                // x[0] y[1]
                int[] pos = steps.Dequeue();
                count--;

                // Ячейки можно посещать лишь 1 раз
                // В очередь добавляем все возможные пути и полностью проходим их

                if (pos[0] == find_x && pos[1] == find_y)
                {
                    Console.WriteLine(pos[2]);
                    Console.ReadKey();
                    return;
                }
                else
                    MakeStep(pos, board, steps, max_y, max_x, ref count);
            }
            Console.WriteLine("NEVAR");
            Console.ReadKey();
        }
    }
}
