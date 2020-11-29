using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public static class PostfixCalculator
    {
        private static string[] operations = new[] { "+", "-", "*" };

        public static string Calculate(string postfixExpression)
        {
            if (postfixExpression == null)
                throw new FormatException();
            if (postfixExpression == string.Empty)
                return LongComplex.Zero.ToString();

            var tokens = postfixExpression.Split(' ');
            var stack = new Stack<string>();
            foreach (var token in tokens)
            {
                if (operations.Contains(token))
                {
                    var operation = token;
                    if (stack.Count < 2)
                        throw new FormatException();
                    var second = LongComplex.Parse(stack.Pop());
                    var first = LongComplex.Parse(stack.Pop());
                    var calculated = Calculate(operation, first, second).ToString();
                    stack.Push(calculated);
                }
                else
                {
                    stack.Push(token);
                }
            }
            if (stack.Count != 1)
                throw new FormatException();
            var result = stack.Pop();
            return LongComplex.Parse(result).ToString();
        }

        private static LongComplex Calculate(string operation, LongComplex operand1, LongComplex operand2)
        {
            if (operation == "+")
                return LongComplex.Add(operand1, operand2);
            if (operation == "-")
                return LongComplex.Subtract(operand1, operand2);
            if (operation == "*")
                return LongComplex.Multiply(operand1, operand2);
            throw new FormatException();
        }
    }
}
