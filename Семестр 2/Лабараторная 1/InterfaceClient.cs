using System;

namespace OOP_
{
    public class InterfaceClient
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int size = 10;

            IHighInterfaceArray array = new HighInterfaceArrayImpl(size);
            FillArrayWithRandomValues(array, random, size);

            Console.WriteLine("Исходный массив (неотсортированный):");
            array.Display();

            Console.WriteLine("\nМинимальное значение:");
            long min = array.FindMin();
            Console.WriteLine(min);

            Console.WriteLine("\nМаксимальное значение:");
            long max = array.FindMax();
            Console.WriteLine(max);

            Console.WriteLine("\nСортировка с последовательностью Knuth:");
            array.Sort("Knuth");
            array.Display();

            Console.WriteLine("\nСортировка с последовательностью Shell:");
            array.Sort("Shell");
            array.Display();

            Console.WriteLine("\nСортировка с последовательностью ImprovedShell:");
            array.Sort("ImprovedShell");
            array.Display();
        }

        private static void FillArrayWithRandomValues(IHighInterfaceArray array, Random random, int size)
        {
            for (int i = 0; i < size; i++)
            {
                array.Insert(random.Next(1, 100));
            }
        }
    }
}