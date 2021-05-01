using System;
using Microsoft.VisualBasic.CompilerServices;

namespace OOP_Lab4
{
    public class Fraction
    {
        private int nom;
        private int denom;
        private int integ;

        public Fraction(int a = 0, int b = 1, int inte = 0)
        {
            nom   = a;
            denom = b;
            integ = inte;
        }

        public Fraction(Fraction previous) 
            : this(previous.integ, previous.denom, previous.integ)
        {}

        public Fraction normalize()
        {
            if (nom > denom)
            {
                integ = nom / denom;
                nom /= denom;
            }

            return this;
        }

        public Fraction unNormalize()
        {
            if(integ != 0)
                nom += integ * denom;
            return this;
        }

        public Fraction shorten()
        {
            int temp = 1;
            for (int i = 1; i <= Math.Min(nom, denom); i++)
            {
                if (nom % i == 0 && denom % i == 0)
                    temp = i;
            }

            nom   /= temp;
            denom /= temp;

            return this;
        }

        public int toSameDenom(ref Fraction B)
        {
            int denominator = this.denom * B.denom;
            this.nom *= B.denom;
            B.nom *= this.denom;
            this.denom = denominator;
            B.denom = denominator;

            return denominator;
        }

        public static Fraction operator +(Fraction A, Fraction B)
        {
            int denominator = A.toSameDenom(ref B);

            return new Fraction(A.nom + B.nom, denominator, A.integ + B.integ);
        }

        public static Fraction operator -(Fraction A, Fraction B)
        {
            int denominator = A.toSameDenom(ref B);

            return new Fraction(A.nom - B.nom, denominator, A.integ - B.integ);
        }

        public static Fraction operator *(Fraction A, Fraction B)
        {
            return new Fraction(A.nom * B.nom, A.denom * B.denom, A.integ * B.integ);
        }

        public static Fraction operator /(Fraction A, Fraction B)
        {
            A.unNormalize(); B.unNormalize();
            return new Fraction(A.nom * B.denom, A.denom * B.nom).normalize();
        }

        public void show()
        {
            Console.WriteLine($"\ninteger: {integ};");
            Console.WriteLine($"nominator: {nom};");
            Console.WriteLine($"denominator: {denom};\n");
        }
    }
}