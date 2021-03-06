﻿namespace Area
{
    public class Point
    {
        private int x, y;

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

        public int cX
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int cY
        {
            get
            {
                return y;
            }
            set
            {
                x = value;
            }
        }
    }
}
