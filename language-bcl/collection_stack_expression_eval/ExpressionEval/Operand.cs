using System;
using System.Diagnostics.CodeAnalysis;

namespace ExpressionEval
{
    class Operand
    {
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = "It will be used later")] 
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