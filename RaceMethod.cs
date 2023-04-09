using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMLaba2
{
    public class RaceMethod
    {
        private List<List<double>> Matrix { get; set; } = new();
        public RaceMethod(double e = 1e-3, int size = 3)
        {
            eps = e;
            this.size = size;
            Tridiagonal();
        }
        private double eps;
        private int size;
        private void Tridiagonal()
        {
            Console.WriteLine("\n>>>>>>>>>>>>>Tridiagonal Method<<<<<<<<<<<<\n");
            Matrix.Add(new List<double>() { 2, 4, 0, 18 });
            Matrix.Add(new List<double>() { 4, 1, 5, 33 });
            Matrix.Add(new List<double>() { 0, 5, 2, 30 });
            List<double> A = Enumerable.Repeat(0.0, size).ToList(),
            B = Enumerable.Repeat(0.0, size).ToList(),
            result = Enumerable.Repeat(0.0, size).ToList();
            A[0] = Matrix[0][1] / Matrix[0][0];
            B[0] = Matrix[0][size] / Matrix[0][0];
            double x;
            for (int i = 1; i < size; i++)
            {
                x = Matrix[i][i] - A[i - 1] * Matrix[i][i - 1];
                A[i] = Matrix[i][i + 1] / x;
                B[i] = (Matrix[i][size] - Matrix[i][i - 1] * B[i - 1]) / x;
            }
            result[size - 1] = B[size - 1];
            for (int i = size - 2; i >= 0; i--)
            {
                result[i] = B[i] - A[i] * result[i + 1];
            }
            Console.WriteLine("Solution: ");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"x{i} = {result[i]}");
            }

        }
    }
}
