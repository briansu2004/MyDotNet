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

launch.json

Comment out this section will prevent a new brower open when F5

```
      // Enable launching a web browser when ASP.NET Core starts. For more information: https://aka.ms/VSCode-CS-LaunchJson-WebBrowser
      // "serverReadyAction": {
      //     "action": "openExternally",
      //     "pattern": "\\bNow listening on:\\s+(https?://\\S+)"
      // },
```

Running common code from NuGet

Don't Repeat Yourself (DRY)

Microservices should be independent of each other

NuGet is the package manager for .Net

A NuGet package is a single ZIP file (.nupkg) that contains files to share with others

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

```

```

```

## Misc

Cannot implicitly convert type 'Microsoft.AspNetCore.Mvc.NotFoundResult' to 'Play.Catalog.Services.ItemDto' [Play.Catalog.Services]
