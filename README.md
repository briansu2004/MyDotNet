# MyDotNet

My .Net

## General

![](image/README/001.png)

![](image/README/002.png)

![](image/README/003.png)

## Using HttpClient in .NET Core to Connect to APIs in C#

![](image/README/blazor_01.png)

Razor page vs Razor component

Blazor

## Interview Questions

![](image/README/iw_001.png)

![](image/README/iw_002.png)

![](image/README/iw_003.png)

CLR does these 2 important things: IL and Garbage Collector.

![](image/README/iw_004.png)

C# is case-sensitive.

VB .Net is not case-sensitive - because it is basic!

![](image/README/iw_005.png)

![](image/README/iw_006.png)

![](image/README/iw_007.png)

![](image/README/iw_008.png)

![](image/README/iw_009.png)

![](image/README/iw_010.png)

![](image/README/iw_011.png)

![](image/README/iw_012.png)

![](image/README/iw_013.png)

![](image/README/iw_014.png)

## C#

### Using .Net Core + MVC + Swagger + VSCode!

.NET 5 REST API Tutorial - Build From Scratch With C#

https://www.youtube.com/watch?v=ZXdFisA_hOY

.NET Core 3.1 MVC REST API - Full Course

https://www.youtube.com/watch?v=fmvcAzHpsk8

![](image/README/MVC_01.png)

![](image/README/MVC_02.png)

dotnet new ...

dotnet add ...

dotnet ef

```dos
[ApiController]
public class PeopleController : ControllerBase
{
    [HttpGet("people/all")]
    public ActionResult<IEnumerable<Person>> GetAll()
    {
        return new []
        {
            new Person { Name = "Ana" },
            new Person { Name = "Felipe" },
            new Person { Name = "Emillia" }
        };
    }
}

public class Person
{
    public string Name { get; set; }
}
```

### Web API

Visual Studio

### Refit

Visual Studio

Refit is a type-safe REST Client for . NET Core, Xamarin and . Net - developed by Paul Betts. It is inspired by Square's Retrofit library. Refit makes it relatively easy to make calls to REST API, without writing much of wrapping code.

## Entity Framework, EFCore

## MVC? Blazor? Razor Pages?

## Misc

Linq

Razor

MVC

the Repository Pattern, Dependency Injection, Entity Framework, Data Transfer Objects (DTOs), AutoMapper

## C# lint

StyleCop, Sonar, Resharper, Visual Studio and Roslyn
