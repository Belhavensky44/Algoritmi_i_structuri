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
            for (int i = 0; i < nElems; i++)
            {
                if (array[i] == searchValue)
                {
                    return true;
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

            array[nElems] = value;
            nElems++;
        }

        public bool Delete(long value)
        {
            for (int i = 0; i < nElems; i++)
            {
                if (array[i] == value)
                {
                    for (int j = i; j < nElems - 1; j++)
                    {
                        array[j] = array[j + 1];
                    }
                    nElems--;
                    return true;
                }
            }
            return false;
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

            long minValue = array[0];
            for (int i = 1; i < nElems; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }
            return minValue;
        }

        public long FindMax()
        {
            if (nElems == 0)
            {
                throw new InvalidOperationException("Массив пуст.");
            }

            long maxValue = array[0];
            for (int i = 1; i < nElems; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }
            return maxValue;
        }

        public void Sort(string sequenceType = "Knuth")
        {
            Stopwatch watch = Stopwatch.StartNew();

            ShellSort(sequenceType);

            watch.Stop();
            double durationInMilliseconds = watch.Elapsed.TotalMilliseconds;
            Console.WriteLine($"Время сортировки ({sequenceType}): {durationInMilliseconds:F3} мс");
        }

        private void ShellSort(string sequenceType)
        {
            int n = nElems;
            if (n <= 1) return;

            int h = 1;

            switch (sequenceType)
            {
                case "Knuth":
                    while (h <= n / 3)
                    {
                        h = h * 3 + 1;
                    }
                    break;
                case "Shell":
                    h = n / 2;
                    break;
                case "ImprovedShell":
                    h = (int)(n / 2.2);
                    break;
                default:
                    throw new ArgumentException("Неизвестный тип последовательности");
            }

            while (h > 0)
            {
                for (int outer = h; outer < n; outer++)
                {
                    long temp = array[outer];
                    int inner = outer;

                    while (inner >= h && array[inner - h] > temp)
                    {
                        array[inner] = array[inner - h];
                        inner -= h;
                    }

                    array[inner] = temp;
                }

                switch (sequenceType)
                {
                    case "Knuth":
                        h = (h - 1) / 3;
                        break;
                    case "Shell":
                        h = h / 2;
                        break;
                    case "ImprovedShell":
                        h = (int)(h / 2.2);
                        break;
                }
            }
        }
    }
}