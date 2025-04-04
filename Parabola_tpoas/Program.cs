﻿using System;

namespace Parabola
{
    public class ParabolaClass
    {
        public double a, b, c;

        // Метод инициализации
        public void Init(double a_val, double b_val, double c_val)
        {
            a = a_val;
            b = b_val;
            c = c_val;
        }

        // Метод для ввода данных
        public void Read()
        {
            Console.WriteLine("Введите коэффициенты для параболы");
            Console.Write("Введите a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите b: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите c: ");
            c = Convert.ToDouble(Console.ReadLine());
        }

        // Метод для отображения уравнения параболы
        public void Display()
        {
            Console.WriteLine($"Уравнение параболы: {a}x^2 + {b}x + {c}");
        }

        // Метод для вычисления расстояния от вершины параболы до начала координат
        public double VertexDistance()
        {
            double x_vertex = -b / (2 * a);
            double y_vertex = a * x_vertex * x_vertex + b * x_vertex + c;

            double distance = Math.Sqrt(x_vertex * x_vertex + y_vertex * y_vertex);

            return distance;
        }

        // Метод для сложения двух парабол
        public ParabolaClass Add(ParabolaClass one, ParabolaClass two)
        {
            ParabolaClass result = new ParabolaClass();
            result.a = one.a + two.a;
            result.b = one.b + two.b;
            result.c = one.c + two.c;
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание и инициализация объекта
            ParabolaClass p1 = new ParabolaClass();
            p1.Init(2, -4, 4);
            p1.Display();
            Console.WriteLine("Расстояние от вершины до начала координат: " + p1.VertexDistance());

            // Ввод с клавиатуры и работа с динамическим объектом
            ParabolaClass p2 = new ParabolaClass();
            p2.Read();
            p2.Display();
            Console.WriteLine("Расстояние от вершины до начала координат: " + p2.VertexDistance());

            // Сложение двух парабол
            ParabolaClass p3 = p1.Add(p2, p1);
            p3.Display();

            // Работа с динамическим массивом объектов
            Console.Write("Введите количество парабол в массиве: ");
            int n = Convert.ToInt32(Console.ReadLine());

            ParabolaClass[] array = new ParabolaClass[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = new ParabolaClass();
                Console.WriteLine($"Парабола {i + 1}:");
                array[i].Init(i + 1, -2 * i, i); // Пример инициализации
                array[i].Display();
                Console.WriteLine("Расстояние от вершины до начала координат: " + array[i].VertexDistance());
            }

            // Использование метода для сложения парабол
            for (int i = 0; i < n; i++)
            {
                array[i] = array[i].Add(array[0], array[i]); // Сложение с первой параболой
            }
        }
    }
}
