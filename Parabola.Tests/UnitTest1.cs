using NUnit.Framework;
using Parabola.Tests;
using System;
using System.IO;
using static System.Collections.Specialized.BitVector32;

namespace Parabola.Tests
{
    public class UnitTest1
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        //1
        public void Check_values()
        {
            //Подготовка
            Parabola parabola = new Parabola();

            // Действие
            parabola.Init(2, -4, 4);

            //Проверка
            Assert.AreEqual(2, parabola.A);
            Assert.AreEqual(-4, parabola.B);
            Assert.AreEqual(4, parabola.C);
        }
        [Test]
        //2
        public void Check_VertexDistance()
        {
            //Подготовка
            Parabola parabola = new Parabola();
            parabola.Init(1, -2, 1); // (x - 1)^2 → Вершина (1, 0), расстояние = 1

            // Действие
            double distance = parabola.VertexDistance;

            //Проверка 
            Assert.AreEqual(1, distance);
        }
        [Test]
        //3
        public void Add_parabolas()
        {
            //Подготовка
            Parabola p1 = new Parabola();
            Parabola p2 = new Parabola();
            p1.Init(1, 2, 3);
            p2.Init(4, 5, 6);

            // Действие
            Parabola result = p1.Add(p1, p2);

            //Проверка 
            Assert.AreEqual(5, result.A);
            Assert.AreEqual(7, result.B);
            Assert.AreEqual(9, result.C);
        }
    }
}