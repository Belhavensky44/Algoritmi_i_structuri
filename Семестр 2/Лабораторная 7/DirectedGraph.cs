using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_7
{
    public class DirectedGraph
    {
        private readonly int maxVertices;
        private Vertex[] vertexList;
        private int[,] adjacencyMatrix;
        private int vertexCount;

        public DirectedGraph(int maxVertices)
        {
            if (maxVertices <= 0)
                throw new ArgumentException("Максимальное количество вершин должно быть положительным");

            this.maxVertices = maxVertices;
            this.vertexList = new Vertex[maxVertices];
            this.adjacencyMatrix = new int[maxVertices, maxVertices];
        }

        public void AddVertex(char label)
        {
            if (vertexCount >= maxVertices)
                throw new InvalidOperationException("Достигнут лимит вершин");

            for (int i = 0; i < vertexCount; i++)
            {
                if (vertexList[i].Label == label)
                    throw new ArgumentException($"Вершина '{label}' уже существует");
            }

            vertexList[vertexCount++] = new Vertex(label);
        }

        public void AddEdge(char fromLabel, char toLabel)
        {
            int start = GetVertexIndex(fromLabel);
            int end = GetVertexIndex(toLabel);

            if (start == -1)
                throw new ArgumentException($"Вершина '{fromLabel}' не найдена");
            if (end == -1)
                throw new ArgumentException($"Вершина '{toLabel}' не найдена");

            if (start == end)
                throw new ArgumentException("Нельзя создать ребро из вершины в саму себя");

            if (adjacencyMatrix[start, end] != 0)
                throw new ArgumentException($"Ребро из '{fromLabel}' в '{toLabel}' уже существует");

            adjacencyMatrix[start, end] = 1;
        }

        private int GetVertexIndex(char label)
        {
            for (int i = 0; i < vertexCount; i++)
            {
                if (vertexList[i].Label == label)
                    return i;
            }
            return -1;
        }

        public void TopologicalSort()
        {
            if (vertexCount == 0)
            {
                Console.WriteLine("Граф пуст");
                return;
            }

            bool[] removed = new bool[vertexCount];
            char[] result = new char[vertexCount];
            int position = vertexCount - 1;

            while (position >= 0)
            {
                int currentVertex = -1;

                for (int row = 0; row < vertexCount; row++)
                {
                    if (removed[row]) continue;

                    bool hasSuccessor = false;
                    for (int col = 0; col < vertexCount; col++)
                    {
                        if (!removed[col] && adjacencyMatrix[row, col] > 0)
                        {
                            hasSuccessor = true;
                            break;
                        }
                    }

                    if (!hasSuccessor)
                    {
                        currentVertex = row;
                        break;
                    }
                }

                if (currentVertex == -1)
                    throw new InvalidOperationException("Граф содержит цикл");

                result[position--] = vertexList[currentVertex].Label;
                removed[currentVertex] = true;
            }

            Console.WriteLine("Топологический порядок: " + string.Join(" ", result));
        }
    }

    public class Vertex
    {
        public char Label { get; }

        public Vertex(char label)
        {
            if (!char.IsLetter(label))
                throw new ArgumentException("Метка вершины должна быть буквой");

            Label = char.ToUpper(label);
        }
    }

    public class Program
    {
        public static void Main()
        {
            try
            {
                DirectedGraph graph = new DirectedGraph(8);

                graph.AddVertex('A');
                graph.AddVertex('B');
                graph.AddVertex('C');
                graph.AddVertex('D');
                graph.AddVertex('E');
                graph.AddVertex('F');
                graph.AddVertex('G');
                graph.AddVertex('H');

                graph.AddEdge('A', 'D');
                graph.AddEdge('A', 'E');
                graph.AddEdge('B', 'E');
                graph.AddEdge('C', 'F');
                graph.AddEdge('D', 'G');
                graph.AddEdge('E', 'G');
                graph.AddEdge('F', 'H');
                graph.AddEdge('G', 'H');

                graph.TopologicalSort();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}
