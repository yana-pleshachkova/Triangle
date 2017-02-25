using System;

namespace Area
{
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
}
