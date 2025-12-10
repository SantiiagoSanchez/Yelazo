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

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [Nombre] nvarchar(max) NOT NULL,
    [Apellido] nvarchar(max) NOT NULL,
    [Telefono] nvarchar(max) NOT NULL,
    [Direccion] nvarchar(max) NOT NULL,
    [Zona] nvarchar(max) NULL,
    [Estado] bit NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
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
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
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
    [Cantidad] int NOT NULL,
    [Estado] bit NOT NULL,
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

CREATE TABLE [TiposGasto] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TiposGasto] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Carritos] (
    [Id] int NOT NULL IDENTITY,
    [UsuarioId] nvarchar(450) NOT NULL,
    [FechaCreacion] datetime2 NOT NULL,
    [FechaModificacion] datetime2 NULL,
    CONSTRAINT [PK_Carritos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Carritos_AspNetUsers_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Stocks] (
    [Id] int NOT NULL IDENTITY,
    [ProductoId] int NOT NULL,
    [FechaActualizacio] datetime2 NOT NULL,
    [Cantidad] int NOT NULL,
    [Movimiento] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Stocks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Stocks_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [ActividadMantenimientos] (
    [Id] int NOT NULL IDENTITY,
    [FechaActividad] datetime2 NOT NULL,
    [Precio] decimal(18,2) NOT NULL,
    [ProveedorId] int NOT NULL,
    [MantenimientoId] int NOT NULL,
    CONSTRAINT [PK_ActividadMantenimientos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ActividadMantenimientos_Mantenimientos_MantenimientoId] FOREIGN KEY ([MantenimientoId]) REFERENCES [Mantenimientos] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ActividadMantenimientos_Proveedores_ProveedorId] FOREIGN KEY ([ProveedorId]) REFERENCES [Proveedores] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [IngresoInsumos] (
    [Id] int NOT NULL IDENTITY,
    [Cantidad] int NOT NULL,
    [Fecha] datetime2 NOT NULL,
    [Precio] decimal(18,2) NOT NULL,
    [InsumoId] int NOT NULL,
    [ProveedorId] int NOT NULL,
    CONSTRAINT [PK_IngresoInsumos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IngresoInsumos_Insumos_InsumoId] FOREIGN KEY ([InsumoId]) REFERENCES [Insumos] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_IngresoInsumos_Proveedores_ProveedorId] FOREIGN KEY ([ProveedorId]) REFERENCES [Proveedores] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Gastos] (
    [Id] int NOT NULL IDENTITY,
    [Descripcion] nvarchar(max) NOT NULL,
    [Costo] decimal(18,2) NOT NULL,
    [Fecha] datetime2 NOT NULL,
    [tipoGastoId] int NOT NULL,
    [ProveedorId] int NOT NULL,
    CONSTRAINT [PK_Gastos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Gastos_Proveedores_ProveedorId] FOREIGN KEY ([ProveedorId]) REFERENCES [Proveedores] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Gastos_TiposGasto_tipoGastoId] FOREIGN KEY ([tipoGastoId]) REFERENCES [TiposGasto] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [DetalleCarritos] (
    [Id] int NOT NULL IDENTITY,
    [CarritoId] int NOT NULL,
    [ProductoId] int NOT NULL,
    [Cantidad] int NOT NULL,
    [Total] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_DetalleCarritos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DetalleCarritos_Carritos_CarritoId] FOREIGN KEY ([CarritoId]) REFERENCES [Carritos] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DetalleCarritos_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Pedidos] (
    [Id] int NOT NULL IDENTITY,
    [UsuarioId] nvarchar(450) NOT NULL,
    [CarritoId] int NOT NULL,
    [FechaPedido] datetime2 NOT NULL,
    [Total] decimal(18,2) NOT NULL,
    [Estado] nvarchar(max) NOT NULL,
    [Saldo] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pedidos_AspNetUsers_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Pedidos_Carritos_CarritoId] FOREIGN KEY ([CarritoId]) REFERENCES [Carritos] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [DetalleActividadMantenimientos] (
    [Id] int NOT NULL IDENTITY,
    [Cantidad] int NOT NULL,
    [InsumoId] int NOT NULL,
    [ActividadMantenimientoId] int NOT NULL,
    CONSTRAINT [PK_DetalleActividadMantenimientos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DetalleActividadMantenimientos_ActividadMantenimientos_ActividadMantenimientoId] FOREIGN KEY ([ActividadMantenimientoId]) REFERENCES [ActividadMantenimientos] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DetalleActividadMantenimientos_Insumos_InsumoId] FOREIGN KEY ([InsumoId]) REFERENCES [Insumos] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [DetallePedidos] (
    [Id] int NOT NULL IDENTITY,
    [PedidoId] int NOT NULL,
    [ProductoId] int NOT NULL,
    [Cantidad] int NOT NULL,
    [Total] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_DetallePedidos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DetallePedidos_Pedidos_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [Pedidos] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DetallePedidos_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_ActividadMantenimientos_MantenimientoId] ON [ActividadMantenimientos] ([MantenimientoId]);
