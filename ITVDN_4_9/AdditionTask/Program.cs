using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class MyClass : IDisposable
    {
        enum CleanMode
        {
            Destructor,
            Dispose
        }
        private bool isCleaned = false;
        public void Dispose()
        {
            CleanUp(CleanMode.Dispose);
            GC.SuppressFinalize(this);
        }

        ~MyClass()
        {
            CleanUp(CleanMode.Destructor);
            Console.ReadKey();
        }

        private void CleanUp(CleanMode cleanMode)
        {
            if (!isCleaned)
            {
                Console.WriteLine(this);
                switch (cleanMode)
                {
                    case CleanMode.Dispose:
                        Console.Write("Освобождение ресурсов через Dispose\t");
                        break;
                    case CleanMode.Destructor:
                        Console.Write("Освобождение ресурсов через Destructor\t");
                        break;
                }
                Console.WriteLine("Готово!");
            }
            isCleaned = true;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Foo();
        }

        static void Foo()
        {
            using (var myClass = new MyClass())
            {
            }
            Console.WriteLine(new string('-', 20));


            var myClass2 = new MyClass();
            myClass2.Dispose();
            myClass2.Dispose();
            myClass2.Dispose();
            myClass2.Dispose();
            myClass2.Dispose();

            Console.WriteLine(new string('-', 20));

            var myClass3 = new MyClass();
        }
    }
}
