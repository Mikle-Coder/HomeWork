using System;
using System.Collections;

namespace AdditionTask
{
    class Program
    {
        static void Main()
        {
            SortedList<string, string> sortList = new SortedList<string, string>();
            SortedList<string, string> reverseSortList = new SortedList<string, string>(new DescendingComparer<string>());

            sortList["Банан"] = "Banana";
            sortList["Виноград"] = "Grape";
            sortList["Арбуз"] = "Watermelon";

            foreach(var entry in sortList)
                reverseSortList.Add(entry.Key, entry.Value);

            foreach (var entry in sortList)
                Console.WriteLine("{0} = {1}", entry.Key, entry.Value);

            Console.WriteLine(new string('-', 15));

            foreach (var entry in reverseSortList)
                Console.WriteLine("{0} = {1}", entry.Key, entry.Value);

            // Delay.
            Console.ReadKey();
        }
    }

    public class DescendingComparer<T> : IComparer<T>
    {
        CaseInsensitiveComparer comparer = new CaseInsensitiveComparer();

        public int Compare(T? x, T? y)
        {
            // Для сортировки по убыванию.
            // Объекты, переданные для сравнения, меняются местами.
            int result = comparer.Compare(y, x);
            return result;
        }
    }
}