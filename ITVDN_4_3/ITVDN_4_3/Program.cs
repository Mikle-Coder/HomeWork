//  Создайте на диске 100 директорий с именами от Folder_0 до Folder_99, затем удалите их
using System.IO;

class Program
{
    static void Main()
    {
        List<DirectoryInfo> directories = new List<DirectoryInfo>();
        for (int i = 0; i < 100; i++)
            directories.Add(Directory.CreateDirectory(@".\Folder_" + i));

        Console.WriteLine("Директории созданы");
        Console.ReadKey();
        
        foreach(DirectoryInfo d in directories)
            d.Delete();

        Console.WriteLine("Директории удалены");
    }
}