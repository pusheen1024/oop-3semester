// 10: Разработать класс для представления объекта матрица, состоящая из элементов типа char. Определить конструктор с двумя параметрами целого типа – размерность матрицы, который можно использовать как конструктор умолчания. Определить конструктор, который создаёт новую матрицу таким образом, что все её элементы больше элементов другой матрицы на заданное число, и который можно использовать как конструктор копирования. Определить деструктор. Определить преобразования из переменной типа char в матрицу – заполнение матрицы и из матрицы в переменную типа double – среднее арифметическое элементов матрицы.

class CharMatrix {
	private int n; // количество строк
	private int m; // количество столбцов
	private char[][] arr; // матрица
	
	// количество строк
	public int N
	{
		set {n = value; } get {return n; }
	}
	// количество столбцов
	public int M
	{
		set {m = value; } get {return m; }
	}
 	// переопределение обращения по индексам
	public char this[int i, int j]
	{
		set {arr[i][j] = value; } get {return arr[i][j]; }
	}
	// конструктор по умолчанию
	public CharMatrix(int n, int m) 
	{
		this.n = n;
		this.m = m;
		arr = new char[n][];
		for (int i = 0; i < n; i++) arr[i] = new char[m];
	}
	// констуктор копирования
	public CharMatrix(CharMatrix cm, char add) 
	{
		this.n = cm.N;
		this.m = cm.M;
		arr = new char[n][];
		for (int i = 0; i < n; i++) arr[i] = new char[m];
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++) 
			{
				if (char.MaxValue - cm[i, j] < add) 
				{
					throw new OverflowException(); // получилось число, которое не влезает в char
				}
				this.arr[i][j] = (char)(cm[i, j] + add);
			}
		}
	}
	// деструктор
	~CharMatrix()  
	{
		arr = null;
		Console.Write("Объект удалён.");
	}
	// преобразование из матрицы в double
	public static explicit operator double(CharMatrix cm) 
	{
		long sm = 0;
		int sz = cm.N * cm.M;
		for (int i = 0; i < cm.N; i++) 
		{
			for (int j = 0; j < cm.M; j++) 
			{
				sm += cm[i, j];
			}
		}
		return (double)sm / sz;
	}
	// преобразование из char в матрицу (её заполнение)
	public static explicit operator CharMatrix(char elem) 
	{
		CharMatrix cm = new CharMatrix(5, 5);
		for (int i = 0; i < cm.N; i++) 

		{
			for (int j = 0; j < cm.M; j++) 
			{
				cm[i, j] = elem;
			}
		}
		return cm;
	}
	// вывод матрицы
	public void Print()
	{
		for (int i = 0; i < n; i++) 
		{
			for (int j = 0; j < m; j++) 
			{
				Console.Write("{0} ", arr[i][j]);
			}
			Console.WriteLine();
		}
	}
	// ввод матрицы
	public void Input()
    {
		for (int i = 0; i < n; i++) 
		{
			Console.Write("a[{0}] = ", i); 
        	string input = Console.ReadLine();
			string[] str = input.Split();
			if (str.Length != m) 
			{
		    	throw new IndexOutOfRangeException();
			}
			for (int j = 0; j < m; j++) 
			{
            	arr[i][j] = char.Parse(str[j]);
			}
		}
	}
}

class Program
{
	// интерфейс для ввода матрицы
	static CharMatrix InputMatrix(bool empty) 
	{
		Console.Write("Введите количество строк: ");
    	int n = int.Parse(Console.ReadLine());
		Console.Write("Введите количество столбцов: ");
		int m = int.Parse(Console.ReadLine());
		CharMatrix cm = new CharMatrix(n, m);
		if (! empty) cm.Input();
		return cm;
	}
	static void Main()
	{
		CharMatrix cm = null;
		while (true)
		{
			try 
			{
				Console.WriteLine("Что Вы хотите сделать?");
				Console.WriteLine("1 - Создать пустую матрицу;");
				Console.WriteLine("2 - Ввести матрицу с клавиатуры;");
				Console.WriteLine("3 - Создать матрицу по умолчанию, заполненную некоторым элементом;");
				Console.WriteLine("4 - Создать матрицу, где все элементы больше элементов предыдущей матрицы на некоторый символ;");
				Console.WriteLine("5 - Вычислить среднее арифметическое элементов матрицы;");
				Console.WriteLine("0 - Выйти из программы.");
				int choice = int.Parse(Console.ReadLine());
				if (choice == 0) 
				{
					cm = null;
					break;
				}
				else if (choice == 1) 
				{
					cm = InputMatrix(true);
				}
				else if (choice == 2) 
				{
					cm = InputMatrix(false);
				}
				else if (choice == 3)
				{
					Console.Write("Введите символ, которым Вы хотите заполнить матрицу: ");
					char elem = char.Parse(Console.ReadLine());
					cm = (CharMatrix)elem;
				}
				else if (choice == 4)
				{
					Console.Write("Введите символ, который Вы хотите прибавить к элементам матрицы: ");
					char add = char.Parse(Console.ReadLine());
					cm = new CharMatrix(cm, add);
				}
				else if (choice == 5)
				{
					double avg = (double)cm;
					Console.WriteLine("Среднее арифметическое элементов матрицы = {0}.", avg);
					continue;
				}
				else
				{
					Console.WriteLine("Некорректный выбор!");
					continue;
				}
				Console.WriteLine("Результат:");
				cm.Print();
			}
			catch (OverflowException)
			{
				Console.WriteLine("Переполнение!");
			}
			catch (FormatException)
			{
				Console.WriteLine("Неверный формат входных данных!");
			}
			catch (IndexOutOfRangeException)
			{
				Console.WriteLine("Некорректное количество элементов в строке!");
			}
			catch (OutOfMemoryException)
			{
				Console.WriteLine("Недостаточно памяти!");
			}
		}
		Console.WriteLine("До свидания!");
	}
}
