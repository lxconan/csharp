using System;
using System.IO;
using System.Text;

namespace ConsoleRedirector
{
    public class ConsoleStatWriter : TextWriter
    {
        // In this test this property is actually non-sense for us.
        public override Encoding Encoding { get; } = Encoding.Unicode;

        
        /*
         * In this practice, we will write a statistics writer. Which is a writer that actually do
         * statistics on line breaks rather than write text to memory or files. We define a line
         * break is either \r, \n or \r\n.
         *
         * You can add fields or override methods within the region. But you cannot change the
         * signature of existing members.
         *
         * Note that the test may takes minutes to run. The project will be compiled with
         * optimization turned on even in debug mode.
         *
         * Difficulty: Medium
         */
        
        public int Lines
        {
            get
            {
                #region Please implement this property to get total lines
                
                throw new NotImplementedException();
                
                #endregion
            }
        }

        #region Please add your logic to pass the test
        
        #endregion
    }
}