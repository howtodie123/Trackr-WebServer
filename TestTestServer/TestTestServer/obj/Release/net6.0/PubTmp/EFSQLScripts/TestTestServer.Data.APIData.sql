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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530102138_initData')
BEGIN
    CREATE TABLE [Admins] (
        [AdID] int NOT NULL IDENTITY,
        [AdName] nvarchar(max) NULL,
        [AdAccount] nvarchar(max) NULL,
        [AdPassword] nvarchar(max) NULL,
        CONSTRAINT [PK_Admins] PRIMARY KEY ([AdID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530102138_initData')
BEGIN
    CREATE TABLE [Customer] (
        [CusID] int NOT NULL IDENTITY,
        [CusName] nvarchar(max) NULL,
        [CusAddress] nvarchar(max) NULL,
        [CusPhone] nvarchar(max) NULL,
        [CusBirth] datetime2 NOT NULL,
        [CusDateRegister] datetime2 NOT NULL,
        [CusAccount] nvarchar(max) NULL,
        [CusPassword] nvarchar(max) NULL,
        CONSTRAINT [PK_Customer] PRIMARY KEY ([CusID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530102138_initData')
BEGIN
    CREATE TABLE [DeliveryMan] (
        [ManID] int NOT NULL IDENTITY,
        [ManName] nvarchar(max) NULL,
        [ManPhone] nvarchar(max) NULL,
        [ManAccount] nvarchar(max) NULL,
        [ManPassword] nvarchar(max) NULL,
        CONSTRAINT [PK_DeliveryMan] PRIMARY KEY ([ManID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530102138_initData')
BEGIN
    CREATE TABLE [Parcel] (
        [ParID] int NOT NULL IDENTITY,
        [ParImage] nvarchar(max) NULL,
        [ParDescription] nvarchar(max) NULL,
        [ParStatus] nvarchar(max) NULL,
        [ParDeliveryDate] datetime2 NOT NULL,
        [ParLocation] nvarchar(max) NULL,
        [Realtime] nvarchar(max) NULL,
        [Note] nvarchar(max) NULL,
        [Price] int NOT NULL,
        [CusID] int NOT NULL,
        [ManID] int NOT NULL,
        CONSTRAINT [PK_Parcel] PRIMARY KEY ([ParID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530102138_initData')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230530102138_initData', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230601073529_new')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230601073529_new', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602034423_new1')
BEGIN
    ALTER TABLE [DeliveryMan] ADD [ManImage] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602034423_new1')
BEGIN
    ALTER TABLE [Customer] ADD [CusImage] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602034423_new1')
BEGIN
    ALTER TABLE [Admins] ADD [AdImage] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602034423_new1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230602034423_new1', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602114512_new2')
BEGIN
    ALTER TABLE [Parcel] ADD [ParRouteLocation] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602114512_new2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230602114512_new2', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602115643_new 3')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Parcel]') AND [c].[name] = N'ParRouteLocation');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Parcel] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Parcel] ALTER COLUMN [ParRouteLocation] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602115643_new 3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230602115643_new 3', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230609123847_new5')
BEGIN
    CREATE TABLE [Review] (
        [ReID] int NOT NULL IDENTITY,
        [ParID] int NOT NULL,
        [ReDescription] nvarchar(max) NULL,
        [Star] int NOT NULL,
        CONSTRAINT [PK_Review] PRIMARY KEY ([ReID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230609123847_new5')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230609123847_new5', N'7.0.5');
END;
GO

COMMIT;
GO

