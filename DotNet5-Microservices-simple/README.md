# DotNet5-Microservices-simple

DotNet5 Microservices

## Keywords

DTO: An object carries the data between processes.

- [ApiController]
- [Route("items")]
- [HttpGet]
- [HttpGet("{id}")]
- [HttpPost]
- [HttpPut("{id}")]
- [HttpDelete("{id}")]

NoContent()

NotFound()

ActionResult

IActionResult

[Required]

[Range(0, 1000)]

MongoDB.Driver.IMongoCollection

MongoDB.Driver.FilterDefinitionBuilder

```
var mongoClient = new MongoClient("mongodb://localhost:27017");
var database = mongoClient.GetDatabase("Catalog");  // database name
dbCollection = database.GetCollection<Item>("items");    // table name
```

ControllerBase.CreatedAtAction

```
BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
```

local secrets

extract interface

https://localhost:5001/swagger/v1/swagger.json

import it to Postman!

Running common code from NuGet

Don't Repeat Yourself (DRY)

Microservices should be independent of each other

NuGet is the package manager for .Net

A NuGet package is a single ZIP file (.nupkg) that contains files to share with others

Set timouts for inter service communication

implement retries with exponential backoff

Performs call retries a certain number of times with a longer wait between each retry

implement the circuit breaker pattern

Microservices 2 communcation sytles:

Synchronous communcation style vs Asynchronous communcation style

In a distributed system, whenever a service makes a synchronous request to another service, there is an ever-present risk of partial failure.

We must design our services to be resilient to those partial failures.

A service client should be designed not to block indefinitely and use timeouts.

The recommended approach for retries with exponential backoff is to take advantage of more advanced .NET libraries like the open-source Polly library.

Polly is a .NET resilience and transient-fault-handling library that allows developers to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, Rate-limiting and Fallback in a fluent and thread-safe manner.

StartUp.cs

```
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<CatalogClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001");
            })
            .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(1));
```

Add a jitter strategy to the retry policy

A regular Retry policy can affect your system in cases of high concurrency and scalability and under high contention. To overcome peaks of similar retries coming from many clients in partial outages, a good workaround is to add a jitter strategy to the retry algorithm/policy. This strategy can improve the overall performance of the end-to-end system. As recommended in Polly: Retry with Jitter, a good jitter strategy can be implemented by smooth and evenly distributed retry intervals applied with a well-controlled median initial retry delay on an exponential backoff. This approach helps to spread out the spikes when the issue arises. The principle is illustrated by the following example:

```
var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(1), retryCount: 5);

var retryPolicy = Policy
    .Handle<FooException>()
    .WaitAndRetryAsync(delay);
```

Resource exhaustion

Using message broker in the Asynchronous communcation style

- Data in eventually consistent
- Preserves microservice autonomy
- Removes inter-service latency

Implement async communication with RabbitMQ

RabbitMQ is a ligheweught message broker that supports AMQP protocol

MassTransit is free software/open-source .NET-based Enterprise Service Bus software that helps .NET developers route messages over RabbitMQ, Azure Service Bus, SQS, and ActiveMQ service busses. It supports multicast, versioning, encryption, sagas, retries, transactions, distributed systems and other features.

KebabCaseEndpointNameFormatter

```
dbug: MassTransit.Registration.BusDepot[0]
      Starting bus instances: IBus
dbug: MassTransit[0]
      Starting bus: rabbitmq://localhost/
dbug: MassTransit[0]
      Connect: localhost:5672/
dbug: MassTransit[0]
      Connected: localhost:5672/ (address: amqp://localhost:5672, local: 55063)
```

RabbitMQ

http://localhost:15672

guest | guest

## Commands

```
cd C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src
dotnet new webapi -n Play.Catalog.Services
dotnet new webapi -n Play.Catalog.Services --framework net5.0
```

```
cd Play.Catalog.Services
dotnet build
```

```
cd Play.Catalog.Services
dotnet run
```

```
cd Play.Catalog.Services
dotnet dev-certs https --trust
```

```
https://localhost:5001/swagger/index.html
```

```
dotnet add package MongoDB.driver
```

```
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo
```

```
cd C:\Code\MyDotNet\DotNet5-Microservices-simple\
md Play.Common
cd Play.Common
md src
cd C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src
dotnet new classlib -n Play.Common --framework net5.0
```

```
dotnet new classlib -n Play.Common --uninstall
dotnet new classlib -n Play.Common --uninstall --force
```

```
cd C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common
dotnet add package MongoDB.Driver
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Binder
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet pack -o ..\..\..\packages\
```

```
cd C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog
dotnet nuget add source C:\Code\MyDotNet\DotNet5-Microservices-simple\packages -n PlayEconomy
```

```
dotnet nuget list source
```

```
dotnet nuget update source PlayEconomy
```

```
dotnet nuget remove source PlayEconomy
```

```
cd C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services
dotnet add package Play.Common
```

```
dotnet remove package Play.Common
```

```
dotnet list package
```

```
docker stop mongo
docker-compose up
```

```
cd C:\Code\MyDotNet\DotNet5-Microservices-simple\
md Play.Inventory
cd Play.Inventory
md src
cd src
dotnet new webapi -n Play.Inventory.Service
```

```
cd C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service
dotnet add package Play.Common
```

```
dotnet run
```

```
cd C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service
dotnet add package Microsoft.Extensions.Http.Polly
```

```
cd C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src>
dotnet new classlib -n Play.Catalog.Contracts
```

if created in error, just remove the folder and re-create.

