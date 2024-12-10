using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lesson_7
{

    class QueueNode
    {
        public int Data;
        public QueueNode Next;

        public QueueNode(int data)
        {
            Data = data;
            Next = null;
        }
    }

 
    class Queue
    {
        private QueueNode front;
        private QueueNode rear; 

        public Queue()
        {
            front = null;
            rear = null;
        }


        public void Enqueue(int data)
        {
            QueueNode newNode = new QueueNode(data);
            if (rear == null)
            {
                front = rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }
        }

        
        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Очередь пуста. Невозможно извлечь элемент.");
            }
            int dequeuedData = front.Data; 
            front = front.Next;
            if (front == null)
            {
                rear = null;
            }
            return dequeuedData; 
        }

        
        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Очередь пуста. Невозможно получить элемент.");
            }
            return front.Data;
        }

        
        public bool IsEmpty()
        {
            return front == null;
        }

        
        public void Display()
        {
            QueueNode current = front; 
            while (current != null)
            {
                Console.Write(current.Data + " "); 
                current = current.Next; 
            }
            Console.WriteLine();
        }
    }
}