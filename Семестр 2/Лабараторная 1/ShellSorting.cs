using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace lab_1
{
    class ShellSort
    {
        static void Main(string[] args)
        {

            int size = 100000;           // Cоздание массива
            int[] array = new int[size];
            Random random = new Random();


            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(100);
            }


            Console.WriteLine("Выберите метод сортировки:"); //Вывод в консоле вариантов
            Console.WriteLine("1. ShellSort (3h+1)");
            Console.WriteLine("2. ShellSortTwo (N/2)");
            Console.WriteLine("3. ShellSortThree (N/2,2).");
            int choice = Convert.ToInt32(Console.ReadLine());


            int[] arrayToSort = new int[size];
            Array.Copy(array, arrayToSort, size);


            Stopwatch watch = Stopwatch.StartNew();

            if (choice == 1)                                 // Реализация выбора
            {
                ShellSortOne.Sort(arrayToSort);
                Console.WriteLine("Вы выбрали: ShellSortOne (3h+1).");
            }

            else if (choice == 2)
            {
                ShellSortTwo.Sort(arrayToSort);
                Console.WriteLine("Вы выбрали: ShellSortTwo (N/2).");
            }

            else if (choice == 3)
            {
                ShellSortThree.Sort(arrayToSort);
                Console.WriteLine("Вы выбрали: ShellSortThree (N/2,2)."); 
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

        class ShellSortOne //Метод для сортировки Шелла с последовательностью Кнута (3h+1)
        {
            public static void Sort(int[] array) 
            {
                int n = array.Length;

                // Вычисляем начальный шаг по последовательности Кнута
                int h = 1;
                while (h <= n / 3)
                {
                    h = 3 * h + 1; 
                }

                // Начинаем сортировку с уменьшением шага
                while (h >= 1)
                {
                    
                    for (int i = h; i < n; i++)
                    {                     
                        int temp = array[i];
                        int j;

                        for (j = i; j >= h && array[j - h] > temp; j -= h)
                        {
                            array[j] = array[j - h];
                        }

                        array[j] = temp;
                    }

                    h = h / 3;
                }
            }
        }
        class ShellSortTwo  // Метод для сортировки Шелла с интервалом N/2
        {
            public static void Sort(int[] array)
            {
                int n = array.Length;

                int h = n / 2;

                while (h >= 1)
                {
                    for (int i = h; i < n; i++)
                    {
                        int temp = array[i];
                        int j;

                        for (j = i; j >= h && array[j - h] > temp; j -= h)
                        {
                            array[j] = array[j - h];
                        }

                        array[j] = temp;
                    }

                    h = h / 2;
                }
            }
        }
        class ShellSortThree // Метод для сортировки Шелла с интервалом N/2.2
        {
            public static void Sort(int[] array)
            {
                int n = array.Length;

                int h = (int)(n / 2.2);

                while (h >= 1)
                {
                    for (int i = h; i < n; i++)
                    {
                        int temp = array[i];
                        int j;

                        for (j = i; j >= h && array[j - h] > temp; j -= h)
                        {
                            array[j] = array[j - h];
                        }

                        array[j] = temp;
                    }

                    h = (int)(h / 2.2);
                }
            }
        }
    }
}  
