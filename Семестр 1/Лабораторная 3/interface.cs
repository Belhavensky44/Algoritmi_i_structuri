using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

    }
}