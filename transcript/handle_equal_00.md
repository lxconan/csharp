# Questions

## Question 1: Equality Checklist

If you want to modify the equality behavior of a type. What will you do?

## Question 2: Equality Complexity

For an object. There are multiple methods that are related to equality: `Equals()`, `IEquatable<T>`, `GetHashCode`, `==`/`!=`. Why there are so many different approaches?

## Question 3: Immutablility

For the date time offset you implemented. Why you calculate the hash code that way?

## Question 4: Hashing

Can you list the types that are related to `GetHashCode()` method? 

> For example. `Dictionary<,>`, `Hashtable`, `HashSet<T>`, `ConcurrentDictionary<,>`.

## Question 5: Do you know the default behaviors of `Equal`?

Do you know the default behaviors of `Equals`? Are the behaviors equal or different between value type and reference types.

> The default behavior of `Equals` are different between `class` and `struct`. 
>
> * Value types use value equality.
> * Reference types use referential equality.
> * A struct’s Equals method applies structural value equality by default (i.e., it compares each field in the struct).

## Question 6: Exceptions

Can you throw exception in the `Equals` method?

> The answer is no. Because the requirement of `object.Equals` should be:
>
> * An object cannot equal null (unless it’s a nullable type).
> * Equality is reflexive (an object equals itself).
> * Equality is commutative (if a.Equals(b), then b.Equals(a)).
> * Equality is transitive (if a.Equals(b) and b.Equals(c), then a.Equals(c)).
> * Equality operations are repeatable and reliable (they don’t throw exceptions).