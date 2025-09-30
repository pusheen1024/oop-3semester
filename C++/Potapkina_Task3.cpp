// 18) Комплексное число (с перегрузкой арифметических операций и операций сравнения)
// Задание 3: обработка исключений

#include <iostream>
#include <cmath>
#include <fstream>

using namespace std;

typedef long long li;
typedef long double ld;
typedef pair<int, int> ptt;

const ld EPS = 1e-9;
const int MAX_SIZE = 1e7;

// коды ошибок
const int ZERO_DIVISION_ERROR = 0;
const int WRONG_FORMAT = 1;
const int INDEX_ERROR = 2;
const int NO_SUCH_OPERATION = 3;

// класс ошибки
class error {
protected:
    string message;
    int code;

public:
    error() {
        message = "неизвестная ошибка";
        code = 10;
    }
    error(string message, int code) {
        this->message = message;
        this->code = code;
    }
    virtual ostream& print (ostream &out) {
        return out << "Произошла " << message << ". Код ошибки: " << code << '\n';
    }
};

// класс ошибки работы с файлом
class fileError: public error {
private:
    string filename;

public:
    fileError(): error("ошибка при чтении/записи в файл", 11) {};
    fileError(string filename): fileError() {
        this->filename = filename;
    }
    ostream& print (ostream &out) {
        return out << "Произошла " << message << " с названием " << filename << ". Код ошибки: " << code << '\n';
    }
};

// класс ошибки памяти
class memoryError: public error {
public:
    memoryError(): error("ошибка памяти", 12) {};
};

// очистка потока ввода пссле некорректного ввода
void cin_clear() {
    if (cin.eof()) exit(0);
    cin.clear();
    cin.ignore(numeric_limits<streamsize>::max(), '\n');
}

// класс комплексного числа вида (a + bi)
class Complex {
private:
    ld a; // действительная часть
    ld b; // мнимая часть
    bool status; // успешно ли создано число

public:
    Complex() { // конструктор по умолчанию
        this->status = 1;
    }
    Complex(ld a, ld b, bool status) { // конструктор с аргументами
        this->a = a;
        this->b = b;
        this->status = status;
    }
    ~Complex() { // деструктор
    }
    ld getA() {
        return a;
    }
    ld getB() {
        return b;
    }
    bool getStatus() {
        return status;
    }
    void setA(ld a) {
        this->a = a;
    }
    void setB(ld b) {
        this->b = b;
    }
    void setStatus(bool fl) {
        this->status = fl;
    }
    bool isAZero() {
        return abs(a) < EPS;
    }
    bool isBZero() {
        return abs(b) < EPS;
    }
    bool isZero() {
        return isAZero() && isBZero();
    }
    ld getLength() { // модуль комплексного числа
        return sqrt(a * a + b * b);
    }
    void scale(ld x) { // умножить вектор на число
        this->a *= x;
        this->b *= x;
    }
};

// некорректно созданное число
Complex badComplex() {
    return Complex(0, 0, 0);
}

// ввод комплексного числа
Complex inputComplex() {
    ld a, b;
    if (! (cin >> a)) {
        throw int(WRONG_FORMAT);
    }
    if (! (cin >> b)) {
        throw int(WRONG_FORMAT);
    }
    Complex num(a, b, 1);
    return num;
}

// вывод комплексного числа
ostream& operator << (ostream &out, Complex &num) {
    ld a = num.getA(), b = num.getB();
    if (b < 0) return out << "(" << a << b << "*i" << ")";
    else return out << "(" << a << "+" << b << "*i" << ")";
}

// сложение комплексных чисел
Complex operator +(Complex &num1, Complex &num2) {
    Complex res;
    ld a = num1.getA(), b = num1.getB();
    ld c = num2.getA(), d = num2.getB();
    res.setA(a + c);
    res.setB(b + d);
    return res;
}

// вычитание комплексных чисел
Complex operator -(Complex &num1, Complex &num2) {
    Complex res;
    ld a = num1.getA(), b = num1.getB();
    ld c = num2.getA(), d = num2.getB();
    res.setA(a - c);
    res.setB(b - d);
    return res;
}

// умножение комплексных чисел
Complex operator *(Complex &num1, Complex &num2) {
    Complex res;
    ld a = num1.getA(), b = num1.getB();
    ld c = num2.getA(), d = num2.getB();
    res.setA(a * c - b * d);
    res.setB(b * c + a * d);
    return res;
}

// деление комплексных чисел
Complex operator /(Complex &num1, Complex &num2) {
    Complex res;
    ld a = num1.getA(), b = num1.getB();
    ld c = num2.getA(), d = num2.getB();
    ld n = (b * c - a * d) / (c * c + d * d);
    ld m = (b - c * n) / d;
    res.setA(m);
    res.setB(n);
    return res;
}

