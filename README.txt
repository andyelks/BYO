My solution is separated into a few different projects

OWT - Angular web app, very simple single page application.  Makes a http post request from the flightSearch service to retrieve flight options.  Some required validation is setup for from and to input boxes but that is it.

BYOJetApi - .Net WebApi project.  This project provides the Flight search endpoint that the OWT project uses.  
Created FlightSearchController that exposes a post  method to receive flight search requests.  

BYOJetServiceLayer - class library that contains the core of the implementation.  Split into a separate project so
other middleware projects or solutions can also make use of the lower level core code and interfaces.

FlightSearchController uses Autofac Dependency Injection to register the search implementation it is going to use at construction.  All flight search implementations must adhere to the 
IFlightSearch contract.  App Setting in web.config enables you to switch between the 2 flight search implementations.
I also created a IDataLayer contract that both the mock and sql implementations will implement.  I am using the mock implementation because I have not implemented the sql implementation.

Test projects are in the Test folder, created a test project both the service layer and API.  Just one or two test methods implemented in each.  I would in a real application implement a lot more unit tests.

NUGet package manager used to add Autofac and other project packages.

Thanks.
