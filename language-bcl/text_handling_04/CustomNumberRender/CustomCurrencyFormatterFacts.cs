using Xunit;

namespace CustomNumberRender
{
    public class CustomCurrencyFormatterFacts
    {
        [Fact]
        public void should_format_currency()
        {
            var formatter = new CustomCurrencyFormatter();
            string number = formatter.Format(12222.34);

            Assert.Equal("¥1,2222.340", number);
        }

        [Fact]
        public void should_format_currency_rounded()
        {
            var formatter = new CustomCurrencyFormatter();
            string number = formatter.Format(12222.3456);

            Assert.Equal("¥1,2222.346", number);
        }
    }
}
