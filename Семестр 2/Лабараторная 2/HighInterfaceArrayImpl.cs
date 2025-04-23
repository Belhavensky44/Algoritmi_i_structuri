using System;
using System.Collections.Generic;
using System.Diagnostics;

public class HighInterfaceArrayImpl : IHighInterfaceArray
{
    private readonly long[] array;
    private int nElems;

    public HighInterfaceArrayImpl(int size)
    {
        array = new long[size];
        nElems = 0;
    }

    public bool Find(long searchValue)
    {
        for (int i = 0; i < nElems; i++)
        {
            if (array[i] == searchValue)
                return true;
        }
        return false;
    }

    public void Insert(long value)
    {
        if (nElems < array.Length)
        {
            array[nElems] = value;
            nElems++;
        }
    }

    public bool Delete(long value)
    {
        for (int i = 0; i < nElems; i++)
        {
            if (array[i] == value)
            {
                for (int j = i; j < nElems - 1; j++)
                    array[j] = array[j + 1];
                nElems--;
                return true;
            }
        }
        return false;
    }

    public void Display()
    {
        for (int i = 0; i < nElems; i++)
            Console.Write(array[i] + " ");
        Console.WriteLine();
    }

    public int GetSize() => nElems;

    public long FindMin()
    {
        if (nElems == 0) return -1;
        long min = array[0];
        for (int i = 1; i < nElems; i++)
            if (array[i] < min) min = array[i];
        return min;
    }

    public long FindMax()
    {
        if (nElems == 0) return -1;
        long max = array[0];
        for (int i = 1; i < nElems; i++)
            if (array[i] > max) max = array[i];
        return max;
    }

    public void Sort()
    {
        Stopwatch watch = Stopwatch.StartNew();
        QuickSort(0, nElems - 1);
        watch.Stop();
        Console.WriteLine($"Время сортировки: {watch.Elapsed.TotalMilliseconds:F3} мс");
    }

    private void QuickSort(int left, int right)
    {
        const int INSERTION_THRESHOLD = 10;
        var stack = new Stack<(int, int)>();
        stack.Push((left, right));

        while (stack.Count > 0)
        {
            var (start, end) = stack.Pop();

            if (end - start + 1 <= INSERTION_THRESHOLD)
            {
                InsertionSort(start, end);
                continue;
            }

            long pivot = MedianOfThree(start, end);
            int partitionIdx = Partition(start, end, pivot);

            if (partitionIdx - start > end - partitionIdx)
            {
                stack.Push((start, partitionIdx - 1));
                stack.Push((partitionIdx + 1, end));
            }
            else
            {
                stack.Push((partitionIdx + 1, end));
                stack.Push((start, partitionIdx - 1));
            }
        }
    }

    private long MedianOfThree(int left, int right)
    {
        int center = (left + right) / 2;

        if (array[left] > array[center]) Swap(left, center);
        if (array[left] > array[right]) Swap(left, right);
        if (array[center] > array[right]) Swap(center, right);

        Swap(center, right - 1);
        return array[right - 1];
    }

    private int Partition(int left, int right, long pivot)
    {
        int leftPtr = left;
        int rightPtr = right - 1;

        while (true)
        {
            while (array[++leftPtr] < pivot) ;
            while (array[--rightPtr] > pivot) ;

            if (leftPtr >= rightPtr)
                break;
            else
                Swap(leftPtr, rightPtr);
        }

        Swap(leftPtr, right - 1);
        return leftPtr;
    }

    private void InsertionSort(int start, int end)
    {
        for (int i = start + 1; i <= end; i++)
        {
            long temp = array[i];
            int j = i;

            while (j > start && array[j - 1] > temp)
            {
                array[j] = array[j - 1];
                j--;
            }

            array[j] = temp;
        }
    }

    private void Swap(int index1, int index2)
    {
        long temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
}
