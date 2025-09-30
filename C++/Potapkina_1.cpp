#include <iostream>
#include <cmath>

using namespace std;

typedef long long li;
typedef long double ld;
typedef pair<int, int> ptt;

const ld EPS = 1e-9;
const ld PI = acos(-1);

bool notPos(ld a) { // число неположительное
    return a < EPS;
}

bool eq(ld a, ld b) { // числа равны
    return abs(a - b) < EPS;
}

class Figure { // базовая фигура
protected:
    string type; // тип фигуры
    bool status; // статус фигуры

public:
    Figure() {} // пустой конструктор
    Figure(string type) { // конструктор с аргументами
        this->type = type;
        this->status = 1;
    }
    Figure(bool st) {
        this->type = "Фигура";
        this->status = st;
    }
    Figure(const Figure &f) {
        this->type = f.type;
    }
    ~Figure() {} // деструктор
    string getType() {
        return type;
    }
    bool getStatus() {
        return status;
    }
    void setStatus(bool st) {
        this->status = st;
    }
    virtual ld getArea() {
        return 0;
    };
    virtual ld getPerimeter() {
        return 0;
    }
    virtual bool operator ==(Figure *p) {
        return 1;
    }
    virtual ostream& print(ostream &out) {
        return out << "Базовая фигура типа " << type << '\n';
    }
};

class Point: public Figure { // точка
private:
    ld x; // x-координата точки
    ld y; // y-координата точки

public:
    Point() {}
    Point(ld x, ld y) : Figure(1) {
        this->type = "Точка";
        this->x = x;
        this->y = y;
    }
    Point(const Point &p) : Figure(1) {
        this->type = "Точка";
        this->x = p.x;
        this->y = p.y;
    }
    ld getX() {
        return x;
    }
    ld getY() {
        return y;
    }
    bool operator == (Figure *f) {
        Point *p = dynamic_cast<Point*>(f);
        if (p) return (eq(x, p->getX()) && eq(y, p->getY()));
        return false;
    }
    ostream& print(ostream &out) {
        return out << "Точка с координатами (" << x << ", " << y << ")" << '\n';
    }
};

class RightPolygon: virtual public Figure { // правильный многоугольник
protected:
    ld side; // сторона
    int n; // количество сторон

public:
    RightPolygon() {}
    RightPolygon(ld side, int n): Figure(1) {
        if (notPos(side) || n < 3) {
            this->status = 0;
            return;
        }
        this->type = "Правильный многоугольник";
        this->side = side;
        this->n = n;
    }
    RightPolygon(const RightPolygon &p) : Figure(1) {
        this->type = "Правильный многоугольник";
        this->side = p.side;
        this->n = p.n;
    }
    ld getSide() {
        return side;
    }
    int getN() {
        return n;
    }
    ld getSumAngles() { // сумма углов
        return PI * (n - 2);
    }
    ld getAngle() { // угол
        return getSumAngles() / n;
    }
    ld getArea() { // площадь
        return (n * side * side) / (4 * tan(PI / n));
    }
    ld getPerimeter() { // периметр
        return n * side;
    }
    bool operator == (Figure *f) {
        RightPolygon *rp = dynamic_cast<RightPolygon*>(f);
        if (rp) return (eq(side, rp->getSide()) && n == rp->getN());
        return false;
    }
    virtual ostream& print(ostream &out) {
        return out << "Правильный " << n << "-угольник со стороной " << side << '\n';
    }
};

class Rectangle: virtual public Figure { // прямоугольник
private:
    ld width; // ширина
    ld height; // высота

public:
    Rectangle() {}
    Rectangle(ld width, ld height): Figure(1) {
        if (notPos(width) || notPos(height)) {
            this->status = 0;
            return;
        }
        this->type = "Прямоугольник";
        this->width = width;
        this->height = height;
    }
    Rectangle(const Rectangle &r) : Figure(1) {
        this->type = "Прямоугольник";
        this->width = r.width;
        this->height = r.height;
    }
    ld getWidth() {
        return width;
    }
    ld getHeight() {
        return height;
    }
    ld getArea() {
        return width * height;
    }
    ld getPerimeter() {
        return 2 * (width + height);
    }
    virtual bool operator == (Figure *f) {
        Rectangle *rg = dynamic_cast<Rectangle*>(f);
        if (rg) return (eq(width, rg->getWidth()) && eq(height, rg->getHeight()));
        return false;
    }
    virtual ostream& print(ostream &out) {
        return out << "Прямоугольник с шириной " << width << " и высотой " << height << '\n';
    }
};

