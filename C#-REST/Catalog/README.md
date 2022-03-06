# .NET 5/6 REST API - Build From Scratch With C\#

.NET REST API - Build From Scratch With C#

## Keywords

entity, repository, contoller

C# record types

in-memory repositories

init-only properties

Target-typed new expression

Dependency Injection

DTO (Data Transfer Object)

ConfigureServices

Data Anotation

With-expressions

Docker image
Docker container
Docker engine

BsonSerializer
BsonType

Asynchronous Programming
async & await

```dos
using System.Threading.Tasks;

await Task.FromResult(...);
await Task.CompleteTask;
```

Secrets

.Net secret manager

Health checks

AspNetCore.Diagnostics.HealthChecks | HealthCheckUI

liveness probe

readiness probe

TDD

Test with xUnit

Mock with Moq framework

Assertions with FluentAssertions

[Fact]

AAA pattern:

Arrange -> Act -> Assert

Fluent interface

## Commands

```dos
dotnet new webapi -n Catalog
dotnet dev-certs https --trust
dotnet add package MongoDB.Driver
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongodbadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 mongo
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongodbadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 --network=catalognetwork mongo
docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=Pass#word1 --network=catalognetwork catalog:v1
docker tag catalog:v1 briansu2004/catalog:v1
docker push briansu2004/catalog:v1
docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=Pass#word1 --network=catalognetwork briansu2004/catalog:v1
dotnet user-secrets init
dotnet user-secrets set MongoDbSettings:Password Pass#word1
dotnet add package AspNetCore.HealthChecks.MongoDb
dotnet restore "Catalog.csproj"
dotnet build "Catalog.csproj" -c Release -o /app/build
dotnet publish "Catalog.csproj" -c Release -o /app/publish
docker build -t catalog:v1 .
dotnet new xunit -n Catalog.UnitTests
```

```dos
docker ps
docker stop mongo
docker volume ls
docker volume rm mongodbdata
docker network create catalognetwork
docker network ls
docker login
docker tag catalog:v1 <dockerHubUser>/catalog:v1  # tag to docker hub
docker push <dockerHubUser>/catalog:v1 # push to docker hub
docker pull <dockerHubUser>/catalog:v1
docker rmi catalog:v1 # untag
docker rmi <dockerHubUser>/catalog:v1 # untag
docker logout
```

```dos
ENTRYPOINT ["dotnet", "Catalog.dll"]
```

```
C:\Code\MyDotNet\C#-REST\Catalog>docker login
Login with your Docker ID to push and pull images from Docker Hub. If you don't have a Docker ID, head over to https://hub.docker.com to create one.
Username: briansu2004
Password:
Login Succeeded

Logging in with your password grants your terminal complete access to your account.
For better security, log in with a limited-privilege personal access token. Learn more at https://docs.docker.com/go/access-tokens/
```

```
C:\Code\MyDotNet\C#-REST\Catalog>docker push briansu2004/catalog:v1
The push refers to repository [docker.io/briansu2004/catalog]
f10a8b42819d: Pushed
5f70bf18a086: Pushed
550ef9826b5d: Pushed
e75f20f772e5: Pushed
90b1f0e23bf2: Pushed
2d625df30d12: Pushed
d40a5c453e9f: Pushed
68a85fa9d77e: Mounted from library/mongo
v1: digest: sha256:751e6a0187d5994106e530a4d07af8ea2d16fd5596a7d64579ed08addab18448 size: 1995
```

```
C:\Code\MyDotNet\C#-REST\Catalog>docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=Pass#word1 --network=catalognetwork briansu2004/catalog:v1
Unable to find image 'briansu2004/catalog:v1' locally
v1: Pulling from briansu2004/catalog
7c3b88808835: Already exists
921b28e5fdff: Already exists
d8e5d3ff6881: Already exists
ac77651bb778: Already exists
a72848626bb4: Already exists
306c191e65f5: Already exists
4f4fb700ef54: Already exists
42d19a404bf5: Already exists
Digest: sha256:751e6a0187d5994106e530a4d07af8ea2d16fd5596a7d64579ed08addab18448
Status: Downloaded newer image for briansu2004/catalog:v1
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://[::]:80
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /app
```

