using System;

namespace Лаб_3
{
    public class Client
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int size = 1000000; 

            IHighInterfaceArray arrayShell = new HighInterfaceArrayImpl(size);
            IHighInterfaceArray arrayQuick = new HighInterfaceArrayImpl(size);
            IHighInterfaceArray arrayMerge = new HighInterfaceArrayImpl(size);

            FillArrayWithRandomValues(arrayShell, random, size);
            arrayQuick = arrayShell.Clone(); 
            arrayMerge = arrayShell.Clone();

            Console.WriteLine("Тестирование сортировки методом Шелла:");
            arrayShell.SortShell();

            Console.WriteLine("\nТестирование быстрой сортировки:");
            arrayQuick.SortQuick();

            Console.WriteLine("\nТестирование сортировки слиянием:");
            arrayMerge.SortMerge();

            
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        private static void FillArrayWithRandomValues(IHighInterfaceArray array, Random random, int size)
        {
            for (int i = 0; i < size; i++)
            {
                array.Insert(random.Next(1, 100000));
            }
        }
    }
}
