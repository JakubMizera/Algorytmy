public class App
{
    public static void Main(string[] args)
    {
        int[] arr = new int[] { 1, 5, 10, 15, 20, 25, 30 };

        Console.WriteLine(RepeatRecursive("#", 5));
        Console.WriteLine(string.Join(" ", ArraySum(arr, 1, 16)));

        Console.WriteLine(string.Join(' ', Change(47)));

        Console.WriteLine(FibQuick(44));
        int[] array1 = new int[] { 123, 3, 55, 72, 51 };

        Console.WriteLine(string.Join(' ', array1));
    }

    public static string Repeat(string s, int n)
    {
        string result = "";
        for (int i = 0; i < n; i++)
        {
            result = result + s;//result = Repeat(s, i - 1) + s;
        }
        return result;
    }
    //rekurencyjne sumowanie elementów w tablicy
    public static int ArraySum(int[] arr, int start, int end)
    {
        if (start < 1 || end > arr.Length)
        {
            throw new ArgumentException("Wartość dla początku lub końca jest niewłaściwa");
        }
        if (start == end)
        {
            return arr[start];
        }
        else
        {
            int mid = (start + end) / 2;
            return ArraySum(arr, start, mid) + ArraySum(arr, mid + 1, end);
        };
    }
    public static string RepeatRecursive(string s, int n)
    {
        if (n <= 0)
        {
            return "";
        }
        return RepeatRecursive(s, n - 1) + s;
    }

    //Wydawanie reszty dla trzech nominałów 1, 2, 5
    //zdefiniowac dla dowolnych nominałów np. 1 2 5 10 20 50
    public static int[] Change(int amount)
    {
        int[] arr = new int[3];
        arr[2] = amount / 5;
        amount = amount - arr[2] * 5; //nominal 5
        arr[1] = amount / 2;
        amount = amount - arr[1] * 2; //nominal 2
        arr[0] = amount / 1;
        amount = amount - arr[0] * 1; //nominal 1
        return arr;
    }

    public static long Fib(int n)
    {
        if (n < 2)
        {
            return n;
        }
        return Fib(n - 2) + Fib(n - 1);
    }

    public static long FibMem(int n, long[] mem)
    {
        if (n < 2)
        {
            return n;
        }

        if (mem[n - 1] == 0)
        {
            mem[n - 1] = FibMem(n - 1, mem);
        }

        if (mem[n - 2] == 0)
        {
            mem[n - 2] = FibMem(n - 2, mem);
        }

        return mem[n - 2] + mem[n - 1];
    }

    public static long FibQuick(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("Numer wyrazu  nie może być ujemny");
        }
        return FibMem(n, new long[n]);
    }

    //bąbelkowanie

    public static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = arr.Length - 1; j < i; j++)
            {
                if (arr[j] < arr[j - 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;
                }
            }
        }
    }

}