// сравнение комплексных чисел на равенство
bool operator ==(Complex &num1, Complex &num2) {
    return (num1 - num2).isZero();
}

// сравнение комплексных чисел по их модулю
bool operator <(Complex &num1, Complex &num2) {
    ld len_a = num1.getLength();
    ld len_b = num2.getLength();
    return len_b - len_a > EPS;
}

struct node {
    Complex x;
    node *prev;
    node *nxt;
};

// двусвязный список
class List {
private:
    node *head;
    node *tail;

    // удалить ноду
    void deleteNode(node *elem) {
        if (elem == NULL) return;
        if (elem == head && elem == tail) {
            head = tail = NULL;
        }
        else if (elem == head) {
            head = head->nxt;
            head->prev = NULL;
        }
        else if (elem == tail) {
            tail = tail->prev;
            tail->nxt = NULL;
        }
        else {
            elem->nxt->prev = elem->prev;
            elem->prev->nxt = elem->nxt;
        }
        delete elem;
    }

    // вставить элемент после заданной ноды
    void insertNode(node *elem, Complex num) {
        node *nw = new node;
        nw->x = num;
        if (elem == tail) {
            nw->nxt = NULL;
            nw->prev = elem;
            elem->nxt = nw;
            tail = nw;
        }
        else {
            elem->nxt->prev = nw;
            nw->nxt = elem->nxt;
            nw->prev = elem;
            elem->nxt = nw;
        }
    }

public:
    List() {
        head = NULL;
        tail = NULL;
    }

    // добавить элемент в конец списка
    void pushItem(Complex num) {
        node *nw = new node;
        nw->x = num;
        nw->nxt = NULL;
        if (! head && ! tail) {
            nw->prev = NULL;
            head = nw;
        }
        else {
            tail->nxt = nw;
            nw->prev = tail;
        }
        tail = nw;
    }

    // удалить элемент
    void deleteItem(Complex num) {
        auto res = this->findItem(num);
        if (res) this->deleteNode(res);
    }

    // вставить элемент после другого элемента
    void insertItem(Complex num1, Complex num2) {
        auto res = this->findItem(num1);
        if (res) this->insertNode(res, num2);
    }

    // найти первое вхождение данного комплексного числа в списке
    node *findItem(Complex num) {
        node *p = head;
        while (p) {
            if (p->x == num) return p;
            p = p->nxt;
        }
        return NULL;
    }

    // обратиться к элементу по индексу
    Complex operator[](const int idx) {
        node *p = head;
        int i = 0;
        while (p != NULL) {
            if (i == idx) return p->x;
            p = p->nxt;
            i++;
        }
        throw int(INDEX_ERROR);
    }

    // узнать размер списка
    int size() {
        node *p = head;
        int sz = 0;
        while (p != NULL) {
            sz++;
            p = p->nxt;
        }
        return sz;
    }

    // посчитать количество чисел, равных данному
    int countItems(Complex num) {
        int cnt = 0;
        node *p = head;
        while (p) {
            if (p->x == num) cnt++;
            p = p->nxt;
        }
        return cnt;
    }
    // выполнить операцию (умножение на число) над всеми элементами списка
    void change(ld x) {
        node *p = head;
        while (p != NULL) {
            p->x.scale(x);
            p = p->nxt;
        }
    }
    // вывести список
    void print(ostream &out) {
        node *p = head;
        while (p != NULL) {
            out << p->x << ' ';
            p = p->nxt;
        }
        out << '\n';
    }
};

List v; // список комплексных чисел

// интерфейс калькулятора комплексных чисел
Complex calc() {
    cout << "Введите индекс первого числа из списка (нумерация с 0): ";
    int idx;
    if (! (cin >> idx)) {
        throw int(WRONG_FORMAT);
    }
    Complex num1 = v[idx];

    cout << "Введите индекс второго числа: ";
    if (! (cin >> idx)) {
        throw int(WRONG_FORMAT);
    }
    Complex num2 = v[idx];

    cout << "Введите знак операции (+, -, *, /, <): ";
    string sign;
    cin >> sign;
    if (sign.size() > 1) throw int(WRONG_FORMAT);

    char op = sign[0];
    Complex num3;
    switch(op) {
        case '+': {
            num3 = num1 + num2;
            break;
        }
        case '-': {
            num3 = num1 - num2;
            break;
        }
        case '*': {
            num3 = num1 * num2;
            break;
        }
        case '/': {
            if (num2.isZero() || num2.isBZero()) {
                throw int(ZERO_DIVISION_ERROR);
            }
            num3 = num1 / num2;
            break;
        }
        case '<': {
            if (num1 < num2) cout << "Первое число меньше второго (по модулю)." << '\n';
            else if (num1 == num2) cout << "Первое число равно второму." << '\n';
            else cout << "Первое число больше второго (по модулю)." << '\n';
            return badComplex();
        }
        default: {
            throw int(NO_SUCH_OPERATION);
        };
    }
    cout << "Результат: " << num3 << '\n';
    return num3;
}

