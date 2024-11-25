using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_
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
                array.Insert(NextLong64(random, 50));
            }

            array.Display();



            ((HighInterfaceArrayImpl)array).FindMax();
            ((HighInterfaceArrayImpl)array).FindMin();


            long searchValue = NextLong64(random, 50);
            if (array.Find(searchValue))
            {
                Console.WriteLine($"Значение было найдено. {searchValue}");
            }
            else
            {
                Console.WriteLine($"Не удалось найти значение. {searchValue}");
            }
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
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
