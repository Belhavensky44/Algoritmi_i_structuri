using System;

namespace OOP_
{
    public interface IHighInterfaceArray
    {
        bool Find(long searchValue);
        void Insert(long value);
        bool Delete(long value);
        void Display();
        int GetSize();
        long FindMin();
        long FindMax();
        void Sort(string sequenceType = "Knuth");
    }
}