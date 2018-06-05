using System;

namespace AssemblyControlledByUs
{
    public class Parrot : IFlyable
    {
        internal int RandomId { get; } = new Random().Next();

        string IFlyable.Fly()
        {
            #region Please change the code here to pass the test
            
            throw new NotImplementedException();

            #endregion
        }

        #region You can add some code here if you want

        #endregion
    }
}