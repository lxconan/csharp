using System;
using System.Diagnostics.CodeAnalysis;

namespace MyDateTimeOffset
{
    class AwesomeDateTimeOffset : IEquatable<AwesomeDateTimeOffset>
    {
        #region Please implement the following methods
        
        /*
         * In this practice, we will focus on equality. An equality of an object may be more
         * complicated than you think. We will implement Equals, GetHashCode as well as the
         * operators. You can add private members and methods. But you cannot modify the signature
         * of any existed structure.
         *
         * Difficulty: Medium
         */
        
        public AwesomeDateTimeOffset(DateTime baseTime, TimeSpan offset)
        {
            throw new NotImplementedException();
        }

        public bool Equals(AwesomeDateTimeOffset other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(AwesomeDateTimeOffset left, AwesomeDateTimeOffset right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(AwesomeDateTimeOffset left, AwesomeDateTimeOffset right)
        {
            return !(left == right);
        }

        public void SetOffset(TimeSpan offset)
        {
            throw new NotImplementedException();
        }
        
        #endregion
    }
}