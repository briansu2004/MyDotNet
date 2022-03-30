CREATE TABLE [dbo].[People] (
    [Id]           INT             NOT NULL	identity,
    [FirstName]    VARCHAR(50)  NOT NULL,
    [LastName]     VARCHAR(50)  NOT NULL,
    [DateOfBirth]  DATE            NOT NULL,
    [EmailAddress] VARCHAR(50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

