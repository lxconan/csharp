using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace LinqFacts
{
    /* 
     * Description
     * ===========
     * 
     * We have defined the sequence of a poker cards as follows. The ranks from highest to
     * lowest are:
     * 
     * Joker, 3, 2, A, K, Q, J, 10, 9, 8, 7, 6, 5, 4
     * 
     * If cards has the same ranks, the order from highest to lowest depends on their suits
     * (from highest to lowest):
     * 
     * Hearts, Diamonds, Spades, Clubs
     * 
     * Please implement the comparator to correctly order a collection of cards.
     * 
     * Difficulty: Super Easy
     * 
     * Knowledge Point
     * ===============
     * 
     * - IComparer<T>
     */
    public class DefineHowToOrder
    {
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Local")]
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

        enum CardSuit
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades,
            None
        }

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        enum CardRank
        {
            RankA,
            Rank2,
            Rank3,
            Rank4,
            Rank5,
            Rank6,
            Rank7,
            Rank8,
            Rank9,
            Rank10,
            RankJ,
            RankQ,
            RankK,
            Joker
        }

        #region Please modifies the code to pass the test

        class PokerComparer : IComparer<Card>
        {
            public int Compare(Card x, Card y)
            {
                throw new System.NotImplementedException();
            }
        }

        #endregion

        [Fact]
        public void should_order_cards_correctly()
        {
            var cards = new[]
            {
                new Card(CardSuit.Spades, CardRank.RankA),
                new Card(CardSuit.Diamonds, CardRank.Rank5),
                new Card(CardSuit.Spades, CardRank.Rank4),
                new Card(CardSuit.Hearts, CardRank.Rank5),
                new Card(CardSuit.Diamonds, CardRank.Rank2),
                new Card(CardSuit.None, CardRank.Joker),
                new Card(CardSuit.Spades, CardRank.Rank3),
                new Card(CardSuit.Clubs, CardRank.Rank7),
                new Card(CardSuit.Spades, CardRank.Rank6),
                new Card(CardSuit.Spades, CardRank.RankQ),
                new Card(CardSuit.Clubs, CardRank.Rank5)
            };
            
            var expected = new[]
            {
                new Card(CardSuit.Spades, CardRank.Rank4),
                new Card(CardSuit.Clubs, CardRank.Rank5),
                new Card(CardSuit.Diamonds, CardRank.Rank5),
                new Card(CardSuit.Hearts, CardRank.Rank5),
                new Card(CardSuit.Spades, CardRank.Rank6),
                new Card(CardSuit.Clubs, CardRank.Rank7),
                new Card(CardSuit.Spades, CardRank.RankQ),
                new Card(CardSuit.Spades, CardRank.RankA),
                new Card(CardSuit.Diamonds, CardRank.Rank2),
                new Card(CardSuit.Spades, CardRank.Rank3),
                new Card(CardSuit.None, CardRank.Joker)
            };

            Assert.Equal(expected, cards.OrderBy(c => c, new PokerComparer()));
        }
    }
}