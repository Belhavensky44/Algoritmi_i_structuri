using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ООП
{
    public class HighInterfaceClient
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int size = 100;
            IHighInterfaceArray array = new HighInterfaceArrayImpl(size);

            for (int i = 0; i < size; i++)
            {
                array.Insert(NextLong64(random, 50)); // Используем новый метод
            }

            array.Display();

            ((HighInterfaceArrayImpl)array).FindMinMax();


            long searchValue = NextLong64(random, 50); // Также здесь
            if (array.Find(searchValue))
            {
                Console.WriteLine($"Значение было найдено. {searchValue}");
            }
            else
            {
                Console.WriteLine($"Не удалось найти значен123ие. {searchValue}");
            }
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Метод для генерации случайного 64-битного целого числа
        public static long NextLong64(Random random, long maxValue)
        {
            byte[] buffer = new byte[8]; // 8 байт = 64 бита
            random.NextBytes(buffer); // Заполняем массив случайными байтами
            long result = BitConverter.ToInt64(buffer, 0); // Преобразуем в 64-битное целое число

            // Если результат отрицательный, мы можем сделать его положительным, если это необходимо
            // Например, если вы хотите, чтобы значение было в диапазоне [0, maxValue):
            return Math.Abs(result % maxValue);
        }
    }
}
