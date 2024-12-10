using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string[] testStrings = { "65365", "6353", "steck", "asdfvb", "9559", "65365", "" };

            foreach (string str in testStrings)
            {
                Console.WriteLine($"\"{str}\" Это полиндром? {PalindromeChecker.IsPalindrome(str)}");
            }

            
            PriorityQueueImpl queuePriority = new PriorityQueueImpl(5);

            try
            {
                queuePriority.Remove();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                queuePriority.Insert(54);
                queuePriority.Insert(43);
                queuePriority.Insert(76);
                queuePriority.Insert(43);
                queuePriority.Insert(44);
                queuePriority.Insert(55);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            while (!queuePriority.IsEmpty())
            {
                Console.WriteLine("Извлечён: " + queuePriority.Remove());
            }

            try
            {
                queuePriority.Remove();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

           
            QueueImpl queue = new QueueImpl(5);

            try
            {
                queue.Remove();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                queue.Insert(34);
                queue.Insert(90);
                queue.Insert(30);
                queue.Insert(43);
                queue.Insert(23);
                queue.Insert(20); 
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            while (!queue.IsEmpty())
            {
                Console.WriteLine("Извлечён: " + queue.Remove());
            }

            try
            {
                queue.Remove(); 
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            
            StackImpl stack = new StackImpl(15);

            try
            {
                stack.Pop(); 
            }
            catch (InvalidOperationException e) { Console.WriteLine(e.Message); }

            try
            {
                stack.Push(654);
                stack.Push(20);
                stack.Push(303);
                stack.Push(45);
                stack.Push(52);

                for (int i = 0; i < 11; i++)
                {
                    stack.Push(i);
                }
            }
            catch (InvalidOperationException e) { Console.WriteLine(e.Message); }

            while (!stack.IsEmpty())
            {
                Console.WriteLine("Извлечён: " + stack.Pop());
            }

            try
            {
                stack.Pop();
            }
            catch (InvalidOperationException e) { Console.WriteLine(e.Message); }

            Console.ReadKey();
        }
    }
}