using System;
using System.Data;
using System.Linq;

namespace Calculator
{
    public static class Calculator
    {
        static void Main()
        {
            string expression = Console.ReadLine();
            Console.WriteLine(Solve(expression.Split(" ")));
        }

        private static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }

        public static float Solve(string[] expression)
        {
            for (int i = 1; i < expression.Length; i++)
            {
                if (float.TryParse(expression[i - 1], out _) && !float.TryParse(expression[i], out _))
                {
                    string[] resolve = new string[1];
                    resolve[0] = Solve(SubArray<string>(expression, i, expression.Length - i)).ToString();
                    expression =SubArray<string>(expression, 0, i).Concat<string>(resolve).ToArray();
                }
            }

            return Evaluate(expression);
        }

        private static float Evaluate(string[] expression)
        {
            if (expression.Length == 1)
            {
                return float.Parse(expression[0]);
            }
            if (expression.Length > 1 + 1)
            {
                return Operation(Evaluate(SubArray<string>(expression, 1, expression.Length - 1 - 1)), Evaluate(SubArray<string>(expression, expression.Length - 1, 1)), expression[0]);
            }
            return 0;

        }

        private static float Operation(float a, float b, string op)
        {
            return op switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                _ => a / b,
            };
        }
    }
}
