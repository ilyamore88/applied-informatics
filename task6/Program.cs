using System;

namespace task6
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Initial values
             */
            double x0 = 0;
            double y0 = 1;
            double h0 = 2.5;
            double m = 10;

            double x = x0;
            double y = y0;
            double h = h0 / m;

            /*
             * Finding a solution
             */
            for (int j = 1; j <= m; j++)
            {
                double k1 = Function(x, y);
                double k2 = Function(x + h / 2, y + (h * k1) / 2);
                double k3 = Function(x + h / 2, y + (h * k2) / 2);
                double k4 = Function(x + h, y + (h * k3));

                y += (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4);
                x = x0 + j * h;
            }

            Console.WriteLine("Result for function y*cos(x):");
            Console.WriteLine("x:\ty:");
            Console.WriteLine($"{x}\t{y}");
        }

        /*
         * Function example
         */
        static double Function(double x, double y)
        {
            return y * Math.Cos(x);
        }
    }
}