```dos
kubectl config current-context
kubectl create secret generic catalog-secrets --from-literal=mongodb-password='Pass#word1'
kubectl apply -f .\catalog.yaml
kubectl get deployments
kubectl get pods
kubectl get pods -w
kubectl logs <pod>
kubectl logs <pod> -f
kubectl apply -f .\mongodb.yaml
kubectl get statefulsets
kubectl delete pod <pod>
kubectl scale deployments/catalog-deployment --replicas=3
```

```
C:\Code\MyDotNet\C#-REST\Catalog>kubectl create secret generic catalog-secrets --from-literal=mongodb-password='Pass#word1'
secret/catalog-secrets created

C:\Code\MyDotNet\C#-REST\Catalog\kubernetes>kubectl apply -f .\catalog.yaml
deployment.apps/catalog-deployment created
service/catalog-service created

C:\Code\MyDotNet\C#-REST\Catalog\kubernetes>kubectl get deployments
NAME                 READY   UP-TO-DATE   AVAILABLE   AGE
catalog-deployment   0/1     1            0           23s

C:\Code\MyDotNet\C#-REST\Catalog\kubernetes>kubectl get pods
NAME                                  READY   STATUS    RESTARTS   AGE
catalog-deployment-65c96d7d97-vnmj6   0/1     Running   0          57s

C:\Code\MyDotNet\C#-REST\Catalog\kubernetes>kubectl apply -f .\mongodb.yaml
statefulset.apps/mongodb-statefulset created
service/mongodb-service created

C:\Code\MyDotNet\C#-REST\Catalog\kubernetes>kubectl get statefulsets
NAME                  READY   AGE
mongodb-statefulset   1/1     14s

C:\Code\MyDotNet\C#-REST\Catalog\kubernetes>kubectl get pods
NAME                                  READY   STATUS    RESTARTS   AGE
catalog-deployment-65c96d7d97-vnmj6   0/1     Running   0          13m
mongodb-statefulset-0                 1/1     Running   0          32s
```

## Log

### .Net 6.x.x - aborted

```dos
C:\Code\MyDotNet\DotNet5-REST>dotnet new webapi -n Catalog
The template "ASP.NET Core Web API" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj...
  Determining projects to restore...
C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj : error NU1100: Unable to resolve 'Swashbuckle.AspNetCore (>= 6.2.3)' for 'net6.0'.
  Failed to restore C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj (in 217 ms).
Restore failed.
Post action failed.
Manual instructions: Run 'dotnet restore'
```

### .Net 5.0.404 - aborted

```dos
The installation was successful.

The following were installed at: 'C:\Program Files\dotnet\'
    • .NET SDK 5.0.404
    • .NET Runtime 5.0.13
    • ASP.NET Core Runtime 5.0.13
    • .NET Windows Desktop Runtime 5.0.13
```

```dos
C:\Code\MyDotNet\DotNet5-REST>dotnet new webapi -n Catalog

Welcome to .NET 5.0!
---------------------
SDK Version: 5.0.404

Telemetry
---------
The .NET tools collect usage data in order to help us improve your experience. It is collected by Microsoft and shared with the community. You can opt-out of telemetry by setting the DOTNET_CLI_TELEMETRY_OPTOUT environment variable to '1' or 'true' using your favorite shell.

Read more about .NET CLI Tools telemetry: https://aka.ms/dotnet-cli-telemetry

----------------
Installed an ASP.NET Core HTTPS development certificate.
To trust the certificate run 'dotnet dev-certs https --trust' (Windows and macOS only).
Learn about HTTPS: https://aka.ms/dotnet-https
----------------
Write your first app: https://aka.ms/dotnet-hello-world
Find out what's new: https://aka.ms/dotnet-whats-new
Explore documentation: https://aka.ms/dotnet-docs
Report issues and find source on GitHub: https://github.com/dotnet/core
Use 'dotnet --help' to see available commands or visit: https://aka.ms/dotnet-cli
--------------------------------------------------------------------------------------
Getting ready...
The template "ASP.NET Core Web API" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on Catalog\Catalog.csproj...
  Determining projects to restore...
C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj : error NU1100: Unable to resolve 'Swashbuckle.AspNetCore (>= 5.6.3)' for 'net5.0'.
  Failed to restore C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj (in 164 ms).
Restore failed.
Post action failed.
Description: Restore NuGet packages required by this project.
Manual instructions: Run 'dotnet restore'
```

