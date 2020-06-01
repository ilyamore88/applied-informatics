using System;

namespace task9
{
    class Program
    {
        /*
         * Coefficient for the equation
         */
        private static double Сoefficient(double t, double x)
        {
            return 4.0 * (1.1 - 0.7 * x);
        }

        static void Main(string[] args)
        {
            double length = 1.0,
                time,
                precision = 1.0,
                dx,
                dt,
                left = 0,
                right = 0;

            int nX = 5, nT = 15;
            dx = length / (double) (nX - 1);

            double Max = 0.0, s;
            for (int x = 0; x < nX; x++)
            {
                s = Сoefficient(0, dx * x);
                Max = (Max > s) ? Max : s;
            }

            dt = dx * dx * precision / (2.0 * Max);
            time = 20.0 * dt;
            nT = (int) (time / dt + 1.0);

            double[,] u = new double[nT, nX];
            for (int x = 0; x < nX; x++)
                u[0, x] = 0.01 * (1.0 - dx * x) * dx * x;
            u[0, 0] = left;
            u[0, nX - 1] = right;


            double S, F, T, X;

            for (int t = 0; t < nT - 1; t++)
            {
                for (int x = 0; x < nX; x++)
                {
                    T = dt * t;
                    X = dx * x;
                    S = Сoefficient(T, X);
                    F = Math.Exp(T) - 1.0;

                    /*
                     * Left border
                     */
                    if (x == 0)
                    {
                        u[t + 1, x] = left;
                    }

                    /*
                     * Right border
                     */
                    if (x == nX - 1)
                    {
                        u[t + 1, x] = right;
                    }

                    /*
                     * Between the borders
                     */
                    if (x > 0 && x < nX - 1)
                    {
                        u[t + 1, x] = dt / (dx * dx) * S * (u[t, x - 1] + u[t, x + 1]) +
                                      (1.0 - 2.0 * dt / (dx * dx) * S) * u[t, x] + dt * F;
                    }
                }
            }

            /*
             * Write results
             */
            Console.WriteLine($"The number of break points in space:  {nX}");
            Console.WriteLine($"The number of break points in time: {nT}");
            Console.WriteLine($"Time step: {dt}");
            Console.WriteLine($"Time: {time} \n");

            int xx = (int) (0.6 * (nX - 1) / length);
            Console.WriteLine("u = u(0,6; t)");
            for (int t = 0; t < nT; t++)
            {
                Console.WriteLine($"{(dt * t):0.0000}  {u[t, xx]:0.0000}");
            }

            double tt = time / 10.0;

            xx = (int) (tt * (nT - 1) * 1 / time);
            Console.WriteLine($"\nu = u(x; {tt})");

            for (int x = 0; x < nX; x++)
            {
                Console.WriteLine($"{dx * x:0.0000}  {u[xx, x]:0.0000}");
            }

            xx = (int) (tt * (nT - 1) * 2 / time);
            Console.WriteLine($"\nu = u(x; {tt * 2:0.0000})");

            for (int x = 0; x < nX; x++)
            {
                Console.WriteLine($"{(dx * x):0.0000}  {u[xx, x]:0.0000}");
            }

            xx = (int) (tt * (nT - 1) * 4 / time);
            Console.WriteLine($"\nu = u(x; {tt * 4:0.0000})");


            for (int x = 0; x < nX; x++)
            {
                Console.WriteLine($"{(dx * x):0.00000}  {(u[xx, x]):0.0000}");
            }
        }
    }
}