class Square: virtual public RightPolygon, public Rectangle { // квадрат: прямоугольник с равными сторонами или правильный четырёхугольник
private:
    ld side; // сторона

public:
    Square() {}
    Square(ld side): Figure(1), RightPolygon(side, 4), Rectangle(side, side) {
        this->type = "Квадрат";
        this->side = side;
    }
    Square(const Square &p) : RightPolygon((const_cast<Square&>(p)).getSide(), 4),
    Rectangle((const_cast<Square&>(p)).getSide(), (const_cast<Square&>(p)).getSide()) {
        this->type = "Квадрат";
        this->side = p.side;
    }
    ld getSide() {
        return side;
    }
    ld getArea() {
        return side * side;
    }
    ld getPerimeter() {
        return 4 * side;
    }
    virtual bool operator == (Figure *f) {
        Rectangle *rg = dynamic_cast<Rectangle*>(f);
        if (rg) return (eq(side, rg->getWidth()) && eq(side, rg->getHeight()));
        return false;
    }
    ostream& print(ostream &out) {
        return out << "Квадрат со стороной " << side << '\n';
    }
};

class Triangle: virtual public Figure { // треугольник
protected:
    ld a;
    ld b;
    ld c;
public:
    Triangle() {}
    Triangle(ld a, ld b, ld c): Figure(1) {
        if (a + b <= c || a + c <= b || b + c <= a || notPos(a) || notPos(b) || notPos(c)) {
            this->status = 0;
            return;
        }
        this->type = "Треугольник";
        this->a = a;
        this->b = b;
        this->c = c;
    }
    Triangle(const Triangle &t) : Figure(1) {
        this->type = "Треугольник";
        this->a = t.a;
        this->b = t.b;
        this->c = t.c;
    }
    ld getA() {
        return a;
    }
    ld getB() {
        return b;
    }
    ld getC() {
        return c;
    }
    virtual ld getArea() {
        ld p = (a + b + c) / 2;
        return sqrt(p * (p - a) * (p - b) * (p - c));
    }
    ld getPerimeter() {
        return a + b + c;
    }
    virtual bool operator == (Figure *f) {
        Triangle *tr = dynamic_cast<Triangle*>(f);
        if (tr) return (eq(a, tr->getA()) && eq(b, tr->getB()) && eq(c, tr->getC()));
        return false;
    }
    virtual ostream& print(ostream &out) {
        return out << "Треугольник со сторонами " << a << ", " << b << " и " << c << '\n';
    }
};

class EquilateralTriangle: virtual public RightPolygon, public Triangle { // равносторонний
private:
    ld side;
public:
    EquilateralTriangle() {}
    EquilateralTriangle(ld side): Figure(1), RightPolygon(side, 3), Triangle(side, side, side) {
        this->type = "Равносторонний треугольник";
        this->side = side;
    }
    EquilateralTriangle(const EquilateralTriangle &et): RightPolygon((const_cast<EquilateralTriangle&>(et)).getSide(), 3),
    Triangle((const_cast<EquilateralTriangle&>(et)).getSide(), (const_cast<EquilateralTriangle&>(et)).getSide(), (const_cast<EquilateralTriangle&>(et)).getSide()) {
        this->type = "Равносторонний треугольник";
        this->side = et.side;
    }
    ld getSide() {
        return side;
    }
    ld getArea() {
        return side * side * sqrt(3) / 4;
    }
    ld getPerimeter() {
        return side * 3;
    }
    bool operator == (Figure *f) {
        Triangle *tr = dynamic_cast<Triangle*>(f);
        if (tr) return (eq(a, tr->getA()) && eq(b, tr->getB()) && eq(c, tr->getC()));
        RightPolygon *rp = dynamic_cast<RightPolygon*>(f);
        if (rp) return (eq(side, rp->getSide()) && rp->getN() == 3);
        return false;
    }
    ostream& print(ostream &out) {
        return out << "Равносторонний треугольник со стороной " << side << '\n';
    }
};

