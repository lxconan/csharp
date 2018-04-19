# Questions

## Question 1: Bad designed API

It seems that the API of getting switches in `AppContext` class is of a bad design. Could you please provide a good one?

> Ironically, the design of TryGetSwitch illustrates how not to write APIs. The out parameter is unnecessary, and the method should instead return a nullable bool whose value is true, false, or null for undefined. This would then enable the following use:

```csharp
bool switchValue = AppContext.GetSwitch ("...") ?? false;
```

## Question 2: Feature toggle

What is a good feature toggling solution.

* Feature toggle at API level (just like what we have done in our test).
* Feature toggle inside the member implementation.