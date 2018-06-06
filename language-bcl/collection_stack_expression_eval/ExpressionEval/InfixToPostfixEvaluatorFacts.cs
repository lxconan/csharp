using System;
using Xunit;

namespace ExpressionEval
{
    public class InfixToPostfixEvaluatorFacts
    {
        [Fact]
        public void should_calculate_plus()
        {
            var evaluator = new InfixToPostfixEvaluator();
            string[] expression = {"1", "+", "2"};
            string[] postfixExpression = evaluator.Evaluate(expression);

            Assert.Equal(new [] {"1", "2", "+"}, postfixExpression);
        }

        [Fact]
        public void should_calculate_minors()
        {
            var evaluator = new InfixToPostfixEvaluator();
            string[] expression = {"1", "-", "2"};
            string[] postfixExpression = evaluator.Evaluate(expression);

            Assert.Equal(new [] {"1", "2", "-"}, postfixExpression);
        }

        [Fact]
        public void should_calculate_mixed_plus_minors()
        {
            var evaluator = new InfixToPostfixEvaluator();
            string[] expression = {"1", "+", "2", "-", "3"};
            string[] postfixExpression = evaluator.Evaluate(expression);

            Assert.Equal(new [] {"1", "2", "+", "3", "-"}, postfixExpression);
        }

        [Fact]
        public void should_calculate_mixed_plus_minors_times_div()
        {
            var evaluator = new InfixToPostfixEvaluator();
            string[] expression = {"10", "+", "2", "*", "8", "-", "3"};
            string[] postfixExpression = evaluator.Evaluate(expression);

            Assert.Equal(new [] {"10", "2", "8", "*", "+", "3", "-"}, postfixExpression);
        }

        [Fact]
        public void should_throw_if_expression_contains_invalid_token()
        {
            var evaluator = new InfixToPostfixEvaluator();
            string[] expression = {"1", "+", "2", "wtf", "3"};
            Assert.Throws<ArgumentException>(() => evaluator.Evaluate(expression));
        }

        [Fact]
        public void should_detect_simple_syntax_error()
        {
            var evaluator = new InfixToPostfixEvaluator();
            string[] expression = {"+", "1", "+", "2", "-", "3"};
            Assert.Throws<ArgumentException>(() => evaluator.Evaluate(expression));
        }
    }
}
