using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    internal class Program
    {
        static void Main()
        {
            CitizenCollection citizenCollection = new CitizenCollection();
            AddCitizens(citizenCollection);
            Student student = new Student("Арам", "Хачатрян");
            citizenCollection.Add(student);

            Console.WriteLine(citizenCollection);
            Console.WriteLine(new String('-', 40));

            Console.WriteLine();
            Console.WriteLine("Добавляем гражданина: " + student);
            citizenCollection.Add(student);
            Console.WriteLine(citizenCollection);
            Console.WriteLine(new String('-', 40));

            Console.WriteLine("Удаляем гражданина: " + student);
            citizenCollection.Remove(student);
            Console.WriteLine(citizenCollection);
            Console.WriteLine(new String('-', 40));

            Console.WriteLine("Удаляем первого гражданина");
            citizenCollection.Remove();
            Console.WriteLine(citizenCollection);
            Console.WriteLine(new String('-', 40));

            Console.WriteLine("Последний гражданин:\n" + citizenCollection.ReturnLast());
        }

        static void AddCitizens(CitizenCollection citizenCollection)
        {
            Console.WriteLine("Добавляем людей:");
            citizenCollection.Add(new Worker("Марк", "Богатырев"));
            Console.WriteLine(citizenCollection);
            citizenCollection.Add(new Worker("Павел", "Прилучный"));
            Console.WriteLine(citizenCollection);

            citizenCollection.Add(new Student("Михаил", "Милованов"));
            Console.WriteLine(citizenCollection);
            citizenCollection.Add(new Student("Юлия", "Пичулина"));
            Console.WriteLine(citizenCollection);

            citizenCollection.Add(new Pensioner("Григорий", "Лепс"));
            Console.WriteLine(citizenCollection);
            citizenCollection.Add(new Pensioner("Лариса", "Гузеева"));
            Console.WriteLine(citizenCollection);
        }
    }
}
