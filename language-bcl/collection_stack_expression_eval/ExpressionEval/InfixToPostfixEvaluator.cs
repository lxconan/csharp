using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionEval
{
    class InfixToPostfixEvaluator
    {
        public string[] Evaluate(string[] expression)
        {
            object[] tokens = Tokenize(expression);
            var result = new List<string>();
            var operatorStack = new Stack<Operator>();

            foreach (object token in tokens)
            {
                if (token is Operand)
                {
                    result.Add(token.ToString());
                }
                else if (token is Operator)
                {
                    var @operator = (Operator)token;
                    while (operatorStack.Count > 0 && operatorStack.Peek().Priority >= @operator.Priority) 
                    {
                        Operator topOperator = operatorStack.Pop();
                        result.Add(topOperator.ToString());
                    }

                    operatorStack.Push(@operator);
                }
            }

            while (operatorStack.Count > 0)
            {
                result.Add(operatorStack.Pop().ToString());
            }

            return result.ToArray();
        }

        static object[] Tokenize(string[] expression)
        {
            object[] tokens = expression
                .Select(TokenFactory.Create)
                .ToArray();

            ValidateSyntax(tokens);
            return tokens;
        }

        static void ValidateSyntax(object[] tokens)
        {
            object invalidOperand = tokens
                .Where((token, index) => index % 2 == 0)
                .FirstOrDefault(token => !(token is Operand));
            if (invalidOperand != null) 
            {
                throw new ArgumentException($"Syntax error found at \'{invalidOperand.ToString()}\'");
            }

            object invalidOperator = tokens
                .Where((token, index) => index % 2 != 0)
                .FirstOrDefault(token => !(token is Operator));
            if (invalidOperator != null)
            {
                throw new ArgumentException($"Syntax error found at \'{invalidOperator.ToString()}\'");
            }
        }
    }
}