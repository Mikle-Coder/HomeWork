//Создайте класс и примените к его методам атрибут Obsolete сначала в форме, просто
//выводящей предупреждение, а затем в форме, препятствующей компиляции.
//Продемонстрируйте работу атрибута на примере вызова данных методов.

class MyClass
{
    [Obsolete("Метод устарел")]
    public void ObsoleteMessage()
    {
        Console.WriteLine("Hello world!");
    }

    [Obsolete("Метод не используеться", true)]
    public void ObsoleteError()
    {
        Console.WriteLine("Hello world!");
    }

}

class Program
{
    static void Main()
    {
        MyClass instance = new MyClass();

        instance.ObsoleteMessage();

        // instance.ObsoleteError();
    }
}