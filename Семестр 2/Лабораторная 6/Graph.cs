using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    public class Graph
    {
        public class Vertex
        {
            public char Label { get; private set; }
            public bool IsVisited { get; set; }

            public Vertex(char label)
            {
                Label = label;
                IsVisited = false;
            }
        }

        private List<Vertex> vertexList; 
        private List<int>[] adjacencyList; 

        public Graph(int maxVertices)
        {
            vertexList = new List<Vertex>(maxVertices);
            adjacencyList = new List<int>[maxVertices];

            for (int i = 0; i < maxVertices; i++)
            {
                adjacencyList[i] = new List<int>();
            }
        }

        public void AddVertex(char label)
        {
            vertexList.Add(new Vertex(label));
        }

        public void AddEdge(int start, int end)
        {
            if (start >= 0 && start < vertexList.Count &&
                end >= 0 && end < vertexList.Count)
            {
                adjacencyList[start].Add(end);
                adjacencyList[end].Add(start);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Неверные индексы вершин");
            }
        }

        public void PrintGraph()
        {
            for (int i = 0; i < vertexList.Count; i++)
            {
                Console.Write($"Вершина {vertexList[i].Label}: ");
                foreach (var neighbor in adjacencyList[i])
                {
                    Console.Write($"{vertexList[neighbor].Label} ");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Graph graph = new Graph(5);

            graph.AddVertex('Q');
            graph.AddVertex('W');
            graph.AddVertex('E');
            graph.AddVertex('R');

            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(0, 3);

            graph.PrintGraph();
            Console.ReadLine();
        }
    }
}
