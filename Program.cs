using System;

namespace zd1_Demin_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите имя кота и вес через enter");
                Cat murzik = new Cat(Console.ReadLine(), Convert.ToDouble(Console.ReadLine())); ;
                murzik.Meow();
            }
            catch
            {
                Console.WriteLine("Введены неверные даные");
            }
        }
    }
}
