using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ООП
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
            array[nElems] = value;
            nElems++;
        }

        public bool Delete(long value)
        {
            int i;
            for (i = 0; i < nElems; i++)
            {
                if (array[i] == value)
                {
                    break;
                }
            }

            if (i == nElems - 1)
            {
                return false;
            }
            else
            {
                for (int j = i; j < nElems - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                nElems--;
                return true;
            }
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
        public void FindMinMax()
        {
            if (nElems == 0)
            {
                Console.WriteLine("Массив пуст.");
                return;
            }

            long min = array[0];
            long max = array[0];

            for (int i = 1; i < nElems; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
                if (array[i] > max)
                {
                    max = array[i];
                }
            
            }
            Console.WriteLine($"Минимальное значение: {min}");
            Console.WriteLine($"Максимальное значение: {max}");
        }
    }   
}


