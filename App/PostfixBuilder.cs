using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public static class PostfixBuilder
    {
        private static Dictionary<char, int> priorities = new Dictionary<char, int>
        {
            { '(', -1 },
            { ')', -1 },
            { '+', 1 },
            { '-', 1 },
            { '*', 2 }
        };

        public static string BuildPostfixExpression(string infixExpression)
        {
            if (infixExpression == null)
                throw new FormatException();

            var tokens = infixExpression.SplitWithSeparators(priorities.Keys.ToArray());
            if (tokens.Length == 0)
                return string.Empty;

            var result = new List<string>();
            var stack = new Stack<string>();
            bool isUnary = true;
            foreach (var token in tokens)
            {
                if (IsOperand(token))
                {
                    result.Add(token);
                    isUnary = false;
                }
                else if (token == "(")
                {
                    stack.Push(token);
                    isUnary = true;
                }
                else if (token == ")")
                {
                    if (stack.Count == 0)
                        throw new FormatException();
                    while (stack.Peek() != "(")
                    {
                        result.Add(stack.Pop());
                        if (stack.Count == 0)
                            throw new FormatException();
                    }
                    if (stack.Count > 0)
                        stack.Pop();
                    isUnary = false;
                }
                else
                {
                    while (stack.Count > 0 && GetPriority(token) <= GetPriority(stack.Peek()))
                    {
                        result.Add(stack.Pop());
                    }
                    if (isUnary)
                    {
                        result.Add("0");
                    }
                    stack.Push(token);
                    isUnary = false;
                }
            }
            while (stack.Count > 0)
            {
                var token = stack.Pop();
                if (token == "(")
                    throw new FormatException();
                result.Add(token);
            }

            if (result.Count == 0)
                throw new FormatException();
            return string.Join(' ', result);
        }

        private static bool IsOperand(string token) =>
            token.Length != 1 || !priorities.ContainsKey(token[0]);

        private static int GetPriority(string value) =>
            value.Length == 1
                ? priorities.GetValueOrDefault(value[0], 0)
                : 0;
    }
}
