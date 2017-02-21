using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication48
{
    public class Point
    {
        public int x, y;

        // constructor
        public Point() //объекты класса Point будут иметь две координаты, по умолчанию (0;0)
        {
            x = 0;
            y = 0;
        }

        public Point(int k, int l) //объекты класса Point будут иметь две координаты, по умолчанию (0;0)
        {
            x = k;
            y = l;
        }
    }

    public class Edge
    {
        public Point a, b;

        public Edge() //объекты класса Edge будут состоять из двух объектов класса Point
        {
            a = null;
            b = null;
        }

        public Edge(Point k, Point n) //объекты класса Edge будут состоять из двух объектов класса Point
        {
            a = k; //
            b = n;
        }

        public static double lengthEdge(Point a, Point b)
        {
            double s = Math.Sqrt(Math.Pow((b.x - a.x), 2) + Math.Pow((b.y - a.y), 2));

            return s;
        }
    }

    public class Triangle
    {
        public Point s, m, l;

        public Triangle(Point ss, Point mm, Point ll) //объекты класса Triangle будут состоять из трех объектов класса Point
        {
            s = ss;
            m = mm;
            l = ll;

        }

        public override string ToString()
        {
            return String.Format("s({0}, {1}), m({2}, {3}), l({4}, {5})", s.x, s.y, m.x, m.y, l.x, l.y);
        }

        public double Perimetr()
        {
            double a = Edge.lengthEdge(s, m);
            double b = Edge.lengthEdge(s, l);
            double c = Edge.lengthEdge(m, l);

            double per = a + b + c;

            return per;
        }

        public double Area()
        {
            double a = Edge.lengthEdge(s, m);
            double b = Edge.lengthEdge(s, l);
            double c = Edge.lengthEdge(m, l);

            double d = this.Perimetr() / 2;

            double ar = Math.Sqrt(d * (d - a) * (d - b) * (d - c));

            return ar;
        }

        public bool Right()
        {
            double a = Math.Round(Math.Pow(Edge.lengthEdge(s, m), 2));
            double b = Math.Round(Math.Pow(Edge.lengthEdge(s, l), 2));
            double c = Math.Round(Math.Pow(Edge.lengthEdge(m, l), 2));

            if ((a == (b + c)) || (b == (a + c)) || (c == (a + b)))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Isosceles()
        {
            double a = Edge.lengthEdge(s, m);
            double b = Edge.lengthEdge(s, l);
            double c = Edge.lengthEdge(m, l);

            if ((a == b) || (b == c) || (c == a))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Triangle[] mass = new Triangle[5];

            Point p1_0 = new Point(0, 0);
            Point p2_0 = new Point(0, 3);
            Point p3_0 = new Point(4, 0);
            mass[0] = new Triangle(p1_0, p2_0, p3_0);

            Point p1_1 = new Point(0, 0);
            Point p2_1 = new Point(0, 3);
            Point p3_1 = new Point(3, 0);
            mass[1] = new Triangle(p1_1, p2_1, p3_1);

            Point p1_2 = new Point(0, 0);
            Point p2_2 = new Point(0, 8);
            Point p3_2 = new Point(8, 0);
            mass[2] = new Triangle(p1_2, p2_2, p3_2);

            Point p1_3 = new Point(1, 1);
            Point p2_3 = new Point(2, 2);
            Point p3_3 = new Point(3, 4);
            mass[3] = new Triangle(p1_3, p2_3, p3_3);

            Point p1_4 = new Point(0, 0);
            Point p2_4 = new Point(2, 2);
            Point p3_4 = new Point(5, 3);
            mass[4] = new Triangle(p1_4, p2_4, p3_4);

            var dictionary = new Dictionary<int, double>();
            double middle_per = 0;

            var dictionary_2 = new Dictionary<int, double>();
            double middle_area = 0;

            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i].Right())
                {
                    dictionary.Add(i, mass[i].Perimetr());
                }


            }

            for (int i = 0; i < mass.Length; i++)
            {

                if (mass[i].Isosceles())
                {
                    dictionary_2.Add(i, mass[i].Area());
                }
            }

            foreach (var obj in dictionary)
            {
                middle_per += obj.Value;
            }

            foreach (var obj in dictionary_2)
            {
                middle_area += obj.Value;
            }

            middle_per = middle_per / dictionary.Count;
            middle_area = middle_area / dictionary_2.Count;

            Console.WriteLine("Cоздано 5 треугольников");
            for (int i = 0; i < mass.Length; i++)
            {
                Console.WriteLine("Треугольник под номером " + i + " = " + mass[i].ToString());
            }

            Console.WriteLine("Прямоугольных треугольников: " + dictionary.Count);
            foreach (var obj in dictionary)
            {
                Console.WriteLine("Тругольник номер " + obj.Key + " = " + mass[obj.Key].ToString() + " с периметром " + obj.Value);
            }

            Console.WriteLine("Средний периметр прямоугольных треугольников " + middle_per);

            Console.WriteLine("_____________________________________________________________");

            Console.WriteLine("Равнобедренных треугольников: " + dictionary_2.Count);
            foreach (var obj in dictionary_2)
            {
                Console.WriteLine("Тругольник номер " + obj.Key + " = " + mass[obj.Key].ToString() + " с площадью " + obj.Value);
            }

            Console.WriteLine("Средняя площадь равнобедренных треугольников " + middle_area);

            Console.WriteLine("Для выхода нажмите клавишу...");
            Console.ReadKey();
        }
    }
}
