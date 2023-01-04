//Создайте класс, поддерживающий сериализацию. Выполните сериализацию объекта этого
//класса в формате XML. Сначала используйте формат по умолчанию, а затем измените его
//таким образом, чтобы значения полей сохранились в виде атрибутов элементов XML.

using System.Xml.Serialization;

public class Task_2
{
    static void Main()
    {
        SerializableClass instance = new SerializableClass() { Id = 999, Name = "Original" };
        SerializableXMLClass instanceXML = new SerializableXMLClass() { Id = 123, Name = "WithXMLAttrinutes" };
        XMLSerialization(instance);
        XMLSerialization(instanceXML);
    }

    public static string XMLSerialization<T>(T instance)
    {
        Type type = instance.GetType();
        
        string filepath = type.Name + ".xml";
        FileStream stream = File.Create(filepath);
        XmlSerializer xmlSerializer = new XmlSerializer(type);
        xmlSerializer.Serialize(stream, instance);
        stream.Close();
        Console.WriteLine("File {0} is serialized.", filepath);
        return filepath;
    }


}


public class SerializableClass
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class SerializableXMLClass
{
    [XmlAttribute]
    public int Id { get; set; }
    [XmlAttribute]
    public string Name { get; set; }
}