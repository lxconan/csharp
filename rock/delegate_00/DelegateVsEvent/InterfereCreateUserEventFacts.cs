using System;
using Xunit;

namespace DelegateVsEvent
{
    public class InterfereCreateUserEventFacts
    {
        [Fact]
        void should_dispatch_create_user_event()
        {
            var factory = new UserFactoryUsingDelegate();

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

        [Fact]
        void should_interfere_subscribers()
        {
            var factory = new UserFactoryUsingDelegate();

            bool invoked = false;
            factory.UserCreated += (o, e) => { invoked = true; };

            factory.UserCreated(null, null);

            Assert.True(invoked);
        }
    }
}