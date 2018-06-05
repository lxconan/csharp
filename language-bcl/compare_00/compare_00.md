# Questions

## Question 1: Other comparison method

Do you know other ways to compare objects except for the `IComparable` interface? When is suitable to use that approach?

> You can overload `<` and `>` operators.
>
> The `<` and `>` operators are more specialized, and they are intended mostly for numeric types. Because they are statically resolved, they can translate to highly effi‐ cient bytecode, suitable for computationally intensive algorithms.

## Question 2: Rule

What is the rule of the `IComparable` or `IComparable<T>` interface?

> * If a comes after b, a.CompareTo(b) returns a positive number.
> * If a is the same as b, a.CompareTo(b) returns 0.
> * If a comes before b, a.CompareTo(b) returns a negative number.
>
> Please note that it is "comes before/after" rather than "greater/smaller than".

## Question 3: Equality vs. Comparison

What is the difference between `Equals` and `IComparable`.

> Equality can be “fussier” than comparison, but not vice versa (violate this and sorting algorithms will break). So, CompareTo can say “All objects are equal” while Equals says “But some are more equal than others!” 
> A great example of this is System.String. String’s `Equals` method and `==` operator use ordinal comparison, which compares the Unicode point values of each character. Its `CompareTo` method, however, uses a less fussy culture-dependent comparison. On most computers, for instance, the strings `ṻ` and `ǖ` are different according to `Equals`, but the same according to `CompareTo`.

## Question 4: How to ensure Comparison consistancy

How to make sure that the `CompareTo` methods is compatible with `Equals`, which is, equality can be “fussier” than comparison.