```
cd C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Service
dotnet add reference ..\Play.Catalog.Contracts\Play.Catalog.Contracts.csproj
```

```
cd C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services
dotnet add package MassTransit.AspNetCore
dotnet add package MassTransit.RabbitMQ
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services>dotnet run
Building...
dbug: MassTransit.Registration.BusDepot[0]
      Starting bus instances: IBus
dbug: MassTransit[0]
      Starting bus: rabbitmq://localhost/
dbug: MassTransit[0]
      Connect: localhost:5672/
dbug: MassTransit[0]
      Connected: localhost:5672/ (address: amqp://localhost:5672, local: 55063)
info: MassTransit[0]
      Bus started: rabbitmq://localhost/
dbug: MassTransit[0]
      Endpoint Ready: rabbitmq://localhost/L113220_PlayCatalogServices_bus_inzoyy8jqzonzaedbdpynisbri?temporary=true
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services
```

```
cd C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common
dotnet add package MassTransit.AspNetCore
dotnet add package MassTransit.RabbitMQ
```

```
cd C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common
dotnet pack -p:PackageVersion=1.0.1 -o ..\..\..\packages\
```

```
cd C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service
dotnet add package Play.Catalog.Contracts
```

```

```

```

```

```

```

```

```

```

```

### Output

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src>dotnet new webapi -n Play.Catalog.Services
The template "ASP.NET Core Web API" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on Play.Catalog.Services\Play.Catalog.Services.csproj...
  Determining projects to restore...
  Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj (in 341 ms).
Restore succeeded.
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services>dotnet build
Microsoft (R) Build Engine version 16.8.0+126527ff1 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
  All projects are up-to-date for restore.
  Play.Catalog.Services -> C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\bin\Debug\net5.0\Play.Catalog.Services.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:03.29
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services>dotnet run
Building...
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services>dotnet dev-certs https --trust
Trusting the HTTPS development certificate was requested. A confirmation prompt will be displayed if the certificate was not previously trusted. Click yes on the prompt to trust the certificate.
A valid HTTPS certificate is already present.
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services>dotnet add package MongoDB.driver
  Determining projects to restore...
  Writing C:\Users\x239757\AppData\Local\Temp\tmpE3F9.tmp
info : Adding PackageReference for package 'MongoDB.driver' into project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj'.
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/mongodb.driver/index.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/mongodb.driver/index.json 157ms
info : Restoring packages for C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj...
info : Package 'MongoDB.driver' is compatible with all the specified frameworks in project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj'.
info : PackageReference for package 'MongoDB.driver' version '2.14.1' added to file 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj'.
info : Committing restore...
info : Writing assets file to disk. Path: C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\obj\project.assets.json
log  : Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj (in 305 ms).
```

Play.Catalog.Services.csproj

```
  <ItemGroup>
    <PackageReference Include="MongoDB.driver" Version="2.14.1" />
  </ItemGroup>
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src>dotnet new classlib -n Play.Common
The template "Class library" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on Play.Common\Play.Common.csproj...
  Determining projects to restore...
  Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Common\Play.Common.csproj (in 104 ms).
Restore succeeded.
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src>dotnet new classlib -n Play.Common --uninstall --force
The template "Class library" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on Play.Common\Play.Common.csproj...
  Determining projects to restore...
  All projects are up-to-date for restore.
Restore succeeded.
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common>dotnet add package MongoDB.Driver
  Determining projects to restore...
  Writing C:\Users\x239757\AppData\Local\Temp\tmp5D85.tmp
info : Adding PackageReference for package 'MongoDB.Driver' into project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj'.
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/mongodb.driver/index.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/mongodb.driver/index.json 138ms
info : Restoring packages for C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj...
info : Package 'MongoDB.Driver' is compatible with all the specified frameworks in project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj'.
info : PackageReference for package 'MongoDB.Driver' version '2.14.1' added to file 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj'.
info : Committing restore...
info : Writing assets file to disk. Path: C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\obj\project.assets.json
log  : Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj (in 166 ms).
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common>dotnet add package Microsoft.Extensions.Configuration
  Determining projects to restore...
  Writing C:\Users\x239757\AppData\Local\Temp\tmp4015.tmp
info : Adding PackageReference for package 'Microsoft.Extensions.Configuration' into project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj'.
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/microsoft.extensions.configuration/index.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/microsoft.extensions.configuration/index.json 423ms
info : Restoring packages for C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration/index.json 67ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration/6.0.0/microsoft.extensions.configuration.6.0.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration/6.0.0/microsoft.extensions.configuration.6.0.0.nupkg 33ms
info : Installing Microsoft.Extensions.Configuration 6.0.0.
info : Package 'Microsoft.Extensions.Configuration' is compatible with all the specified frameworks in project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj'.
info : PackageReference for package 'Microsoft.Extensions.Configuration' version '6.0.0' added to file 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj'.
info : Committing restore...
info : Writing assets file to disk. Path: C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\obj\project.assets.json
log  : Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj (in 698 ms).
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common>dotnet add package Microsoft.Extensions.Configuration.Binder
  Determining projects to restore...
  Writing C:\Users\x239757\AppData\Local\Temp\tmpB891.tmp
