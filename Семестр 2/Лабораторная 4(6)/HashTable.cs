using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{

    public class HashTable
    {
        public static void Main()
        {
            Console.WriteLine("Введите начальный размер хеш-таблицы:");
            int initialSize = int.Parse(Console.ReadLine());

            Console.WriteLine("\nСколько чисел добавить?");
            int numbersToAdd = int.Parse(Console.ReadLine());

           
            var hashTable = new HashTableWithChaining(initialSize);
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

    public class HashTableWithChaining
    {
        private class Node
        {
            public int Key { get; }
            public Node Next { get; set; }

            public Node(int key)
            {
                Key = key;
            }
        }

        private Node[] buckets;
        private int count;
        private const double ResizeThreshold = 0.5;

        public HashTableWithChaining(int initialCapacity = 16)
        {
            buckets = new Node[GetNextPrime(initialCapacity)];
        }

        public int Count => count;

        public void Insert(int key)
        {
            if (Contains(key)) return;

  
            if ((double)count / buckets.Length >= ResizeThreshold)
            {
                Console.WriteLine($"\nЗаполнение достигло {count}/{buckets.Length} (>50%) - увеличиваем таблицу...");
                Resize();
            }

            int bucketIndex = GetBucketIndex(key);
            var newNode = new Node(key);
            newNode.Next = buckets[bucketIndex];
            buckets[bucketIndex] = newNode;
            count++;
        }

        public bool Contains(int key)
        {
            int bucketIndex = GetBucketIndex(key);
            var current = buckets[bucketIndex];

            while (current != null)
            {
                if (current.Key == key)
                    return true;
                current = current.Next;
            }
            return false;
        }

        private void Resize()
        {
            Console.WriteLine($"Старый размер: {buckets.Length}");
            var oldBuckets = buckets;
            int newSize = GetNextPrime(buckets.Length * 2);
            buckets = new Node[newSize];
            count = 0;

            Console.WriteLine($"Новый размер: {newSize}");

            foreach (var node in oldBuckets)
            {
                var current = node;
                while (current != null)
                {
                    Insert(current.Key);
                    current = current.Next;
                }
            }
        }

        public void PrintAllElements()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                Console.Write($"Корзина {i}: ");
                var current = buckets[i];

                if (current == null)
                {
                    Console.WriteLine("пусто");
                    continue;
                }

                while (current != null)
                {
                    Console.Write(current.Key);
                    if (current.Next != null) Console.Write(" -> ");
                    current = current.Next;
                }
                Console.WriteLine();
            }
        }

        public void PrintStats()
        {
            Console.WriteLine($"Общее количество корзин: {buckets.Length}");
            Console.WriteLine($"Количество элементов: {count}");
            Console.WriteLine($"Коэффициент заполнения: {(double)count / buckets.Length:P0}");

            int emptyBuckets = 0;
            int maxChainLength = 0;

            for (int i = 0; i < buckets.Length; i++)
            {
                int chainLength = 0;
                var current = buckets[i];
                while (current != null)
                {
                    chainLength++;
                    current = current.Next;
                }

                if (chainLength == 0) emptyBuckets++;
                if (chainLength > maxChainLength) maxChainLength = chainLength;
            }

            Console.WriteLine($"Пустых корзин: {emptyBuckets}");
            Console.WriteLine($"Самая длинная цепочка: {maxChainLength}");
        }

        private int GetBucketIndex(int key)
        {
            return Math.Abs(key.GetHashCode()) % buckets.Length;
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
