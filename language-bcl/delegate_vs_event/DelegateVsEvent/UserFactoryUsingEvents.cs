using System;
using System.Collections.Generic;

#pragma warning disable 67

namespace DelegateVsEvent
{
    sealed class UserFactoryUsingEvents : IUserFactory
    {
        public event EventHandler<CreateUserEventArgs> UserCreated;
        readonly List<string> eventLogs = new List<string>();

        public User CreateUser(string name, int yearOfBirth)
        {
            /*
             * It is easy for a C# application using event dispatching. You can use an event to
             * make it. Please implement the following method to pass the test. You are allowed to
             * modify the code within region. But adding additional namespace is allowed.
             *
             * Difficulty: Medium
             */
            
            #region Please modify the code to pass the test

            throw new NotImplementedException();
            
            #endregion
        }

        public IReadOnlyCollection<string> EventLogs => eventLogs.AsReadOnly();
    }
}