### .Net 5.0.100 - yes!

```dos
The installation was successful.

The following were installed at: 'C:\Program Files\dotnet\'
    • .NET SDK 5.0.100
    • .NET Runtime 5.0.0
    • ASP.NET Core Runtime 5.0.0
    • .NET Windows Desktop Runtime 5.0.0
```

```dos
C:\Code\MyDotNet>dotnet new webapi -n Catalog
Getting ready...
The template "ASP.NET Core Web API" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on Catalog\Catalog.csproj...
  Determining projects to restore...
  Restored C:\Code\MyDotNet\Catalog\Catalog.csproj (in 10.06 sec).
Restore succeeded.
```

```dos
C:\Code\MyDotNet\DotNet5-REST\Catalog>dotnet dev-certs https --trust
Trusting the HTTPS development certificate was requested. A confirmation prompt will be displayed if the certificate was not previously trusted. Click yes on the prompt to trust the certificate.
A valid HTTPS certificate is already present.
```

Remove the following in launch.json

```dos
            // Enable launching a web browser when ASP.NET Core starts. For more information: https://aka.ms/VSCode-CS-LaunchJson-WebBrowser
            "serverReadyAction": {
                "action": "openExternally",
                "pattern": "\\bNow listening on:\\s+(https?://\\S+)"
            },
```

```dos
C:\Code\MyDotNet\DotNet5-REST\Catalog>dotnet add package MongoDB.Driver
  Determining projects to restore...
  Writing C:\Users\x239757\AppData\Local\Temp\tmpAAE4.tmp
info : Adding PackageReference for package 'MongoDB.Driver' into project 'C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj'.
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/mongodb.driver/index.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/mongodb.driver/index.json 135ms
info : Restoring packages for C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/mongodb.driver/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/mongodb.driver/index.json 64ms
info :   GET https://api.nuget.org/v3-flatcontainer/mongodb.driver/2.14.1/mongodb.driver.2.14.1.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/mongodb.driver/2.14.1/mongodb.driver.2.14.1.nupkg 62ms
info :   GET https://api.nuget.org/v3-flatcontainer/mongodb.bson/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/mongodb.driver.core/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/mongodb.libmongocrypt/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/mongodb.bson/index.json 107ms
info :   GET https://api.nuget.org/v3-flatcontainer/mongodb.bson/2.14.1/mongodb.bson.2.14.1.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/mongodb.bson/2.14.1/mongodb.bson.2.14.1.nupkg 80ms
info :   GET https://api.nuget.org/v3-flatcontainer/system.runtime.compilerservices.unsafe/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/system.runtime.compilerservices.unsafe/index.json 70ms
info :   GET https://api.nuget.org/v3-flatcontainer/system.runtime.compilerservices.unsafe/5.0.0/system.runtime.compilerservices.unsafe.5.0.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/mongodb.driver.core/index.json 288ms
info :   GET https://api.nuget.org/v3-flatcontainer/mongodb.driver.core/2.14.1/mongodb.driver.core.2.14.1.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/mongodb.libmongocrypt/index.json 297ms
info :   GET https://api.nuget.org/v3-flatcontainer/mongodb.libmongocrypt/1.3.0/mongodb.libmongocrypt.1.3.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/system.runtime.compilerservices.unsafe/5.0.0/system.runtime.compilerservices.unsafe.5.0.0.nupkg 40ms
info :   OK https://api.nuget.org/v3-flatcontainer/mongodb.driver.core/2.14.1/mongodb.driver.core.2.14.1.nupkg 42ms
info :   OK https://api.nuget.org/v3-flatcontainer/mongodb.libmongocrypt/1.3.0/mongodb.libmongocrypt.1.3.0.nupkg 95ms
info :   GET https://api.nuget.org/v3-flatcontainer/dnsclient/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/sharpcompress/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/system.buffers/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/dnsclient/index.json 85ms
info :   OK https://api.nuget.org/v3-flatcontainer/sharpcompress/index.json 84ms
info :   OK https://api.nuget.org/v3-flatcontainer/system.buffers/index.json 81ms
info :   GET https://api.nuget.org/v3-flatcontainer/dnsclient/1.4.0/dnsclient.1.4.0.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/sharpcompress/0.30.1/sharpcompress.0.30.1.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/system.buffers/4.5.1/system.buffers.4.5.1.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/dnsclient/1.4.0/dnsclient.1.4.0.nupkg 71ms
info :   OK https://api.nuget.org/v3-flatcontainer/system.buffers/4.5.1/system.buffers.4.5.1.nupkg 78ms
info :   OK https://api.nuget.org/v3-flatcontainer/sharpcompress/0.30.1/sharpcompress.0.30.1.nupkg 85ms
info : Installing SharpCompress 0.30.1.
info : Installing System.Buffers 4.5.1.
info : Installing DnsClient 1.4.0.
info : Installing System.Runtime.CompilerServices.Unsafe 5.0.0.
info : Installing MongoDB.Driver.Core 2.14.1.
info : Installing MongoDB.Libmongocrypt 1.3.0.
info : Installing MongoDB.Bson 2.14.1.
info : Installing MongoDB.Driver 2.14.1.
info : Package 'MongoDB.Driver' is compatible with all the specified frameworks in project 'C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj'.
info : PackageReference for package 'MongoDB.Driver' version '2.14.1' added to file 'C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj'.
info : Committing restore...
info : Writing assets file to disk. Path: C:\Code\MyDotNet\DotNet5-REST\Catalog\obj\project.assets.json
log  : Restored C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj (in 3.28 sec).
```