GO

CREATE INDEX [IX_ActividadMantenimientos_ProveedorId] ON [ActividadMantenimientos] ([ProveedorId]);
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

CREATE INDEX [IX_Carritos_UsuarioId] ON [Carritos] ([UsuarioId]);
GO

CREATE INDEX [IX_DetalleActividadMantenimientos_ActividadMantenimientoId] ON [DetalleActividadMantenimientos] ([ActividadMantenimientoId]);
GO

CREATE INDEX [IX_DetalleActividadMantenimientos_InsumoId] ON [DetalleActividadMantenimientos] ([InsumoId]);
GO

CREATE INDEX [IX_DetalleCarritos_CarritoId] ON [DetalleCarritos] ([CarritoId]);
GO

CREATE INDEX [IX_DetalleCarritos_ProductoId] ON [DetalleCarritos] ([ProductoId]);
GO

CREATE INDEX [IX_DetallePedidos_PedidoId] ON [DetallePedidos] ([PedidoId]);
GO

CREATE INDEX [IX_DetallePedidos_ProductoId] ON [DetallePedidos] ([ProductoId]);
GO

CREATE INDEX [IX_Gastos_ProveedorId] ON [Gastos] ([ProveedorId]);
GO

CREATE INDEX [IX_Gastos_tipoGastoId] ON [Gastos] ([tipoGastoId]);
GO

CREATE INDEX [IX_IngresoInsumos_InsumoId] ON [IngresoInsumos] ([InsumoId]);
GO

CREATE INDEX [IX_IngresoInsumos_ProveedorId] ON [IngresoInsumos] ([ProveedorId]);
GO

CREATE INDEX [IX_Pedidos_CarritoId] ON [Pedidos] ([CarritoId]);
GO

CREATE INDEX [IX_Pedidos_UsuarioId] ON [Pedidos] ([UsuarioId]);
GO

CREATE INDEX [IX_Stocks_ProductoId] ON [Stocks] ([ProductoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251110191252_db-yelazo2.0', N'8.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO AspNetRoles(Id, Name, NormalizedName)
                               VALUES('ba018153-7544-4fbd-a59c-c2660628308e', 'admin', 'ADMIN')
GO

INSERT INTO AspNetRoles(Id, Name, NormalizedName)
                               VALUES('ba018153-7544-4fbd-a59c-c2660628419f', 'produccion', 'PRODUCCION')
GO

INSERT INTO AspNetRoles(Id, Name, NormalizedName)
                               VALUES('ba018153-7544-4fbd-a59c-c3770628308e', 'repartidor', 'REPARTIDOR')
GO

INSERT INTO AspNetRoles(Id, Name, NormalizedName)
                               VALUES('ba018153-7544-4fbd-a59c-c5880628532e', 'cliente', 'CLIENTE')
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251110191850_roles', N'8.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Carritos] ADD [Finalizado] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251110193128_campo_finalizado', N'8.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Pagos] (
    [Id] int NOT NULL IDENTITY,
    [PedidoId] int NOT NULL,
    [Monto] decimal(18,2) NOT NULL,
    [FechaPago] datetime2 NOT NULL,
    [MetodoPagoId] int NOT NULL,
    CONSTRAINT [PK_Pagos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pagos_MetodosPago_MetodoPagoId] FOREIGN KEY ([MetodoPagoId]) REFERENCES [MetodosPago] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Pagos_Pedidos_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [Pedidos] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Pagos_MetodoPagoId] ON [Pagos] ([MetodoPagoId]);
GO

CREATE INDEX [IX_Pagos_PedidoId] ON [Pagos] ([PedidoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251124145055_tabla_pagos', N'8.0.17');
GO

COMMIT;
GO

