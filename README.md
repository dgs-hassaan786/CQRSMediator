# CQRSMediator
This is a very basic implementation of the CQRS along with the mediator. We are going to learn about the stuff like why to use, what is the purpose and how to implement.

# What is a CQRS
CQRS is a architectural pattern which describes the responsibilities segregation/separation of a command or a query?

# What is a Command
Any operation which has a direct reflect on the state of the object is a command. A Command is a void in nature and could be an insert, or an update or a delete action.

# What is a Query
Query is any operation which only access the object rather than modifying it or has no effect on the state of the object. It could be a select action.

# What structure is being followed here?
The pure CQRS could be implemented via Event Registration and Handlers, but here we are using a Mediator pattern via Mediatr implementation which provides us interfaces of IRequest and IRequestHandler. 

If you go through the initial commits then you will find the repository pattern implementation. We have used Repositories as a service for the Queries and Command.

# CouchBase as DB
We are using the CouchBase as a database provider. In the coming series we will configure multiple data sources.
