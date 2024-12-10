using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lesson_7
{
    class PalindromeNode
    {
        public char Data;
        public PalindromeNode Next;

        public PalindromeNode(char data)
        {
            Data = data;
            Next = null;
        }
    }

    class LinkedList
    {
        private PalindromeNode head;

        public void Append(char data)
        {
            PalindromeNode newNode = new PalindromeNode(data);
            if (head == null)
            {
                head = newNode;
                return;
            }

            PalindromeNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();

            queue.Enqueue(3);
            queue.Enqueue(56);
            queue.Enqueue(153);

            Console.Write("Элементы очереди: ");
            queue.Display();

            Console.WriteLine("Извлеченный элемент: " + queue.Dequeue());
            Console.WriteLine("Передний элемент очереди: " + queue.Peek());

            Console.Write("Элементы очереди после извлечения: ");
            queue.Display();

            Stack stack = new Stack();

            stack.Push(3);
            stack.Push(56);
            stack.Push(153);

            Console.Write("Элементы стека: ");
            stack.Display();

            Console.WriteLine("Извлеченный элемент: " + stack.Pop());
            Console.WriteLine("Верхний элемент стека: " + stack.Peek());

            Console.Write("Элементы стека после извлечения: ");
            stack.Display();

            string input = Console.ReadLine();
        }
    }
}