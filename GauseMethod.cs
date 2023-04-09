using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMLaba2
{
    public class GauseMethod
    {
        public GauseMethod(int size_ = 4)
        {
            size = size_;
            Gauss();
        }
        private int size;
        private List<List<double>> Matrix = new();
        private List<List<double>> InverseMatrix = new();
        private void DisplayMatrix(int? i)
        {
            if (i is not null) Console.WriteLine($"iteration {i}:");
            else Console.WriteLine("Matrix:");
            foreach (var list in Matrix)
            {
                foreach (var num in list) Console.Write($"{num:0.00000} ");
                Console.WriteLine();
            }
        }
        private void DisplayInverseMatrix()
        {
            Console.WriteLine("Inverse matrix: ");
            foreach (var list in InverseMatrix)
            {
                for (var i = 0; i < size; i++)
                    Console.Write($"{list[i]:0.0000} ");
                Console.WriteLine();
            }
        }
        private void Gauss()
        {
            Console.WriteLine("\n>>>>>>>>>>>>>Gauss Method<<<<<<<<<<<<<\n");
            Matrix.Add(new List<double>() { 5, 2, 1, 0, 15 });
            Matrix.Add(new List<double>() { 1, 3, 2, 8, 58 });
            Matrix.Add(new List<double>() { 4, -6, 1, 0, -10 });
            Matrix.Add(new List<double>() { 5, 0, 3, 2, 27 });
            InverseMatrix.Add(new List<double>() { 1, 0, 0, 0, 0 });
            InverseMatrix.Add(new List<double>() { 0, 1, 0, 0, 0 });
            InverseMatrix.Add(new List<double>() { 0, 0, 1, 0, 0 });
            InverseMatrix.Add(new List<double>() { 0, 0, 0, 1, 0 });
            double ratio;
            for (var i = 0; i < size; i++)
            {
                for (var j = i + 1; j < size; j++)
                {
                    ratio = Matrix[j][i] / Matrix[i][i];
                    for (var k = i; k <= size; k++)
                    {
                        InverseMatrix[j][k] -= ratio *
                        InverseMatrix[i][k];
                    }
                }
                DisplayMatrix(i);
            }
            double det = 1;
            for (var i = 0; i < size; i++) det *= Matrix[i][i];
            for (var pos = size - 1; pos >= 0; pos--)
            {
                ratio = Matrix[pos][pos];
                if (ratio != 0)
                    for (var col = size; col >= 0; col--)
                    {
                        Matrix[pos][col] /= ratio;
                        InverseMatrix[pos][col] /= ratio;
                    }
            }
            for (var pos = size - 1; pos >= 0; pos--)
                for (var row = pos - 1; row >= 0; row--)
                {
                    ratio = Matrix[row][pos];
                    Matrix[row][size] -= ratio * Matrix[pos][size];
                    Matrix[row][pos] -= ratio * Matrix[pos][pos];
                    InverseMatrix[row][size] -= ratio *
                   InverseMatrix[pos][size];
                    InverseMatrix[row][pos] -= ratio *
                   InverseMatrix[pos][pos];
                }
            var answers = Enumerable.Repeat(0.0, size).ToList();
            answers[size - 1] = Matrix[size - 1][size] / Matrix[size -
           1][size - 1];
            for (var i = size - 2; i >= 0; i--)
            {
                answers[i] = Matrix[i][size];
                for (var j = i + 1; j < size; j++)
                    answers[i] = answers[i] - Matrix[i][j] * answers[j];
                answers[i] = answers[i] / Matrix[i][i];
            }
            DisplayMatrix(null);
            DisplayInverseMatrix();
            Console.WriteLine("Solution:");
            for (var i = 0; i < size; i++) Console.WriteLine($"x{i + 1} = { answers[i]:.0000} ");
            Console.WriteLine($"Determinant: {det}");
        }
    }
}
