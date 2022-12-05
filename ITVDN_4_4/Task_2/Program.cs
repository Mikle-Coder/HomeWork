//Напишите программу, которая бы позволила вам по указанному адресу web-страницы
//выбирать все ссылки на другие страницы, номера телефонов, почтовые адреса и сохраняла
//полученный результат в файл.

using System.Net;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Введите адрес сайта для проверки: ");
        string url = Console.ReadLine();
        string responseFromServer = GetResponseFromServer(url);

        string filepath = "result.txt";
        StreamWriter writer = new StreamWriter(filepath);
        WriteAllLinks(writer, responseFromServer);
        WriteAllEmails(writer, responseFromServer);
        WriteAllPhones(writer, responseFromServer);
        writer.Close();

        StreamReader reader = new StreamReader(filepath);
        Console.WriteLine(reader.ReadToEnd());
        reader.Close();
        Console.ReadKey();
    }

    static string GetResponseFromServer(string url)
    {
        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        Console.WriteLine("Ответ: " + ((HttpWebResponse)response).StatusDescription);
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        reader.Close();
        response.Close();

        return responseFromServer;
    }

    static void WriteAllLinks(StreamWriter writer, string responseFromServer)
    {
        Regex linkRegex = new Regex("href=['\"](?<link>http\\S+)['\"]");
        MatchCollection matches = linkRegex.Matches(responseFromServer);
        if (matches.Count > 0)
        {
            writer.WriteLine(new string('-', 20));
            foreach (Match match in matches)
                writer.WriteLine("Ссылка: " + match.Groups["link"].Value);
        }
    }

    static void WriteAllEmails(StreamWriter writer, string responseFromServer)
    {
        Regex emailRegex = new Regex(@"(?<email>[0-9A-z_.-]+@[0-9A-z-_]+(\.com|\.ru))");
        MatchCollection matches = emailRegex.Matches(responseFromServer);
        if (matches.Count > 0)
        {
            writer.WriteLine(new string('-', 20));
            foreach (Match match in matches)
                writer.WriteLine("Почта: " + match.Groups["email"].Value);
        }
    }

    static void WriteAllPhones(StreamWriter writer, string responseFromServer)
    {
        Regex phoneRegex = new Regex(@">(?<phone>\+?\d[-\s]?\(?\d{3}\)?[-\s]?\d{3}[-\s]?\d{2}[-\s]?\d{2})<");
        MatchCollection matches = phoneRegex.Matches(responseFromServer);
        if(matches.Count > 0)
        {
            writer.WriteLine(new string('-', 20));
            foreach (Match match in matches)
                writer.WriteLine("Телефон: " + match.Groups["phone"].Value);
        }
    }
}