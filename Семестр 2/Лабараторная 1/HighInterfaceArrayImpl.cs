using System;
using System.Diagnostics;

namespace OOP_
{
    public class HighInterfaceArrayImpl : IHighInterfaceArray
    {
        private readonly long[] array;
        private int nElems;

        public HighInterfaceArrayImpl(int size)
        {
            array = new long[size];
            nElems = 0;
        }

        public bool Find(long searchValue)
        {
            int low = 0;
            int high = nElems - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (array[mid] == searchValue)
                {
                    return true;
                }
                else if (array[mid] < searchValue)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return false;
        }

        public void Insert(long value)
        {
            if (nElems >= array.Length)
            {
                Console.WriteLine("Массив заполнен. Невозможно вставить новое значение.");
                return;
            }

            int position = FindInsertPosition(value);

            for (int i = nElems; i > position; i--)
            {
                array[i] = array[i - 1];
            }

            array[position] = value;
            nElems++;
        }

        private int FindInsertPosition(long value)
        {
            int low = 0;
            int high = nElems - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (array[mid] < value)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return low;
        }

        public bool Delete(long value)
        {
            int index = FindIndex(value);
            if (index == -1) return false;

            for (int i = index; i < nElems - 1; i++)
            {
                array[i] = array[i + 1];
            }

            nElems--;
            return true;
        }

        private int FindIndex(long value)
        {
            int low = 0;
            int high = nElems - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (array[mid] == value)
                {
                    return mid;
                }
                else if (array[mid] < value)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }

        public void Display()
        {
            for (int i = 0; i < nElems; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public int GetSize()
        {
            return nElems;
        }

        public long FindMin()
        {
            if (nElems == 0)
            {
                throw new InvalidOperationException("Массив пуст.");
            }
            Sort();
            return array[0];
        }

        public long FindMax()
        {
            if (nElems == 0)
            {
                throw new InvalidOperationException("Массив пуст.");
            }
            Sort();
            return array[nElems - 1];
        }

        private void Sort()
        {
            Stopwatch watch = Stopwatch.StartNew();

            // Выбор метода сортировки Шелла
            Console.WriteLine("Выберите метод сортировки Шелла:");
            Console.WriteLine("1. ShellSort (3h+1)");
            Console.WriteLine("2. ShellSortTwo (N/2)");
            Console.WriteLine("3. ShellSortThree (N/2.2).");
            int choice = Convert.ToInt32(Console.ReadLine());

            int[] tempArray = new int[nElems];
            for (int i = 0; i < nElems; i++)
            {
                tempArray[i] = (int)array[i]; // Преобразуем long в int для сортировки
            }

            switch (choice)
            {
                case 1:
                    ShellSortOne.Sort(tempArray);
                    Console.WriteLine("Вы выбрали: ShellSortOne (3h+1).");
                    break;
                case 2:
                    ShellSortTwo.Sort(tempArray);
                    Console.WriteLine("Вы выбрали: ShellSortTwo (N/2).");
                    break;
                case 3:
                    ShellSortThree.Sort(tempArray);
                    Console.WriteLine("Вы выбрали: ShellSortThree (N/2.2).");
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Используется стандартная сортировка.");
                    Array.Sort(tempArray);
                    break;
            }

            for (int i = 0; i < nElems; i++)
            {
                array[i] = tempArray[i]; // Возвращаем отсортированные значения обратно в массив
            }

            watch.Stop();
            double durationInMilliseconds = watch.Elapsed.TotalMilliseconds;
            Console.WriteLine($"Время сортировки: {durationInMilliseconds:F3} мс");
        }

        // Методы сортировки Шелла
        private class ShellSortOne
        {
            public static void Sort(int[] array)
            {
                int n = array.Length;
                int h = 1;
                while (h <= n / 3)
                {
                    h = 3 * h + 1;
                }

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

        private class ShellSortTwo
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

        private class ShellSortThree
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