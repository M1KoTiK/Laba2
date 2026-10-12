using ConsoleApp.ConsoleObject.Table;
using ConsoleApp.ConsoleObject.Table.TableRows;
using Laba2.ConsoleObject.Table.TableRows;
using System;
using System.Collections.Generic;

public class Program
{
    static Random rng = new Random(12345);

    static ITableRow Row(params object[] cells)
    {
        return new TableRow(new List<object>(cells));
    }

    static int[] MakeSorted(int n)
    {
        int[] a = new int[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = i * 2;
        }
        return a;
    }

    static int[] MakeShuffled(int n)
    {
        int[] a = MakeSorted(n);
        for (int i = n - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (a[i], a[j]) = (a[j], a[i]);
        }
        return a;
    }

    static int RandomQuery(int n)
    {
        return rng.Next(0, 2 * n);
    }

    static int SequentialSearch(int[] a, int x, out int comps)
    {
        comps = 0;
        for (int i = 0; i < a.Length; i++)
        {
            comps++;
            if (a[i] == x)
            {
                return i;
            }
        }
        return -1;
    }

    static int BinarySearch(int[] a, int x, out int comps)
    {
        comps = 0;
        int left = 0;
        int right = a.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            comps++;
            if (a[mid] == x)
            {
                return mid;
            }
            if (x > a[mid])
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }

    static long BubbleSort(int[] a)
    {
        long comps = 0;
        for (int i = 0; i < a.Length - 1; i++)
        {
            for (int j = 0; j < a.Length - 1 - i; j++)
            {
                comps++;
                if (a[j] > a[j + 1])
                {
                    (a[j], a[j + 1]) = (a[j + 1], a[j]);
                }
            }
        }
        return comps;
    }

    static long MergeSort(int[] a)
    {
        long comps = 0;
        MergeSortRec(a, new int[a.Length], 0, a.Length - 1, ref comps);
        return comps;
    }

    static void MergeSortRec(int[] a, int[] tmp, int l, int r, ref long comps)
    {
        if (l >= r)
        {
            return;
        }

        int m = (l + r) / 2;
        MergeSortRec(a, tmp, l, m, ref comps);
        MergeSortRec(a, tmp, m + 1, r, ref comps);

        int i = l;
        int j = m + 1;
        int k = l;
        while (i <= m && j <= r)
        {
            comps++;
            if (a[i] <= a[j])
            {
                tmp[k] = a[i];
                i++;
            }
            else
            {
                tmp[k] = a[j];
                j++;
            }
            k++;
        }
        while (i <= m)
        {
            tmp[k] = a[i];
            i++;
            k++;
        }
        while (j <= r)
        {
            tmp[k] = a[j];
            j++;
            k++;
        }
        Array.Copy(tmp, l, a, l, r - l + 1);
    }

    static void Task1()
    {
        Console.WriteLine("\nЗадание 1");
        var rows = new List<ITableRow>();
        rows.Add(Row("Размер массива", "Искомое", "Индекс", "Сравнений"));

        foreach (int n in new int[] { 10, 100, 1000, 10000 })
        {
            int[] a = MakeShuffled(n);
            int[] queries = { a[0], a[n / 2], a[n - 1], 1, RandomQuery(n) };

            foreach (int x in queries)
            {
                int index = SequentialSearch(a, x, out int comps);
                rows.Add(Row(n, x, index, comps));
            }
        }
        new Table("task1", rows).Print();
    }

    static void Task2()
    {
        Console.WriteLine("\nЗадание 2");
        var rows = new List<ITableRow>();
        rows.Add(Row("Размер массива", "Искомое", "Индекс", "Сравнений"));

        foreach (int n in new int[] { 10, 100, 1000, 10000 })
        {
            int[] a = MakeSorted(n);
            int[] queries = { a[0], a[n / 2], a[n - 1], 1, RandomQuery(n) };

            foreach (int x in queries)
            {
                int index = BinarySearch(a, x, out int comps);
                rows.Add(Row(n, x, index, comps));
            }
        }
        new Table("task2", rows).Print();
    }

    static void Task3()
    {
        Console.WriteLine("\nЗадание 3 (зависимость сложности поиска от размера массива)");
        var rows = new List<ITableRow>();
        rows.Add(Row("Размер массива (N)", "Практическая сложность последовательного поиска", "Практическая сложность двоичного поиска"));

        for (int n = 20; n <= 500; n += 20)
        {
            int[] a = MakeSorted(n);
            int x = RandomQuery(n);

            SequentialSearch(a, x, out int seq);
            BinarySearch(a, x, out int bin);

            rows.Add(Row(n, seq, bin));
        }
        new Table("task3", rows).Print();
    }

    static void Task3Theory()
    {
        Console.WriteLine("\nЗадание 3 (сравнение с теорией, среднее по 1000 запросов)");
        var rows = new List<ITableRow>();
        rows.Add(Row("Размер массива (N)", "Практ. последовательный", "Теория N/2", "Практ. двоичный", "Теория log2(N)"));

        foreach (int n in new int[] { 20, 100, 200, 300, 400, 500 })
        {
            int[] a = MakeSorted(n);
            long seqSum = 0;
            long binSum = 0;
            int queries = 1000;

            for (int q = 0; q < queries; q++)
            {
                int x = a[rng.Next(n)];
                SequentialSearch(a, x, out int c1);
                BinarySearch(a, x, out int c2);
                seqSum += c1;
                binSum += c2;
            }

            rows.Add(Row(n,
                Math.Round((double)seqSum / queries, 1),
                n / 2,
                Math.Round((double)binSum / queries, 1),
                Math.Round(Math.Log2(n), 1)));
        }
        new Table("task3theory", rows).Print();
    }

    static int FindMinK(int n, int sortType, out long sortCost)
    {
        int[] unsorted = MakeShuffled(n);
        int[] sorted = (int[])unsorted.Clone();

        if (sortType == 1)
        {
            sortCost = BubbleSort(sorted);
        }
        else
        {
            sortCost = MergeSort(sorted);
        }

        long seqTotal = 0;
        long binTotal = sortCost;

        for (int k = 1; k <= 20 * n; k++)
        {
            int x = RandomQuery(n);

            SequentialSearch(unsorted, x, out int c1);
            BinarySearch(sorted, x, out int c2);
            seqTotal += c1;
            binTotal += c2;

            if (binTotal < seqTotal)
            {
                return k;
            }
        }
        return -1;
    }

    static void MinKTable(string title, string sortName, int sortType)
    {
        Console.WriteLine("\n" + title);
        var rows = new List<ITableRow>();
        rows.Add(Row("Размер массива (N)", "Сравнений при сортировке (" + sortName + ")", "K (эксперимент)", "K (теория)"));

        foreach (int n in new int[] { 100, 500, 1000, 2000 })
        {
            int k = FindMinK(n, sortType, out long cost);

            double log = Math.Log2(n);
            double theory;
            if (sortType == 1)
            {
                theory = n * (double)n / (n - log);
            }
            else
            {
                theory = n * log / (n - log);
            }

            rows.Add(Row(n, cost, k, Math.Round(theory)));
        }
        new Table("mink" + sortType, rows).Print();
    }

    static void Task4()
    {
        MinKTable("Допю. зад. 1 (пузырьковая)", "пузырёк", 1);
    }

    static void Task5()
    {
        MinKTable("Доп зад. 2(слиянием)", "слияние", 2);
    }

    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Task1();
        Task2();
        Task3();
        Task3Theory();
        Task4();
        Task5();
    }
}