public interface IHighInterfaceArray
{
    void Insert(long value);
    void Display();
    int GetSize();
    void SortShell();
    void SortQuick();
    void SortMerge();
    HighInterfaceArrayImpl Clone();
}
