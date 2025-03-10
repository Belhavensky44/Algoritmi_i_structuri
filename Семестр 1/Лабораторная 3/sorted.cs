using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            for (int i = 1; i < nElems; i++)
            {
                long key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }
    }
}