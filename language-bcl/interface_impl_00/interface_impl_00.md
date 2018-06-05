# Questions

## Question 1: The best practice

**Can you summarize the best practice when you implementing an interface.**

Please mind that there are many ways to implement an interface. For example. You can explicitly implement an interface and you can implicitly implement interface. These conditions may be different.

Besides, You may put some consideration on the ownership of the code. What will you do if we can control both the interface and the derived classes. What will you do if we can only control the interface and base classes.

And the last what if you do not want to allow other to derive from your class.

## Question 2: What is the output

Suppose we have an interface:

```csharp
public interface IFlyable
{
  string Fly();
}
```

And we have a class that explicitly implements the interface:

```csharp
class Bird : IFlyable
{
  string IFlyable.Fly()
  {
    return "Bird.Fly()";
  }
}
```

If we have another class that inherit `Bird` but implements `IFlyable` at the same time.

```csharp
class Parrot : Bird, IFlyable
{
	string IFlyable.Fly()
	{
		return "Parrot.Fly() explicite";
	}
	
	public string Fly()
	{
		return "Parrot.Fly() implicite";
	}
}
```

So, what is the output of the following code:

```csharp
var parrot = new Parrot();
var bird = (Bird)new Parrot();

Console.WriteLine(parrot.Fly()); // Parrot.Fly() implicite
Console.WriteLine(((IFlyable)bird).Fly()); // Parrot.Fly() explicite
```

## Question 3: What is the output

Suppose we have an interface

```csharp
public interface IFlyable
{
	string Fly();
}
```

And we have the following implementations:

```csharp
class Bird : IFlyable
{
	public string Fly()
	{
		return "Bird.Fly()";
	}
}

class Parrot : Bird, IFlyable
{
	string IFlyable.Fly()
	{
		return "Parrot.Fly() explicite";
	}
}
```

So what is the output ofthe following code:

```csharp
var parrot = new Parrot();
var bird = (Bird)new Parrot();

Console.WriteLine(parrot.Fly()); // Bird.Fly()
Console.WriteLine(((IFlyable)bird).Fly()); // Parrot.Fly() explicite
```