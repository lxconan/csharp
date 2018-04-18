using System.Linq;
using Xunit;

namespace SortPokers
{
    public class SortPokerFacts
    {
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