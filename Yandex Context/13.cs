using System;
using System.Collections.Generic;
using System.Linq;

namespace _13
{
    class Program
    {
        public static void GoThrough(int index, bool[] isVisited, List<int>[] graph)
        {
            // Устанавливается флаг посещения
            isVisited[index] = true;
            // Проходим по всем соседям
            foreach (int item in graph[index])
                // Если какой-то сосед не посещен
                if (!isVisited[item])
                    // Выполняем те же действия и для него
                    GoThrough(item, isVisited, graph);
        }

        public static int Task1(int count, bool[] isVisited, List<int>[] graph)
        {
            int result = 0;
            // Проходим по всем вершинам
            for (int i = 0; i < count; i++)
                // Если вершина не посещалась
                if (!isVisited[i])
                {
                    // Устанавливаем посещение и проверяем все связи
                    GoThrough(i, isVisited, graph);
                    result++;
                }
            return result;
        }

        public static int Task13(int result, int[] data)
        {
            if (data[1] - data[0] + 1 >= 0 && result == 1)
                return data[1] - data[0] + 1;
            else
                return -1;
        }


        static void Main(string[] args)
        {
            // [n][m]
            int[] data = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
            // Массив для проверки посещения вершин
            bool[] isVisited = new bool[data[0]];
            for (int i = 0; i < data[0]; i++)
                isVisited[i] = false;
            // Граф
            List<int>[] graph = new List<int>[data[0]];
            for (int i = 0; i < data[0]; i++)
                graph[i] = new List<int>();

            for (int i = 0; i < data[1]; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                // редактируем в индексы
                input[0]--;
                input[1]--;
                // Заполняем информацию о вершинах
                graph[input[0]].Add(input[1]);
                graph[input[1]].Add(input[0]);
            }
            // Ответ
            Console.WriteLine(Task13((Task1(data[0], isVisited, graph)), data));
        }
    }
}
