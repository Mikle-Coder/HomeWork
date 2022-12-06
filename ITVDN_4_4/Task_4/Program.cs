//Создайте текстовый файл-чек по типу «Наименование товара – 0.00 (цена) руб.» с
//определенным количеством наименований товаров и датой совершения покупки. Выведите на
//экран информацию из чека в формате текущей локали пользователя и в формате локали en-
//US.

using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using static Receipt;

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Receipt receipt = CreateReceipt();
        FileInfo file = receipt.CreateReceiptTextFile();

        var my = CultureInfo.CurrentCulture;
        var us = new CultureInfo("en-US");

        string sentence = File.ReadAllText(file.FullName);
        Console.WriteLine(sentence);

        Console.WriteLine(new string('-', 25));

        string sentenceMy = Regex.Replace(sentence, @"[0-9]+[.,][0-9]+ руб\.", (m) => double.Parse(m.Value.Substring(0, m.Value.Length - 5).Replace('.', ',')).ToString("C", my));
        Console.WriteLine(sentenceMy);
        
        Console.WriteLine(new string('-', 25));

        string sentenceUs = Regex.Replace(sentence, @"[0-9]+[.,][0-9]+ руб\.", (m) => double.Parse(m.Value.Substring(0, m.Value.Length - 5).Replace('.', ',')).ToString("C", us));
        Console.WriteLine(sentenceUs);
    }

    static Receipt CreateReceipt()
    {
        List<Product> positions = new List<Product>();
        positions.Add(new Product("Кекс шоколадный", 59.99, 2));
        positions.Add(new Product("Кекс ванильный", 49.99, 1));
        positions.Add(new Product("Кекс фисташковый", 49.99, 4));

        return new Receipt(positions, DateTime.Now);
    }
}

public class Receipt
{
    private DateTime Date;
    private List<Product> Positions;

    public Receipt(List<Product> positions, DateTime date)
    {
        Positions = positions;
        Date = date;
    }

    public FileInfo CreateReceiptTextFile()
    {
        FileInfo file = new FileInfo("Чек.txt");
        StreamWriter writer = new StreamWriter(file.OpenWrite());
        writer.WriteLine($"\tЧек от {Date}");
        foreach (Product p in Positions)
            writer.WriteLine($"{p.Name, -22} - {p.Count}\t|{p.Price} руб.|");
        writer.Close();
        return file;
    }
}

public class Product
{
    public Product(string name, double price, int count)
    {
        Name = name;
        Price = price;
        Count = count;
    }
    public string Name;
    public double Price;
    public int Count;
}
