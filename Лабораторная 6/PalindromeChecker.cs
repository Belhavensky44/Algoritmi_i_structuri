using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lesson_6
{
    public class PalindromeChecker
    {
        public static bool IsPalindrome(string str)
        {
            Stack<char> stack = new Stack<char>();
            int length = str.Length;

          
            for (int i = 0; i < length; i++)
            {
                stack.Push(str[i]);
            }

          
            for (int i = 0; i < length; i++)
            {
                if (str[i] != stack.Pop())
                {
                    return false; 
                }
            }
            return true;
            
        }
    }
   
}