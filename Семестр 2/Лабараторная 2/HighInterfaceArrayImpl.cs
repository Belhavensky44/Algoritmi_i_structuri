public class HighInterfaceArrayImpl : IHighInterfaceArray
{
    private readonly long[] array;
    private int nElems;

    public HighInterfaceArrayImpl(int size)
    {
        array = new long[size];
        nElems = 0;
    }

    // Другие методы (Find, Insert, Delete, Display, GetSize, FindMin, FindMax)...

    public void Sort()
    {
        Stopwatch watch = Stopwatch.StartNew();

        QuickSort(0, nElems - 1); // Вызов быстрой сортировки

        watch.Stop();
        double durationInMilliseconds = watch.Elapsed.TotalMilliseconds;
        Console.WriteLine($"Время сортировки (QuickSort): {durationInMilliseconds:F3} мс");
    }

    private void QuickSort(int left, int right)
    {
        Stack<(int, int)> stack = new Stack<(int, int)>();
        stack.Push((left, right));

        while (stack.Count > 0)
        {
            var (start, end) = stack.Pop();

            if (start >= end)
                continue;

            long pivot = array[end]; // Опорный элемент (последний элемент)
            int partition = Partition(start, end, pivot);

            // Добавляем границы подмассивов в стек
            stack.Push((start, partition - 1));
            stack.Push((partition + 1, end));
        }
    }

    private int Partition(int left, int right, long pivot)
    {
        int leftPtr = left - 1;
        int rightPtr = right;

        while (true)
        {
            while (array[++leftPtr] < pivot) ;
            while (rightPtr > 0 && array[--rightPtr] > pivot) ;

            if (leftPtr >= rightPtr)
                break;
            else
                Swap(leftPtr, rightPtr);
        }

        Swap(leftPtr, right);
        return leftPtr;
    }

    private void Swap(int index1, int index2)
    {
        long temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
}