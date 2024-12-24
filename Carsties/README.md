# dotnet commands
* dotnet info
* dotnet new list
* dotnet new sln
* docker compose up -d
* dotnet new webapi -o src/AuctionService -controllers
* dotnet sln add src/AuctionService
* dotnet tool list -g
* dotnet ef migrations add "InitialCreate" -o Data/Migrations
* dotnet ef database update   
* dotnet ef database drop        

# **Search Service**

* .NET web api
* Mongo DB
* Service bus - rabbitMQ

# Nuget Packages

Automapper
Microsoft.Extensions.Http.Polly
MongoDB.Entities
MassTransit.RabbitMQ


## **Search Service Specification**

## Infrastructure
- .Net Web API
- Mongo DB
- Service Bus - RabbitMQ

## Nuget Packages
- AutoMapper.Extensions.Microsoft.DependancyInjection
- Microsoft.Extensions.Http.Polly
- MongoDB.Entities
- MassTransit.RabbitMQ

## Queries handled
- Search - Gets a paged list of auctions based on query params.   Returns list of Item

## Events consumed
**AuctionService.AuctionCreated** - When an auction has been created in the
AuctionService

**AuctionService.AuctionUpdated** - When an auction has been created in the
AuctionService

**AuctionService.AuctionDeleted** - When an auction has been deleted in the
AuctionService

**BidService.AuctionFinished** - When an auction has reached it’s AuctionEnd
date/time

**BidService.BidPlaced** - When a bid has been placed in the BidService

## API Endpoints
GET
api/search?query 

Get paged list of auctions based on query params (searchTerm, pageSize, pageNumber, seller, winner, orderBy, filterBy)

## Models

**Item**

| Property Name    | Property Type | Default Value |
|------------------|---------------|---------------|
| Id               | Guid          |               |
| CreatedAt        | DateTime      |               |
| UpdatedAt        | DateTime      |               |
| AuctionEnd       | DateTime      |               |
| Seller           | string        |               |
| Winner           | string        |               |
| Make             | string        |               |
| Model            | string        |               |
| Year             | int           |               |
| Color            | string        |               |
| Mileage          | int           |               |
| ImageUrl         | string        |               |
| Status           | string        |               |
| ReservePrice     | int           |               |
| SoldAmount?      | int           |               |
| CurrentHighBid?  | int           |               |


## Event Consumed Types

### AuctionCreated

| Property Name    | Property Type | Default Value |
|------------------|---------------|---------------|
| Id               | Guid          |               |
| CreatedAt        | DateTime      |               |
| UpdatedAt        | DateTime      |               |
| AuctionEnd       | DateTime      |               |
| Seller           | string        |               |
| Winner           | string        |               |
| Make             | string        |               |
| Model            | string        |               |
| Year             | int           |               |
| Color            | string        |               |
| Mileage          | int           |               |
| ImageUrl         | string        |               |
| Status           | string        |               |
| ReservePrice     | int           |               |
| SoldAmount?      | int           |               |
| CurrentHighBid?  | int           |               |


### Auction Updated

| Property Name | Property Type | Default Value |
|---------------|---------------|---------------|
| Make          | string        |               |
| Model         | string        |               |
| Color         | string        |               |
| Mileage       | int           |               |
| Year          | int           |               |

### Auction Deleted

| Property Name | Property Type | Default Value |
|---------------|---------------|---------------|
| Id            | string        |               |

### Auction Finished

| Property Name | Property Type | Default Value |
|---------------|---------------|---------------|
| ItemSold      | boolean       |               |
| AuctionId     | string        |               |
| Winner        | string        |               |
| Seller        | string        |               |
| Amount?       | int           |               |

### Bid Placed

| Property Name | Property Type | Default Value |
|---------------|---------------|---------------|
| Id            | string        |               |
| AuctionId     | string        |               |
| Bidder        | string        |               |
| BidTime       | date/time     |               |
| Amount        | int           |               |
| BidStatus     | string        |               |


*  dotnet new webapi -o src/SearchService -controllers
*  dotnet sln add src/SearchService

## Modify launchSettings.json under properties folder.
```json
  {
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "launchUrl": "swagger",
      "applicationUrl": "http://localhost:7002",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```
* Install MongoDB.Entities
* Install Automapper, version 13+ includes dependency injection extensions with the main package.

* Add mongo to the yml 
```yaml
services:
  postgres:
    image: postgres
    environment:
      - POSTGRES_PASSWORD=postgrespw
    ports:
      - 5432:5432
    volumes:
      - pgdata:/var/lib/postgresql/data
  mongodb:
    image: mongo
    environment:
        - MONGO_INITDB_ROOT_USERNAME=root
        - MONGO_INITDB_ROOT_PASSWORD=mongopw
    ports:
      - 27017:27017
        
volumes:
  pgdata:
  
  
```
Once all changes have been made to controller and services, run the following command to build the docker image and run the container.

If after deleting the container the data is not being deleted from the database, you can remove the volume and recreate it with the following command:

`docker volume rm carsties_mongodata`

```shell
docker-compose up -d
[+] Running 2/2
✔ Container carsties-mongodb-1   Started                                                                                                                                                                                  0.6s
✔ Container carsties-postgres-1  Running                                                                                                                                                                                  0.0s
bash-5.2$ docker volume list
DRIVER    VOLUME NAME
local     abb0372dc6b6621223b5c00359f14489cc5e2599bd3f165aab09e287008474b4
local     carsties_mongodata
local     carsties_pgdata
bash-5.2$ docker volume rm carsties_mongodata
Error response from daemon: remove carsties_mongodata: volume is in use - [3fad3cd151778eddd5d0ef64771d47274ecc940998292a066ce9dc821cfba33a]
bash-5.2$ docker volume rm carsties_mongodata
carsties_mongodata
bash-5.2$ docker-compose up -d
[+] Running 3/3
✔ Volume "carsties_mongodata"    Created                                                                                                                                                                                  0.0s
✔ Container carsties-mongodb-1   Started                                                                                                                                                                                  0.6s
✔ Container carsties-postgres-1  Running      
```


```javascript
 Carsties   main ≡  ?1 ~5    dotnet new classlib -o src/Contracts
The template "Class Library" was created successfully.

Processing post-creation actions...
Restoring /Users/oscarlagatta/Documents/sandbox/demo/Carsties/src/Contracts/Contracts.csproj:
  Determining projects to restore...
  Restored /Users/oscarlagatta/Documents/sandbox/demo/Carsties/src/Contracts/Contracts.csproj (in 27 ms).
Restore succeeded.


  Carsties   main ≡  ?2 ~5    dotnet sln add src/Contracts

Project `src/Contracts/Contracts.csproj` added to the solution.
  Carsties   main ≡  ?2 ~6    
  Carsties   main ≡  ?2 ~6    cd src   
  src   main ≡  ?2 ~6    cd AuctionService 
  AuctionService   main ≡  ?2 ~6    dotnet add reference ../../src/Contracts 
Reference `..\Contracts\Contracts.csproj` added to the project.
  AuctionService   main ≡  ?2 ~6    cd ..
  src   main ≡  ?2 ~6    cd SearchService 
  SearchService   main ≡  ?2 ~6    dotnet add reference ../../src/Contracts
Reference `..\Contracts\Contracts.csproj` added to the project.


```