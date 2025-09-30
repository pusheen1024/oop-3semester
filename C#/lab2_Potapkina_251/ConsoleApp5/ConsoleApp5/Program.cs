// Задание 4.11: Для каждого столбца найти номер последнего нечетного элемента и записать данные в новый массив.


using System;
namespace ConsoleApplication
{
    class Class
    {
        static int[][] InputMatrix() // Ввод двумерного массива
        {
            Console.Write("Введите размерность массива: ");
            int n = int.Parse(Console.ReadLine());
            int[][] arr = new int[n][];
            for (int i = 0; i < n; i++)
            {
                arr[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    Console.Write("a[{0},{1}] = ", i, j);
                    arr[i][j] = int.Parse(Console.ReadLine());
                }
            }
            return arr;
        }

        static void PrintArray(int[] a) // Вывод одномерного массива
        {
            for (int i = 0; i < a.Length; i++)
                Console.Write("{0} ", a[i]);
        }

        static void PrintMatrix(int[][] a) // Вывод двумерного массива
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                    Console.Write("{0} ", a[i][j]);
                Console.WriteLine();
            }
        }

        static int LastOdd(int[] a) // Индекс последнего нечётного элемента в массиве (-1, если такого нет)
        {
            int nch = -1;
            for (int i = 0; i < a.Length; i++)
                if (a[i] % 2 != 0) nch = i + 1;
            return nch;
        }

        static void Main()
        {
            try
            {
                int[][] arr = InputMatrix();
                Console.WriteLine("Исходный массив:");
                PrintMatrix(arr);
                int[] result = new int[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                    result[i] = LastOdd(arr[i]);
                Console.WriteLine("Новый массив:");
                PrintArray(result);
            }
            catch(OverflowException)
            {
                Console.WriteLine("Переполнение!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода данных!");
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Недостаточно памяти для создания нового объекта!");
            }
        }
    }
}