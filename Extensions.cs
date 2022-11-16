using System;
using System.Collections.Generic;
using System.Linq;


namespace Exceptions
{
    class Program
    {
        static void Main()
        {
            //ShowStructWorkerWork();
            ShowStructPriceWork();
        }

        public static void ShowStructWorkerWork()
        {
            List<Worker> workerList = new List<Worker>();

            workerList.Add(new Worker("Милованов", "Михаил", "Игоревич", "Инженер по планирвоанию", 2021));
            workerList.Add(new Worker("Хачатрян", "Арам", "Граерович", "Инженер по планирвоанию", 2021));
            workerList.Add(new Worker("Дёмочкин", "Тимфоей", "Олегович", "Ведущий инженер по планирвоанию", 2020));
            workerList.Add(new Worker("Чистякова", "Виктория", "Геннадиевна", "Руководитель отдела планирования", 2020));

            workerList.Sort((a,b) => a.fullname.CompareTo(b.fullname));

            Random random = new Random();

            foreach (Worker worker in workerList)
            {
                Console.ForegroundColor = (ConsoleColor)random.Next(0, Enum.GetNames(typeof(ConsoleColor)).Length);

                Console.WriteLine("ФИО : " + worker.fullname);
                Console.WriteLine("Должность : " + worker.position);
                Console.WriteLine("Дата устройства : " + worker.yearOfEmployment);
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public static void ShowStructPriceWork()
        {
            List<Price> listPrice = new List<Price>();
            listPrice.Add(new Price() { article = "Смартфон", price = 10599.99, shop = "OZON" });
            listPrice.Add(new Price() { article = "Кружка", price = 700.99, shop = "OZON" });
            listPrice.Add(new Price() { article = "Компьютерная мышь", price = 3599.99, shop = "OZON" });
            listPrice.Add(new Price() { article = "Паприка", price = 49, shop = "Перекресток" });
            listPrice.Add(new Price() { article = "Картофель", price = 39, shop = "Перекресток" });
            listPrice.Add(new Price() { article = "Килька в банке", price = 99.99, shop = "Перекресток" });
            Price.ShowByShop(listPrice);
            //
            Console.Write("\nВведите название магазина: ");
            string searchShop = Console.ReadLine();
            Console.WriteLine();

            Price.ShowByShop(listPrice, searchShop);


            Console.ReadKey();
        }

        class Calculator
        {
            public static void ShowFunctionsWork()
            {
            Start:
                Console.WriteLine("Введите число a");
                double a = double.Parse(Console.ReadLine());

                Console.WriteLine("Введите число b");
                double b = double.Parse(Console.ReadLine());

                Console.WriteLine("Результаты вычислений:");

                Console.Write("Сумма : ");
                Console.WriteLine(Calculator.Addition(a, b));

                Console.Write("Разница : ");
                Console.WriteLine(Calculator.Subtraction(a, b));

                Console.Write("Умножение : ");
                Console.WriteLine(Calculator.Multipilcation(a, b));

                Console.Write("Деление : ");
                if (b == 0) { throw new DivideByZeroException("Нельзя делить на ноль, дубина"); }
                Console.WriteLine(Calculator.Division(a, b));

                // Delay.
                Console.ReadKey();

                goto Start;
            }
            public static double Addition(double a, double b) => a + b;
            public static double Subtraction(double a, double b) => a - b;
            public static double Multipilcation(double a, double b) => a * b;
            public static double Division(double a, double b) => a / b;
        }
        public struct Worker
        {
            private Person person { get; set; }
            public string fullname  {get => person.GetFullName();}
            public string position { get; set; }
            public int yearOfEmployment { get; set; }
            public Worker(string lastName, string firstName, string patronymic, string position, int yearOfEmployment)
            {
                this.person = new Person(firstName, lastName, patronymic);
                this.position = position;
                this.yearOfEmployment = yearOfEmployment;
            }

            public struct Person
            {
                private string firstName { get; set; }
                private string lastName { get; set; }
                private string patronymic { get; set; }

                public string GetFullName()
                {
                    return lastName + " " + firstName + " " + patronymic;
                }

                public Person(string firstName, string lastName, string patronymic)
                {
                    this.firstName = firstName;
                    this.lastName = lastName;
                    this.patronymic = patronymic;
                }

            }
        }

        public struct Price
        {
            public string article { get; set; }
            public string shop { get; set; }
            public double price { get; set; }

            public static void ShowByShop(List<Price> listPrice, string shop = null)
            {
                listPrice.Sort((a, b) => a.article.CompareTo(b.article));

                if (!(shop == null || listPrice.Any(item => item.shop == shop)))
                    throw new Exception("Такого магазина нет");

                Console.WriteLine(new string('-', 30 + 20 + 20 + 5));
                Console.WriteLine("|{0,-30}|{1,-20}|{2,-20}|", "Товар", "Цена", "Магазин");
                Console.WriteLine(new string('-', 30 + 20 + 20 + 5));
                foreach (Price item in listPrice.Where(_item => (shop == null || _item.shop == shop)))
                    Console.WriteLine("|{0,-30}|{1,-20}|{2,-20}|", item.article, item.price, item.shop);
                Console.WriteLine(new string('-', 30 + 20 + 20 + 5));
            }
        }
    }
}
