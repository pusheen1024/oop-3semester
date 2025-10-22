/* Методы первой части задания должны быть перегружены (три варианта вызова) и использовать параметр по умолчанию. Расположите все методы задания в динамической или статической библиотеке. Продемонстрируйте их подключение к приложению.
Задание 10: Написать метод, который положительные числа возводит в квадрат, а отрицательные – в куб. С его помощью обработать ряд чисел от -10 до 10.
Написать метод расширения, определяющий является ли число простым.*/

using System.Reflection;

class Program {
	static void Main() {
		// подключение динамической библиотеки
		Assembly asm = Assembly.LoadFrom("/home/pusheen/КНиИТ/ООП/C#/lab4_Potapkina_251/CalcLibrary/bin/Debug/net8.0/CalcLibrary.dll");
		Type[] types = asm.GetTypes();
		Type calc = types[0];
		Object obj_calc = Activator.CreateInstance(calc);
		Type prime = types[1];
		Object obj_prime = Activator.CreateInstance(prime);
		Type[] int_type = new Type[] {typeof(int)};
		MethodInfo mi_calc = calc.GetMethod("calc", int_type); // использовать перегруженный метод calc для int
		MethodInfo mi_prime = prime.GetMethod("isPrime");
		Object[] numbers = new Object[21];
		for (int i = -10; i <= 10; i++) numbers[i + 10] = i;
		Console.WriteLine("Исходный массив:");
		for (int i = 0; i < 21; i++) Console.Write("{0} ", numbers[i]);
		for (int i = 0; i < 21; i++) {
			Object[] num = new Object[] {numbers[i]};
			numbers[i] = mi_calc.Invoke(obj_calc, num); // изменить число с помощью метода
		}
		Console.WriteLine();
		Console.WriteLine("Изменённый массив:");
		for (int i = 0; i < 21; i++) Console.Write("{0} ", numbers[i]);
		Console.WriteLine();
		while (true) {
			try {
				Console.WriteLine("Введите натуральное число, которое Вы хотите проверить на простоту. Введите 0, если хотите завершить взаимодействие.");
				int x = int.Parse(Console.ReadLine());
				if (x < 0) {
					Console.WriteLine("Число должно быть натуральным!");
				}
				else if (x == 0) {
					Console.WriteLine("До свидания!");
					break;
				}
				else {
					Object[] num = new Object[] {x};
					bool ans = (bool) mi_prime.Invoke(obj_prime, num);
					if (ans) Console.WriteLine("Число простое.");
					else Console.WriteLine("Число не простое.");
				}
			}
			catch (OverflowException) {
				Console.WriteLine("Переполнение!");
			}
			catch (FormatException) {
				Console.WriteLine("Неверный формат ввода данных!");
			}
		}	
	}
}
