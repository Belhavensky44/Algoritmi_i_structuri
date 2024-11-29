using System;

namespace OOP_
{
    public class UnsortedArrayImpl : IHighInterfaceArray
    {
        private readonly long[] array;
        private int nElems;

        public UnsortedArrayImpl(int size)
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
            int index = Array.IndexOf(array, value, 0, nElems);
            if (index == -1) return false; 

            
            for (int i = index; i < nElems - 1; i++)
            {
                array[i] = array[i + 1];
            }

            nElems--;
            return true;
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
                throw new InvalidOperationException("Массив пуст.");

            long minValue = array[0];
            for (int i = 1; i < nElems; i++)
            {
                if (array[i] < minValue)
                    minValue = array[i];
            }
            return minValue;
        }

        public long FindMax()
        {
            if (nElems == 0)
                throw new InvalidOperationException("Массив пуст.");

            long maxValue = array[0];
            for (int i = 1; i < nElems; i++)
            {
                if (array[i] > maxValue)
                    maxValue = array[i];
            }
            return maxValue;
        }
    }
}