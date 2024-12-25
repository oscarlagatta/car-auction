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


```bash
Carsties
dotnet new classlib -o src/Contracts
The template "Class Library" was created successfully.
Processing post-creation actions...
Restoring /Users/oscarlagatta/Documents/sandbox/demo/Carsties/src/Contracts/Contracts.csproj:
Determining projects to restore...
Restored /Users/oscarlagatta/Documents/sandbox/demo/Carsties/src/Contracts/Contracts.csproj (in 27 ms).
Restore succeeded.

Carsties
dotnet sln add src/Contracts
Project `src/Contracts/Contracts.csproj` added to the solution.

Carsties
cd src
cd AuctionService
dotnet add reference ../../src/Contracts
Reference `..\Contracts\Contracts.csproj` added to the project.

cd ..
cd SearchService
dotnet add reference ../../src/Contracts
Reference `..\Contracts\Contracts.csproj` added to the project.

```
## Identity Server

### Creating the Identity Server Project
Identity server used to be open source and free, but since the project become a full time job for the developers 
no longer can be used for free. Now is a commercial product with different tiers. But there is a community edition
that we do not need a license for evaluation, development, test environments, or personal projects.
Simply ignore the startup warning message, it will not constrain the server application. 

We need to install Duende.IdentityServer.Templates the templates.

`dotnet new --install Duende.IdentityServier.Templates`

Identity Server doesn't have support for storing user, but it does has support for adding ASP.NET identity, which
uses Entity Framework to create a user store for us to use and there'll be several tables for users, roles and claims.


When we run the following `dotnet new --install Duende.IdentityServier.Templates` doesn't really matter where we run, 
but we do it at the solution level. This will install 6 templates we can use to CREATE A NEW PROJECT.

The one we are interested is the one that comes with ASP.NET Core Identity, called ISASPID. We create then a project with 
that template

`dotnet new isaspid -o src/IdentityService`

I will ask us if we want to run a seed method which will provide a couple of users to our database. 
But in our case we pressed `N` and pressed return. 

So then it is easy to manage, we can add this project to the solution, so we can see the IdentityService 
in our list of projects inside the solution explorer.

`dotnet sln add src/IdentityService`

### Reviewing and configuring IdentityService project.

We then take a look at the csproj file of the project, we make sure we are using net8.0 and the other packages are
compatible. 
By default uses SqlLite, but we removed it and added `PostgreSQL` package using Nuget.



```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

	<PropertyGroup>
		<TargetFramework>net8.0</TargetFramework>
		<ImplicitUsings>enable</ImplicitUsings>
		<Nullable>enable</Nullable>
	</PropertyGroup>

	<ItemGroup>
		<PackageReference Include="Duende.IdentityServer.AspNetIdentity" Version="7.0.4" />

		<PackageReference Include="Microsoft.AspNetCore.Authentication.Google" Version="8.0.3" />

		<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="8.0.11" />
		<PackageReference Include="Serilog.AspNetCore" Version="8.0.0" />

		<PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="8.0.3" />
		<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="8.0.3" />
		<PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="8.0.3" />
		<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.3" />
	</ItemGroup>
</Project>
```
In launchSettings.json we change from http to https and localhost:5000, but we do this because the complexity of using
SSL with docker means that we don't want to mess around with SSL for any of our internal services for what we are doing 
here, we can do, but it does add a level of complexity that's not included here.
We are going to have SSL going from our clients to Identity Server; but we will approach that in a different way than
having each service listening on SSL or Https internally, in that will effectively be our networked services.
They'll all going to be internal services, and we are going to have an ingress outside of these services that's going to 
provide external access into those services that's going to provide external access into those services.
And that's the point we are going to use SSL for.

```json
{
  "profiles": {
    "SelfHost": {
      "commandName": "Project",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      },
      "applicationUrl": "http://localhost:5000"
    }
  }
}
```

`There won't be insecure traffic going to and from our services from external`, but there will be insecure traffic on our
internal network that nobody else can get to anyway.

There is a `Models` folder, we have a single entity object for the application user, and this is deriving from identity user.
This is not identity service specific, this is comming from ASP.NET identity, and one of the more confusing aspects of what
we are doing is the overuse of this word.
Identity seems to be used anywhere, but the identity server, the Duende Identity Server, just think of that as an 
Identity Provider, and when it comes to ASP.NET IDENTITY consider that as a User Store and user Management feature.
Identity Provider is really responsible for the issuance of Tokens using the OAuth 2.0 and OpenID connect protocols.

We also have `Pages` folder and this provides the user interface that is used to allow users to log in to Identity Server.

As this project starts with a Migrations folder that has SQLite specific commands, then we need to remove the Migrations
folder entirely and create a new migration as follows

`dotnet ef migrations add "InitialCreate" -o Data/Migrations`

If for any reason you get a message saying that the Entity Framework tools is older than that of the runtime, you'd 
probably do the following

`dotnet tool update dotnet-ef -g`

After configuring Identity Server when I run I get the following error, 
`aspnetcore-browser-refresh.js:268 Refused to connect to 'wss://localhost:54628/' 
because it violates the following Content Security Policy directive: "default-src 'self'". 
Note that 'connect-src' was not explicitly set, so 'default-src' is used as a fallback.`

he error you're encountering is related to Content Security Policy (CSP), which is a browser feature designed 
to enhance the security of web applications by preventing certain actions (like connecting to untrusted sources). 
In this case, the websocket (wss://localhost:54628/) connection is being blocked because it's not allowed by 
your CSP configuration.
This issue often arises during development when live reload or browser refresh scripts 
(like aspnetcore-browser-refresh.js) attempt to connect using a WebSocket for hot-reloading purposes.

Understanding the Error
**Default CSP Rule**: The default-src 'self' directive means that your application can only load resources from its own origin 
(localhost in this case).
**Blocked WebSocket**: The WebSocket connection (wss://localhost:54628/) originates on a different port (54628), 
and as a result, gets blocked.

**_How to Fix It_**
You need to explicitly allow WebSocket connections in your Content Security Policy (CSP) configuration. 
Here's how you can resolve this issue:

1. **Option 1:** Modify CSP to Allow WebSocket Connections
   Update your application to include a connect-src directive in the CSP policy to allow WebSocket connections on your development server.
2. If you're configuring CSP in the ASP.NET Core Startup.cs or Program.cs, locate the code where CSP headers are added 
   (or install a tool like NWebsec if you're directly managing CSP headers).
   Update CSP to allow wss:// connections on localhost:
```csharp
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Security-Policy",
        "default-src 'self'; connect-src 'self' wss://localhost:54628;"); // Allow the WebSocket connection
    await next();
});

app.MapControllers();

app.Run();
```
**_Explanation_**:
The connect-src directive specifically governs WebSocket, EventSource, and XMLHttpRequest connections.
Adding wss://localhost:54628 allows WebSocket connections to your hot-reload service.
