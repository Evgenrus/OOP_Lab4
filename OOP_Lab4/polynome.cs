using System;
using Microsoft.VisualBasic.CompilerServices;

namespace OOP_Lab4
{
    public class polynome
    {
        private double[] m_data;
        private int m_size;

        public polynome(int size = 0, double[] data = null)
        {
            m_size = size;
            if (data != null)
            {
                m_data = new double[m_size];
                Array.Copy(data, m_data, data.Length);
            }
            else m_data = null;
        }
        
        public polynome(polynome previous) 
            : this(previous.m_size, previous.m_data)
        {}

        public static polynome operator +(polynome A, polynome B)
        {
            if (A.m_size > B.m_size)
            {
                Array.Resize(ref B.m_data, A.m_size);
                B.m_size = A.m_size;
            } 
            else
            {
                Array.Resize(ref A.m_data, B.m_size);
                A.m_size = B.m_size;
            }

            double[] res = new double[A.m_size];
            
            for (int i = 0; i < A.m_size; i++)
            {
                res[i] = A.m_data[i] + B.m_data[i];
            }

            return new polynome(A.m_size, res);
        }

        public static polynome operator -(polynome A, polynome B)
        {
            if (A.m_size > B.m_size)
            {
                Array.Resize(ref B.m_data, A.m_size);
                B.m_size = A.m_size;
            } 
            else
            {
                Array.Resize(ref A.m_data, B.m_size);
                A.m_size = B.m_size;
            }

            double[] res = new double[A.m_size];
            
            for (int i = 0; i < A.m_size; i++)
            {
                res[i] = A.m_data[i] - B.m_data[i];
            }

            return new polynome(A.m_size, res);
        }

        public static polynome operator *(polynome A, polynome B)
        {
            A.trim(); B.trim();
            int size = A.m_size + B.m_size;
            var res = new double[size];

            for (int i = 0; i < A.m_size; i++)
            {
                for (int j = 0; j < B.m_size; j++)
                {
                    res[i + j] += A.m_data[i] * B.m_data[j];
                }
            }

            return new polynome(size, res);
        }
        
        public polynome trim()
        {
            int last = 0;
            for (int i = 0; i < m_size; i++)
            {
                if (m_data[i] != 0)
                    last = i;
            }
            
            Array.Resize(ref m_data, last + 1);
            m_size = last + 1;
            
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

            for (int i = 0; i < m_size; i++)
            {
                res += m_data[i] * Math.Pow(x, i);
            }
            
            return res;
        }
    }
}