```dos
C:\Code\MyDotNet\DotNet5-REST\Catalog>dotnet user-secrets init
Set UserSecretsId to 'f30bdcb5-1fb2-43a7-820d-f76f5ff06912' for MSBuild project 'C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj'.

C:\Code\MyDotNet\DotNet5-REST\Catalog>dotnet user-secrets set MongoDbSettings:Password Pass#word1
Successfully saved MongoDbSettings:Password = Pass#word1 to the secret store.
```

```dos
C:\Code\MyDotNet\DotNet5-REST\Catalog>dotnet add package AspNetCore.HealthChecks.MongoDb
  Determining projects to restore...
  Writing C:\Users\x239757\AppData\Local\Temp\tmp4365.tmp
info : Adding PackageReference for package 'AspNetCore.HealthChecks.MongoDb' into project 'C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj'.
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/aspnetcore.healthchecks.mongodb/index.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/aspnetcore.healthchecks.mongodb/index.json 118ms
info : Restoring packages for C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/aspnetcore.healthchecks.mongodb/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/aspnetcore.healthchecks.mongodb/index.json 69ms
info :   GET https://api.nuget.org/v3-flatcontainer/aspnetcore.healthchecks.mongodb/6.0.1/aspnetcore.healthchecks.mongodb.6.0.1.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/aspnetcore.healthchecks.mongodb/6.0.1/aspnetcore.healthchecks.mongodb.6.0.1.nupkg 33ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks/index.json 85ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks/6.0.0/microsoft.extensions.diagnostics.healthchecks.6.0.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks/6.0.0/microsoft.extensions.diagnostics.healthchecks.6.0.0.nupkg 38ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks.abstractions/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.hosting.abstractions/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.logging.abstractions/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.options/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks.abstractions/index.json 50ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks.abstractions/6.0.0/microsoft.extensions.diagnostics.healthchecks.abstractions.6.0.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.diagnostics.healthchecks.abstractions/6.0.0/microsoft.extensions.diagnostics.healthchecks.abstractions.6.0.0.nupkg 37ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.hosting.abstractions/index.json 160ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.hosting.abstractions/6.0.0/microsoft.extensions.hosting.abstractions.6.0.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.hosting.abstractions/6.0.0/microsoft.extensions.hosting.abstractions.6.0.0.nupkg 71ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.logging.abstractions/index.json 256ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.options/index.json 255ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.logging.abstractions/6.0.0/microsoft.extensions.logging.abstractions.6.0.0.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.options/6.0.0/microsoft.extensions.options.6.0.0.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration.abstractions/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.dependencyinjection.abstractions/index.json
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.fileproviders.abstractions/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.options/6.0.0/microsoft.extensions.options.6.0.0.nupkg 46ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.logging.abstractions/6.0.0/microsoft.extensions.logging.abstractions.6.0.0.nupkg 54ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration.abstractions/index.json 57ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration.abstractions/6.0.0/microsoft.extensions.configuration.abstractions.6.0.0.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.primitives/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.dependencyinjection.abstractions/index.json 74ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.dependencyinjection.abstractions/6.0.0/microsoft.extensions.dependencyinjection.abstractions.6.0.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.configuration.abstractions/6.0.0/microsoft.extensions.configuration.abstractions.6.0.0.nupkg 107ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.dependencyinjection.abstractions/6.0.0/microsoft.extensions.dependencyinjection.abstractions.6.0.0.nupkg 74ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.primitives/index.json 113ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.primitives/6.0.0/microsoft.extensions.primitives.6.0.0.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/system.memory/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.primitives/6.0.0/microsoft.extensions.primitives.6.0.0.nupkg 54ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.fileproviders.abstractions/index.json 267ms
info :   OK https://api.nuget.org/v3-flatcontainer/system.memory/index.json 60ms
info :   GET https://api.nuget.org/v3-flatcontainer/microsoft.extensions.fileproviders.abstractions/6.0.0/microsoft.extensions.fileproviders.abstractions.6.0.0.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/system.memory/4.5.4/system.memory.4.5.4.nupkg
info :   GET https://api.nuget.org/v3-flatcontainer/system.runtime.compilerservices.unsafe/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/system.memory/4.5.4/system.memory.4.5.4.nupkg 72ms
info :   OK https://api.nuget.org/v3-flatcontainer/microsoft.extensions.fileproviders.abstractions/6.0.0/microsoft.extensions.fileproviders.abstractions.6.0.0.nupkg 76ms
info :   OK https://api.nuget.org/v3-flatcontainer/system.runtime.compilerservices.unsafe/index.json 88ms
info :   GET https://api.nuget.org/v3-flatcontainer/system.runtime.compilerservices.unsafe/6.0.0/system.runtime.compilerservices.unsafe.6.0.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/system.runtime.compilerservices.unsafe/6.0.0/system.runtime.compilerservices.unsafe.6.0.0.nupkg 63ms
info : Installing System.Runtime.CompilerServices.Unsafe 6.0.0.
info : Installing System.Memory 4.5.4.
info : Installing Microsoft.Extensions.FileProviders.Abstractions 6.0.0.
info : Installing Microsoft.Extensions.Configuration.Abstractions 6.0.0.
info : Installing Microsoft.Extensions.Primitives 6.0.0.
info : Installing Microsoft.Extensions.DependencyInjection.Abstractions 6.0.0.
info : Installing Microsoft.Extensions.Logging.Abstractions 6.0.0.
info : Installing Microsoft.Extensions.Hosting.Abstractions 6.0.0.
info : Installing Microsoft.Extensions.Options 6.0.0.
info : Installing Microsoft.Extensions.Diagnostics.HealthChecks.Abstractions 6.0.0.
info : Installing Microsoft.Extensions.Diagnostics.HealthChecks 6.0.0.
info : Installing AspNetCore.HealthChecks.MongoDb 6.0.1.
info : Package 'AspNetCore.HealthChecks.MongoDb' is compatible with all the specified frameworks in project 'C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj'.
info : PackageReference for package 'AspNetCore.HealthChecks.MongoDb' version '6.0.1' added to file 'C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj'.
info : Committing restore...
info : Writing assets file to disk. Path: C:\Code\MyDotNet\DotNet5-REST\Catalog\obj\project.assets.json
log  : Restored C:\Code\MyDotNet\DotNet5-REST\Catalog\Catalog.csproj (in 1.99 sec).
```

