# MessageBoard

## .NET Core API For Adding And Retrieving Messages

## Notes

* Repository pattern used to make swapping out the implementation of the repository simple as well as improve testability.
* The repository has been mocked. Given the simple data structure, a NoSQL database such as dynamoDB might be suitable. Of course with the repository mocked it is volatile and so will be lost outsid of a session.
* As only one "table" is being used it would be overkill to utilise the UoW pattern.
* Still to do are the front end, though this is easily interchangable as data addition/requests are all through the RESTful API.
* As the board messages increase then paged retrieval might need to be introduced.
* Another consideration is notification of updates; just notify the user and let them update/refresh, or automatically. How to do this, polling, long polling, signalr is a nce wrapper for this capability.
* End user error return values also need to be implemented.