using System;

namespace ExpressionEval
{
    class Operand
    {
        public int Value { get; }

        public Operand(string value)
        {
            if (!int.TryParse(value, out int parsed))
            {
                throw new ArgumentException($"Unrecognized operand {value}.");
            }

            Value = parsed;
        }

        public override string ToString() => Value.ToString("D");
    }
}