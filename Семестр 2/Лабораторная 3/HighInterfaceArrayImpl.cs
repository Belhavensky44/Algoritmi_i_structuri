using System;
using System.Diagnostics;

public class HighInterfaceArrayImpl : IHighInterfaceArray
{
    private readonly long[] array;
    private int nElems;

    
    private int comparisonCount;
    private int swapCount;
    private Stopwatch stopwatch;

    public HighInterfaceArrayImpl(int size)
    {
        array = new long[size];
        nElems = 0;
    }

    
    public HighInterfaceArrayImpl Clone()
    {
        HighInterfaceArrayImpl clone = new HighInterfaceArrayImpl(array.Length);
        Array.Copy(array, clone.array, nElems);
        clone.nElems = nElems;
        return clone;
    }

    
    public void Insert(long value)
    {
        array[nElems] = value;
        nElems++;
    }

    
    public void Display()
    {
        for (int i = 0; i < nElems; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    
    public int GetSize()
    {
        return nElems;
    }

    
    public void SortShell()
    {
        ResetCounters();
        stopwatch = Stopwatch.StartNew();

        int gap = nElems / 2;
        while (gap > 0)
        {
            for (int i = gap; i < nElems; i++)
            {
                long temp = array[i];
                int j;
                for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                {
                    array[j] = array[j - gap];
                    swapCount++;
                    comparisonCount++;
                }
                array[j] = temp;
                swapCount++;
            }
            gap /= 2;
        }

        stopwatch.Stop();
        PrintStatistics("Shell Sort");
    }

    
    public void SortQuick()
    {
        ResetCounters();
        stopwatch = Stopwatch.StartNew();

        QuickSort(0, nElems - 1);

        stopwatch.Stop();
        PrintStatistics("Quick Sort");
    }

    private void QuickSort(int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(left, right);
            QuickSort(left, pivotIndex - 1);
            QuickSort(pivotIndex + 1, right);
        }
    }

    private int Partition(int left, int right)
    {
        long pivot = array[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            comparisonCount++;
            if (array[j] < pivot)
            {
                i++;
                Swap(i, j);
            }
        }
        Swap(i + 1, right);
        return i + 1;
    }

    
    public void SortMerge()
    {
        ResetCounters();
        stopwatch = Stopwatch.StartNew();

        MergeSort(0, nElems - 1);

        stopwatch.Stop();
        PrintStatistics("Merge Sort");
    }

    private void MergeSort(int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            MergeSort(left, mid);
            MergeSort(mid + 1, right);
            Merge(left, mid, right);
        }
    }

    private void Merge(int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        long[] leftArray = new long[n1];
        long[] rightArray = new long[n2];

        Array.Copy(array, left, leftArray, 0, n1);
        Array.Copy(array, mid + 1, rightArray, 0, n2);

        int i = 0, j = 0, k = left;
        while (i < n1 && j < n2)
        {
            comparisonCount++;
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            swapCount++;
            k++;
        }

        while (i < n1)
        {
            array[k] = leftArray[i];
            i++;
            k++;
            swapCount++;
        }

        while (j < n2)
        {
            array[k] = rightArray[j];
            j++;
            k++;
            swapCount++;
        }
    }

    
    private void Swap(int index1, int index2)
    {
        long temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
        swapCount++;
    }

    private void ResetCounters()
    {
        comparisonCount = 0;
        swapCount = 0;
    }

    private void PrintStatistics(string sortType)
    {
        Console.WriteLine($"\n{sortType}:");
        Console.WriteLine($"Количество сравнений: {comparisonCount}");
        Console.WriteLine($"Количество перестановок: {swapCount}");
        Console.WriteLine($"Время выполнения: {stopwatch.Elapsed.TotalMilliseconds:F3} мс");
    }
}
