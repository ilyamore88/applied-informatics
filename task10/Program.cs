using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] table =
            { {360, 18,  15, 12},
                {192, 6,  4, 8},
                {180,  5,  3, 3},
                { 0, -9, -10, -16} };

            double[] result = new double[3];
            double[,] table_result;
            Simplex S = new Simplex(table);
            table_result = S.Calculate(result);

            Console.WriteLine("Solved simplex table:");
            for (int i = 0; i < table_result.GetLength(0); i++)
            {
                for (int j = 0; j < table_result.GetLength(1); j++)
                    Console.Write(table_result[i, j] + " ");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Solution of simplex table:");
            Console.WriteLine("A = " + result[0]);
            Console.WriteLine("B = " + result[1]);
            Console.WriteLine("C = " + result[2]);
            Console.ReadLine();
        }
    }
}
