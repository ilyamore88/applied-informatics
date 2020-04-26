using System;
using System.Collections.Generic;

namespace task7
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Example functions
             */
            List<Func<double, double, double, double>> functions = new List<Func<double, double, double, double>>();
            functions.Add((x, y, z) => 5 * x - 2 * y + z);
            functions.Add((x, y, z) => 2 * x + y - z);

            /*
             * Initial values
             */
            double x0 = 0;
            double y0 = 1;
            double z0 = 1;

            double a = 0;
            double b = 1;
            double h = 0.1;

            int n = (int) ((b - a) / h);

            /*
             * Array of results
             */
            double[] valuesY = new double[n];
            double[] valuesZ = new double[n];

            double prevX = x0;
            double prevY = y0;
            double prevZ = z0;

            /*
             * Finding a solution
             */
            for (int i = 0; i < n; i++)
            {
                if (i != 0)
                {
                    prevY = valuesY[i - 1];
                    prevZ = valuesZ[i - 1];
                }

                double k1 = functions[0](prevX, prevY, prevZ);
                double k2 = functions[0](prevX + h / 2, prevY + h * k1 / 2, prevZ + h * k1 / 2);
                double k3 = functions[0](prevX + h / 2, prevY + h * k2 / 2, prevZ + h * k2 / 2);
                double k4 = functions[0](prevX + h, prevY + h * k3, prevZ + h * k3);
                valuesY[i] = prevY + (h / 6 * (k1 + 2 * k2 + 2 * k3 + k4));

                k1 = functions[1](prevX, prevY, prevZ);
                k2 = functions[1](prevX + h / 2, prevY + h * k1 / 2, prevZ + h * k1 / 2);
                k3 = functions[1](prevX + h / 2, prevY + h * k2 / 2, prevZ + h * k2 / 2);
                k4 = functions[1](prevX + h, prevY + h * k3, prevZ + h * k3);
                valuesZ[i] = prevZ + (h / 6 * (k1 + 2 * k2 + 2 * k3 + k4));
            }

            /*
             * Print results
             */
            Console.WriteLine("Result:");
            Console.WriteLine($"x = {x0}\ty = {y0}\tz = {z0}");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"x = {(i + 1) * h + x0}\ty = {valuesY[i]}\tz = {valuesZ[i]}");
            }
        }
    }
}