info : Adding PackageReference for package 'Microsoft.Extensions.Configuration.Binder' into project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj'.
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/microsoft.extensions.configuration.binder/index.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/microsoft.extensions.configuration.binder/index.json 434ms
info : Restoring packages for C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration.binder/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration.binder/index.json 207ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration.binder/6.0.0/microsoft.extensions.configuration.binder.6.0.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration.binder/6.0.0/microsoft.extensions.configuration.binder.6.0.0.nupkg 64ms
info : Installing Microsoft.Extensions.Configuration.Binder 6.0.0.
info : Package 'Microsoft.Extensions.Configuration.Binder' is compatible with all the specified frameworks in project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj'.
info : PackageReference for package 'Microsoft.Extensions.Configuration.Binder' version '6.0.0' added to file 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj'.
info : Committing restore...
info : Writing assets file to disk. Path: C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\obj\project.assets.json
log  : Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj (in 755 ms).
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common>
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common>dotnet add package Microsoft.Extensions.DependencyInjection
  Determining projects to restore...
  Writing C:\Users\x239757\AppData\Local\Temp\tmp41B6.tmp
info : Adding PackageReference for package 'Microsoft.Extensions.DependencyInjection' into project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj'.
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/microsoft.extensions.dependencyinjection/index.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/microsoft.extensions.dependencyinjection/index.json 534ms
info : Restoring packages for C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.dependencyinjection/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.dependencyinjection/index.json 626ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.dependencyinjection/6.0.0/microsoft.extensions.dependencyinjection.6.0.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.dependencyinjection/6.0.0/microsoft.extensions.dependencyinjection.6.0.0.nupkg 232ms
info : Installing Microsoft.Extensions.DependencyInjection 6.0.0.
info : Package 'Microsoft.Extensions.DependencyInjection' is compatible with all the specified frameworks in project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj'.
info : PackageReference for package 'Microsoft.Extensions.DependencyInjection' version '6.0.0' added to file 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj'.
info : Committing restore...
info : Writing assets file to disk. Path: C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\obj\project.assets.json
log  : Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj (in 2.03 sec).
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common>dotnet pack -o ..\..\..\packages\
Microsoft (R) Build Engine version 16.8.0+126527ff1 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
  All projects are up-to-date for restore.
  Play.Common -> C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\bin\Debug\net5.0\Play.Common.dll
  Successfully created package 'C:\Code\MyDotNet\DotNet5-Microservices-simple\packages\Play.Common.1.0.0.nupkg'.
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\packages>dir
 Volume in drive C is L113220
 Volume Serial Number is E8F0-3AB6

 Directory of C:\Code\MyDotNet\DotNet5-Microservices-simple\packages

07/03/2022  08:27 PM    <DIR>          .
07/03/2022  08:27 PM    <DIR>          ..
07/03/2022  08:27 PM             8,698 Play.Common.1.0.0.nupkg
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog>dotnet nuget add source C:\Code\MyDotNet\DotNet5-Microservices-simple\packages -n PlayEconomy
Package source with Name: PlayEconomy added successfully.
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services>dotnet add package Play.Common
  Determining projects to restore...
  Writing C:\Users\x239757\AppData\Local\Temp\tmpB9BD.tmp
info : Adding PackageReference for package 'Play.Common' into project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj'.
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/play.common/index.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/play.common/index.json 525ms
info : Restoring packages for C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj...
info : Installing Play.Common 1.0.0.
info : Package 'Play.Common' is compatible with all the specified frameworks in project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj'.
info : PackageReference for package 'Play.Common' version '1.0.0' added to file 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj'.
info : Committing restore...
info : Writing assets file to disk. Path: C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\obj\project.assets.json
log  : Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj (in 213 ms).
```

Play.Catalog.Service.csproj

```
  <ItemGroup>
    ...
    <PackageReference Include="Play.Common" Version="1.0.0" />
    ...
  </ItemGroup>
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog>dotnet nuget list source
Registered Sources:
  1.  nuget.org [Enabled]
      https://api.nuget.org/v3/index.json
  2.  PlayEconomy [Enabled]
      C:\Code\MyDotNet\DotNet5-Microservices-simple\packages
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog>dotnet nuget update source PlayEconomy
Package source "PlayEconomy" was successfully updated.
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services>dotnet remove package Play.Common
info : Removing PackageReference for package 'Play.Common' from project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj'.
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\packages>dotnet nuget remove source PlayEconomy
Package source with Name: PlayEconomy removed successfully.
```

```

C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Infra>docker-compose up
[+] Running 3/3
 - Network playinfra_default       Created                                                                                                                              0.1s
 - Volume "playinfra_mongodbdata"  Created                                                                                                                              0.0s
 - Container mongo                 Created                                                                                                                              0.2s
