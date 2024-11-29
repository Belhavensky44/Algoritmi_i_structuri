using System;

namespace OOP_
{
    public class HighInterfaceClient
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int size = 100;

           
            IHighInterfaceArray sortedArray = new HighInterfaceArrayImpl(size);
            FillArrayWithRandomValues(sortedArray, random, size);

            Console.WriteLine("Отсортированный массив:");
            sortedArray.Display();

            try
            {
                long sortedMaxValue = sortedArray.FindMax();
                long sortedMinValue = sortedArray.FindMin();
                Console.WriteLine($"Максимальное значение (отсортированный): {sortedMaxValue}");
                Console.WriteLine($"Минимальное значение (отсортированный): {sortedMinValue}");

                long searchValueSorted = NextLong64(random, 50);
                Console.WriteLine($"Поиск значения {searchValueSorted} в отсортированном массиве: " +
                                  (sortedArray.Find(searchValueSorted) ? "Найдено" : "Не найдено"));

                Console.WriteLine();

                
                IHighInterfaceArray unsortedArray = new UnsortedArrayImpl(size);
                FillArrayWithRandomValues(unsortedArray, random, size);

                Console.WriteLine("Неотсортированный массив:");
                unsortedArray.Display();

                long unsortedMaxValue = unsortedArray.FindMax();
                long unsortedMinValue = unsortedArray.FindMin();
                Console.WriteLine($"Максимальное значение (неотсортированный): {unsortedMaxValue}");
                Console.WriteLine($"Минимальное значение (неотсортированный): {unsortedMinValue}");

                long searchValueUnsorted = NextLong64(random, 50);
                Console.WriteLine($"Поиск значения {searchValueUnsorted} в неотсортированном массиве: " +
                                  (unsortedArray.Find(searchValueUnsorted) ? "Найдено" : "Не найдено"));

                Console.WriteLine("Нажмите любую клавишу для выхода...");
                Console.ReadKey();

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void FillArrayWithRandomValues(IHighInterfaceArray array, Random random, int size)
        {
            for (int i = 0; i < size; i++)
            {
                array.Insert(NextLong64(random, 50));
            }
        }

        public static long NextLong64(Random random, long maxValue)
        {
            byte[] buffer = new byte[8];
            random.NextBytes(buffer);
            long result = BitConverter.ToInt64(buffer, 0);

            return Math.Abs(result % maxValue);
        }
    }
}