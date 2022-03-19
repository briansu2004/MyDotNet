# Sqlite

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
