/* Методы первой части задания должны быть перегружены (три варианта вызова) и использовать параметр по умолчанию. Расположите все методы задания в динамической и статической библиотеке. Продемонстрируйте их подключение к приложению.
Задание 10: Написать метод, который положительные числа возводит в квадрат, а отрицательные – в куб. С его помощью обработать ряд чисел от -10 до 10.
Написать метод расширения, определяющий является ли число простым.*/

namespace ClassLibrary {
	
	public class Calc {
		public static int calc(int x) {
			if (x > 0) return x * x;
			return x * x * x;
		}
		public static long calc(long x) {
			if (x > 0) return x * x;
			return x * x * x;	
		}
		public static double calc(double x) {
			if (x > 0) return Math.Pow(x, 2);
		   	return Math.Pow(x, 3);
		}
	}

	public class MathExtension {
		public static bool isPrime(int x) {
			for (int i = 2; i * i <= x; i++) {
				if (x % i == 0) return false;
			}
			return x != 1;
		}
	}
}
