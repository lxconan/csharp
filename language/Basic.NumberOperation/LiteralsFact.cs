using System;
using Xunit;

namespace Basic.NumberOperation
{
    public class LiteralsFact
    {
        [Fact]
        public void should_get_correct_type_for_floating_point_number_without_literal()
        {
            #region edit area
            
            // change "typeof(string)" to correct type.
            Type guessTheType = typeof (string);
            
            #endregion

            Assert.Equal(guessTheType, 1.0.GetType());
            Assert.Equal(guessTheType, 1E3.GetType());
        }

        [Fact]
        public void should_get_correct_type_for_integer_without_literal()
        {
            #region edit area

            // change "typeof(string)" to correct type.
            Type guessTheType = typeof (string);

            #endregion

            Assert.Equal(guessTheType, 1.GetType());
            Assert.Equal(guessTheType, 0x123.GetType());
        }

        [Fact]
        public void should_get_correct_type_for_M_literal()
        {
            #region edit area

            // change "typeof(string)" to correct type.
            Type guessTheType = typeof (string);

            #endregion

            Assert.Equal(guessTheType, 1M.GetType());
        }

        [Fact]
        public void should_get_correct_type_for_L_literal()
        {
            #region edit area

            // change "typeof(string)" to correct type.
            Type guessTheType = typeof (string);

            #endregion

            Assert.Equal(guessTheType, 5L.GetType());
        }

        [Fact]
        public void should_get_correct_type_for_F_literal()
        {
            #region edit area

            // change "typeof(string)" to correct type.
            Type guessTheType = typeof (string);

            #endregion

            Assert.Equal(guessTheType, 5F.GetType());
        }
    }
}