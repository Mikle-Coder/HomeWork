//  Создайте файл, запишите в него произвольные данные и закройте файл. Затем снова откройте
//  этот файл, прочитайте из него данные и выведете их на консоль.
using System.IO;

class Program
{
    static void Main()
    {
        FileInfo file = new FileInfo("NewFile.txt");
        StreamWriter streamWriter = file.CreateText();
        

        streamWriter.WriteLine("I add new Line1");
        streamWriter.Write(streamWriter.NewLine);
        streamWriter.WriteLine("I add new Line3");

        streamWriter.Close();

        StreamReader streamReader = new StreamReader(file.FullName);

        while(true)
        {
            string line = streamReader.ReadLine();
            if (line != null)
                Console.WriteLine(line);
            else
                break;
        }

        streamReader.Close();
    }
}