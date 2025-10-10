// Задание 3. Добавьте в программу метод MakeArray, предназначенный для создания ступенчатого массива,
// в котором количество элементов в каждой строке больше номера строки в два раза.
// А сам элемент равен сумме номеров строки и столбца, в котором он находится.
// Продемонстрируйте работу данного метода.

class Program
{
    static void PrintArray(string info, int[][] arr) // вывод массива
    {
        Console.WriteLine(info);
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++) Console.Write("{0} ", arr[i][j]);
            Console.WriteLine();
        }
    }
    
    static void MakeArray(int[][] arr) // создание ступенчатого массива
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = new int[2 * i];
            for (int j = 0; j < arr[i].Length; j++)
                arr[i][j] = i + j;
        }
    }
    static void Main()
    {
        try
        {
            Console.Write("Введите количество строк: ");
            int n = int.Parse(Console.ReadLine());
            int[][] arr = new int[n][];
            MakeArray(arr);
            PrintArray("Ступенчатый массив:", arr);
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
