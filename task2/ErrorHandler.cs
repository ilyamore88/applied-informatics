using System;

namespace task2
{
    public class ErrorHandler
    {
        public static void WriteErrorInConsole(Exception exception, string message = "Something went wrong!")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.WriteLine("Stack trace:");
            Console.WriteLine(exception.StackTrace);
            Console.ResetColor();
            System.Environment.Exit(1);
        }
    }
}
