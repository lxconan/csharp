# Questions

## Question 1: Explicit Cast

What will happen if we explicitly cast an enum value to a integral type that is not the actual underlying integer type. And why?

```csharp
static int GetIntegeralValue(Enum value)
{
    return (int)(object)value;
}
```

## Question 2: Underlying Type

Can you get the actual underlying type of the enum value? How to do that? Can you implement the method in the project using this approach?

## Question 3: `IConvertible`

Since the enum implements `IConvertible`, can you implement the method using this approach?

## Question 4: Compile type integeral

Does the program below contains syntax error or runtime error?

```csharp
public enum BorderSides { Left=1, Right=2, Top=4, Bottom=8 }
...
BorderSides b = BorderSides.Left;
b += 1234;
```

So why?

## Question 5: Runtime type

The enum is treated as integer value by compiler, but why it contains type information at runtime?

```csharp
[Flags] public enum BorderSides { Left=1, Right=2, Top=4, Bottom=8 }
...
Console.WriteLine (BorderSides.Right.ToString());        // Right
Console.WriteLine (BorderSides.Right.GetType().Name);    // BorderSides
```