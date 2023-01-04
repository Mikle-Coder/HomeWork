//Создайте пользовательский атрибут AccessLevelAttribute, позволяющий определить
//уровень доступа пользователя к системе. Сформируйте состав сотрудников некоторой фирмы
//в виде набора классов, например, Manager, Programmer, Director. При помощи атрибута
//AccessLevelAttribute распределите уровни доступа персонала и отобразите на экране
//реакцию системы на попытку каждого сотрудника получить доступ в защищенную секцию.

using System.Reflection;
using static AccessLevelAttribute;

namespace AdditionTask
{
    class Program
    {
        static void Main()
        {
            Programmer programmer = new Programmer();
            Manager manager = new Manager();
            Director director = new Director();

            GetAccess(programmer);
            GetAccess(manager);
            GetAccess(director);
        }

        static void GetAccess(Employee employee)
        {
            Type type = employee.GetType();
            AccessLevelAttribute attribute = type.GetCustomAttribute(typeof(AccessLevelAttribute), false) as AccessLevelAttribute;
            Console.WriteLine("Пользователь вошел в систему.\tДолжность: {0}\t Уровень доступа: {1}", employee.Post, attribute.AccessLevel);
        }
    }

    abstract class Employee
    {
        public abstract string Post { get;}
    }

    [AccessLevel(AccessLevelControl.LowControl)]
    class Programmer : Employee
    {
        public override string Post { get => "Программист"; }
    }

    [AccessLevel(AccessLevelControl.MediumControl)]
    class Manager : Employee
    {
        public override string Post { get => "Менеджер"; }
    }

    [AccessLevel(AccessLevelControl.FullControl)]
    class Director : Employee
    {
        public override string Post { get => "Директор"; }
    }
}
