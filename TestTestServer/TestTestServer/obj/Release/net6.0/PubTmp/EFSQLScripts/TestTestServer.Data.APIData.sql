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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519111703_init')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230519111703_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230519111703_init', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230520040134_DeliveryMan')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230520040134_DeliveryMan')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230520040134_DeliveryMan', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230520042622_Customer')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230520042622_Customer')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230520042622_Customer', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230520054847_Parcel')
BEGIN
    CREATE TABLE [Parcel] (
        [ParID] int NOT NULL IDENTITY,
        [ParDescription] nvarchar(max) NULL,
        [ParStatus] nvarchar(max) NULL,
        [ParDeliveryDate] datetime2 NOT NULL,
        [ParLocation] nvarchar(max) NULL,
        [Realtime] datetime2 NOT NULL,
        [Note] nvarchar(max) NULL,
        [Price] int NOT NULL,
        [CusID] int NOT NULL,
        [ManID] int NOT NULL,
        CONSTRAINT [PK_Parcel] PRIMARY KEY ([ParID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230520054847_Parcel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230520054847_Parcel', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230520150006_a')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230520150006_a', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230525012533_huhu')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230525012533_huhu', N'7.0.5');
END;
GO

COMMIT;
GO

