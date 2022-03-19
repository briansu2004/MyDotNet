# MyDotNet

My .Net

## General

![](image/README/001.png)

![](image/README/002.png)

![](image/README/003.png)

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

## Local .Net installation

### Understand the CPU

To download .net core, there are 3 options for Windows - x64, x86, and Arm64.

Like x86 and x64, ARM is a different processor (CPU) architecture. The ARM architecture is typically used to build CPUs for a mobile device, ARM64 is simply an extension or evolution of the ARM architecture that supports 64-bit processing. Devices built on the ARM64 architecture include desktop PCs, mobile devices, and some IoT Core devices (Rasperry Pi 2, Raspberry Pi 3, and DragonBoard). For example the Microsoft HoloLens 2 uses an ARM64 processor.

How to Check if Processor is 32-bit, 64-bit, or ARM in Windows 10?

- Open the Settings app.
- Navigate to System > About.
- On the right, check out the System type value
- It shows either a x86-based processor (32-bit), x64-based processor (64-bit), or ARM-based processor depending on the hardware you have.

![](image/README/cpu_type.png)

### .Net core 6.0

dotnet-sdk-6.0.201-win-x64.exe

.Net SDK 6.0.201

.Net runtime 6.0.3 (x64)

The folder is not under C:\Windows\Microsoft.NET\Framework or C:\Windows\Microsoft.NET\Framework64

### SQL Server 2019 Express

SQL2019-SSEI-Expr.exe

C:\Program Files\Microsoft SQL Server

Connection String:

Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;

SQL Server install log folder:

C:\Program Files\Microsoft SQL Server\150\Setup Bootstrap\Log\20220317_084609

Installation media folder:

C:\SQL2019\Express_ENU

Installation resource folder:

C:\Program Files\Microsoft SQL Server\150\SSEI\Resources

![](image/README/sql_server_2019_express_install.png)

Connect SQL Server with SQL CMD:

`sqlcmd -S L113220\SQLEXPRESS -E`

![](image/README/sql_server_2019_express_sqlcmd.png)

### SQL Server Management Studio (SSMS) 18

SSMS-Setup-ENU.exe

C:\Program Files (x86)\Microsoft SQL Server Management Studio 18

![](image/README/ssms_01.png)

![](image/README/ssms_02.png)

### Visual Studio 2022 Preview Enterprise Edition

C:\Program Files\Microsoft Visual Studio\2022\Preview

![](image/README/visual_studio_installer.png)

![](image/README/vs_01.png)

![](image/README/vs_02.png)

## New targets

### Blazor

Blazor is a free and open-source web framework that enables developers to create web apps using C# and HTML.

Blazor Server vs. Blazor WebAssembly

@page

@variable

@event

@code

```
@page "/counter"

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

![](image/README/blazor_01.png)

Razor page vs Razor component

![](image/README/blazor_02.png)

![](image/README/blazor_03.png)

![](image/README/blazor_04.png)

@using

@inject

@if

![](image/README/blazor_component_lifecycle.png)

![](image/README/blazor_05.png)

Dapper

Dapper is a simple object mapper for .NET that owns the title of King of Micro ORM in terms of speed, as it’s virtually as fast as using a raw ADO.NET data reader. It is available as a NuGet package. An ORM (object-relational mapper) is responsible for mapping databases and programming languages.

Dapper is database independent. It does not contain any database-specific implementation. Arguably, it is chosen by people who want to write their own SQL query. It simply provides extension methods for the IDbConnection interface which helps users to query and perform CRUD operations in databases.

Dapper is in production use at Stack Overflow.

![](image/README/blazor_dapper.png)

ctor -> tab -> create a constructor

prop -> tab -> create a property

Control + .

Quick Actions and Refactorings (Control + .) -> Extract interface

SQL Server Object Expolorer

![](image/README/MSSQLLocalDB.png)

x.Server/Program.cs

```
global using BlazorFullStackCrud.Shared;
```

x.Client/Program.cs

```
global using BlazorFullStackCrud.Client.Services.SuperHeroService;
...
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
```

```
https://localhost:7251/superheroes
https://localhost:7251/api/superhero
```

Use the @inject directive to inject the service into components. @inject has two parameters (type and name). Type represents the service type and name represents the service instance name.

```
@inject ServiceType ServiceInstanceName
```

NuGet:

```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Sqlite
```

```
dotnet tool install --global dotnet-ef
```

```
PM> dotnet tool install --global dotnet-ef
You can invoke the tool using the following command: dotnet-ef
Tool 'dotnet-ef' (version '6.0.3') was successfully installed.
```

```
dotnet-ef
```

```
PM> dotnet-ef

                     _/\__
               ---==/    \\
         ___  ___   |.    \|\
        | __|| __|  |  )   \\\
        | _| | _|   \_/ |  //|\\
        |___||_|       /   \\\/\\

Entity Framework Core .NET Command-line Tools 6.0.3

Usage: dotnet ef [options] [command]

