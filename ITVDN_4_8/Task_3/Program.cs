//Создайте новое приложение, в котором выполните десериализацию объекта из предыдущего
//примера. Отобразите состояние объекта на экране.

using System.Xml;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        SerializableClass instance = new SerializableClass() { Id = 999, Name = "Original" };
        SerializableXMLClass instanceXML = new SerializableXMLClass() { Id = 123, Name = "WithXMLAttributes" };

        string instance_path = Task_2.XMLSerialization(instance);
        string instanceXML_path = Task_2.XMLSerialization(instanceXML);

        XmlSerializer serializer = new XmlSerializer(typeof(SerializableClass));
        FileStream original = new FileStream(instance_path, FileMode.Open, FileAccess.Read);
        SerializableClass instance_Deser = (SerializableClass)serializer.Deserialize(original);
        original.Close();
        Console.WriteLine(instance_Deser.Name + " " + instance_Deser.Id);

        serializer = new XmlSerializer(typeof(SerializableXMLClass));
        original = new FileStream(instanceXML_path, FileMode.Open, FileAccess.Read);
        SerializableXMLClass instanceXML_Deser = (SerializableXMLClass)serializer.Deserialize(original);
        Console.WriteLine(instanceXML_Deser.Name + " " + instanceXML_Deser.Id);
        original.Close();
    }
}