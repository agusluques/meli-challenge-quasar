# Meli Challenge - Fuego de Quasar
---
* [Quick start](#quick-start)
* [Endpoints](#endpoints)
    * POST /api/topsecret
    * POST /api/topsecret_split
    * GET /api/topsecret_split
* [Implementation details](#implementation-details)
* [Libraries](#libraries)
* [Code smells and assumptions](#code-smells-and-assumptions)
* [TODO](#todo)

### Quick start
---
- **Run it locally**
    - Pre-requisites:
        - [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)    
    - Simply run `dotnet run` from the root or use Visual Studio
    - Go to https://localhost:5001/swagger/index.html to see available endpoints

- **Deployed app**
    - Go to https://fuegodequasarmeli.azurewebsites.net/swagger/index.html to see available endpoints

### Endpoints
---
#### POST /api/topsecret
    
```json
{
    "satellites": [
        {
            "name": "kenobi",
            "distance": 100.0,
            "message": ["este", "", "", "mensaje", ""]
        },
        {
            "name": "skywalker",
            "distance": 115.5,
            "message": ["", "es", "", "", "secreto"]
        },
        {
            "name": "sato",
            "distance": 142.7,
            "message": ["este", "", "un", "", ""]
        }
    ]
}
```
    
#### POST /api/topsecret_split

```json
{
    "satellite": {
        "name": "kenobi",
        "distance": 100.0,
        "message": ["este", "", "", "mensaje", ""]
    }
}
```
    
:information_source: *Note: I decided not to follow the challenge instructions because I consider that a `POST /api/topsecret_split/{id}` **does not** respect REST protocol.*

#### GET /api/topsecret_split

:information_source: *Note: I decided to delete satellites information when this endpoint call is finished for testing purposes.*

### Implementation details
---
#### Architecture
I decided to use the [Vertical Slice Architecture](https://jimmybogard.com/vertical-slice-architecture/) with [CQRS pattern](https://martinfowler.com/bliki/CQRS.html) instead of clean (or 'onion') architecture.

![alt vertical slice architecture](https://jimmybogardsblog.blob.core.windows.net/jimmybogardsblog/3/2018/Picture0030.png)
*Verical Slice Architecture*

![alt vertical slice architecture](https://martinfowler.com/bliki/images/cqrs/cqrs.png)
*CQRS*

#### Libraries

- [MediatR](https://www.nuget.org/packages/MediatR/) (v9.0.0): For implementing Mediator pattern.
- [AutoMapper](https://www.nuget.org/packages/AutoMapper/) (v10.1.1): For mapping objects.
- [Entity Framework Core](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/) (v5.0.2): For managing object-database operations. Used 'InMemory' database for testing purpose.
- [FluentValidation](https://www.nuget.org/packages/FluentValidation/) (v9.4.0): For validating query and commands requests.
- [Swashbuckle](https://www.nuget.org/packages/Swashbuckle.AspNetCore/) (v5.6.3): For generation SwaggerUI.
- [StyleCop.Analyzers](https://www.nuget.org/packages/StyleCop.Analyzers/1.1.118) (v1.1.118): For coding style analysis.

#### Code smells and assumptions

- As the instructions ask to implement a `GetLocation` method which receives **only** an array of distances, I can only assume that the satellites are known and the order of them is also known.
- I assume that the messages' gap is only at the beginning.

#### TODO

- Unit tests and integration test (maybe using SpecFlow)
