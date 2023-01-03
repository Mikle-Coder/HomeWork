//Создайте программу, в которой предоставьте пользователю доступ к сборке из Задания 2.
//Реализуйте использование метода конвертации значения температуры из шкалы Цельсия в
//шкалу Фаренгейта. Выполняя задание используйте только рефлексию.

using System.Reflection;

class Program
{
    static void Main()
    {
        Assembly assembly = Assembly.Load("Task_2");

        Type type = assembly.GetType("Task_2.Temperature");

        object instance = Activator.CreateInstance(type);

        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        object[] temperature = { 15 };

        Console.WriteLine(temperature[0] + " °C по °F равно " + methods[0].Invoke(instance, temperature));
    }
}