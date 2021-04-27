namespace OOP_Lab4
{
    public class Fraction
    {
        private int nom;
        private int denom;
        private int integ;

        public Fraction(int a = 0, int b = 1, int integ = 0)
        {
            nom   = a;
            denom = b;
            this.integ     = integ;
            this.shorten();
        }

        public Fraction(Fraction previous) 
            : this(previous.integ, previous.denom, previous.integ)
        {}

        public void normalize()
        {
            integ = nom / denom;
            nom /= denom;
            shorten();
        }

        public void unNormalize()
        {
            if (integ == 0)
                return;
            nom += integ * denom;
        }

        public void shorten()
        {
            int temp = 1;
            for (int i = 0; i < nom; i++)
            {
                if (nom % i == 0 && denom % i == 0)
                    temp = i;
            }

            nom   /= temp;
            denom /= temp;
        }

        public static Fraction operator *(Fraction A, Fraction B)
        {
            return new Fraction(A.nom * B.nom, A.denom * B.denom, A.integ * B.integ);
        }

        public static Fraction operator /(Fraction A, Fraction B)
        {
            A.unNormalize(); B.unNormalize();
            
        }
    }
}