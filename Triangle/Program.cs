using System;
using System.Collections.Generic;

namespace Area
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle[] mass = new Triangle[7];

            Point p1_0 = new Point(0, 0);
            Point p2_0 = new Point(0, 3);
            Point p3_0 = new Point(4, 0);
            mass[0] = new Triangle(p1_0, p2_0, p3_0);

            Point p1_1 = new Point(1, 1);
            Point p2_1 = new Point(1, 3);
            Point p3_1 = new Point(3, 1);
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

            // Некорректный треугольник - точки лежат на одной прямой
            Point p1_5 = new Point(1, 2);
            Point p2_5 = new Point(2, 4);
            Point p3_5 = new Point(3, 6);
            mass[5] = new Triangle(p1_5, p2_5, p3_5);

            // Корректно вычисляет площадь, если точки имеют отрицательные координаты
            Point p1_6 = new Point(-1, -1);
            Point p2_6 = new Point(-1, -3);
            Point p3_6 = new Point(-3, -1);
            mass[6] = new Triangle(p1_6, p2_6, p3_6);

            var dictionary = new Dictionary<int, double>();
            double middle_per = 0;

            var dictionary_2 = new Dictionary<int, double>();
            double middle_area = 0;

            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i].Right() == 1)
                {
                    dictionary.Add(i, mass[i].Perimetr());
                }


            }

            for (int i = 0; i < mass.Length; i++)
            {

                if (mass[i].Isosceles() == 1)
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

            Console.WriteLine("Cоздано " + mass.Length + " треугольников");
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
