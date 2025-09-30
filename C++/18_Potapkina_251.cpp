// 18) Комплексное число (с перегрузкой арифметических операций и операций сравнения)

#include <iostream>
#include <cmath>

using namespace std;

typedef long long li;
typedef long double ld;
typedef pair<int, int> ptt;

const ld EPS = 1e-9;

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
        cin.clear();
        return badComplex();
    }
    if (! (cin >> b)) {
        cin.clear();
        return badComplex();
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
        return badComplex();
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
    void print() {
        node *p = head;
        while (p != NULL) {
            cout << p->x << ' ';
            p = p->nxt;
        }
        cout << '\n';
    }
};

List v; // список комплексных чисел

// интерфейс калькулятора комплексных чисел
Complex calc() {
    cout << "Введите индекс первого числа из списка (нумерация с 0): ";
    int idx;
    if (! (cin >> idx)) {
        cout << "Некорректный индекс!" << '\n';
        cin.clear();
        return badComplex();
    }
    Complex num1 = v[idx];
    if (! num1.getStatus()) {
        cout << "Выход за границы списка!" << '\n';
        return badComplex();
    }
    cout << "Введите индекс второго числа из списка: ";
    if (! (cin >> idx)) {
        cout << "Некорректный индекс!" << '\n';
        cin.clear();
        return badComplex();
    }
    Complex num2 = v[idx];
    if (! num2.getStatus()) {
        cout << "Выход за границы списка!" << '\n';
        return badComplex();
    }
    cout << "Введите знак операции (+, -, *, /, <): ";
    string sign;
    cin >> sign;
    if (sign.size() > 1) {
        cout << "Некорректная операция!" << '\n';
        return badComplex();
    }
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
                cout << "Деление на ноль запрещено!" << '\n';
                return badComplex();
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
            cout << "Некорректная операция!" << '\n';
            return badComplex();
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
    if (choice.size() > 1) {
        cout << "Некорректный выбор!" << '\n';
        return;
    }
    char ch = choice[0];
    switch(ch) {
        case '1': {
            cout << "Введите число, которое хотите добавить: ";
            Complex num = inputComplex();
            if (! num.getStatus()) {
                cout << "Некорректное число!" << '\n';
                return;
            }
            v.pushItem(num);
            break;
        }
        case '2': {
            cout << "Введите число, которое хотите удалить: ";
            Complex num = inputComplex();
            if (! num.getStatus()) {
                cout << "Некорректное число!" << '\n';
                return;
            }
            v.deleteItem(num);
            break;
        }
        case '3': {
            cout << "Введите первое число: ";
            Complex num1 = inputComplex();
            if (! num1.getStatus()) {
                cout << "Некорректное число!" << '\n';
                return;
            }
            cout << "Введите второе число: ";
            Complex num2 = inputComplex();
            if (! num2.getStatus()) {
                cout << "Некорректное число!" << '\n';
                return;
            }
            v.insertItem(num1, num2);
            break;
        }
        case '4': {
            cout << "Введите комплексное число: ";
            Complex num = inputComplex();
            if (! num.getStatus()) {
                cout << "Некорректное число!" << '\n';
                return;
            }
            cout << "Количество элементов в списке, равных заданному: " << v.countItems(num) << '\n';
            return;
        }
        case '5': {
            cout << "Введите вещественное число: ";
            ld x;
            if (! (cin >> x)) {
                cout << "Некорректное число!" << '\n';
                cin.clear();
                return;
            }
            v.change(x);
            break;
        }
        case '6': {
            Complex res = calc();
            if (! res.getStatus()) return;
            v.pushItem(res);
            break;
        }
        default: {
            cout << "Некорректный выбор!" << '\n';
            return;
        }
    }
    cout << "Список после выполнения операции: ";
    v.print();
}

// результат запроса
int getAns() {
    string choice;
    cout << "Хотите продолжить? 1/д/y - да, 0/н/n - нет" << '\n';
    cin >> choice;
    if (choice == "1" || choice == "д" || choice == "y") return 1;
    if (choice == "0" || choice == "н" || choice == "n") return 0;
    return 2;
}

int main() {
    setlocale(LC_ALL, "RUS");
    cout << "Задание 1: работа с комплексными числами" << '\n';
    cout << "Числа вида a + bi вводятся в формате a b, где a и b - некоторые вещественные числа." << '\n';
    cout << "Список комплексных чисел:" << '\n';
    do {
        changeList();
        int res;
        while ((res = getAns()) == 2) cout << "Некорректный ответ!" << '\n';
        if (! res) break;
    }
    while (true);
}
