// Разработать класс для представления объекта матрица, состоящая из элементов типа char. Определить конструктор с двумя параметрами целого типа – размерность матрицы, который можно использовать как конструктор умолчания. Определить конструктор, который создаёт новую матрицу таким образом, что все её элементы больше элементов другой матрицы на заданное число, и который можно использовать как конструктор копирования. Определить деструктор. Определить преобразования из переменной типа char в матрицу – заполнение матрицы и из матрицы в переменную типа double – среднее арифметическое элементов матрицы.

class CharMatrix {
	private int n; // количество строк
	private int m; // количество столбцов
	private char[][] arr; // матрица

	// конструктор по умолчанию
	public CharMatrix(int n, int m) 
	{
		this.n = n;
		this.m = m;
		arr = new char[n][];
		for (int i = 0; i < n; i++) arr[i] = new char[m];
	}

	// создание матрицы из двумерного массива
	public CharMatrix(char[][] arr)
	{
		this.n = arr.Length;
		this.m = arr[0].Length;
		this.arr = arr;
	}
}
	/*// констуктор копирования
	public CharMatrix(CharMatrix cm, char add) 
	{
		CharMatrix cm_new(cm.N(), cm.M());
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++) 
			{
				cm_new[i][j] = cm[i][j] + add;
			}
		}
	}

	// деструктор
	~public CharMatrix() 
	{
		Console.Write("Объект удалён.");
	}

	// преобразование из матрицы в double
	public static explicit operator double(CharMatrix cm) 
	{
		long long sm = 0;
		int sz = n * 1ll * m;
		for (int i = 0; i < n; i++) 
		{
			for (int j = 0; j < m; j++) 
			{
				sm += arr[i][j];
			}
		}
		return double(sm) / sz;
	}

	// преобразование из char в матрицу (её заполнение)
	public static explicit operator CharMatrix(int n, int m, char elem) {
		CharMatrix cm = CharMatrix(n, m);
		for (int i = 0; i < n; i++) 
		{
			for (int j = 0; j < m; j++) 
			{
				arr[i][j] = elem;
			}
		}

	}
	public int N
	{
		set {n = value; } get {return n; }
	}
	public int M
	{
		set {m = value; } get {return m; }
	}
	public char[][] A 
	{
		get {return a; }
	}
	public char this[int i][int j]
	{
		set {arr[i][j] = value; } get {arr[i][j]; }
	}*/
}

class Program
{
	static void Main() 
	{
		CharMatrix c(2, 3);
	}	
}
