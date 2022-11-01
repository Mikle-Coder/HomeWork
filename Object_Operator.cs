using System;
using System.Runtime.CompilerServices;

// Прототип, (Prototype) — шаблон проектирования, порождающий объекты.

namespace Prototype
{
    public class Program
    {
        static void DrawLine() => Console.WriteLine(new string('-', 30));

        static void Main()
        {
            Point point = new Point("Точка", 1, 1);
            Point pointClone = point.Clone();
            Point pointDeepClone = point.DeepClone();

            Point.ShowPoints(point, pointClone, pointDeepClone);

            pointClone.Name = "Копия Точки";
            pointDeepClone.Name = "Полная копия Точки";

            pointClone.X = pointClone.Y = 2;
            pointDeepClone.X = pointDeepClone.Y = 3;

            Point.ShowPoints(point, pointClone, pointDeepClone);

            Console.WriteLine(point + " ++ \t" + ++point);
            Console.WriteLine(point + " -- \t" + --point);
            DrawLine();

            Console.WriteLine($"{point} += {point + point}");
            Console.WriteLine($"{point} -= {point - point}");
            Console.WriteLine($"{point} *= {point * point}");
            Console.WriteLine($"{point} /= {point / point}");
            DrawLine();

            Console.WriteLine($"{point} == {pointDeepClone} - " + (point == pointDeepClone));
            Console.WriteLine($"{point} != {pointDeepClone} - " + (point != pointDeepClone));
            Console.WriteLine($"{point} > {pointDeepClone} - " + (point > pointDeepClone));
            Console.WriteLine($"{point} < {pointDeepClone} - " + (point < pointDeepClone));
            Console.WriteLine($"{point} >= {pointDeepClone} - " + (point >= pointDeepClone));
            Console.WriteLine($"{point} <= {pointDeepClone} - " + (point <= pointDeepClone));
            DrawLine();

            int[] arrayPoint1 = { 1, 2 };
            Point pointArray1 = arrayPoint1;
            Console.WriteLine(pointArray1);

            Point pointArray2 = new Point("Массив из Точки", 20, 30);
            int[] arrayPoint2 = (int[])pointArray2;

            Console.WriteLine($"[{arrayPoint2[0]} {arrayPoint2[1]}]");
            // Задержка.
            Console.ReadKey();
        }

        class Point
        {
            static int Count;
            public Point(string name, int x, int y) :this()
            {
                X = x;
                Y = y;
                Name = name;
            }

            private Point() { Count++; point = new Point_(); }
            private class Point_ {public int x; public int y;}
            private Point_ point;
            public string Name { get; set; }

            public int X { get => point.x; set => point.x = value; }
            public int Y { get => point.y; set => point.y = value; }

            public Point Clone() => (Point)MemberwiseClone();
            public Point DeepClone() => new Point() {Name = Name, X = X, Y = Y};

            public override string ToString() => $"{Name} [x:{X}, y:{Y}]";

            public static void ShowPoints(params Point[] points)
            {
                foreach (Point point in points)
                    Console.WriteLine(point);
                DrawLine();
            }

            //Операторы сравнения
            public static bool operator < (Point point1, Point point2) => point1.X < point2.X && point1.Y < point2.Y;
            public static bool operator > (Point point1, Point point2) => point1.X > point2.X && point1.Y > point2.Y;

            public static bool operator <= (Point point1, Point point2) => point1.X <= point2.X && point1.Y <= point2.Y;
            public static bool operator >= (Point point1, Point point2) => point1.X >= point2.X && point1.Y >= point2.Y;

            public static bool operator == (Point point1, Point point2) => point1.X == point2.X && point1.Y == point2.Y;
            public static bool operator != (Point point1, Point point2) => point1.X != point2.X && point1.Y != point2.Y;

            //Тернарные операторы
            public static Point operator ++ (Point point) { point.X++; point.Y++; return point; }
            public static Point operator -- (Point point) { point.X--; point.Y--; return point; }

            //Математичсекие опреаторы
            public static Point operator + (Point point1, Point point2) => new Point("Новая точка " + (Count + 1), point1.X + point2.X, point1.Y + point2.Y);
            public static Point operator - (Point point1, Point point2) => new Point("Новая точка " + (Count + 1), point1.X - point2.X, point1.Y - point2.Y);
            public static Point operator / (Point point1, Point point2) => new Point("Новая точка " + (Count + 1), point1.X / point2.X, point1.Y / point2.Y);
            public static Point operator * (Point point1, Point point2) => new Point("Новая точка " + (Count + 1), point1.X * point2.X, point1.Y * point2.Y);

            //Операторы преобразования типа

                //Вспомогательный конструктор
                private Point(string Name, int[] arrayPoint) : this(Name, arrayPoint[0], arrayPoint[1])
                {

                }

                //Неявное преобразование
                public static implicit operator Point(int[] arrayPoint)
                {
                    return new Point("Точка из масиива", arrayPoint);
                }

                //Явное преобразование
                public static explicit operator int[](Point point) 
                {
                    return new int[] { point.X, point.Y };
                }

        }
    }
}