Options:
  --version        Show version information
  -h|--help        Show help information
  -v|--verbose     Show verbose output.
  --no-color       Don't colorize output.
  --prefix-output  Prefix output with level.

Commands:
  database    Commands to manage the database.
  dbcontext   Commands to manage DbContext types.
  migrations  Commands to manage migrations.

Use "dotnet ef [command] --help" for more information about a command.
PM>
```

```
dotnet ef migrations add Initial
```

```
PM> dotnet ef migrations add Initial
Build started...
Build succeeded.
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 6.0.3 initialized 'DataContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer:6.0.3' with options: None
Done. To undo this action, use 'ef migrations remove'
PM>
```

What is dotnet EF migrations?

Migration is a way to keep the database schema in sync with the EF Core model by preserving data.

EF Core migrations are a set of commands which you can execute in NuGet Package Manager Console or in dotnet Command Line Interface (CLI).

![](image/README/dotnet_EF_migration.png)

```
dotnet ef database update
```

```
PM> dotnet ef database update
Build started...
Build succeeded.
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 6.0.3 initialized 'DataContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer:6.0.3' with options: None
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (30ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (24ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [__EFMigrationsHistory] (
          [MigrationId] nvarchar(150) NOT NULL,
          [ProductVersion] nvarchar(32) NOT NULL,
          CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [MigrationId], [ProductVersion]
      FROM [__EFMigrationsHistory]
      ORDER BY [MigrationId];
info: Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20220319003804_Initial'.
Applying migration '20220319003804_Initial'.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [Comics] (
          [Id] int NOT NULL IDENTITY,
          [Name] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_Comics] PRIMARY KEY ([Id])
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [SuperHeroes] (
          [Id] int NOT NULL IDENTITY,
          [FirstName] nvarchar(max) NOT NULL,
          [LastName] nvarchar(max) NOT NULL,
          [HeroName] nvarchar(max) NOT NULL,
          [ComicId] int NOT NULL,
          CONSTRAINT [PK_SuperHeroes] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_SuperHeroes_Comics_ComicId] FOREIGN KEY ([ComicId]) REFERENCES [Comics] ([Id]) ON DELETE CASCADE
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (20ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Comics]'))
          SET IDENTITY_INSERT [Comics] ON;
      INSERT INTO [Comics] ([Id], [Name])
      VALUES (1, N'Mavel');
      IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Comics]'))
          SET IDENTITY_INSERT [Comics] OFF;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (9ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Comics]'))
          SET IDENTITY_INSERT [Comics] ON;
      INSERT INTO [Comics] ([Id], [Name])
      VALUES (2, N'DC');
      IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Comics]'))
          SET IDENTITY_INSERT [Comics] OFF;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (10ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ComicId', N'FirstName', N'HeroName', N'LastName') AND [object_id] = OBJECT_ID(N'[SuperHeroes]'))
          SET IDENTITY_INSERT [SuperHeroes] ON;
      INSERT INTO [SuperHeroes] ([Id], [ComicId], [FirstName], [HeroName], [LastName])
      VALUES (1, 1, N'Peter', N'SpiderMan', N'Parker');
      IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ComicId', N'FirstName', N'HeroName', N'LastName') AND [object_id] = OBJECT_ID(N'[SuperHeroes]'))
          SET IDENTITY_INSERT [SuperHeroes] OFF;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (9ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ComicId', N'FirstName', N'HeroName', N'LastName') AND [object_id] = OBJECT_ID(N'[SuperHeroes]'))
          SET IDENTITY_INSERT [SuperHeroes] ON;
      INSERT INTO [SuperHeroes] ([Id], [ComicId], [FirstName], [HeroName], [LastName])
      VALUES (2, 2, N'Bruce', N'BatMan', N'Wayne');
      IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ComicId', N'FirstName', N'HeroName', N'LastName') AND [object_id] = OBJECT_ID(N'[SuperHeroes]'))
          SET IDENTITY_INSERT [SuperHeroes] OFF;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (21ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE INDEX [IX_SuperHeroes_ComicId] ON [SuperHeroes] ([ComicId]);
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'20220319003804_Initial', N'6.0.3');
Done.
PM>
```

Blazor Routing

Routing in Blazor is achieved by providing a route template to each accessible component in the app with an @page directive.

When a Razor file with an @page directive is compiled, the generated class is given a RouteAttribute specifying the route template. At runtime, the router searches for component classes with a RouteAttribute and renders whichever component has a route template that matches the requested URL.

Asynchronous methods (async) don't support returning void

The Blazor framework doesn't track void-returning asynchronous methods (async). As a result, exceptions aren't caught if void is returned. Always return a Task from asynchronous methods.

To escape an @ symbol in Razor markup, use a second @ symbol:

```
<p>@@Username</p>
```

`App.razor`

Router?

```
<Router AppAssembly="@typeof(App).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
        <FocusOnNavigate RouteData="@routeData" Selector="h1" />
    </Found>
    <NotFound>
        <PageTitle>Not found</PageTitle>
        <LayoutView Layout="@typeof(MainLayout)">
            <p role="alert">Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>
```

`_Imports.razor`

Every folder of an app can optionally contain a template file named \_Imports.razor.

The \_Imports.razor file is similar to the \_ViewImports.cshtml file for Razor views and pages but applied specifically to Razor component files.

It's simply a file where you can put you using statements for all razor files and also if you to inject something on all pages you could add it there also.

You can also add [Authorize] there to make all pages require authorization as well, which is pretty nifty for a whitelist approach (add [AllowAnonymous] only if needed) if you're doing something like say an Admin portal.

`Task Class`

Namespace: System.Threading.Tasks

Assembly: System.Runtime.dll

Represents an asynchronous operation.

The Task class represents a single operation that does not return a value and that usually executes asynchronously. Task objects are one of the central components of the task-based asynchronous pattern first introduced in the .NET Framework 4. Because the work performed by a Task object typically executes asynchronously on a thread pool thread rather than synchronously on the main application thread, you can use the Status property, as well as the IsCanceled, IsCompleted, and IsFaulted properties, to determine the state of a task. Most commonly, a lambda expression is used to specify the work that the task is to perform.

For operations that return values, you use the Task<TResult> class.

TAP vs APM vs EAP

`Task-based asynchronous pattern (TAP)`

TAP uses a single method to represent the initiation and completion of an asynchronous operation. This contrasts with both the Asynchronous Programming Model (APM or IAsyncResult) pattern and the Event-based Asynchronous Pattern (EAP).

`Generate Angular and React components`

Generate framework-specific JavaScript (JS) components from Razor components for web frameworks, such as Angular or React. This capability isn't included with .NET 6, but is enabled by the new support for rendering Razor components from JS. The JS component generation sample on GitHub demonstrates how to generate Angular and React components from Razor components. See the GitHub sample app's README.md file for additional information.

Warning

The Angular and React component features are currently experimental, unsupported, and subject to change or be removed at any time. We welcome your feedback on how well this particular approach meets your requirements.

#### Troubleshooting

![](image/README/1647711725506.png)

aspnetcore-browser-refresh.js:234 WebSocket connection to 'wss://localhost:44392/BlazorFullStackCrud.Server/' failed: Error in connection establishment: net::ERR_CERT_AUTHORITY_INVALID

![](image/README/1647711784499.png)

```
C:\Program Files (x86)\IIS Express\IisExpressAdminCmd.exe setupsslUrl -url:https://localhost:44392/ -UseSelfSigned
```

```
C:\WINDOWS\system32>cd C:\Program Files (x86)\IIS Express\

C:\Program Files (x86)\IIS Express>IisExpressAdminCmd.exe setupsslUrl -url:https://localhost:44392/ -UseSelfSigned
setupsslUrlCommand 'setupsslUrl' failed.
The requested operation requires elevation (Run as administrator).

C:\Program Files (x86)\IIS Express>IisExpressAdminCmd.exe setupsslUrl -url:https://localhost:44392/ -UseSelfSigned
Command 'setupsslUrl' completed.
```

### Sqlite

Sqlite Studio 3.3.3

C:\Apps\SQLiteStudio\

C:\CodeRepo\SqliteDB\Worksheet.db

![](image/README/Sqlite_Worksheet_01.png)

![](image/README/Sqlite_Worksheet_02.png)

![](image/README/Sqlite_Worksheet_03.png)

![](image/README/Sqlite_Worksheet_04.png)

![](image/README/Sqlite_Worksheet_05.png)

![](image/README/Sqlite_Worksheet_06.png)

```
drop table people;

CREATE TABLE [dbo].[People] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50)  NOT NULL,
    [LastName]     VARCHAR (50)  NOT NULL,
    [DateOfBirth]  DATE            NULL,
    [EmailAddress] VARCHAR (100)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
```

Add a new item -> Razor Component

Razor Component vs Razor Page vs Razor View

oi is an open source icon library

To format a selection: Ctrl+K, Ctrl+F

To format a document: Ctrl+K, Ctrl+D

## Playwright

Use it to do e2e

https://playwright.dev/

### Telerik

    Progressive Telerik

    Telerik UI for ASP.NET AJAX

### MAUI

    .NET Multi-platform App UI documentation

    .NET Multi-platform App UI (.NET MAUI) lets you build native apps using a .NET cross-platform UI toolkit that targets the mobile and desktop form factors on Android, iOS, macOS, Windows, and Tizen.

    online + offline mode

### WPF

    Backup plan if MAUI doesn't work.

### PCF

### NgRx

NgRx Store provides reactive state management for Angular apps inspired by Redux. Unify the events in your application and derive state using RxJS.

Someone said - NgRx has so much boilerplate code and it’s syntax is not straight forward at all. Services and RxJs can do everything you want to accomplish with NgRx with none of the useless boilerplate code that is required by NgRx.

He suggested to use service + RxJs instead of NgRx.
