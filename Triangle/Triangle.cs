using System;

namespace Area
{
    class Triangle
    {
        public Point s, m, l;

        public Triangle(Point p1, Point p2, Point p3) //объекты класса Triangle будут состоять из трех объектов класса Point
        {
            if ((p3.cX - p1.cX) * (p2.cY - p1.cY) == (p2.cX - p1.cX) * (p3.cY - p1.cY))
            {
                s = null;
                m = null;
                l = null;
            }
            else
            {
                s = p1;
                m = p2;
                l = p3;
            }
        }

        public override string ToString()
        {
            if (s == null || m == null || l == null)
            {
                return String.Format("Incorrect tringle");
            }

            return String.Format("s({0}, {1}), m({2}, {3}), l({4}, {5})", s.cX, s.cY, m.cX, m.cY, l.cX, l.cY);
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

            double ar = Math.Sqrt(Math.Abs(d * (d - a) * (d - b) * (d - c))); // Вычисление площади по формуле Герона, берем по модулю, т.к. точки могут быть с отрицательными координатами

            return ar;
        }

        public int Right()
        {
            if (s == null || m == null || l == null)
            {
                return -1; // Не корректный треугольник - точки лежат на 1 прямой
            }

            double a = Math.Round(Math.Pow(Edge.lengthEdge(s, m), 2));
            double b = Math.Round(Math.Pow(Edge.lengthEdge(s, l), 2));
            double c = Math.Round(Math.Pow(Edge.lengthEdge(m, l), 2));

            if ((a == (b + c)) || (b == (a + c)) || (c == (a + b)))
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public int Isosceles()
        {
            if (s == null || m == null || l == null)
            {
                return -1; // Не корректный треугольник - точки лежат на 1 прямой
            }

            double a = Edge.lengthEdge(s, m);
            double b = Edge.lengthEdge(s, l);
            double c = Edge.lengthEdge(m, l);

            if ((a == b) || (b == c) || (c == a))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
