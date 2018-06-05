using System;
using System.Diagnostics.CodeAnalysis;

namespace DelegateVsEvent
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    class CreateUserEventArgs : EventArgs
    {
        public CreateUserEventArgs(Guid id, string name, int yearOfBirth)
        {
            Name = name;
            YearOfBirth = yearOfBirth;
            Id = id;
        }

        public string Name { get; }
        public int YearOfBirth { get; }
        public Guid Id { get; }
    }
}