class RightTriangle: public Triangle {
public:
    RightTriangle() {}
    RightTriangle(ld a, ld b): Figure(1), Triangle(a, b, sqrt(a * a + b * b)) {
        this->type = "Прямоугольный треугольник";
    }
    RightTriangle(const RightTriangle &rt) : Triangle(const_cast<RightTriangle&>(rt).getA(), const_cast<RightTriangle&>(rt).getB(),
                                                      sqrt(const_cast<RightTriangle&>(rt).getA() * const_cast<RightTriangle&>(rt).getA() +
                                                      const_cast<RightTriangle&>(rt).getB() * const_cast<RightTriangle&>(rt).getB())) {
        this->type = "Прямоугольный треугольник";
        this->a = rt.a;
        this->b = rt.b;
        this->c = rt.c;
    }
    ld getArea() {
        return (this->a * this->b) / 2;
    }
    ostream& print(ostream &out) {
        return out << "Прямоугольный треугольник с катетами " << a << " и " << b << " и гипотенузой " << c << '\n';
    }
};

class Circle: public Figure { // круг
private:
    ld rad; // радиус
public:
    Circle() {}
    Circle(ld rad): Figure(1) {
        this->type = "Круг";
        this->rad = rad;
    }
    Circle(const Circle &c) : Figure(1) {
        this->type = "Круг";
        this->rad = c.rad;
    }
    ld getRad() {
        return rad;
    }
    ld getArea() {
        return PI * rad * rad;
    }
    ld getPerimeter() {
        return 2 * PI * rad;
    }
    bool operator == (Figure *f) {
        Circle *c = dynamic_cast<Circle*>(f);
        if (c) return eq(rad, c->getRad());
        return false;
    }
    ostream& print(ostream &out) {
        return out << "Круг радиуса " << rad << '\n';
    }
};

