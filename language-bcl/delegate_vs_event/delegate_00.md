# Questions

## Question 1: Multicast

You can do a multiple dispatch on event and delegate. So what is the default behavior when one of the subscriber throw an exception?

## Question 2: Delegate vs. Event

What are the differences between delegate and event? Can delegate implementation interfere subscribers? Can event implementation interfere subscribers?

Suppose you are making an event dispatching system, please list your design considerations.

## Question 3: Concurrency

What if your producer is called concurrently? How to invoke event in that case?

## Question 4: Subscribing / Unsubscribing behavior

How to change the default behavior when you are subscribing/unsubscribing event.