using System;
using Xunit;

namespace DelegateVsEvent
{
    public class DispatchCreateUserEventFacts
    {
        [Fact]
        void should_dispatch_create_user_event()
        {
            var factory = new UserFactoryUsingEvents();

            string nameInEvent = null;
            int yearOfBirthInEvent = 0;
            Guid idInEvent = Guid.Empty;

            factory.UserCreated += (_, e) =>
            {
                nameInEvent = e.Name;
                yearOfBirthInEvent = e.YearOfBirth;
                idInEvent = e.Id;
            };
            
            User user = factory.CreateUser("name", 1990);
            
            Assert.Equal(user.Id, idInEvent);
            Assert.Equal(user.YearOfBirth, yearOfBirthInEvent);
            Assert.Equal(user.Name, nameInEvent);
        }
    }

    public class HandleInvokeExceptionFacts
    {   
        [Fact]
        void should_create_user_if_consumer_fails()
        {
            var factory = new UserFactoryUsingEvents();
            factory.UserCreated +=
                (o, e) => throw new ApplicationException("Something bad happend");
            factory.UserCreated += (o, e) => { };

            User user = factory.CreateUser("name", 1980);
            
            Assert.Equal("name", user.Name);
            Assert.Equal(1980, user.YearOfBirth);
            Assert.Equal(new [] {"Error: Something bad happend", "Success"}, factory.EventLogs);
        }
        
        [Fact]
        void should_create_user_if_consumer_fails_multiple_invoke()
        {
            var factory = new UserFactoryUsingEvents();
            factory.UserCreated +=
                (o, e) => throw new ApplicationException("Something bad happend");
            factory.UserCreated += (o, e) => { };

            factory.CreateUser("name", 1980);
            User user = factory.CreateUser("name", 1980);
            
            Assert.Equal("name", user.Name);
            Assert.Equal(1980, user.YearOfBirth);
            Assert.Equal(new [] {"Error: Something bad happend", "Success"}, factory.EventLogs);
        }
    }
}