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
                return 0.ToString();

            var tokens = postfixExpression.Split(' ');
            var stack = new Stack<string>();
            foreach (var token in tokens)
            {
                if (operations.Contains(token))
                {
                    var operation = token;
                    if (stack.Count < 2)
                        throw new FormatException();
                    var second = int.Parse(stack.Pop());
                    var first = int.Parse(stack.Pop());
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
            return int.Parse(result).ToString();
        }

        private static int Calculate(string operation, int operand1, int operand2)
        {
            if (operation == "+")
                return operand1 + operand2;
            if (operation == "-")
                return operand1 - operand2;
            if (operation == "*")
                return operand1 * operand2;
            throw new FormatException();
        }
    }
}
