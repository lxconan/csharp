using System;
using System.Diagnostics.CodeAnalysis;

namespace SortPokers
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    class Card : IEquatable<Card>
    {
        public Card(CardSuit suit, CardRank rank)
        {
            if (suit == CardSuit.None && rank != CardRank.Joker)
            {
                throw new ArgumentException("Joker has no suit.");
            }

            Suit = suit;
            Rank = rank;
        }

        public CardRank Rank { get; }
        public CardSuit Suit { get; }

        public bool Equals(Card other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Rank == other.Rank && Suit == other.Suit;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Card) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Rank * 397) ^ (int) Suit;
            }
        }
    }
}