struct node {
    Figure *x;
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
    void insertNode(node *elem, Figure *f) {
        node *nw = new node;
        nw->x = f;
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
    void pushItem(Figure *f) {
        node *nw = new node;
        nw->x = f;
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
    void deleteItem(Figure *f) {
        auto res = this->findItem(f);
        if (res) this->deleteNode(res);
    }

    // вставить элемент после другого элемента
    void insertItem(Figure *f1, Figure *f2) {
        auto res = this->findItem(f1);
        if (res) this->insertNode(res, f2);
    }

    // найти первое вхождение данного элемента в списке
    node *findItem(Figure *f) {
        node *p = head;
        while (p) {
            if ((*p->x) == f) return p;
            p = p->nxt;
        }
        return NULL;
    }

    // обратиться к элементу по индексу
    Figure* operator[](const int idx) {
        node *p = head;
        int i = 0;
        while (p != NULL) {
            if (i == idx) return p->x;
            p = p->nxt;
            i++;
        }
        return NULL;
    }

    // вывести список
    void print(ostream &out) {
        node *p = head;
        while (p != NULL) {
            (p->x)->print(out);
            p = p->nxt;
        }
        out << '\n';
    }
};

List v; // список фигур

Figure* create() { // создание фигуры
    cout << "Какую фигуру Вы хотите задать?" << '\n';
    cout << "1 - прямоугольник;" << '\n';
    cout << "2 - квадрат;" << '\n';
    cout << "3 - треугольник;" << '\n';
    cout << "4 - равносторонний треугольник;" << '\n';
    cout << "5 - прямоугольный треугольник;" << '\n';
    cout << "6 - правильный многоугольник;" << '\n';
    cout << "7 - точка;" << '\n';
    cout << "8 - круг." << '\n';
    int c;
    cin >> c;
    switch(c) {
        case 1: {
            cout << "Введите ширину и высоту: ";
            ld width, height;
            cin >> width >> height;
            return new Rectangle(width, height);
        }
        case 2: {
            cout << "Введите сторону: ";
            ld side;
            cin >> side;
            return new Square(side);
        }
        case 3: {
            cout << "Введите 3 стороны: ";
            ld a, b, c;
            cin >> a >> b >> c;
            return new Triangle(a, b, c);
        }
        case 4: {
            cout << "Введите сторону: ";
            ld side;
            cin >> side;
            return new EquilateralTriangle(side);
        }
        case 5: {
            cout << "Введите 2 катета: ";
            ld a, b;
            cin >> a >> b;
            return new RightTriangle(a, b);
        }
        case 6: {
            cout << "Введите длину стороны и их количество: ";
            ld side;
            int n;
            cin >> side >> n;
            return new RightPolygon(side, n);
        }
        case 7: {
            cout << "Введите x-координату и y-координату: ";
            ld x, y;
            cin >> x >> y;
            return new Point(x, y);
        }
        case 8: {
            cout << "Введите радиус: ";
            ld r;
            cin >> r;
            return new Circle(r);
        }
        default: {
            return new Figure(0);
        }
    }
}

int main() {
    while (true) {
        cout << "Что Вы хотите сделать?" << '\n';
        cout << "1 - добавить новый элемент в конец списка;" <<'\n';
        cout << "2 - удалить первое вхождение заданного элемента;" << '\n';
        cout << "3 - если в списке присутствует первый элемент, вставить после его первого вхождения второй;" << '\n';
        cout << "4 - вывести элемент по индексу;" << '\n';
        cout << "5 - найти периметр фигуры по индексу;" << '\n';
        cout << "6 - найти площадь фигуры по индексу;" << '\n';
        cout << "7 - выйти из программы." << '\n';
        int ch;
        cin >> ch;
        switch(ch) {
            case 1: {
                Figure *f = create();
                if (! f->getStatus()) {
                    cout << "Некорректная фигура!" << '\n';
                    break;
                }
                v.pushItem(f);
                break;
            }
            case 2: {
                Figure *f = create();
                if (! f->getStatus()) {
                    cout << "Некорректная фигура!" << '\n';
                    break;
                }
                v.deleteItem(f);
                break;
            }
            case 3: {
                cout << "Первая фигура:" << '\n';
                Figure *f1 = create();
                if (! f1->getStatus()) {
                    cout << "Некорректная фигура!" << '\n';
                    break;
                }
                cout << "Вторая фигура:" << '\n';
                Figure *f2 = create();
                if (! f2->getStatus()) {
                    cout << "Некорректная фигура!" << '\n';
                    break;
                }
                v.insertItem(f1, f2);
                break;
            }
            case 4: {
                cout << "Введите индекс: ";
                int idx;
                cin >> idx;
                auto res = v[idx];
                if (res) res->print(cout);
                else cout << "Элемента с таким индексом не существует!" << '\n';
                break;
            }
            case 5: {
                cout << "Введите индекс: ";
                int idx;
                cin >> idx;
                Figure *res = v[idx];
                if (res) cout << "Периметр равен " << (res->getPerimeter()) << '\n';
                else cout << "Элемента с таким индексом не существует!" << '\n';
                break;
            }
            case 6: {
                cout << "Введите индекс: ";
                int idx;
                cin >> idx;
                Figure *res = v[idx];
                if (res) cout << "Площадь равна " << (res->getArea()) << '\n';
                else cout << "Элемента с таким индексом не существует!" << '\n';
                break;
            }
            case 7: {
                cout << "До свидания!" << '\n';
                return 0;
            }
            default: {
                cout << "Некорректный выбор!" << '\n';
                break;
            }
        }
        cout << '\n';
        cout << "Список после выполнения операции:" << '\n';
        v.print(cout);
    }
}
