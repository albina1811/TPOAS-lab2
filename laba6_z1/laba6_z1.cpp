#include <iostream>
#include <cmath>
using namespace std;

class QuadraticFunction {
protected:
    double a, b, c; 

public:
    QuadraticFunction(double a_val = 0, double b_val = 0, double c_val = 0)
        : a(a_val), b(b_val), c(c_val) {
    }

    virtual void Display() {
        cout << "Квадратичная функция: " << a << "x^2 + " << b << "x + " << c << endl;
    }

    virtual double VertexDistance() = 0; // Чисто виртуальная функция
};

class Parabola : public QuadraticFunction {
public:
    Parabola(double a_val = 0, double b_val = 0, double c_val = 0)
        : QuadraticFunction(a_val, b_val, c_val) {
    }

    double VertexDistance() override {
        double x_vertex = -b / (2 * a); // Координата x вершины параболы
        double y_vertex = a * x_vertex * x_vertex + b * x_vertex + c; // Координата y вершины
        return sqrt(x_vertex * x_vertex + y_vertex * y_vertex); // Евклидово расстояние до начала координат
    }

    void Display() override {
        cout << "Уравнение параболы: " << a << "x^2 + " << b << "x + " << c << endl;
    }
};

class Ellipse : public QuadraticFunction {
private:
    double d;

public:
    Ellipse(double a_val, double b_val, double c_val, double d_val)
        : QuadraticFunction(a_val, b_val, c_val), d(d_val) {
    }

    double VertexDistance() override {
        return sqrt(a * a + b * b + c * c + d * d); // Евклидово расстояние
    }

    void Display() override {
        cout << "Уравнение эллипса: " << a << "x^2 + " << b << "y^2 + " << c << "x + " << d << endl;
    }
};

class Paraboloid : public Parabola {
private:
    double z; 

public:
    Paraboloid(double a_val = 0, double b_val = 0, double c_val = 0, double z_val = 0)
        : Parabola(a_val, b_val, c_val), z(z_val) {
    }
    double VertexDistance() override {
        double base_distance = Parabola::VertexDistance(); // Используем вычисленное расстояние для параболы
        return sqrt(base_distance * base_distance + z * z); // Добавляем влияние z-координаты
    }

    void Display() override {
        Parabola::Display(); // Вызываем метод базового класса
        cout << "Значение z (расстояние от плоскости XOY): " << z << endl;
    }
};

int main() {
    setlocale(LC_ALL, "rus"); 

    // Создаем объект параболы
    Parabola p(2, -4, 4);
    p.Display();
    cout << "Расстояние от вершины до начала координат (парабола): " << p.VertexDistance() << endl;

    // Создаем объект параболоида
    Paraboloid pb(1, -2, 3, 5);
    pb.Display();
    cout << "Расстояние от вершины до начала координат (параболоид): " << pb.VertexDistance() << endl;

    // Создаем объект эллипса
    Ellipse e(3, 2, -1, 4);
    e.Display();
    cout << "Расстояние от начала координат (эллипс): " << e.VertexDistance() << endl;

    return 0; 
}
