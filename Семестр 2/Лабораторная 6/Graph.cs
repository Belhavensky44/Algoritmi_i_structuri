using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab_6
{
    public class Graph
    {
        private Dictionary<string, int> vertexIndices;
        private List<string> vertices;
        private List<int>[] adjacencyList;

        public Graph(int maxVertices)
        {
            vertexIndices = new Dictionary<string, int>();
            vertices = new List<string>();
            adjacencyList = new List<int>[maxVertices];

            for (int i = 0; i < maxVertices; i++)
            {
                adjacencyList[i] = new List<int>();
            }
        }

        public bool AddVertex(string name)
        {
            if (vertexIndices.ContainsKey(name))
                return false;

            vertexIndices[name] = vertices.Count;
            vertices.Add(name);
            return true;
        }

        public bool AddEdge(string vertex1, string vertex2, bool autoCreateVertices = false)
        {
            if (autoCreateVertices)
            {
                AddVertex(vertex1);
                AddVertex(vertex2);
            }

            if (!vertexIndices.TryGetValue(vertex1, out int index1))
            {
                Console.WriteLine($"Ошибка: вершина '{vertex1}' не существует");
                return false;
            }

            if (!vertexIndices.TryGetValue(vertex2, out int index2))
            {
                Console.WriteLine($"Ошибка: вершина '{vertex2}' не существует");
                return false;
            }

            if (adjacencyList[index1].Contains(index2))
            {
                Console.WriteLine($"Предупреждение: ребро '{vertex1}-{vertex2}' уже существует");
                return false;
            }

            adjacencyList[index1].Add(index2);
            adjacencyList[index2].Add(index1);
            Console.WriteLine($"Добавлено ребро: {vertex1}-{vertex2}");
            return true;
        }

        public void PrintGraph()
        {
            Console.WriteLine("\nТекущая структура графа:");
            foreach (var vertex in vertices)
            {
                Console.Write($"{vertex}: ");
                foreach (var neighborIndex in adjacencyList[vertexIndices[vertex]])
                {
                    Console.Write($"{vertices[neighborIndex]} ");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Graph graph = new Graph(10);

            graph.AddVertex("Москва");
            graph.AddVertex("Санкт-Петербург");
            graph.AddVertex("Казань");
            
            // Стандартное добавление ребра
            graph.AddEdge("Москва", "Санкт-Петербург");
            //Попытка добавить ребро с несуществующей вершиной
            graph.AddEdge("Москва", "Владивосток");
            // Автоматическое создание вершин
            graph.AddEdge("Сочи", "Калининград", autoCreateVertices: true);
            // Попытка добавить существующее ребро
            graph.AddEdge("Москва", "Санкт-Петербург");

            graph.PrintGraph();

            Console.ReadLine();
        }
    }
}
