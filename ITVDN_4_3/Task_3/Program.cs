//Напишите приложение для поиска заданного файла на диске. Добавьте код, использующий
//класс FileStream и позволяющий просматривать файл в текстовом окне. В заключение
//добавьте возможность сжатия найденного файла.

using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

class Pogram
{
    static void Main()
    {
        Console.WriteLine("Это программа по поиску файлов на компьютере");
        Console.Write("Введи название файла текстового формата (например file.txt):\t");

        Console.ForegroundColor = ConsoleColor.Blue;
        string fileName = Console.ReadLine();
        Console.ResetColor();

        FileInfo file = default;
        bool isFileExists = default;
        TimeSpan searchingTime = default;

        isFileExists = SearchFile(fileName, out file, out searchingTime);

        if(!isFileExists)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Файл {fileName} не найден");
            Console.ResetColor();
            return;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Файл {fileName} найден");
            Console.ResetColor();
        }

        Console.WriteLine("Путь :\t" + file.FullName);

        ShowFile(file);
        FileInfo zipFile = CompressFile(file);

        Console.Write($"Файл {file.Name} успешно сжат в ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(zipFile.Name);
        Console.ResetColor();
        Console.Write($" c путём");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\t{zipFile.FullName}");
        Console.ResetColor();
    }

    static FileInfo CompressFile(FileInfo file)
    {
        FileStream source = file.OpenRead();
        string newZipFilePath = file.FullName.Substring(0, file.FullName.Length - file.Extension.Length) + ".zip";
        FileInfo zipFile= new FileInfo(newZipFilePath);
        FileStream destination = File.Create(zipFile.FullName);

        GZipStream compressor = new GZipStream(destination, CompressionMode.Compress);

        int theByte = source.ReadByte();
        while (theByte != -1)
        {
            compressor.WriteByte((byte)theByte);
            theByte = source.ReadByte();
        }

        compressor.Close();
        return zipFile;
    }

    static void ShowFile(FileInfo file)
    {
        Console.WriteLine($"\nСодержимое файла {file.Name}:\n");
        StreamReader reader = file.OpenText();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(reader.ReadToEnd());
        Console.ResetColor();
        Console.WriteLine("\n");
        reader.Close();
    }

    static bool SearchFile(string fileName, out FileInfo outputFile, out TimeSpan searchingTime)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        DirectoryInfo directory = new DirectoryInfo("C:\\");

        outputFile = default;
        bool isFileExists = default;

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        isFileExists = SearchFileInDirectoryAndReturnExsists(directory, fileName, out outputFile);
        stopwatch.Stop();

        searchingTime = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);
        Console.ResetColor();

        Console.WriteLine("\n\n\n" + new string('-', 100) + "\n");

        return isFileExists;
    }

    static bool SearchFileInDirectoryAndReturnExsists(DirectoryInfo directory, string fileName, out FileInfo outputFile)
    {
        DirectoryInfo[] directiries = null;
        outputFile = default;
        try
        {
            directiries = directory.GetDirectories();
        }
            
        catch
        {
            return false;
        }

        FileInfo[] files = directory.GetFiles();

        foreach(FileInfo file in files)
            if(file.Name == fileName)
            {
                outputFile = file;
                return true;
            }

        foreach(DirectoryInfo dir in directiries)
        {
            Console.WriteLine("Проверка директории " + dir.FullName);
            if(SearchFileInDirectoryAndReturnExsists(dir, fileName, out outputFile))
            {
                return true;
            }
        }

        return false; 
    }
}