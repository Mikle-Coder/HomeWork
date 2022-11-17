//Создайте коллекцию типа OrderedDictionary и реализуйте в ней возможность сравнения значений ключей.

using System.Collections;
using System.Collections.Specialized;

namespace Task_04
{
    class Entry
    {
        public int Key;
        public int Value;

        public override string ToString() => $"K:{Key}\tV:{Value}";
    }
    class Program
    {
        static void Main()
        {
            OrderedDictionary orderedDictionary = new OrderedDictionary(new EntryComparer());

            Entry entry1 = new Entry() { Key = 10, Value = 2};
            Entry entry2 = new Entry() { Key = 11, Value = 3};
            Entry entry3 = new Entry() { Key = 12, Value = 9};
            Entry entry4 = new Entry() { Key = 13, Value = 9};

            Console.WriteLine(entry1);
            Console.WriteLine(entry2);
            Console.WriteLine(entry3);
            Console.WriteLine(entry4);
            Console.WriteLine();

            orderedDictionary.Add(entry1, "Entry1");
            orderedDictionary.Add(entry2, "Entry2");
            orderedDictionary.Add(entry3, "Entry3");

            string message = "Элемент Entry4 эквивалентен Entry3 по Value, поэтому его нельзя добавить в словарь";

            try
            {
                orderedDictionary.Add(entry4, "Entry4");
            }

            catch
            {
                Console.WriteLine(message);
            }

            Console.WriteLine(new String('-', message.Length));

            foreach (DictionaryEntry item in orderedDictionary)
                Console.WriteLine(item.Value + "\t" + item.Key);
        }
    }

    class EntryComparer : IEqualityComparer
    {
        public new bool Equals(object? x, object? y)
        {
            Entry entryX = x as Entry;
            Entry entryY = y as Entry;

            return entryX.Value == entryY.Value;
        }

        public int GetHashCode(object obj)
        {
            Entry entry = obj as Entry;
            return entry.Value;
        }
    }
}