//Напишите консольное приложение, позволяющие пользователю зарегистрироваться под
//«Логином», состоящем только из символов латинского алфавита, и пароля, состоящего из
//цифр и символов.
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string loginPattern = @"^[A-z]+$";
        string passwordPattern = @"^[^A-я]+$";
        Console.WriteLine("Добро пожаловать на регистрацию!\n");

    Login:
        Console.ResetColor();
        Console.WriteLine("Введите ниже свой ЛОГИН. Используйте только латинские буквы:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string login = Console.ReadLine();

        if(!Regex.IsMatch(login, loginPattern))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nНужно вводить только латинские буквы!\n\n");
            goto Login;
        }

    Password:
        Console.ResetColor();
        Console.WriteLine("Введите ниже свой ПАРОЛЬ. Используйте только символы и цифры:");
        Console.ForegroundColor= ConsoleColor.Yellow;
        string password = Console.ReadLine();

        if (!Regex.IsMatch(password, passwordPattern))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nНужно вводить только символы и цифры!\n\n");
            goto Password;
        }

        Console.ResetColor();
        Console.WriteLine("\n\n\tПоздравляем с регистрацией!");
        Console.WriteLine($"Ваш логин\t{login}");
        Console.WriteLine($"Ваш парооль\t{password}");
    }

}