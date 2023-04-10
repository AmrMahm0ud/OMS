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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230318025854_BD_Init')
BEGIN
    CREATE TABLE [Status] (
        [id] int NOT NULL IDENTITY,
        [name] nvarchar(max) NULL,
        CONSTRAINT [PK_Status] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230318025854_BD_Init')
BEGIN
    CREATE TABLE [Users] (
        [id] int NOT NULL IDENTITY,
        [userName] nvarchar(max) NOT NULL,
        [userPassword] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230318025854_BD_Init')
BEGIN
    CREATE TABLE [Tasks] (
        [orderId] int NOT NULL IDENTITY,
        [orderAmount] float NOT NULL,
        [COD] float NOT NULL,
        [orderStatus] int NULL,
        [assinedTo] int NULL,
        CONSTRAINT [PK_Tasks] PRIMARY KEY ([orderId]),
        CONSTRAINT [FK_Tasks_Status_orderStatus] FOREIGN KEY ([orderStatus]) REFERENCES [Status] ([id]),
        CONSTRAINT [FK_Tasks_Users_assinedTo] FOREIGN KEY ([assinedTo]) REFERENCES [Users] ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230318025854_BD_Init')
BEGIN
    CREATE INDEX [IX_Tasks_assinedTo] ON [Tasks] ([assinedTo]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230318025854_BD_Init')
BEGIN
    CREATE INDEX [IX_Tasks_orderStatus] ON [Tasks] ([orderStatus]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230318025854_BD_Init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230318025854_BD_Init', N'7.0.4');
END;
GO

COMMIT;
GO

