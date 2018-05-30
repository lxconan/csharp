using System.Diagnostics.CodeAnalysis;
using System.Text;
using basic.Common;
using Xunit;

namespace basic
{
    public class Disposable
    {
        [Fact]
        [SuppressMessage("ReSharper", "UseNullPropagation")]
        public void should_call_dispose_anyway_using_try_finally()
        {
            var tracer = new StringBuilder();
            DisposableWithTracingDemoClass demoDisposable = null;

            try
            {
                demoDisposable = new DisposableWithTracingDemoClass(tracer);
            }
            finally
            {
                if (demoDisposable != null)
                {
                    demoDisposable.Dispose();
                }
            }

            // change variable value to fix test.
            const string expectedTracingMessage = "";

            Assert.Equal(expectedTracingMessage, tracer.ToString());
        }

        [Fact]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public void should_use_using_statement_for_simplicity()
        {
            var tracer = new StringBuilder();

            using (var demoDisposable = new DisposableWithTracingDemoClass(tracer))
            {
                // blah, blah, ...
            }

            // change the variable value to fix the test.
            const string expectedTracingMessage = "";

            Assert.Equal(expectedTracingMessage, tracer.ToString());
        }
    }
}