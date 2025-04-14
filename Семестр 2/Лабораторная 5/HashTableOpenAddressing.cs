using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    public class HashTable
    {
        public static void Main()
        {
            Console.WriteLine("Введите начальный размер хеш-таблицы:");
            int initialSize = int.Parse(Console.ReadLine());

            Console.WriteLine("\nСколько чисел добавить?");
            int numbersToAdd = int.Parse(Console.ReadLine());

            var hashTable = new HashTableWithOpenAddressing(initialSize);
            var random = new Random();

            Console.WriteLine("\nДобавляем случайные числа...");
            for (int i = 0; i < numbersToAdd; i++)
            {
                int num = random.Next(1, 1000);
                hashTable.Insert(num);
                Console.WriteLine($"Добавлено: {num}");
            }

            Console.WriteLine("\nСтатистика хеш-таблицы:");
            hashTable.PrintStats();

            Console.WriteLine("\nСодержимое хеш-таблицы:");
            hashTable.PrintAllElements();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }

    public class HashTableWithOpenAddressing
    {
        private int?[] table;
        private int count;
        private const double ResizeThreshold = 0.5;

        public HashTableWithOpenAddressing(int initialCapacity = 16)
        {
            table = new int?[GetNextPrime(initialCapacity)];
        }

        public int Count => count;

        private int HashFunction(int key)
        {
            return Math.Abs(key.GetHashCode()) % table.Length;
        }

        private int QuadraticProbing(int key, int i)
        {
            return (HashFunction(key) + i * i) % table.Length;
        }

        public void Insert(int key)
        {
            if (Contains(key)) return;

            if ((double)count / table.Length >= ResizeThreshold)
            {
                Console.WriteLine($"\nЗаполнение достигло {count}/{table.Length} (>50%) - увеличиваем таблицу...");
                Resize();
            }

            for (int i = 0; i < table.Length; i++)
            {
                int index = QuadraticProbing(key, i);
                if (table[index] == null)
                {
                    table[index] = key;
                    count++;
                    return;
                }
            }
            throw new Exception("Хеш-таблица переполнена");
        }

        public bool Contains(int key)
        {
            for (int i = 0; i < table.Length; i++)
            {
                int index = QuadraticProbing(key, i);
                if (table[index] == key)
                    return true;
                if (table[index] == null)
                    return false;
            }
            return false;
        }

        private void Resize()
        {
            Console.WriteLine($"Старый размер: {table.Length}");
            var oldTable = table;
            int newSize = GetNextPrime(table.Length * 2);
            table = new int?[newSize];
            count = 0;

            Console.WriteLine($"Новый размер: {newSize}");

            foreach (var key in oldTable)
            {
                if (key.HasValue)
                    Insert(key.Value);
            }
        }

        public void PrintAllElements()
        {
            for (int i = 0; i < table.Length; i++)
            {
                Console.WriteLine($"Ячейка {i}: {(table[i]?.ToString() ?? "пусто")}");
            }
        }

        public void PrintStats()
        {
            Console.WriteLine($"Общий размер таблицы: {table.Length}");
            Console.WriteLine($"Количество элементов: {count}");
            Console.WriteLine($"Коэффициент заполнения: {(double)count / table.Length:P0}");

            int emptyCells = 0;

            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] == null)
                    emptyCells++;
            }

            Console.WriteLine($"Пустых ячеек: {emptyCells}");
        }

        private static int GetNextPrime(int min)
        {
            for (int i = min; ; i++)
            {
                if (IsPrime(i))
                    return i;
            }
        }

        private static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 3; i * i <= n; i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }
}
