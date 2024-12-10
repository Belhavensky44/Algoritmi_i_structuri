using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lesson_6
{
    public class PriorityQueueImpl
    {
        private int maxSize;
        private long[] queArray;
        private int nItems;

        public PriorityQueueImpl(int s)
        {
            maxSize = s;
            queArray = new long[maxSize];
            nItems = 0;
        }

        public void Insert(long item)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Очередь переполнена, невозможно вставить элемент: " + item);
            }

            int j;
            if (nItems == 0)
            {
                queArray[nItems++] = item;
            }
            else
            {
                for (j = nItems - 1; j >= 0; j--)
                {
                    if (item > queArray[j])
                    {
                        queArray[j + 1] = queArray[j];
                    }
                    else
                    {
                        break;
                    }
                }
                queArray[j + 1] = item;
                nItems++;
            }
        }

        public long Remove()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Очередь пуста, невозможно извлечь элемент.");
            }
            return queArray[--nItems];
        }

        public bool IsEmpty()
        {
            return (nItems == 0);
        }

        public bool IsFull()
        {
            return (nItems == maxSize);
        }
    }
}