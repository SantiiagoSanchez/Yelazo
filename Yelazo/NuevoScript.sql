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

CREATE TABLE [Insumos] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Stock] int NOT NULL,
    [FechaActualizacion] datetime2 NOT NULL,
    [Categoria] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Insumos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Mantenimientos] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Frecuencia] int NOT NULL,
    [Descripcion] nvarchar(max) NOT NULL,
    [Estado] bit NOT NULL,
    [Insumo] bit NOT NULL,
    CONSTRAINT [PK_Mantenimientos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [MetodosPago] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_MetodosPago] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Productos] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Presentacion] nvarchar(max) NOT NULL,
    [Precio] decimal(18,2) NOT NULL,
    [Descripcion] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Productos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Proveedores] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Telefono] nvarchar(max) NOT NULL,
    [Correo] nvarchar(max) NULL,
    [Direccion] nvarchar(max) NOT NULL,
    [Descripcion] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Proveedores] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Roles] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TiposGasto] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TiposGasto] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250819223523_BaseDatos2.0', N'8.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Productos] ADD [Cantidad] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [Stocks] (
    [Id] int NOT NULL IDENTITY,
    [ProductoId] int NOT NULL,
    [FechaActualizacio] datetime2 NOT NULL,
    [Cantidad] int NOT NULL,
    [Movimiento] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Stocks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Stocks_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Stocks_ProductoId] ON [Stocks] ([ProductoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250919113653_Tabla_Stock', N'8.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Productos] ADD [Estado] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

CREATE TABLE [Gastos] (
    [Id] int NOT NULL IDENTITY,
    [Descripcion] nvarchar(max) NOT NULL,
    [Costo] decimal(18,2) NOT NULL,
    [Fecha] datetime2 NOT NULL,
    [tipoGastoId] int NOT NULL,
    [ProveedorId] int NOT NULL,
    CONSTRAINT [PK_Gastos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Gastos_Proveedores_ProveedorId] FOREIGN KEY ([ProveedorId]) REFERENCES [Proveedores] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Gastos_TiposGasto_tipoGastoId] FOREIGN KEY ([tipoGastoId]) REFERENCES [TiposGasto] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Gastos_ProveedorId] ON [Gastos] ([ProveedorId]);
GO

CREATE INDEX [IX_Gastos_tipoGastoId] ON [Gastos] ([tipoGastoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250929142105_TablaGasto', N'8.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [ActividadMantenimientos] (
    [Id] int NOT NULL IDENTITY,
    [FechaActividad] datetime2 NOT NULL,
    [Precio] decimal(18,2) NOT NULL,
    [ProveedorId] int NOT NULL,
    [MantenimientoId] int NOT NULL,
    CONSTRAINT [PK_ActividadMantenimientos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ActividadMantenimientos_Mantenimientos_MantenimientoId] FOREIGN KEY ([MantenimientoId]) REFERENCES [Mantenimientos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ActividadMantenimientos_Proveedores_ProveedorId] FOREIGN KEY ([ProveedorId]) REFERENCES [Proveedores] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [DetalleActividadMantenimientos] (
    [Id] int NOT NULL IDENTITY,
    [Cantidad] int NOT NULL,
    [InsumoId] int NOT NULL,
    [ActividadMantenimientoId] int NOT NULL,
    CONSTRAINT [PK_DetalleActividadMantenimientos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DetalleActividadMantenimientos_ActividadMantenimientos_ActividadMantenimientoId] FOREIGN KEY ([ActividadMantenimientoId]) REFERENCES [ActividadMantenimientos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_DetalleActividadMantenimientos_Insumos_InsumoId] FOREIGN KEY ([InsumoId]) REFERENCES [Insumos] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ActividadMantenimientos_MantenimientoId] ON [ActividadMantenimientos] ([MantenimientoId]);
GO

CREATE INDEX [IX_ActividadMantenimientos_ProveedorId] ON [ActividadMantenimientos] ([ProveedorId]);
GO

CREATE INDEX [IX_DetalleActividadMantenimientos_ActividadMantenimientoId] ON [DetalleActividadMantenimientos] ([ActividadMantenimientoId]);
GO

CREATE INDEX [IX_DetalleActividadMantenimientos_InsumoId] ON [DetalleActividadMantenimientos] ([InsumoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251006121232_TablasMantenimientos', N'8.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [IngresoInsumos] (
    [Id] int NOT NULL IDENTITY,
    [Cantidad] int NOT NULL,
    [Fecha] datetime2 NOT NULL,
    [Precio] decimal(18,2) NOT NULL,
    [InsumoId] int NOT NULL,
    [ProveedorId] int NOT NULL,
    CONSTRAINT [PK_IngresoInsumos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IngresoInsumos_Insumos_InsumoId] FOREIGN KEY ([InsumoId]) REFERENCES [Insumos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_IngresoInsumos_Proveedores_ProveedorId] FOREIGN KEY ([ProveedorId]) REFERENCES [Proveedores] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_IngresoInsumos_InsumoId] ON [IngresoInsumos] ([InsumoId]);
GO

CREATE INDEX [IX_IngresoInsumos_ProveedorId] ON [IngresoInsumos] ([ProveedorId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251017121002_Tabla_insumos', N'8.0.17');
GO

COMMIT;
GO

