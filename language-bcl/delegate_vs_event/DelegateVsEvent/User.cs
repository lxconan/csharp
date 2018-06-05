using System;
using System.Diagnostics.CodeAnalysis;

namespace DelegateVsEvent
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    class User
    {
        public User(Guid id, string name, int yearOfBirth)
        {
            if (name == null) {throw new ArgumentNullException(nameof(name));}
            if (name.Length == 0) { throw new ArgumentException("Name cannot be empty");}
            if (yearOfBirth < 1900 || yearOfBirth > DateTime.UtcNow.Year)
            {
                throw new ArgumentOutOfRangeException(nameof(yearOfBirth)); 
            }
            
            Name = name;
            YearOfBirth = yearOfBirth;
            Id = id;
        }

        public Guid Id { get; }
        public string Name { get; }
        public int YearOfBirth { get; }
    }
}