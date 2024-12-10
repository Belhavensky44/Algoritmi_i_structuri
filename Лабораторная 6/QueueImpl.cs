using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace lesson_6
{
    public class QueueImpl
    {
        private int maxSize;
        private long[] queArray;
        private int front;
        private int rear;
        private int nItems;

        public QueueImpl(int s)
        {
            maxSize = s;
            queArray = new long[maxSize];
            front = 0;
            rear = -1;
            nItems = 0;
        }

        public void Insert(long j)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Очередь переполнена, невозможно вставить элемент: " + j);
            }

            if (rear == maxSize - 1)
            {
                rear = -1;
            }

            queArray[++rear] = j;
            nItems++;
        }

        public long Remove()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Очередь пуста, невозможно извлечь элемент.");
            }

            long temp = queArray[front++];

            if (front == maxSize)
            {
                front = 0; 
            }

            nItems--;
            return temp;
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