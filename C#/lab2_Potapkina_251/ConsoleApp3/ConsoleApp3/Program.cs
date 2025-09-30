// Задание 2. Добавьте в программу метод InputArray, предназначенный для ввода с клавиатуры элементов массива.
// Продемонстрируйте работу данного метода.

class Program
{
    static void InputArray(int[] arr) // ввод массива с клавиатуры
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("a[{0}] = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    static void PrintArray(string info, int[] arr) // вывод массива
    {
        Console.WriteLine(info);
        for (int i = 0; i < arr.Length; i++) Console.Write("{0} ", arr[i]);
        Console.WriteLine();
    }

    static void Main()
    {
        try
        {
            Console.Write("Введите размерность массива: ");
            int n = int.Parse(Console.ReadLine());
            int [] arr = new int[n];
            InputArray(arr);
            PrintArray("Исходный массив:", arr);
            Array.Sort(arr);
            PrintArray("Массив отсортирован по возрастанию:", arr);
            Array.Reverse(arr);
            PrintArray("Массив отсортирован по убыванию:", arr);
        }
        catch (FormatException)
        {
            Console.WriteLine("Неверный формат ввода данных!");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Переполнение!");
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("Недостаточно памяти для создания нового объекта!");
        }
    }
}