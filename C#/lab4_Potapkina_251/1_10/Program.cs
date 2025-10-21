/* Задание 1. Создайте класс Point с компонентами:
 Индексатор, позволяющий по индексу 0 обращаться к полю x, по индексу 1 – к полю y, при других значениях индекса выдается сообщение об ошибке.
Перегрузку:
    • операции ++ (--): одновременно увеличивает (уменьшает) значение полей х и у на 1;
    • констант true и false: обращение к экземпляру класса дает значение true, если значение полей x и у совпадает, иначе false;
    • операции бинарный +: одновременно добавляет к полям х и у значение скаляра; 
Преобразования типа Point в string (и наоборот). */

class Point {
	private int x;
	private int y;

	// конструктор умолчания
	public Point() {
		x = 0;
		y = 0;
	}

	// конструктор с заданными значениями x и y
	public Point(int x, int y) {
		this.x = x;
		this.y = y;
	}
	
	// деструктор
	~Point() {
		Console.WriteLine("Объект удалён.");
	}
	
	// перегрузка оператора инкремента
	public static Point operator ++(Point p) {
		p.x++;
		p.y++;
		return p;
	}

	// перегрузка оператора декремента
	public static Point operator --(Point p) {
		p.x--;
		p.y--;
		return p;
	}

	// перегрузка оператора бинарного +
	public static Point operator +(Point p, int add) {
		p.x += add;
		p.y += add;
		return p;
	}
	
	// перегрузка оператора бинарного -
	public static Point operator +(int add, Point p) {
		p.x += add;
		p.y += add;
		return p;
	}

	// преобразование в true
	public static bool operator true(Point p) {
		return (p.x == p.y);
	}

	// преобразование в false
	public static bool operator false(Point p) {
		return (p.x != p.y);
	}

	// индексатор
	public int this[int idx] {
		get {
			if (idx < 0 || idx > 1) throw new IndexOutOfRangeException();
			return (idx == 0 ? x : y); 
		}
		set {
			if (idx < 0 || idx > 1) throw new IndexOutOfRangeException();
			if(idx == 0) x = value;
			else if (idx == 1) y = value;
		}
	}
	
	// преобразование из точки в строку
	public static explicit operator string(Point p) {
		return string.Format("({0}, {1})", p.x, p.y);
	}
	
	// преобразование из строки в точку
	public static explicit operator Point(string s) {
		s = s.Substring(1, s.Length - 2);
		string[] coords = s.Split(", ");
		int x = int.Parse(coords[0]);
		int y = int.Parse(coords[1]);
		return new Point(x, y);
	}
}

class Program {
	static void Main() {
		Point p = new Point(); // изначально точка будет иметь координаты (0, 0)
		while (true) {
			Console.WriteLine("Что Вы хотите сделать?");
			Console.WriteLine("1 - создать точку с заданными координатами;");
			Console.WriteLine("2 - создать точку из строки;");
			Console.WriteLine("3 - вывести координату точки по индексу;");
			Console.WriteLine("4 - изменить координату точки по индексу;");
			Console.WriteLine("5 - увеличить координаты точки на 1;");
			Console.WriteLine("6 - уменьшить координаты точки на 1;");
			Console.WriteLine("7 - прибавить к координатам точки некоторое число;");
			Console.WriteLine("8 - проверить, совпадают ли x и y координаты точки;");
			Console.WriteLine("0 - выйти из программы.");
			try {
				int choice = int.Parse(Console.ReadLine());
				if (choice == 1) {
					Console.Write("Введите x: ");
					int x = int.Parse(Console.ReadLine());
					Console.Write("Введите y: ");
					int y = int.Parse(Console.ReadLine());
					p = new Point(x, y);
				}
				else if (choice == 2) {
					Console.Write("Введите строку в формате (<x координата>, <y координата>): ");
					string s = Console.ReadLine();
					p = (Point)s;
				}
				else if (choice == 3) {
					Console.Write("Введите индекс: ");
					int idx = int.Parse(Console.ReadLine());
					Console.WriteLine("{0}-ая координата точки = {1}", idx, p[idx]);
					continue;
				}
				else if (choice == 4) {
					Console.Write("Введите индекс: ");
					int idx = int.Parse(Console.ReadLine());
					Console.Write("Введите новое значение координаты: ");
					int val = int.Parse(Console.ReadLine());
					p[idx] = val;
				}
				else if (choice == 5) {
					p++;
				}
				else if (choice == 6) {
					p--;
				}
				else if (choice == 7) {
					Console.Write("Введите это число: ");
					int add = int.Parse(Console.ReadLine());
					p = p + add;
				}
				else if (choice == 8) {
					if (p) Console.WriteLine("Совпадают.");
					else Console.WriteLine("Не совпадают.");
					continue;
				}
				else if (choice == 0) {
					Console.WriteLine("До свидания!");
					break;
				}
				else {
					Console.WriteLine("Некорректный выбор!");
					continue;
				}
				Console.WriteLine("Точка после выполнения операции " + (string) p);
			}
			catch (OverflowException) {
				Console.WriteLine("Переполнение!");
			}
			catch (FormatException) {
				Console.WriteLine("Неверный формат ввода данных!");
			}
			catch (IndexOutOfRangeException) {
				Console.WriteLine("Некорректный индекс!");
			}
		}	
	}
}
