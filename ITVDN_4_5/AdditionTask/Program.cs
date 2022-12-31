//Создайте.xml файл, который соответствовал бы следующим требованиям:
// имя файла: TelephoneBook.xml
// корневой элемент: “MyContacts”
// тег “Contact”, и в нем должно быть записано имя контакта и атрибут “TelephoneNumber”
//со значением номера телефона.
//Создайте приложение, которое выводит на экран всю информацию об указанном .xml файле.
//Задание 3
//Из файла TelephoneBook.xml (файл должен был быть создан в процессе выполнения
//дополнительного задания) выведите на экран только номера телефонов.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdditionTask
{
    class Program
    {
        static  void Main()
        {
            string filepath = "TelephoneBook.xml";
            CreateXMLFile(filepath);
            ShowXMLFile(filepath);
            Console.WriteLine(new string('-', 20));
            ShowOnlyPhoneNumbers(filepath);
        }

        static void CreateXMLFile(string filepath)
        {
            var xmlWriter = XmlWriter.Create(filepath);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("MyContacts");
            xmlWriter.WriteStartElement("Contact");
            xmlWriter.WriteStartAttribute("TelephoneNumber");
            xmlWriter.WriteString("89774555216");
            xmlWriter.WriteEndAttribute();
            xmlWriter.WriteString("Вася Пупкин");

            //Закрываются сами автоматически при создании нового элемента или закрытии файла, можно и без нижних строчек
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Close();
        }

        static void ShowXMLFile(string filepath)
        {
            XmlReader xmlReader = XmlReader.Create(filepath);

            while (xmlReader.Read())
            {
                Console.WriteLine("NodeType: {0,-15}| Name: {1,-15}| Value: {2,-30}| Attribute: {3,-15}",
                                xmlReader.NodeType,
                                xmlReader.Name,
                                xmlReader.Value,
                                xmlReader.HasAttributes ? xmlReader.GetAttribute(0) : "");
                
            }

            xmlReader.Close();
        }

        static void ShowOnlyPhoneNumbers(string filepatch)
        {
            XmlReader xmlReader= XmlReader.Create(filepatch);

            while (xmlReader.Read())
                if (xmlReader.GetAttribute("TelephoneNumber") != null)
                    Console.WriteLine("Номер телефона: {0}", xmlReader.GetAttribute("TelephoneNumber"));


            xmlReader.Close();
        }
    }
}
