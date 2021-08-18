IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF SCHEMA_ID(N'events') IS NULL EXEC(N'CREATE SCHEMA [events];');
GO

IF SCHEMA_ID(N'notification') IS NULL EXEC(N'CREATE SCHEMA [notification];');
GO

IF SCHEMA_ID(N'identity') IS NULL EXEC(N'CREATE SCHEMA [identity];');
GO

CREATE TABLE [identity].[User] (
    [Id] uniqueidentifier NOT NULL,
    [UserName] nvarchar(max) NULL,
    [NormalizedUserName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [NormalizedEmail] nvarchar(max) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [events].[Event] (
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [Date] datetime2 NOT NULL,
    [WithYear] bit NOT NULL,
    CONSTRAINT [PK_Event] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Event_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [identity].[User] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [notification].[Notification] (
    [Id] uniqueidentifier NOT NULL,
    [EventId] uniqueidentifier NOT NULL,
    [Viewed] bit NOT NULL,
    CONSTRAINT [PK_Notification] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Notification_Event_EventId] FOREIGN KEY ([EventId]) REFERENCES [events].[Event] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Event_UserId] ON [events].[Event] ([UserId]);
GO

CREATE INDEX [IX_Notification_EventId] ON [notification].[Notification] ([EventId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210818154516_initial', N'5.0.9');
GO

COMMIT;
GO

