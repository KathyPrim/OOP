using System;
using System.Collections.Generic;

public class MaxFlow
{
    static readonly int V = 14; // кол-во вершин

    /* Возвращает true, если есть путь от
    S до T в графе. Заполняет parent[] для
    хранения пути.*/
    bool bfs(int[,] rGraph, int s, int t, int[] parent)
    {
        // Создаем массив посещений и
        // помечаем все вершины как не посещенные
        bool[] visited = new bool[V];
        for (int i = 0; i < V; ++i)
            visited[i] = false;

        // Создание очередии добавление исходной
        // вершины в очередь. Отмечаем ее как посещенную
        List<int> queue = new List<int>();
        queue.Add(s);
        visited[s] = true;
        parent[s] = -1;

        while (queue.Count != 0)
        {
            int u = queue[0];
            queue.RemoveAt(0);

            for (int v = 0; v < V; v++)
            {
                if (visited[v] == false
                    && rGraph[u, v] > 0)
                {
                    // Если находим соедение стока с истоком в остаточном графе
                    // то прекращаем алгоритм BFS. Устанавливаем
                    // родительский узел и возвращаем true
                    if (v == t)
                    {
                        parent[v] = u;
                        return true;
                    }
                    queue.Add(v);
                    parent[v] = u;
                    visited[v] = true;
                }
            }
        }

        // Мы не нашли путь в BFS, поэтому возвращаем false
        return false;
    }

    // Возвращает максимальный поток из S в T в графе
    int fordFulkerson(int[,] graph, int s, int t)
    {
        int u, v;

        // Создаем остаточный граф и заполняем его
        // заданными пропускными способностями.
        // Остаточный граф rGrapg[i,j] показывает
        // остаточную пропускную способность ребра
        // от i до j.
        int[,] rGraph = new int[V, V];

        for (u = 0; u < V; u++)
            for (v = 0; v < V; v++)
                rGraph[u, v] = graph[u, v];

        // Массив зяполняется BFS и хранит путь
        int[] parent = new int[V];

        int max_flow = 0; // Изначально максимальный поток равен 0

        // Пока существует путь от истока до стока в остаточном графе
        // увеличиваем максимальный поток
        while (bfs(rGraph, s, t, parent))
        {
            // Найдем максимальный поток на найденном пути
            int path_flow = int.MaxValue;
            for (v = t; v != s; v = parent[v])
            {
                u = parent[v];
                path_flow
                    = Math.Min(path_flow, rGraph[u, v]);
            }

            // обновляем очтаточные пропускные способности 
            // на найденном пути
            for (v = t; v != s; v = parent[v])
            {
                u = parent[v];
                rGraph[u, v] -= path_flow;
                rGraph[v, u] += path_flow;
            }

            // Добавляем максимальный поток пути к общему максимальному потоку
            max_flow += path_flow;
        }

        return max_flow;
    }

    public static void Main()
    {
        int[,] graph = new int[,] {
            { 0,9,5,9,5,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,6,0,0,0,0,0,0,0,0 },
            { 0,3,0,6,0,4,3,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,6,0,0,0,0,0,0 },
            { 0,0,0,3,0,0,0,0,3,0,0,0,0,0 },
            { 0,0,0,0,0,0,1,0,0,7,0,0,0,0 },
            { 0,0,0,0,0,0,0,1,0,5,3,0,0,0 },
            { 0,0,0,0,0,0,0,0,1,0,0,7,0,0 },
            { 0,0,0,5,0,0,0,0,0,0,0,0,3,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,6 },
            { 0,0,0,0,0,0,0,5,0,0,0,0,0,7 },
            { 0,0,0,0,0,0,3,0,0,0,7,0,0,6 },
            { 0,0,0,0,0,0,0,7,0,0,0,4,0,7 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
        };
        MaxFlow m = new MaxFlow();

        Console.WriteLine("Максимальный поток через заданный граф: "
                          + m.fordFulkerson(graph, 0, 13));
    }
}