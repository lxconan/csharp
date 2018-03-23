# Questions

## Question 1 (`IEnumerable`): Why iterator

Why do you think is necessary to process collection of elements in an iterative way. What is the advantage of the iterative processing and what is the advantage of the buffered processing.

## Question 2 (`IEnumerable`): Do I have to implement all the methods for an `IEnumerator`

An `IEnumerator<T>` interface is defined as follows:

```csharp
public interface IEnumerator
{
    object Current { get; }

    bool MoveNext();
    void Reset();
}
```

Which methods have to be implemented and which methods do not?

Do you know the usage of `Reset` method?

> The `Reset` method is provided for COM interop. It does not need to be implemented.

## Question 3 (`IEnumerable`): Is an `IEnumerable` immutable

If it is immutable, what *should* happen if an underlaying storage is changed when you are iterating with an `IEnumerator`?

## Question 4 (`IEnumerable`): Multiple enumeration

What is a multiple enumeration. What is the disadvantage of multiple enumeration. Could you provide a solution to multiple enumeration? In which condition does the solution works the best?

## Question 5 (`IEnumerable`): Streaming

Can you compare the way of data processing for `IEnumerable`, `Stream` and `TextReader`? 