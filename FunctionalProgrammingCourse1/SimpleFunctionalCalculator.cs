using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalProgrammingCourse1
{
    public static class ConsoleHelper
    {
        public static void PrintToConsole(this decimal value)
        {
            Console.WriteLine(value);
        }

    }
    public class SimpleFunctionalCalculator
    {
        public delegate decimal MathOperation(decimal lhs, decimal rhs);

        public static decimal Add(decimal left, decimal right)
        {
            return left + right;
        }
        public static decimal Subtract(decimal left, decimal right)
        {
            return left - right;
        }
        public static decimal Multiply(decimal left, decimal right)
        {
            return left * right;
        }
        public static decimal Divide(decimal left, decimal right)
        {
            return left / right;
        }

        private static MathOperation GetOperation(char upper)
        {
            switch (upper)
            {
                case '+': return delegate (decimal l, decimal r) { return l + r; };
                case '-': return (l, r) => l - r;
                case '*': return Multiply;
                case '/': return Divide;
            }

            throw new NotSupportedException("Unsupported Operation");
        }

        private static Decimal Eval(string expr)
        {
            var elements = expr.Split(' ', 3);
            var l = decimal.Parse(elements[0]);
            var r = decimal.Parse(elements[1]);
            var op = elements[2][0];

            return GetOperation(op)(l, r);
        }

        public void Begin()
        {
            Eval("1 3 +").PrintToConsole();
            Eval("10 5 -").PrintToConsole();
            Eval("2 3 *").PrintToConsole();
            Eval("21 3 /").PrintToConsole();
        }
    }
}
