using System;
using Microsoft.VisualBasic.CompilerServices;

namespace OOP_Lab4
{
    public class polynome
    {
        private double[] m_data;
        private int Size => m_data.Length;

        public polynome(int size = 1, double[] data = null)
        {
            if (data != null)
            {
                m_data = new double[size];
                Array.Copy(data, m_data, data.Length);
            }
            else m_data = null;
        }
        
        public polynome(polynome previous) 
            : this(previous.Size, previous.m_data)
        {}

        public static polynome operator +(polynome A, polynome B)
        {
            double[] res = new double[Math.Max(A.Size, B.Size)];
            
            for (int i = 0; i < A.Size; i++)
            {
                res[i] = A.m_data[i] + B.m_data[i];
            }

            return new polynome(A.Size, res);
        }

        public static polynome operator -(polynome A, polynome B)
        {
            double[] res = new double[Math.Max(A.Size, B.Size)];
            
            for (int i = 0; i < A.Size; i++)
            {
                res[i] = A.m_data[i] - B.m_data[i];
            }

            return new polynome(A.Size, res);
        }

        public static polynome operator *(polynome A, polynome B)
        {
            A.trim(); B.trim();
            int size = A.Size + B.Size;
            var res = new double[size];

            for (int i = 0; i < A.Size; i++)
            {
                for (int j = 0; j < B.Size; j++)
                {
                    res[i + j] += A.m_data[i] * B.m_data[j];
                }
            }

            return new polynome(size, res);
        }
        
        public polynome trim()
        {
            int last = 0;
            for (int i = Size - 1; i > 0; i++)
            {
                if (m_data[i] == 0) break;
            }
            
            Array.Resize(ref m_data, last + 1);

            return this;
        }

        public void show()
        {
            this.trim();
            foreach (var number in m_data)
            {
                Console.Write($"{number}, ");
            }
            Console.WriteLine(";");
        }

        public double calculate(double x)
        {
            double res = 0;

            for (int i = 0; i < Size; i++)
            {
                res += m_data[i] * Math.Pow(x, i);
            }
            
            return res;
        }
    }
}