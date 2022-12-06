//Напишите шуточную программу «Дешифратор», которая бы в текстовом файле могла бы
//заменить все предлоги на слово «ГАВ!».

using System.IO;
using System.Text.RegularExpressions;
using System.Text;

class Program
{
    static void Main()
    {
        FileInfo file = CreateTextFile(null);
        string text = File.ReadAllText(file.FullName, Encoding.Unicode);
        Console.WriteLine("Исходный текст:\n" + text);

        Console.WriteLine("\n" + new string('-', 80) + "\n");

        string encryptedText = Regex.Replace(text, @"\s?\b[а-я]{1,3}\b[\s.]?", " ГАВ! ");
        Console.WriteLine($"Зашифрованный текст:\n{encryptedText}");
        CreateTextFile(encryptedText);
        
        Console.ReadKey();
    }

    static FileInfo CreateTextFile(string? text)
    {
        string fileName = "NewText.txt";
        if (text is null)
        {
            text = "Язык C# появился на свет в июне 2000 г. в результате кропотливой работы большой группы разработчиков компании Microsoft, возглавляемой Андерсом Хейлсбергом (Anders Hejlsberg). Этот человек известен как автор одного из первых компилируемых языков программирования для персональных компьютеров IBM -- Turbo Pascal. Наверное, на территории бывшего Советского Союза многие разработчики со стажем, да и просто люди, обучавшиеся в той или иной форме программированию в вузах, испытали на себе очарование и удобство использования этого продукта. Кроме того, во время работы в корпорации Borland Андерс Хейлсберг прославился созданием интегрированной среды Delphi (он руководил этим проектом вплоть до выхода версии 4.0).";
            fileName = "Text.txt";
        }

        FileInfo file = new FileInfo(fileName);
        File.WriteAllText(file.FullName, text, Encoding.Unicode);
        return file;
    }
}