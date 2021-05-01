using System;

namespace OOP_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Fraction a = new Fraction(1, 1, 0);
            Fraction b = new Fraction(4, 2, 0);
            b.shorten();
            b.show();
            a.show();
            (a+b).show();
            (a/b).show();
        }
    }
}