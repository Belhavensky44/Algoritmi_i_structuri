using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace lesson_6
{
    public class StackImpl
    {
        private int maxSize;
        private long[] stackArray; 
        private int top; 

        public StackImpl(int size)
        {
            this.maxSize = size;
            this.stackArray = new long[maxSize]; 
            this.top = -1; 
        }


        public void Push(long value)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Стек переполнен, невозможно вставить элемент: " + value);
            }
            stackArray[++top] = value;
        }


        public long Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Стек пуст, невозможно извлечь элемент.");
            }
            return stackArray[top--]; 
        }


        public long Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Стек пуст, невозможно прочитать верхний элемент.");
            }
            return stackArray[top];
        }


        public bool IsEmpty()
        {
            return (top == -1);
        }

 
        public bool IsFull()
        {
            return (top == maxSize - 1);
        }
    }
}