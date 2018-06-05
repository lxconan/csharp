using System.Collections.Generic;
using System.Linq;

namespace EnumeratorDistinct
{
    class AnagramEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x == null | y == null) return false;
            int length = x.Length;
            if (length != y.Length) return false;
            using (IEnumerator<char> en = x.OrderBy(i => i).GetEnumerator())
            {
                foreach (char c in y.OrderBy(i => i))
                {
                    en.MoveNext();
                    if (c != en.Current) return false;
                }
            }
            return true;
        }

        public int GetHashCode(string obj)
        {
            if (obj == null) return 0;
            int hash = obj.Length;
            foreach (char c in obj)
            {
                hash ^= c;
            }

            return hash;
        }
    }
}