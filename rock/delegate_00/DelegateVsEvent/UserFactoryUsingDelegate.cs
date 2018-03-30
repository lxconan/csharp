using System;

namespace DelegateVsEvent
{
    sealed class UserFactoryUsingDelegate : IUserFactory
    {
        public EventHandler<CreateUserEventArgs> UserCreated;

        public User CreateUser(string name, int yearOfBirth)
        {
            /*
             * It is easy for a C# application using event dispatching. You can use a delegate to
             * make it. Please implement the following method to pass the test. You are allowed to
             * modify the code within region. But adding additional namespace is allowed.
             *
             * Difficulty: Medium
             */
            
            #region Please modify the code to pass the test

            throw new NotImplementedException();
            
            #endregion
        }
    }
}