//Создайте свою пользовательскую сборку по примеру сборки CarLibrary из урока, сборка будет
//использоваться для работы с конвертером температуры.

namespace Task_2
{
    internal class Temperature
    {
        private double ConvertCelsiusToFahrenheit(double temperature)
        {
            return temperature * 9 / 5 + 32;
        }
    }
}