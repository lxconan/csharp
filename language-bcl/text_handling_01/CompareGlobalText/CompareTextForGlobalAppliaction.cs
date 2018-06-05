using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Xunit;

namespace CompareGlobalText
{
    /* 
     * Description
     * ===========
     * 
     * This practice show how culture information affect string manipulation. You have to
     * implement a method `Translate()` to get translation from a dictionary. The input
     * is a string of words which are divided by comma. The output should be their translations
     * joined by ";".
     * 
     * Difficulty: Super Easy
     * 
     * Knowledge Point
     * ===============
     * 
     * - CultureInfo
     * - Thread.CurrentCulture
     */
    public class CompareTextForGlobalAppliaction
    {
        readonly Dictionary<string, string> dictionary = new Dictionary<string, string>
        {
            {"internal", "Happening or arising or located within some limits or especially surface"},
            {"advice", "A proposal for an appropriate course of action" },
            {"surface", "The outer boundary of an artifact or a material layer constituting or resembling such a boundary"},
            {"i", "A speaker or writer uses I to refer to himself or herself" }
        };

        #region #region Please modifies the code to pass the test

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static string Translate(string words, IDictionary<string, string> dictionary)
        {
            throw new NotImplementedException();
        }

        #endregion

        [Theory]
        [InlineData("en-US")]
        [InlineData("en-CA")]
        [InlineData("en-SG")]
        [InlineData("zh-CN")]
        [InlineData("tr-TR")]
        [InlineData("fi-FI")]
        public void should_translate_for_users_around_the_world(string cultureName)
        {
            CultureInfo.CurrentCulture = new CultureInfo(cultureName);
            const string userInput = "Advice, Surface, I";

            string translation = Translate(userInput, dictionary);

            Assert.Equal(
                "A proposal for an appropriate course of action; " +
                "The outer boundary of an artifact or a material layer constituting or resembling such a boundary; " +
                "A speaker or writer uses I to refer to himself or herself", 
                translation);
        }
    }
}