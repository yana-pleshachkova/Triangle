using System;

namespace Area
{
    class Triangle
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
}
