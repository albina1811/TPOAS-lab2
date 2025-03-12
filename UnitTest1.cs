using Parabola;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        //1
        public void Check_values()
        {
            // Подготовка
            ParabolaClass parabola = new ParabolaClass();

            // Действие
            parabola.Init(2, -4, 4);

            // Проверка
            Assert.AreEqual(2, parabola.a);
            Assert.AreEqual(-4, parabola.b);
            Assert.AreEqual(4, parabola.c);
        }
        [Test]
        //2
        public void Check_VertexDistance() // Проверка корректного подсчета расстояния
        {
            // Подготовка
            ParabolaClass parabola = new ParabolaClass();
            parabola.Init(1, -2, 1); // (x - 1)^2 -> вершина (1, 0), расстояние = 1

            // Действие
            double distance = parabola.VertexDistance();

            // Проверка 
            Assert.AreEqual(1, distance);
        }
        [Test]
        //3
        public void Add_parabolas() // Проверка корректного сложения парабол
        {
            // Подготовка
            ParabolaClass p1 = new ParabolaClass();
            ParabolaClass p2 = new ParabolaClass();
            p1.Init(1, 2, 3);
            p2.Init(4, 5, 6);

            // Действие
            ParabolaClass result = p1.Add(p1, p2);

            // Проверка 
            Assert.AreEqual(5, result.a);
            Assert.AreEqual(7, result.b);
            Assert.AreEqual(9, result.c);
        }
        [Test]
        //4
        public void Add_negativeCof() // Проверка корректного сложения парабол с отрицательными коэффициентами
        {
            // Подготовка
            ParabolaClass p1 = new ParabolaClass();
            ParabolaClass p2 = new ParabolaClass();
            p1.Init(-2, -3, -4);
            p2.Init(-1, -5, -6);

            // Действие
            ParabolaClass result = p1.Add(p1, p2);

            // Проверка
            Assert.AreEqual(-3, result.a);
            Assert.AreEqual(-8, result.b);
            Assert.AreEqual(-10, result.c);
        }
        [Test]
        //5
        public void VertexDistance_ZeroC() // Проверка корректного подсчета расстояния при с=0
        {
            // Подготовка
            ParabolaClass parabola = new ParabolaClass();
            parabola.Init(1, -4, 0); // Вершина x = 2, y = -4 -> расстояние = 4.47

            // Действие 
            double distance = parabola.VertexDistance();

            // Проверка
            Assert.AreEqual(Math.Sqrt(20), distance, 0.01);
        }
        [Test]
        //6
        public void VertexDistance_ZeroB() // Проверка корректного подсчета расстояния при b=0
        {
            // Подготовка
            ParabolaClass parabola = new ParabolaClass();
            parabola.Init(2, 0, 5); // Вершина x = 0, y = 5 -> расстояние = 5

            // Действие 
            double distance = parabola.VertexDistance();

            // Проверка
            Assert.AreEqual(5, distance);
        }
        [Test]
        //7
        public void Init_ZeroA() //Проверка верной инициализации при a=0
        {
            // Подготовка
            ParabolaClass parabola = new ParabolaClass();

            // Действие
            parabola.Init(0, 3, 5); 

            // Проверка
            Assert.AreEqual(0, parabola.a);
            Assert.AreEqual(3, parabola.b);
            Assert.AreEqual(5, parabola.c);
        }
        [Test]
        //8
        public void Add_NullCof() // Проверка корректного сложения парабол с нулевыми коэффициентами
        {
            // Подготовка
            ParabolaClass p1 = new ParabolaClass();
            ParabolaClass p2 = new ParabolaClass();
            p1.Init(0, 0, 0);
            p2.Init(0, 0, 0);

            // Дейсвтие
            ParabolaClass result = p1.Add(p1, p2);

            // Проверка
            Assert.AreEqual(0, result.a);
            Assert.AreEqual(0, result.b);
            Assert.AreEqual(0, result.c);
        }
        [Test]
        //9
        public void Dispay_equation()
        {
            // Подготовка
            ParabolaClass parabola = new ParabolaClass();
            parabola.Init(2, -3, 5);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Действие
                parabola.Display();

                // Проверка
                string expectedOutput = "Уравнение параболы: 2x^2 + -3x + 5\r\n";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

        [Test]
        //10
        public void Check_Array_() // Проверка работы с массивом парабол
        {
             // Подготовка
             ParabolaClass[] parabolas = new ParabolaClass[3];

             parabolas[0] = new ParabolaClass();
             parabolas[0].Init(1, -2, 1); // Вершина (1, 0) -> расстояние = 1

             parabolas[1] = new ParabolaClass();
             parabolas[1].Init(2, -4, 2); // Вершина (1, 0) -> расстояние = 1

             parabolas[2] = new ParabolaClass();
             parabolas[2].Init(1, 0, -1); // Вершина (0, -1) -> расстояние = 1

             // Действие
             double[] distances = new double[3];
            for (int i = 0; i < parabolas.Length; i++)
            {
                distances[i] = parabolas[i].VertexDistance();
            }

             // Проверка
              Assert.AreEqual(1, distances[0]);
              Assert.AreEqual(1, distances[1]);
              Assert.AreEqual(1, distances[2]);
        }
    }
}