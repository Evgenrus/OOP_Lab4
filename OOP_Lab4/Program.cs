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

            double[] one = {3.2, 4.3, 5.6, 7.8};
            double[] two = {9.0, 3.1};

            polynome C = new polynome(4, one);
            polynome D = new polynome(2, two);
            
            (C+D).show();
            (D+C).show();
            
            (C*D).show();
        }
    }
}