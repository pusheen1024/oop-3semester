/*Вариант 11: Объёмная фигура (Определить объём, определить площадь поверхности).
Класс 2. Прямой круговой конус (радиус основания, высота).
Класс 3. Усечённый прямой круговой конус (радиус малого основания).*/

// объёмная фигура (абстрактный класс)
abstract class Figure {
	public Figure() {}
	public abstract double GetVolume();
	public abstract double GetSurfaceArea();
}

// конус
class Cone : Figure {
	protected double radius;
	protected double height;

	public Cone(double radius, double height) : base() {
		if (radius < 0 || height < 0) {
			throw new FormatException();
		}
		this.radius = radius;
		this.height = height;
	}
	public override string ToString() {
		return string.Format("конус с радиусом {0} и высотой {1}", radius, height);
	}
	// образующая конуса
	public virtual double GetL() {
		return Math.Sqrt(height * height + radius * radius);
	}
	// объём конуса
	public override double GetVolume() {
		return Math.PI * radius * radius * height / 3;
	}
	// площадь поверхности конуса
	public override double GetSurfaceArea() {
		return Math.PI * radius * (radius + this.GetL());
	}
}
// усечённый конус
class TruncCone : Cone {
	protected double radius1;
	
	public TruncCone(double radius, double radius1, double height): base(radius, height) {
		if (radius1 < 0 || radius1 >= radius) {
			throw new FormatException();
		}
		this.radius1 = radius1;
	}
	public override string ToString() {
		return string.Format("усечённый конус с радиусом {0}, малым радиусом {1} и высотой {2}", radius, radius1, height);
	}
	public override double GetL() {
		return Math.Sqrt((radius - radius1) * (radius - radius1) + height * height);
	}
	public override double GetVolume() {
		return Math.PI * height * (radius * radius + radius * radius1 + radius1 * radius1) / 3;
	}
	public override double GetSurfaceArea() {
		return Math.PI * (this.GetL() * (radius + radius1) + radius * radius + radius1 * radius1);
	}
}

class Program {
	static void Main() {
		Figure f = null;
		while (true) {
			try {
				Console.WriteLine("Что Вы хотите сделать?");
				Console.WriteLine("1 - создать конус;");
				Console.WriteLine("2 - создать усечённый конус;");
				Console.WriteLine("3 - узнать объём;");
				Console.WriteLine("4 - узнать площадь поверхности;");
				Console.WriteLine("0 - выйти из программы.");
				int choice = int.Parse(Console.ReadLine());
				if (choice == 1 || choice == 2) {
					Console.Write("Введите радиус: ");
					double radius = double.Parse(Console.ReadLine());
					Console.Write("Введите высоту: ");
					double height = double.Parse(Console.ReadLine());
					if (choice == 1) {
						f = new Cone(radius, height);
					}
					else {
						Console.Write("Введите малый радиус: ");
						double radius1 = double.Parse(Console.ReadLine());
						f = new TruncCone(radius, radius1, height);
					}
					Console.WriteLine("Была создана фигура {0}", f);
				}
				else if (choice == 3 || choice == 4) {
					if (f == null) {
						Console.WriteLine("Фигура ещё не создана.");
					}
					else if (choice == 3) {
						Console.WriteLine("Объём фигуры = {0}", f.GetVolume());
					}
					else if (choice == 4) {
						Console.WriteLine("Площадь поверхности фигуры = {0}", f.GetSurfaceArea());
					}
				}
				else if (choice == 0) {
					Console.WriteLine("До свидания!");
					break;
				}
				else {
					Console.WriteLine("Некорректный выбор!");
				}
			}
			catch (FormatException) {
				Console.WriteLine("Неверный формат ввода данных или некорректное значение!");
			}
			catch (OverflowException) {
				Console.WriteLine("Переполнение!");
			}
		}
	}
}