Attaching to mongo
mongo  | {"t":{"$date":"2022-03-08T02:15:44.039+00:00"},"s":"I",  "c":"NETWORK",  "id":4915701, "ctx":"-","msg":"Initialized wire specification","attr":{"spec":{"incomingExternalClient":{"minWireVersion":0,"maxWireVersion":13},"incomingInternalClient":{"minWireVersion":0,"maxWireVersion":13},"outgoing":{"minWireVersion":0,"maxWireVersion":13},"isInternalClient":true}}}
mongo  | {"t":{"$date":"2022-03-08T02:15:44.044+00:00"},"s":"I",  "c":"CONTROL",  "id":23285,   "ctx":"main","msg":"Automatically disabling TLS 1.0, to force-enable TLS 1.0
specify --sslDisabledProtocols 'none'"}
mongo  | {"t":{"$date":"2022-03-08T02:15:44.046+00:00"},"s":"W",  "c":"ASIO",     "id":22601,   "ctx":"main","msg":"No TransportLayer configured during NetworkInterface startup"}
mongo  | {"t":{"$date":"2022-03-08T02:15:44.048+00:00"},"s":"I",  "c":"NETWORK",  "id":4648601, "ctx":"main","msg":"Implicit TCP FastOpen unavailable. If TCP FastOpen is required, set tcpFastOpenServer, tcpFastOpenClient, and tcpFastOpenQueueSize."}
mongo  | {"t":{"$date":"2022-03-08T02:15:44.068+00:00"},"s":"W",  "c":"ASIO",     "id":22601,   "ctx":"main","msg":"No TransportLayer configured during NetworkInterface startup"}
mongo  | {"t":{"$date":"2022-03-08T02:15:44.069+00:00"},"s":"I",  "c":"REPL",     "id":5123008, "ctx":"main","msg":"Successfully registered PrimaryOnlyService","attr":{"service":"TenantMigrationDonorService","ns":"config.tenantMigrationDonors"}}
mongo  | {"t":{"$date":"2022-03-08T02:15:44.069+00:00"},"s":"I",  "c":"REPL",     "id":5123008, "ctx":"main","msg":"Successfully registered PrimaryOnlyService","attr":{"service":"TenantMigrationRecipientService","ns":"config.tenantMigrationRecipients"}}
mongo  | {"t":{"$date":"2022-03-08T02:15:44.069+00:00"},"s":"I",  "c":"CONTROL",  "id":5945603, "ctx":"main","msg":"Multi threading initialized"}
mongo  | {"t":{"$date":"2022-03-08T02:15:44.071+00:00"},"s":"I",  "c":"CONTROL",  "id":4615611, "ctx":"initandlisten","msg":"MongoDB starting","attr":{"pid":1,"port":27017,"dbPath":"/data/db","architecture":"64-bit","host":"3a04ba216a0a"}}
mongo  | {"t":{"$date":"2022-03-08T02:15:44.072+00:00"},"s":"I",  "c":"CONTROL",  "id":23403,   "ctx":"initandlisten","msg":"Build Info","attr":{"buildInfo":{"version":"5.0.6","gitVersion":"212a8dbb47f07427dae194a9c75baec1d81d9259","openSSLVersion":"OpenSSL 1.1.1f  31 Mar 2020","modules":[],"allocator":"tcmalloc","environment":{"distmod":"ubuntu2004","distarch":"x86_64","target_arch":"x86_64"}}}}
mongo  | {"t":{"$date":"2022-03-08T02:15:44.072+00:00"},"s":"I",  "c":"CONTROL",  "id":51765,   "ctx":"initandlisten","msg":"Operating System","attr":{"os":{"name":"Ubuntu","version":"20.04"}}}
mongo  | {"t":{"$date":"2022-03-08T02:19:45.228+00:00"},"s":"I",  "c":"STORAGE",  "id":22430,   "ctx":"Checkpointer","msg":"WiredTiger message","attr":{"message":"[1646705985:228710][1:0x7faa638b0700], WT_SESSION.checkpoint: [WT_VERB_CHECKPOINT_PROGRESS] saving checkpoint snapshot min: 41, snapshot max: 41 snapshot count: 0, oldest timestamp: (0, 0) , meta checkpoint timestamp: (0, 0) base write gen: 1"}}
Gracefully stopping... (press Ctrl+C again to force)
[+] Running 1/1
 - Container mongo  Stopped                                                                                                                                                                         0.6s
canceled
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Infra>docker-compose up -d
[+] Running 1/1
 - Container mongo  Started
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src>dotnet new webapi -n Play.Inventory.Service
The template "ASP.NET Core Web API" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on Play.Inventory.Service\Play.Inventory.Service.csproj...
  Determining projects to restore...
  Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj (in 212 ms).
Restore succeeded.
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service>dotnet add package Play.Common
  Determining projects to restore...
  Writing C:\Users\x239757\AppData\Local\Temp\tmpE78B.tmp
info : Adding PackageReference for package 'Play.Common' into project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj'.
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/play.common/index.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/play.common/index.json 85ms
info : Restoring packages for C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj...
info : Package 'Play.Common' is compatible with all the specified frameworks in project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj'.
info : PackageReference for package 'Play.Common' version '1.0.0' added to file 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj'.
info : Committing restore...
info : Writing assets file to disk. Path: C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\obj\project.assets.json
log  : Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj (in 260 ms).
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service>dotnet add package Microsoft.Extensions.Http.Polly
  Determining projects to restore...
  Writing C:\Users\x239757\AppData\Local\Temp\tmp2209.tmp
info : Adding PackageReference for package 'Microsoft.Extensions.Http.Polly' into project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj'.
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/microsoft.extensions.http.polly/index.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/microsoft.extensions.http.polly/index.json 708ms
info : Restoring packages for C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.http.polly/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.http.polly/index.json 166ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.http.polly/6.0.3/microsoft.extensions.http.polly.6.0.3.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.http.polly/6.0.3/microsoft.extensions.http.polly.6.0.3.nupkg 53ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.http/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/polly/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/polly.extensions.http/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.http/index.json 164ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.http/6.0.0/microsoft.extensions.http.6.0.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.http/6.0.0/microsoft.extensions.http.6.0.0.nupkg 47ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.logging/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.logging/index.json 95ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.logging/6.0.0/microsoft.extensions.logging.6.0.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/polly.extensions.http/index.json 464ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.logging/6.0.0/microsoft.extensions.logging.6.0.0.nupkg 48ms
info :   GET https://api.nuget.org/v3-flatcontainer/polly.extensions.http/3.0.0/polly.extensions.http.3.0.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/polly/index.json 506ms
info :   GET https://api.nuget.org/v3-flatcontainer/system.diagnostics.diagnosticsource/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/polly/7.2.2/polly.7.2.2.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/polly.extensions.http/3.0.0/polly.extensions.http.3.0.0.nupkg 49ms
info :   OK https://api.nuget.org/v3-flatcontainer/polly/7.2.2/polly.7.2.2.nupkg 43ms
info :   OK https://api.nuget.org/v3-flatcontainer/system.diagnostics.diagnosticsource/index.json 75ms
info :   GET https://api.nuget.org/v3-flatcontainer/system.diagnostics.diagnosticsource/6.0.0/system.diagnostics.diagnosticsource.6.0.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/system.diagnostics.diagnosticsource/6.0.0/system.diagnostics.diagnosticsource.6.0.0.nupkg 35ms
info : Installing System.Diagnostics.DiagnosticSource 6.0.0.
info : Installing Microsoft.Extensions.Logging 6.0.0.
info : Installing Microsoft.Extensions.Http 6.0.0.
info : Installing Polly 7.2.2.
info : Installing Polly.Extensions.Http 3.0.0.
info : Installing Microsoft.Extensions.Http.Polly 6.0.3.
info : Package 'Microsoft.Extensions.Http.Polly' is compatible with all the specified frameworks in project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj'.
info : PackageReference for package 'Microsoft.Extensions.Http.Polly' version '6.0.3' added to file 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj'.
info : Committing restore...
info : Writing assets file to disk. Path: C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\obj\project.assets.json
log  : Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj (in 2.14 sec).
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src>dotnet new classlib -n Play.Catalog.Contracts
The template "Class library" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on Play.Catalog.Contracts\Play.Catalog.Contracts.csproj...
  Determining projects to restore...
  Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Contracts\Play.Catalog.Contracts.csproj (in 67 ms).
Restore succeeded.
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services>dotnet add reference ..\Play.Catalog.Contracts\Play.Catalog.Contracts.csproj
Reference `..\Play.Catalog.Contracts\Play.Catalog.Contracts.csproj` added to the project.
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services>dotnet add package MassTransit.AspNetCore
  Determining projects to restore...
  Writing C:\Users\x239757\AppData\Local\Temp\tmpE632.tmp
info : Adding PackageReference for package 'MassTransit.AspNetCore' into project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj'.
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/index.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/index.json 140ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/5.1.5.1690-develop/5.2.4-develop.1858.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/5.1.5.1690-develop/5.2.4-develop.1858.json 156ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/5.2.4-develop.1861/5.5.2-develop.2037.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/5.2.4-develop.1861/5.5.2-develop.2037.json 144ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/5.5.2-develop.2038/6.0.0-develop.2222.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/5.5.2-develop.2038/6.0.0-develop.2222.json 137ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/6.0.0-develop.2229/6.2.0-develop.2418.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/6.0.0-develop.2229/6.2.0-develop.2418.json 55ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/6.2.0/6.2.6-develop.2651.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/6.2.0/6.2.6-develop.2651.json 147ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/6.2.6-develop.2659/7.0.3-develop.2889.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/6.2.6-develop.2659/7.0.3-develop.2889.json 59ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/7.0.3-develop.2891/7.1.0-develop.3129.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/7.0.3-develop.2891/7.1.0-develop.3129.json 138ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/7.1.0-develop.3133/7.1.8-develop.30.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/7.1.0-develop.3133/7.1.8-develop.30.json 117ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/7.1.8-develop.33/7.2.2-develop.192.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/7.1.8-develop.33/7.2.2-develop.192.json 72ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/7.2.2-develop.197/7.3.1.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.aspnetcore/page/7.2.2-develop.197/7.3.1.json 125ms
info : Restoring packages for C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/masstransit.aspnetcore/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/masstransit.aspnetcore/index.json 62ms
info :   GET https://api.nuget.org/v3-flatcontainer/masstransit.aspnetcore/7.3.1/masstransit.aspnetcore.7.3.1.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/masstransit.aspnetcore/7.3.1/masstransit.aspnetcore.7.3.1.nupkg 52ms
info :   GET https://api.nuget.org/v3-flatcontainer/masstransit.extensions.dependencyinjection/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/masstransit/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.hosting.abstractions/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/masstransit.extensions.dependencyinjection/index.json 71ms
info :   GET https://api.nuget.org/v3-flatcontainer/masstransit.extensions.dependencyinjection/7.3.1/masstransit.extensions.dependencyinjection.7.3.1.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/masstransit.extensions.dependencyinjection/7.3.1/masstransit.extensions.dependencyinjection.7.3.1.nupkg 55ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.dependencyinjection.abstractions/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/masstransit/index.json 198ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks/index.json 216ms
info :   GET https://api.nuget.org/v3-flatcontainer/masstransit/7.3.1/masstransit.7.3.1.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks/3.1.18/microsoft.extensions.diagnostics.healthchecks.3.1.18.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.dependencyinjection.abstractions/index.json 69ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.dependencyinjection.abstractions/2.1.1/microsoft.extensions.dependencyinjection.abstractions.2.1.1.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.hosting.abstractions/index.json 265ms
info :   OK https://api.nuget.org/v3-flatcontainer/masstransit/7.3.1/masstransit.7.3.1.nupkg 52ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.hosting.abstractions/3.1.18/microsoft.extensions.hosting.abstractions.3.1.18.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks/3.1.18/microsoft.extensions.diagnostics.healthchecks.3.1.18.nupkg 58ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.dependencyinjection.abstractions/2.1.1/microsoft.extensions.dependencyinjection.abstractions.2.1.1.nupkg 45ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.hosting.abstractions/3.1.18/microsoft.extensions.hosting.abstractions.3.1.18.nupkg 47ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks.abstractions/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.options/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration.abstractions/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.dependencyinjection.abstractions/3.1.18/microsoft.extensions.dependencyinjection.abstractions.3.1.18.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.fileproviders.abstractions/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.logging.abstractions/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks.abstractions/index.json 78ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.options/index.json 76ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.options/3.1.18/microsoft.extensions.options.3.1.18.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks.abstractions/3.1.18/microsoft.extensions.diagnostics.healthchecks.abstractions.3.1.18.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration.abstractions/index.json 76ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks.abstractions/3.1.18/microsoft.extensions.diagnostics.healthchecks.abstractions.3.1.18.nupkg 44ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration.abstractions/3.1.18/microsoft.extensions.configuration.abstractions.3.1.18.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.options/3.1.18/microsoft.extensions.options.3.1.18.nupkg 50ms
info :   GET https://api.nuget.org/v3-flatcontainer/automatonymous/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.bcl.asyncinterfaces/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/newid/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.primitives/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/newtonsoft.json/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/newtonsoft.json.bson/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/system.diagnostics.diagnosticsource/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/system.reflection.emit/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/system.reflection.emit.lightweight/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/system.text.json/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/system.threading.channels/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/system.valuetuple/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration.abstractions/3.1.18/microsoft.extensions.configuration.abstractions.3.1.18.nupkg 67ms
info :   OK https://api.nuget.org/v3-flatcontainer/automatonymous/index.json 77ms
info :   GET https://api.nuget.org/v3-flatcontainer/automatonymous/5.1.3/automatonymous.5.1.3.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.bcl.asyncinterfaces/index.json 81ms
info :   OK https://api.nuget.org/v3-flatcontainer/newid/index.json 79ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.bcl.asyncinterfaces/5.0.0/microsoft.bcl.asyncinterfaces.5.0.0.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/newid/3.0.3/newid.3.0.3.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.dependencyinjection.abstractions/3.1.18/microsoft.extensions.dependencyinjection.abstractions.3.1.18.nupkg 169ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.bcl.asyncinterfaces/5.0.0/microsoft.bcl.asyncinterfaces.5.0.0.nupkg 86ms
info :   OK https://api.nuget.org/v3-flatcontainer/newid/3.0.3/newid.3.0.3.nupkg 91ms
info :   OK https://api.nuget.org/v3-flatcontainer/automatonymous/5.1.3/automatonymous.5.1.3.nupkg 98ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.fileproviders.abstractions/index.json 275ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.logging.abstractions/index.json 273ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.fileproviders.abstractions/3.1.18/microsoft.extensions.fileproviders.abstractions.3.1.18.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.logging.abstractions/3.1.18/microsoft.extensions.logging.abstractions.3.1.18.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.logging.abstractions/2.1.1/microsoft.extensions.logging.abstractions.2.1.1.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.primitives/index.json 224ms
info :   OK https://api.nuget.org/v3-flatcontainer/newtonsoft.json.bson/index.json 224ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.primitives/3.1.18/microsoft.extensions.primitives.3.1.18.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/newtonsoft.json.bson/1.0.2/newtonsoft.json.bson.1.0.2.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/greenpipes/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.logging.abstractions/3.1.18/microsoft.extensions.logging.abstractions.3.1.18.nupkg 46ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.fileproviders.abstractions/3.1.18/microsoft.extensions.fileproviders.abstractions.3.1.18.nupkg 53ms
info :   OK https://api.nuget.org/v3-flatcontainer/newtonsoft.json/index.json 260ms
info :   OK https://api.nuget.org/v3-flatcontainer/system.diagnostics.diagnosticsource/index.json 255ms
info :   GET https://api.nuget.org/v3-flatcontainer/newtonsoft.json/12.0.1/newtonsoft.json.12.0.1.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/system.diagnostics.diagnosticsource/4.7.1/system.diagnostics.diagnosticsource.4.7.1.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.logging.abstractions/2.1.1/microsoft.extensions.logging.abstractions.2.1.1.nupkg 74ms
info :   OK https://api.nuget.org/v3-flatcontainer/newtonsoft.json.bson/1.0.2/newtonsoft.json.bson.1.0.2.nupkg 49ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.primitives/3.1.18/microsoft.extensions.primitives.3.1.18.nupkg 54ms
info :   OK https://api.nuget.org/v3-flatcontainer/newtonsoft.json/12.0.1/newtonsoft.json.12.0.1.nupkg 37ms
info :   OK https://api.nuget.org/v3-flatcontainer/system.reflection.emit.lightweight/index.json 292ms
info :   GET https://api.nuget.org/v3-flatcontainer/system.reflection.emit.lightweight/4.7.0/system.reflection.emit.lightweight.4.7.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/system.threading.channels/index.json 292ms
info :   OK https://api.nuget.org/v3-flatcontainer/system.text.json/index.json 299ms
info :   GET https://api.nuget.org/v3-flatcontainer/system.threading.channels/4.7.1/system.threading.channels.4.7.1.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/system.text.json/5.0.2/system.text.json.5.0.2.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/system.diagnostics.diagnosticsource/4.7.1/system.diagnostics.diagnosticsource.4.7.1.nupkg 42ms
info :   OK https://api.nuget.org/v3-flatcontainer/system.reflection.emit/index.json 314ms
info :   GET https://api.nuget.org/v3-flatcontainer/system.reflection.emit/4.7.0/system.reflection.emit.4.7.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/system.reflection.emit.lightweight/4.7.0/system.reflection.emit.lightweight.4.7.0.nupkg 42ms
info :   OK https://api.nuget.org/v3-flatcontainer/system.threading.channels/4.7.1/system.threading.channels.4.7.1.nupkg 38ms
info :   OK https://api.nuget.org/v3-flatcontainer/system.reflection.emit/4.7.0/system.reflection.emit.4.7.0.nupkg 36ms
info :   OK https://api.nuget.org/v3-flatcontainer/system.text.json/5.0.2/system.text.json.5.0.2.nupkg 54ms
info :   OK https://api.nuget.org/v3-flatcontainer/system.valuetuple/index.json 356ms
info :   GET https://api.nuget.org/v3-flatcontainer/system.valuetuple/4.5.0/system.valuetuple.4.5.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/greenpipes/index.json 141ms
info :   GET https://api.nuget.org/v3-flatcontainer/greenpipes/4.0.1/greenpipes.4.0.1.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/system.valuetuple/4.5.0/system.valuetuple.4.5.0.nupkg 39ms
info :   OK https://api.nuget.org/v3-flatcontainer/greenpipes/4.0.1/greenpipes.4.0.1.nupkg 37ms
info : Installing GreenPipes 4.0.1.
info : Installing Microsoft.Extensions.Primitives 3.1.18.
info : Installing Newtonsoft.Json 12.0.1.
info : Installing System.Text.Json 5.0.2.
info : Installing System.ValueTuple 4.5.0.
info : Installing Automatonymous 5.1.3.
info : Installing System.Reflection.Emit 4.7.0.
info : Installing System.Threading.Channels 4.7.1.
info : Installing System.Reflection.Emit.Lightweight 4.7.0.
info : Installing System.Diagnostics.DiagnosticSource 4.7.1.
info : Installing Newtonsoft.Json.Bson 1.0.2.
info : Installing Microsoft.Extensions.Logging.Abstractions 2.1.1.
info : Installing NewId 3.0.3.
info : Installing Microsoft.Bcl.AsyncInterfaces 5.0.0.
info : Installing Microsoft.Extensions.Configuration.Abstractions 3.1.18.
info : Installing Microsoft.Extensions.FileProviders.Abstractions 3.1.18.
info : Installing MassTransit.AspNetCore 7.3.1.
info : Installing MassTransit.Extensions.DependencyInjection 7.3.1.
info : Installing Microsoft.Extensions.Diagnostics.HealthChecks 3.1.18.
info : Installing Microsoft.Extensions.Logging.Abstractions 3.1.18.
info : Installing Microsoft.Extensions.Hosting.Abstractions 3.1.18.
info : Installing MassTransit 7.3.1.
info : Installing Microsoft.Extensions.DependencyInjection.Abstractions 3.1.18.
info : Installing Microsoft.Extensions.DependencyInjection.Abstractions 2.1.1.
info : Installing Microsoft.Extensions.Diagnostics.HealthChecks.Abstractions 3.1.18.
info : Installing Microsoft.Extensions.Options 3.1.18.
info : Package 'MassTransit.AspNetCore' is compatible with all the specified frameworks in project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj'.
info : PackageReference for package 'MassTransit.AspNetCore' version '7.3.1' added to file 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj'.
info : Committing restore...
info : Writing assets file to disk. Path: C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\obj\project.assets.json
log  : Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj (in 2.56 sec).
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services>dotnet add package MassTransit.RabbitMQ
  Determining projects to restore...
  Writing C:\Users\x239757\AppData\Local\Temp\tmpE92B.tmp
info : Adding PackageReference for package 'MassTransit.RabbitMQ' into project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj'.
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/index.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/index.json 490ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/2.0.0.1/3.2.3.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/2.0.0.1/3.2.3.json 131ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/3.2.4/4.0.0.1365-develop.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/3.2.4/4.0.0.1365-develop.json 57ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/4.0.0.1366-develop/5.0.1.1500-develop.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/4.0.0.1366-develop/5.0.1.1500-develop.json 60ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/5.0.1.1501-develop/5.1.5.1621-develop.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/5.0.1.1501-develop/5.1.5.1621-develop.json 73ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/5.1.5.1623-develop/5.2.1-develop.1833.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/5.1.5.1623-develop/5.2.1-develop.1833.json 63ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/5.2.1/5.5.0-develop.1954.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/5.2.1/5.5.0-develop.1954.json 123ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/5.5.0-develop.1958/5.5.5-develop.2120.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/5.5.0-develop.1958/5.5.5-develop.2120.json 125ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/5.5.5-develop.2122/6.0.2-develop.2345.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/5.5.5-develop.2122/6.0.2-develop.2345.json 106ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/6.0.2-develop.2350/6.2.5-develop.2538.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/6.0.2-develop.2350/6.2.5-develop.2538.json 72ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/6.2.5-develop.2539/7.0.0-develop.2812.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/6.2.5-develop.2539/7.0.0-develop.2812.json 121ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/7.0.0-develop.2813/7.0.5-develop.3006.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/7.0.0-develop.2813/7.0.5-develop.3006.json 57ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/7.0.5/7.1.5-develop.3273.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/7.0.5/7.1.5-develop.3273.json 108ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/7.1.5-develop.3275/7.2.0-develop.3348.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/7.1.5-develop.3275/7.2.0-develop.3348.json 120ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/7.2.0-develop.3351/7.3.0-develop.297.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/7.2.0-develop.3351/7.3.0-develop.297.json 134ms
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/7.3.0-develop.299/8.0.0-develop.392.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/masstransit.rabbitmq/page/7.3.0-develop.299/8.0.0-develop.392.json 121ms
info : Restoring packages for C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/masstransit.rabbitmq/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/masstransit.rabbitmq/index.json 172ms
info :   GET https://api.nuget.org/v3-flatcontainer/masstransit.rabbitmq/7.3.1/masstransit.rabbitmq.7.3.1.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/masstransit.rabbitmq/7.3.1/masstransit.rabbitmq.7.3.1.nupkg 41ms
info :   GET https://api.nuget.org/v3-flatcontainer/rabbitmq.client/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/rabbitmq.client/index.json 71ms
info :   GET https://api.nuget.org/v3-flatcontainer/rabbitmq.client/6.2.2/rabbitmq.client.6.2.2.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/rabbitmq.client/6.2.2/rabbitmq.client.6.2.2.nupkg 36ms
info : Installing RabbitMQ.Client 6.2.2.
info : Installing MassTransit.RabbitMQ 7.3.1.
info : Package 'MassTransit.RabbitMQ' is compatible with all the specified frameworks in project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj'.
info : PackageReference for package 'MassTransit.RabbitMQ' version '7.3.1' added to file 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj'.
info : Committing restore...
info : Writing assets file to disk. Path: C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\obj\project.assets.json
log  : Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Catalog\src\Play.Catalog.Services\Play.Catalog.Services.csproj (in 1.11 sec).
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common>dotnet pack -p:PackageVersion=1.0.1 -o ..\..\..\packages\
Microsoft (R) Build Engine version 16.8.0+126527ff1 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
  Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\Play.Common.csproj (in 266 ms).
  Unable to use package assets cache due to I/O error. This can occur when the same project is built more than once in parallel. Performance may be degraded,
but the build result will not be impacted.
  Play.Common -> C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Common\src\Play.Common\bin\Debug\net5.0\Play.Common.dll
  Successfully created package 'C:\Code\MyDotNet\DotNet5-Microservices-simple\packages\Play.Common.1.0.1.nupkg'.
```

```
C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service>dotnet add package Play.Catalog.Contracts
  Determining projects to restore...
  Writing C:\Users\x239757\AppData\Local\Temp\tmp28F0.tmp
info : Adding PackageReference for package 'Play.Catalog.Contracts' into project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj'.
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/play.catalog.contracts/index.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/play.catalog.contracts/index.json 159ms
info : Restoring packages for C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj...
info : Installing Play.Catalog.Contracts 1.0.0.
info : Package 'Play.Catalog.Contracts' is compatible with all the specified frameworks in project 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj'.
info : PackageReference for package 'Play.Catalog.Contracts' version '1.0.0' added to file 'C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj'.
info : Committing restore...
info : Writing assets file to disk. Path: C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\obj\project.assets.json
log  : Restored C:\Code\MyDotNet\DotNet5-Microservices-simple\Play.Inventory\src\Play.Inventory.Service\Play.Inventory.Service.csproj (in 198 ms).
```

```

```

```

```

```

```

```

```

## Misc

Cannot implicitly convert type 'Microsoft.AspNetCore.Mvc.NotFoundResult' to 'Play.Catalog.Services.ItemDto' [Play.Catalog.Services]

## Tips

### VSCode

#### Prevent to popup a new brower when F5

launch.json

Comment out this section will prevent a new brower popup when F5

```
      // Enable launching a web browser when ASP.NET Core starts. For more information: https://aka.ms/VSCode-CS-LaunchJson-WebBrowser
      // "serverReadyAction": {
      //     "action": "openExternally",
      //     "pattern": "\\bNow listening on:\\s+(https?://\\S+)"
      // },
```

#### Auto generate .Net assets

VSCode -> View -> Command Palette -> .Net: Generate Assets for Build and Debug

#### VSCode YAML

Settings -> render whitespace

#### OmniSharp

VSCode -> View -> Command Palette -> OmniSharp: ...

VSCode -> View -> Command Palette -> OmniSharp: Restart OmniSharp

### Postman

### {{$guid}} is a built-in function can be used in POST etc.

i.e.

```
"userId": "{{$guid}}",
```

### Postman can import Swagger JSON

It is very easy and cool.

## Troubleshooting

### undefined /swagger/v1/swagger.json

https://stackoverflow.com/questions/56859604/swagger-not-loading-failed-to-load-api-definition-fetch-error-undefined

Simply navigate to https://localhost:{PortNo}/swagger/v1/swagger.json and get much more details about the error message.

Root cause: forgot the annoation [HttpGet] [HttpPost]

### Postman baseURL

Can't add "/" at the end by default

### Stuck at 6-7 "Consuming messages for eventual data consistency"

```
Exception has occurred: CLR/System.AggregateException
An unhandled exception of type 'System.AggregateException' occurred in Microsoft.Extensions.DependencyInjection.dll: 'Some services are not able to be constructed'
 Inner exceptions found, see $exception in variables window for more details.
 Innermost exception 	 System.InvalidOperationException : Unable to resolve service for type 'Play.Common.IRepository`1[Play.Inventory.Service.Entities.CatalogItem]' while attempting to activate 'Play.Inventory.Service.Consumers.CatalogItemCreatedConsumer'.
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, Type serviceType, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(ServiceDescriptor descriptor, Type serviceType, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.GetCallSite(ServiceDescriptor serviceDescriptor, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.ValidateService(ServiceDescriptor descriptor)
```
