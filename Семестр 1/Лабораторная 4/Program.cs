using System;
using System.Diagnostics;

namespace lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int size = 100000; 
            int[] array = new int[size];
            Random random = new Random();

            
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(100); 
            }

            
            Console.WriteLine("Выберите метод сортировки:");
            Console.WriteLine("1. Пузырьковая сортировка");
            Console.WriteLine("2. Сортировка вставками");
            Console.WriteLine("3. Сортировка выбором");
            int choice = Convert.ToInt32(Console.ReadLine());

          
            int[] arrayToSort = new int[size];
            Array.Copy(array, arrayToSort, size);

            
            Stopwatch watch = Stopwatch.StartNew(); 

            if (choice == 1)
            {
                BubbleSort.Sort(arrayToSort); 
                Console.WriteLine("Вы выбрали пузырьковую сортировку.");
            }
            else if (choice == 2)
            {
                InsertionSort.Sort(arrayToSort); 
                Console.WriteLine("Вы выбрали сортировку вставками.");
            }
            else if (choice == 3)
            {
                SelectionSort.Sort(arrayToSort); 
                Console.WriteLine("Вы выбрали сортировку выбором.");
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
                return;
            }

            watch.Stop();

            
            double durationInSeconds = watch.ElapsedMilliseconds / 1000.0; 
            Console.WriteLine("Время сортировки: " + durationInSeconds + " секунд");

           
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}