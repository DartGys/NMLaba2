using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMLaba2
{
    public class ZeydelMethod
    {
        public ZeydelMethod(double e = 1e-3)
        {
            Eps = e;
            Solve();
        }
        private double Eps;
        double x1n(double x1, double x2, double x3, double x4) => (double) 1/6 * (-2 * x3 -3 * x4 + 24);
        double x2n(double x1, double x2, double x3, double x4) => (double) 1/4 * (-2 * x3 -1 * x4 + 18);
        double x3n(double x1, double x2, double x3, double x4) => (double) 1/5 * (-2 * x1 -2 * x2 + 21);
        double x4n(double x1, double x2, double x3, double x4) => (double) 1/3 * (-1 * x1 -1 * x2 + 15);

        private void Solve()
        {
            Console.WriteLine("\n>>>>>>>>>>>>>Zeydel Method<<<<<<<<<<<<\n");
            double x01 = 0, x02 = 0, x03 = 0, x04 = 0;
            double x11, x22, x33, x44;
            double e1, e2, e3, e4, e;
            int i = 1;
            do
            {
                x11 = x1n(x01, x02, x03, x04);
                x22 = x2n(x01, x02, x03, x04);
                x33 = x3n(x01, x02, x03, x04);
                x44 = x4n(x01, x02, x03, x04);
                Console.WriteLine($"iteration {i}:\t {x11}, {x22}, {x33}, {x44}");
                e1 = Math.Abs(x01 - x11);
                e2 = Math.Abs(x02 - x22);
                e3 = Math.Abs(x03 - x33);
                e4 = Math.Abs(x04 - x44);
                e = Math.Sqrt(Math.Pow(e1, 2) + Math.Pow(e2, 2) +
               Math.Pow(e3, 2) + Math.Pow(e4, 2));
                if (e < Eps) break;
                x01 = x11;
                x02 = x22;
                x03 = x33;
                x04 = x44;
                i++;
            } while (e > Eps);

            Console.WriteLine("\nSolution:");
            Console.WriteLine($"x1 = {x11}");
            Console.WriteLine($"x2 = {x22}");
            Console.WriteLine($"x3 = {x33}");
            Console.WriteLine($"x4 = {x44}");
        }
    }
}

