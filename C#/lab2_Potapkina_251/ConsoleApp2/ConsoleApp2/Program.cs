// Задание 1. Измените программу так, чтобы метод Change удваивал значения положительных элементов массива.

class Program
{
    static void Print(int n, int[] a)
    {
        for (int i = 0; i < n - 1; i++) Console.Write("{0}, ", a[i]);
        Console.Write(a[n - 1]);
        Console.WriteLine();
    }
    static void Change(int n, int[] a)
    {
        for (int i = 0; i < n; i++)
            if (a[i] > 0) a[i] *= 2;
    }
    static void Main()
    {
        int n = 10;
        int[] arr = { 1024, -337, 11, 7, -2, 3, 5, -8, 17, 0 };
        Console.Write("Массив до изменения: ");
        Print(n, arr);
        Change(n, arr);
        Console.Write("Массив после изменения: ");
        Print(n, arr);
    }
}