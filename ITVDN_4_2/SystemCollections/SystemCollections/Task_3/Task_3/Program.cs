//Задание : Несколькими способами создайте коллекцию, в которой можно хранить только целочисленные и
//вещественные значения, по типу «счет предприятия – доступная сумма» соответственно.

using System;
using System.Collections;

namespace Task_3
{
    class Program
    {
        static void Main()
        {

            Dictionary<int, double> dictionary = new Dictionary<int, double>(); //Первый способ

            SortedDictionary<int, double> sortedDictionary = new SortedDictionary<int, double>(); //Второй способ

            sortedDictionary[1191] = 98.68;
            sortedDictionary[2119] = 1033.33;
            sortedDictionary[1213] = 3123.33;
            sortedDictionary[1114] = 564.33;

            foreach(var item in sortedDictionary)
                Console.WriteLine("№ " + item.Key + " доступно: " + item.Value.ToString("C"));
        }
    }

}