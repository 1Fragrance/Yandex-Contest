using System;
using System.Linq;
using System.Collections.Generic;
namespace _555
{
    class Program
    {
        static void Main(string[] args)
        {
            // кол-во вершин
            int n;
            // кол-во ребер
            int m;
            // Индекс первого / индекс второго/ вес ребра
            int[] data;
            // Откуда и куда
            int begin, end;

            n = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());

            // Граф
            List<int[]>[] graph = new List<int[]>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int[]>();

            for (int i = 0; i < m; i++)
            {
                data = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                data[0]--;
                data[1]--;

                // Заполняем граф
                graph[data[0]].Add(new int[] { data[1], data[2] });
                graph[data[1]].Add(new int[] { data[0], data[2] });
            }

            begin = Convert.ToInt32(Console.ReadLine());
            end = Convert.ToInt32(Console.ReadLine());
            begin--;
            end--;

            // Массив с весами вершин
            Int64[] nodeValue = new Int64[n];
            // Массив посещений вершин
            bool[] visited = new bool[n];
            // Изначально на всех вершинах бесконечность
            for (int i = 0; i < n; i++)
                nodeValue[i] = Int64.MaxValue;
            nodeValue[begin] = 0;

            for(int i = 0; i < n; i++)
            {
                int minNode = Int32.MinValue;
                // Поиск непосещенной вершины
                for (int j = 0; j < n; j++)
                {
                    if (visited[j] == false)
                    {
                        if (minNode == Int32.MinValue)
                            minNode = j;
                        else if (nodeValue[minNode] > nodeValue[j])
                            minNode = j;
                    }
                }
                if(nodeValue[minNode] == Int32.MaxValue)
                    break;
                else
                {
                    visited[minNode] = true;
                    SetDistance(graph, minNode, nodeValue);
                }
            }

            Console.WriteLine(nodeValue[end]);
            Console.ReadKey();
        }


        // Проходим по всем возможным путям из вершины и сравниваем пути
        public static void SetDistance(List<int[]>[] graph, int minNode, Int64[] nodeValue)
        {
            for (int j = 0; j < graph[minNode].Count; j++)
            {
               Int64 neighbour = graph[minNode][j][0];
               Int64 weight = graph[minNode][j][1];
                if (nodeValue[minNode] + weight < nodeValue[neighbour])
                    nodeValue[neighbour] = nodeValue[minNode] + weight;
            }
        }
    }
}