```dos
C:\Code\MyDotNet\DotNet5-REST\Catalog>kubectl config current-context
gke_cio-gke-private-yul-001-9ed5d0_northamerica-northeast1_private-yul-np-001

C:\Code\MyDotNet\C#-REST\Catalog>kubectl config get-contexts
CURRENT   NAME              CLUSTER            AUTHINFO                  NAMESPACE
*         docker-desktop    docker-desktop    docker-desktop
          pr-001   pr-001   pr-001   cust-blah
          np-001   np-001   np-001   cust-blah

C:\Code\MyDotNet\C#-REST\Catalog>kubectl config use-context docker-desktop
Switched to context "docker-desktop".

C:\Code\MyDotNet\C#-REST\Catalog>kubectl config current-context
docker-desktop
```

## Notes

### Catalog.csproj

project file

### Program.cs

App entry point

### Startup.cs

### WeatherForecast.cs

Model

### Controllers/WeatherForecastController.cs

Controller

### appsettings.json and appsettings.Development.json

Older version has them in the Properties folder.

```dos
"MongoDbSettings": {
    "Host": "localhost",
    "Port": "27017"
}
```

### Properties/launchSettings.json

URLs

### .vscode/launch.json

Newer version dones't have them!

### .vscode/tasks.json

Newer version dones't have them!

