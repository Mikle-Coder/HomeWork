//Создайте пользовательский тип (например, класс) и выполните сериализацию объекта этого
//типа, учитывая тот факт, что состояние объекта необходимо будет передать по сети.

using System.Runtime.Serialization.Formatters.Soap;

class Program
{
    public static void Main()
    {
        SerializableClass instance = new SerializableClass() { Id = 999, Name = "First" };
        SOAPSerialization(instance);
    }

    public static void SOAPSerialization(SerializableClass instance)
    {
        SoapFormatter formater = new SoapFormatter();
        FileStream stream = File.Create("CarData.xml");
        formater.Serialize(stream, instance);
        stream.Close();
    }
}

[Serializable]
public class SerializableClass
{
    public int Id { get; set; }
    public string Name { get; set; }
}