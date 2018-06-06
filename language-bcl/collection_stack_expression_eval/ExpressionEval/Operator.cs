using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ExpressionEval
{
    class Operator
    {
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = "It will be used later")] 
        public string Name { get; }
        
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = "It will be used later")]
        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global", Justification = "It will be used later")]
        public int Priority { get; }

        Operator(string name, int priority)
        {
            Name = name;
            Priority = priority;
        }

        public override string ToString() => Name;

        public static Operator Create(string name)
        {
            return IsOperator(name)
                ? new Operator(name, SupportedOperators[name])
                : throw new ArgumentException($"Not supported operator {name}");
        }

        public static bool IsOperator(string name) => SupportedOperators.ContainsKey(name);

        private static readonly Dictionary<string, int> SupportedOperators = new Dictionary<string, int>
        {
            { "+", 1 },
            { "-", 1 },
            { "*", 2 },
            { "/", 2 }
        };
    }
}