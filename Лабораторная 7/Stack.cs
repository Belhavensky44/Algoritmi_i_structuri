using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lesson_7
{
    class StackNode
    {
        public int Data;
        public StackNode Next; 

        public StackNode(int data)
        {
            Data = data;
            Next = null; 
        }
    }

    class Stack
    {
        private StackNode top;

        public Stack()
        {
            top = null; 
        }

 
        public void Push(int data)
        {
            StackNode newNode = new StackNode(data); 
            newNode.Next = top; 
            top = newNode; 
        }

   
        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст. Невозможно извлечь элемент.");

            int poppedData = top.Data; 
            top = top.Next; 

            return poppedData; 
        }

       
        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст. Невозможно получить элемент.");

            return top.Data; 
        }

  
        public bool IsEmpty()
        {
            return top == null; 
        }

 
        public void Display()
        {
            StackNode current = top;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}