## Misc

### Troubleshooting on Controller

[Route("[items]")]

has to be changed to -

[Route("items")]

## VS Code tips

### How do I make VS Code open files in a new tab?

1. Double-click your files instead of single-clicking. Instead of single clicking on your files, (like I do in the previous GIF) double-click. .

2. Right click your tab and select "Keep Open" ...

3. Use the (Ctrl + K Enter) keyboard shortcut. ...

4. Double-click the tab you want to keep open.

### VS Code Ctrl+J === Ctrl+`

### VS Code terminal split (side by side)

## URLs

https://localhost:5001/swagger/index.html

## Screenshot

![](image/README/cert_trust.png)

![](image/README/swagger_01.png)

![](image/README/record_type_01.png)

![](image/README/record_type_02.png)

![](image/README/init_only_properties.png)

![](image/README/DI_01.png)

![](image/README/DI_02.png)

```dos
        private readonly InMemItemsRepository repository;

        public ItemsController()
        {
            repository = new InMemItemsRepository();
        }
```

=>

```dos
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }
```

![](image/README/persistence_no_sql.png)

![](image/README/docker_image.png)

![](image/README/docker_container.png)

![](image/README/docker_engine.png)

![](image/README/async.png)

```dos
services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
})
```

MvcOptions.SuppressAsyncSuffixInActionNames Property

ActionName is used to construct the route to the action as well as in view lookup.

When true, MVC will trim the suffix "Async" applied to action method names.

For example, the action name for ProductsController.ListProductsAsync will be canonicalized as ListProducts. Consequently, it will be routeable at /Products/ListProducts with views looked up at /Views/Products/ListProducts.cshtml.

![](image/README/secret_mgr.png)

%APPDATA%\Microsoft\UserSecrets

appsettings.json

```dos
"MongoDbSettings": {
    "Host": "localhost",
    "Port": "27017",
    "User": "mongodbadmin",
}
```

`+` (same pattern)

```dos
dotnet user-secrets set MongoDbSettings:Password Pass#word1
```

![](image/README/health_check.png)

Starup.cs

```dos
  public void ConfigureServices(IServiceCollection services)
  {
      ...
      services.AddHealthChecks()
          .AddMongoDb(
            MongoDbSettings.ConnectionString,
            name: "mongodb",
            timeout: TimeSpan.FromSeconds(3),
            tags: new[] { "ready" }
          );
  }

  ...

    app.UseEndpoints(endpoints =>
    {
        ...
        endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions{
            Predicate = (check) => check.Tags.Contains("ready")
        ;});

        endpoints.MapHealthChecks("/health/live", new HealthCheckOptions{
            Predicate = (_) => false
        ;});
    });
```

![](image/README/health_ready.png)

![](image/README/health_live.png)

![](image/README/prepare_deployment.png)

![](image/README/use_docker_in_prod.png)

![](image/README/why_orchestration.png)

![](image/README/k8s_01.png)

![](image/README/k8s_02.png)

![](image/README/mi.png)

![](image/README/cpu_500m.png)

cpu: "500m" means 0.5 cpu

![](image/README/k8s_probe.png)

![](image/README/k8s_service.png)

![](image/README/k8s_statefulset.png)

![](image/README/k8s_persistent_volume.png)

![](image/README/k8s_volume_ReadWriteMode.png)

![](image/README/k8s_headless_service.png)

![](image/README/rocket_parts.png)

![](image/README/unit_test_01.png)
