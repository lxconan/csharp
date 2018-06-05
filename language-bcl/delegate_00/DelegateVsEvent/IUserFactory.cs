namespace DelegateVsEvent
{
    interface IUserFactory
    {
        User CreateUser(string name, int yearOfBirth);
    }
}