using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ExpressionEval
{
    class InfixToPostfixEvaluator
    {
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public string[] Evaluate(string[] expression)
        {
            object[] tokens = Tokenize(expression);
            
            // TODO: Please implement the method to pass all the test. The existing code can help you.
            //
            // The algorithms to convert an infix expression to a postfix expression is as follows.
            // Note that we only support +, -, *, / operators and we only support integers.
            //
            // For each token in expression:
            // 
            // * When we get a operand, we just output it
            // * When we get an operator `o`, pop the top element in the stack until there is no
            //   operator having higher or equal priority than `o`. Then push the `o` into the stack.
            // * When the expression is ended. Pop all the operators in the stack.
            throw new NotImplementedException();
        }

        static object[] Tokenize(IEnumerable<string> expression)
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
                throw new ArgumentException($"Syntax error found at \'{invalidOperand}\'");
            }

            object invalidOperator = tokens
                .Where((token, index) => index % 2 != 0)
                .FirstOrDefault(token => !(token is Operator));
            if (invalidOperator != null)
            {
                throw new ArgumentException($"Syntax error found at \'{invalidOperator}\'");
            }
        }
    }
}