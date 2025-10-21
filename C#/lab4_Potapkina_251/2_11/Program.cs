/* Разработать базовый класс, содержащий виртуальные методы, и производный от него класс, в котором эти методы переопределены. Дополнительно требуется переопределить методы класса System.Object. 
Вариант 11: Базовый. Квартира (адрес дома, номер, площадь, число комнат, этаж).
Производный. Квартира с лоджией (площадь лоджии)
Методы: Определить цену. */

class Flat {
	protected string address;
	protected int flat_number;
	protected int area;
	protected int number_of_rooms;
	protected int floor;
	protected const int PRICE = 100000; 
	
	public Flat(string address, int flat_number, int area, int number_of_rooms, int floor) {
		if (flat_number <= 0 || area <= 0 || number_of_rooms <= 0 || floor <= 0) {
			throw new FormatException();
		}
		this.address = address;
		this.flat_number = flat_number;
		this.area = area;
		this.number_of_rooms = number_of_rooms;
		this.floor = floor;
	}

	public override string ToString() {
		return string.Format("Квартира №{0}, расположенная в доме по адресу {1} на {2} этаже, площадью {3} м^2, с {4} комнатами", 
							 flat_number, address, floor, area, number_of_rooms);
	}

	public virtual int getPrice() {
		return PRICE * area;
	}
}

sealed class FlatWithBalcony : Flat {
	private int balcony_area;

	public FlatWithBalcony(string address, int flat_number, int area, int number_of_rooms, int floor, int balcony_area): 
	base(address, flat_number, area, number_of_rooms, floor) {
		if (balcony_area <= 0) throw new FormatException();
		this.balcony_area = balcony_area;
	}

	public override string ToString() {
		return base.ToString() + String.Format(" и лоджией площадью {0} м^2", balcony_area);
	}

	public override int getPrice() {
		return PRICE * (area + balcony_area);
	}

}

partial class Program {
	static void Main() {
		Flat f = null;
		while (true) {
			try {
				Console.WriteLine("Что Вы хотите сделать?");
				Console.WriteLine("1 - создать квартиру;");
				Console.WriteLine("2 - создать квартиру с балконом;");
				Console.WriteLine("3 - узнать цену квартиры;");
				Console.WriteLine("0 - выйти из программы.");
				int choice = int.Parse(Console.ReadLine());
				if (choice == 1 || choice == 2) {
					Console.Write("Адрес квартиры: ");
					string address = Console.ReadLine();
					Console.Write("Номер квартиры: ");
					int flat_number = int.Parse(Console.ReadLine());
					Console.Write("Площадь квартиры: ");
					int area = int.Parse(Console.ReadLine());
					Console.Write("Количество комнат: ");
					int number_of_rooms = int.Parse(Console.ReadLine());
					Console.Write("Этаж: ");
					int floor = int.Parse(Console.ReadLine());
					if (choice == 1) {
						f = new Flat(address, flat_number, area, number_of_rooms, floor);
						Console.WriteLine(f);
					}
					else {
						Console.Write("Площадь лоджии: ");
						int balcony_area = int.Parse(Console.ReadLine());
						f = new FlatWithBalcony(address, flat_number, area, number_of_rooms, floor, balcony_area);
						Console.WriteLine(f);
					}
				}
				else if (choice == 3) {
					if (f == null) {
						Console.WriteLine("Квартира пока не создана.");
					}
					else Console.WriteLine(string.Format("Цена квартиры составляет {0} рублей", f.getPrice()));
				}
				else if (choice == 0) {
					Console.WriteLine("До свидания!");
					break;
				}
				else {
					Console.WriteLine("Некорректный выбор!");
				}
			}
			catch (OverflowException) {
				Console.WriteLine("Переполнение!");
			}
			catch (FormatException) {
				Console.WriteLine("Неверный формат ввода данных или некорректное значение!");
			}
		}
	}
}
