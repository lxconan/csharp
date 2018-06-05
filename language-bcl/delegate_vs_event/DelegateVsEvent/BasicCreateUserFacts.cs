using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace DelegateVsEvent
{
    public class BasicCreateUserFacts
    {
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static IEnumerable<object[]> UserFactories => 
            new []
            {
                new object[] {new UserFactoryUsingDelegate()},
                new object[] {new UserFactoryUsingEvents()}
            };

        [Theory]
        [MemberData(nameof(UserFactories))]
        void should_create_user(IUserFactory factory)
        {
            User user = factory.CreateUser("User Name", 1980);
            
            Assert.True(user.Id != Guid.Empty);
            Assert.Equal("User Name", user.Name);
            Assert.Equal(1980, user.YearOfBirth);
        }

        [Theory]
        [MemberData(nameof(UserFactories))]
        void should_throw_if_name_is_not_provided(IUserFactory factory)
        {
            Assert.Throws<ArgumentNullException>(() => factory.CreateUser(null, 1980));
        }
        
        [Theory]
        [MemberData(nameof(UserFactories))]
        void should_throw_if_name_is_empty(IUserFactory factory)
        {
            Assert.Throws<ArgumentException>(() => factory.CreateUser(string.Empty, 1980));
        }

        [Theory]
        [MemberData(nameof(UserFactories))]
        void should_throw_if_year_of_birth_is_out_of_range(IUserFactory factory)
        {
            int[] outOfRangeYears = {1899, DateTime.UtcNow.Year + 1};
            foreach (int outOfRangeYear in outOfRangeYears)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                    factory.CreateUser("name", outOfRangeYear));
            }
        }
    }
}