# service-bus-config
Fiddling around with initializing service bus queues, topics and subscriptions

## Basic Idea
- POCO class that using Microsoft.Extensions.Configuration.Binding to read from a JSON file
- A single class with a single method that creates all queues/topics/subscriptions as necessary
- No attempt is made to clean up resources that are not longer in use, instead if they are unsed for a specific period of time Azure will delete them.

## TODO
- Handle all queue/topic/susbcription properties
- Validate the configuration class once it is hydrated to make sure it has all the necessary data that connot be defaulted.
- Unit Testing
- Repackaging - Currently there is just a console app here. I'd like to more the business logic and POCO into a class library and create some simple queue reader/writers and topic/publisher/subscriptes.
- 

## Questions