// интерфейс списка комплексных чисел
void changeList() {
    cout << "Что Вы хотите сделать?" << '\n';
    cout << "1 - добавить новый элемент в конец списка;" <<'\n';
    cout << "2 - удалить первое вхождение заданного элемента;" << '\n';
    cout << "3 - если в списке присутствует первый элемент, вставить после его первого вхождения второй;" << '\n';
    cout << "4 - посчитать в списке количество элементов, равных заданному;" << '\n';
    cout << "5 - умножить все комплексные числа в списке на некоторое вещественное число;" << '\n';
    cout << "6 - выполнить арифметическую операцию с комплексными числами и при возможности добавить результат в конец списка." << '\n';
    string choice;
    cin >> choice;
    if (choice.size() > 1) throw int(WRONG_FORMAT);
    char ch = choice[0];
    switch(ch) {
        case '1': {
            cout << "Введите число, которое хотите добавить: ";
            Complex num = inputComplex();
            v.pushItem(num);
            break;
        }
        case '2': {
            cout << "Введите число, которое хотите удалить: ";
            Complex num = inputComplex();
            v.deleteItem(num);
            break;
        }
        case '3': {
            cout << "Введите первое число: ";
            Complex num1 = inputComplex();
            cout << "Введите второе число: ";
            Complex num2 = inputComplex();
            v.insertItem(num1, num2);
            break;
        }
        case '4': {
            cout << "Введите комплексное число: ";
            Complex num = inputComplex();
            cout << "Количество элементов в списке, равных заданному: " << v.countItems(num) << '\n';
            return;
        }
        case '5': {
            cout << "Введите вещественное число: ";
            ld x;
            if (! (cin >> x)) {
                throw int(WRONG_FORMAT);
            }
            v.change(x);
            break;
        }
        case '6': {
            Complex res = calc();
            v.pushItem(res);
            break;
        }
        default: {
            throw int(NO_SUCH_OPERATION);
        }
    }
    if (v.size() > MAX_SIZE) throw memoryError();
    cout << "Список после выполнения операции: ";
    v.print(cout);
}

// результат запроса
int getAns() {
    string choice;
    cout << "Хотите продолжить? 1/д/y - да, 0/н/n - нет" << '\n';
    cin >> choice;
    cin_clear();
    if (choice == "1" || choice == "д" || choice == "y") return 1;
    if (choice == "0" || choice == "н" || choice == "n") return 0;
    return 2;
}

int main() {
    setlocale(LC_ALL, "RUS");
    try {
        cout << "Задание 1: работа с комплексными числами" << '\n';
        cout << "Числа вида a + bi вводятся в формате a b, где a и b - некоторые вещественные числа." << '\n';
        cout << "Список комплексных чисел:" << '\n';
        do {
            try {
                changeList();
            }
            catch (int er) {
                cin_clear();
                switch(er) {
                    case ZERO_DIVISION_ERROR: {
                        cerr << "Деление на ноль невозможно!";
                        break;
                    }
                    case WRONG_FORMAT: {
                        cerr << "Неверный формат ввода данных!";
                        break;
                    }
                    case INDEX_ERROR: {
                        cerr << "Выход за границы списка!";
                        break;
                    }
                    case NO_SUCH_OPERATION: {
                        cerr << "Некорректный выбор!";
                        break;
                    }
                    default: {
                        cerr << "Неизвестная ошибка!";
                        break;
                    }
                }
                cerr << " Код ошибки: " << er << '\n';
            }
            catch (memoryError &me) {
                me.print(cerr);
            }
            catch (error er) {
                er.print(cerr);
            }
            int res;
            while ((res = getAns()) == 2) cout << "Некорректный ответ!" << '\n';
            if (! res) break;
        }
        while (true);

        cout << "Введите название файла, куда Вы хотите записать получившийся список: ";
        string filename;
        cin >> filename;
        ofstream out(filename);
        if (! out) throw fileError(filename);
        v.print(out);
    }
    catch (fileError fe) {
        fe.print(cerr);
    }
    catch(...) {
        cerr << "Неизвестная ошибка!" << '\n';
    }
}
