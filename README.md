# MyDotNet

My .Net

## My .Net experience

### My Linked In posts

Got some new additions to my collection - Blazor + MAUI + Telerik.

## Modern .Net migration

![](image/README/dotnet_migration_01.png)

![](image/README/dotnet_migration_02.png)

![](image/README/dotnet_migration_03.png)

![](image/README/dotnet_migration_04.png)

![](image/README/dotnet_migration_05.png)

![](image/README/dotnet_migration_06.png)

![](image/README/dotnet_migration_07.png)

## General

![](image/README/001.png)

![](image/README/002.png)

![](image/README/003.png)

![](image/README/004.png)

![](image/README/005.png)

## ASP .Net core

ASP .Net AJAX -> ASP .Net MVC -> ASP .Net Core

![](image/README/aspnet_01.png)

![](image/README/aspnet_02.png)

![](image/README/aspnet_03.png)

![](image/README/aspnet_04.png)

![](image/README/aspnet_05.png)

![](image/README/aspnet_06.png)

![](image/README/aspnet_07.png)

![](image/README/aspnet_08.png)

![](image/README/aspnet_09.png)

![](image/README/aspnet_10.png)

![](image/README/aspnet_11.png)

![](image/README/aspnet_12.png)

![](image/README/aspnet_13.png)

![](image/README/aspnet_14.png)

## Entity Framework

![](image/README/ef_01.png)

![](image/README/ef_02.png)

![](image/README/ef_03.png)

## Front end : ASP .net or Angular/React

If you want a good alternative to Angular, I'd recommend you Blazor WebAssembly not exactly ASP .NET Core.

The only real alternative to Angular in the .NET Ecosystem is Blazor WebAssembly, where you can write SPA with C# or F# with the power of WebAssembly, this allows you to run your app without special configurations or IIS.

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

## .Net installation

[.Net installation](my_DotNetInstall.md)

## New targets

### Blazor

[My Blazor](my_Blazor.md)

### MAUI

.NET Multi-platform App UI documentation

.NET Multi-platform App UI (.NET MAUI) lets you build native apps using a .NET cross-platform UI toolkit that targets the mobile and desktop form factors on Android, iOS, macOS, Windows, and Tizen.

online + offline mode

[My MAUI](my_MAUI.md)

### Sqlite

Sqlite Studio 3.3.3

[My Sqlite](my_Sqlite.md)

## Playwright

Use it to do e2e

https://playwright.dev/

### Telerik

Progressive Telerik

[My Telerik](my_Telerik.md)

### WPF

Backup plan if MAUI doesn't work.

## Misc

### Visual Studio format code

To format a selection: Ctrl+K, Ctrl+F

To format a document: Ctrl+K, Ctrl+D

### PCF

### NgRx

NgRx Store provides reactive state management for Angular apps inspired by Redux. Unify the events in your application and derive state using RxJS.

Someone said - NgRx has so much boilerplate code and it’s syntax is not straight forward at all. Services and RxJs can do everything you want to accomplish with NgRx with none of the useless boilerplate code that is required by NgRx.

He suggested to use service + RxJs instead of NgRx.

## Interview Questions

[.Net Interview Questions](my_DotNetIwQ.md)

## Repos to clone
