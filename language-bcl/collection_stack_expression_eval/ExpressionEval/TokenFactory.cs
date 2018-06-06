namespace ExpressionEval
{
    static class TokenFactory
    {
        public static object Create(string token)
        {
            return Operator.IsOperator(token) 
                ? (object)Operator.Create(token) 
                : new Operand(token);
        }
    }
}