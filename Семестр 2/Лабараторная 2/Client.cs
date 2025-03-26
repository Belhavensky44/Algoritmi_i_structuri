using System;

namespace OOP_
{
    public class Client
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int size = 10;

            IHighInterfaceArray array = new HighInterfaceArrayImpl(size);
            FillArrayWithRandomValues(array, random, size);

            Console.WriteLine("Исходный массив (неотсортированный):");
            array.Display();

            array.Sort(); // Вызов сортировки

            Console.WriteLine("\nМассив после сортировки:");
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