using System;

namespace task2
{
    public class NonSquareMatrixException : ArithmeticException
    {
        public override string Message { get; } = "The matrix is not square.";
    }
}
