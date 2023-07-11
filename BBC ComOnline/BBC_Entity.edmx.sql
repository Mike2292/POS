
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/21/2021 03:28:54
-- Generated from EDMX file: C:\Users\Usuario\source\repos\BBC ComOnline\BBC ComOnline\BBC_Entity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BBC_ComOnline];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ArticuloArticulo_Proveedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articulo_Proveedor] DROP CONSTRAINT [FK_ArticuloArticulo_Proveedor];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaEmpresa_Articulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empresa_Articulo] DROP CONSTRAINT [FK_EmpresaEmpresa_Articulo];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticuloEmpresa_Articulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empresa_Articulo] DROP CONSTRAINT [FK_ArticuloEmpresa_Articulo];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoriaEmpresa_Articulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empresa_Articulo] DROP CONSTRAINT [FK_CategoriaEmpresa_Articulo];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonalUsuario_Personal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario_Personal] DROP CONSTRAINT [FK_PersonalUsuario_Personal];
GO
IF OBJECT_ID(N'[dbo].[FK_CargoPersonal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personals] DROP CONSTRAINT [FK_CargoPersonal];
GO
IF OBJECT_ID(N'[dbo].[FK_CargoCargo_Modulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cargo_Modulo] DROP CONSTRAINT [FK_CargoCargo_Modulo];
GO
IF OBJECT_ID(N'[dbo].[FK_ModuloCargo_Modulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cargo_Modulo] DROP CONSTRAINT [FK_ModuloCargo_Modulo];
GO
IF OBJECT_ID(N'[dbo].[FK_Unidad_MedidaEmpresa_Articulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empresa_Articulo] DROP CONSTRAINT [FK_Unidad_MedidaEmpresa_Articulo];
GO
IF OBJECT_ID(N'[dbo].[FK_ProveedorArticulo_Proveedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articulo_Proveedor] DROP CONSTRAINT [FK_ProveedorArticulo_Proveedor];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_EmpresaUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioUsuario_Personal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario_Personal] DROP CONSTRAINT [FK_UsuarioUsuario_Personal];
GO
IF OBJECT_ID(N'[dbo].[FK_VentaEmpresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VentaSet] DROP CONSTRAINT [FK_VentaEmpresa];
GO
IF OBJECT_ID(N'[dbo].[FK_VentaDetalle_Venta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Detalle_VentaSet] DROP CONSTRAINT [FK_VentaDetalle_Venta];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticuloDetalle_Venta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Detalle_VentaSet] DROP CONSTRAINT [FK_ArticuloDetalle_Venta];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioCarro_Compra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Carro_CompraSet] DROP CONSTRAINT [FK_UsuarioCarro_Compra];
GO
IF OBJECT_ID(N'[dbo].[FK_Carro_CompraDetalle_Carro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Detalle_CarroSet] DROP CONSTRAINT [FK_Carro_CompraDetalle_Carro];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticuloDetalle_Carro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Detalle_CarroSet] DROP CONSTRAINT [FK_ArticuloDetalle_Carro];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioCaja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CajaSet] DROP CONSTRAINT [FK_UsuarioCaja];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Articuloes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articuloes];
GO
IF OBJECT_ID(N'[dbo].[Proveedors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedors];
GO
IF OBJECT_ID(N'[dbo].[Empresas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empresas];
GO
IF OBJECT_ID(N'[dbo].[Articulo_Proveedor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articulo_Proveedor];
GO
IF OBJECT_ID(N'[dbo].[Empresa_Articulo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empresa_Articulo];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[Personals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personals];
GO
IF OBJECT_ID(N'[dbo].[Categorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categorias];
GO
IF OBJECT_ID(N'[dbo].[Cargoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cargoes];
GO
IF OBJECT_ID(N'[dbo].[Usuario_Personal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario_Personal];
GO
IF OBJECT_ID(N'[dbo].[Moduloes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Moduloes];
GO
IF OBJECT_ID(N'[dbo].[Cargo_Modulo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cargo_Modulo];
GO
IF OBJECT_ID(N'[dbo].[Unidad_Medida]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Unidad_Medida];
GO
IF OBJECT_ID(N'[dbo].[VentaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VentaSet];
GO
IF OBJECT_ID(N'[dbo].[Detalle_VentaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Detalle_VentaSet];
GO
IF OBJECT_ID(N'[dbo].[Detalle_CarroSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Detalle_CarroSet];
GO
IF OBJECT_ID(N'[dbo].[Carro_CompraSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Carro_CompraSet];
GO
IF OBJECT_ID(N'[dbo].[CajaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CajaSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Articuloes'
CREATE TABLE [dbo].[Articuloes] (
    [EAN] varchar(20)  NOT NULL,
    [Descripcion] varchar(100)  NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'Proveedors'
CREATE TABLE [dbo].[Proveedors] (
    [Rut] nvarchar(11)  NOT NULL,
    [RazonSocial] nvarchar(50)  NOT NULL,
    [Rubro] nvarchar(50)  NOT NULL,
    [Direccion] nvarchar(100)  NOT NULL,
    [Telefono] nvarchar(12)  NOT NULL,
    [Correo] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Empresas'
CREATE TABLE [dbo].[Empresas] (
    [Rut] nvarchar(11)  NOT NULL,
    [RazonSocial] nvarchar(50)  NOT NULL,
    [Rubro] nvarchar(50)  NOT NULL,
    [Direccion] nvarchar(100)  NOT NULL,
    [Telefono] nvarchar(12)  NOT NULL
);
GO

-- Creating table 'Articulo_Proveedor'
CREATE TABLE [dbo].[Articulo_Proveedor] (
    [EAN_ID] varchar(20)  NOT NULL,
    [ProveedorRut] nvarchar(11)  NOT NULL
);
GO

-- Creating table 'Empresa_Articulo'
CREATE TABLE [dbo].[Empresa_Articulo] (
    [EmpresaRut] nvarchar(11)  NOT NULL,
    [EAN_ID] varchar(20)  NOT NULL,
    [Codigo_Interno] nvarchar(20)  NULL,
    [Unidad_MedidaId] int  NULL,
    [CategoriaId] int  NULL,
    [Precio_Publico] decimal(18,0)  NOT NULL,
    [Precio_Costo] decimal(18,0)  NOT NULL,
    [Cantidad] decimal(18,0)  NOT NULL,
    [Fecha_Compra] datetime  NULL,
    [IVA] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Correo] nvarchar(100)  NOT NULL,
    [Clave] nvarchar(100)  NOT NULL,
    [Estado] bit  NOT NULL,
    [EmpresaRut] nvarchar(11)  NOT NULL
);
GO

-- Creating table 'Personals'
CREATE TABLE [dbo].[Personals] (
    [Rut] nvarchar(11)  NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Apellido] nvarchar(50)  NOT NULL,
    [Genero] nvarchar(50)  NOT NULL,
    [CargoId] int  NOT NULL
);
GO

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Cargoes'
CREATE TABLE [dbo].[Cargoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Usuario_Personal'
CREATE TABLE [dbo].[Usuario_Personal] (
    [UsuarioId] int  NOT NULL,
    [PersonalRut] nvarchar(11)  NOT NULL,
    [Personal_Rut] nvarchar(11)  NOT NULL,
    [Usuario_Id] int  NOT NULL
);
GO

-- Creating table 'Moduloes'
CREATE TABLE [dbo].[Moduloes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Cargo_Modulo'
CREATE TABLE [dbo].[Cargo_Modulo] (
    [CargoId] int  NOT NULL,
    [ModuloId] int  NOT NULL
);
GO

-- Creating table 'Unidad_Medida'
CREATE TABLE [dbo].[Unidad_Medida] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'VentaSet'
CREATE TABLE [dbo].[VentaSet] (
    [Id] nvarchar(100)  NOT NULL,
    [NumeroOrden] nvarchar(max)  NULL,
    [FechaVenta] datetime  NOT NULL,
    [MetodoPago] nvarchar(max)  NOT NULL,
    [Total] decimal(18,0)  NOT NULL,
    [Empresa_Rut] nvarchar(11)  NOT NULL
);
GO

-- Creating table 'Detalle_VentaSet'
CREATE TABLE [dbo].[Detalle_VentaSet] (
    [Id] nvarchar(100)  NOT NULL,
    [VentaId] nvarchar(100)  NOT NULL,
    [ArticuloEAN] varchar(20)  NOT NULL,
    [PrecioUnitario] decimal(18,0)  NOT NULL,
    [Cantidad] decimal(18,0)  NOT NULL,
    [SubTotal] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Detalle_CarroSet'
CREATE TABLE [dbo].[Detalle_CarroSet] (
    [ID] nvarchar(50)  NOT NULL,
    [Carro_CompraId] nvarchar(50)  NOT NULL,
    [ArticuloEAN] varchar(20)  NOT NULL,
    [Descripcion_Producto] nvarchar(100)  NOT NULL,
    [Precio] decimal(18,0)  NOT NULL,
    [Cantidad] decimal(18,0)  NOT NULL,
    [SubTotal] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Carro_CompraSet'
CREATE TABLE [dbo].[Carro_CompraSet] (
    [Id] nvarchar(50)  NOT NULL,
    [UsuarioId] int  NOT NULL,
    [Total] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'CajaSet'
CREATE TABLE [dbo].[CajaSet] (
    [Id] nvarchar(50)  NOT NULL,
    [UsuarioId] int  NOT NULL,
    [FechaApertura] datetime  NOT NULL,
    [FechaCierre] datetime  NOT NULL,
    [Estado] bit  NOT NULL,
    [MontoInicial] decimal(18,0)  NOT NULL,
    [Total] decimal(18,0)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EAN] in table 'Articuloes'
ALTER TABLE [dbo].[Articuloes]
ADD CONSTRAINT [PK_Articuloes]
    PRIMARY KEY CLUSTERED ([EAN] ASC);
GO

-- Creating primary key on [Rut] in table 'Proveedors'
ALTER TABLE [dbo].[Proveedors]
ADD CONSTRAINT [PK_Proveedors]
    PRIMARY KEY CLUSTERED ([Rut] ASC);
GO

-- Creating primary key on [Rut] in table 'Empresas'
ALTER TABLE [dbo].[Empresas]
ADD CONSTRAINT [PK_Empresas]
    PRIMARY KEY CLUSTERED ([Rut] ASC);
GO

-- Creating primary key on [EAN_ID], [ProveedorRut] in table 'Articulo_Proveedor'
ALTER TABLE [dbo].[Articulo_Proveedor]
ADD CONSTRAINT [PK_Articulo_Proveedor]
    PRIMARY KEY CLUSTERED ([EAN_ID], [ProveedorRut] ASC);
GO

-- Creating primary key on [EmpresaRut], [EAN_ID] in table 'Empresa_Articulo'
ALTER TABLE [dbo].[Empresa_Articulo]
ADD CONSTRAINT [PK_Empresa_Articulo]
    PRIMARY KEY CLUSTERED ([EmpresaRut], [EAN_ID] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Rut] in table 'Personals'
ALTER TABLE [dbo].[Personals]
ADD CONSTRAINT [PK_Personals]
    PRIMARY KEY CLUSTERED ([Rut] ASC);
GO

-- Creating primary key on [Id] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cargoes'
ALTER TABLE [dbo].[Cargoes]
ADD CONSTRAINT [PK_Cargoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [PersonalRut], [UsuarioId] in table 'Usuario_Personal'
ALTER TABLE [dbo].[Usuario_Personal]
ADD CONSTRAINT [PK_Usuario_Personal]
    PRIMARY KEY CLUSTERED ([PersonalRut], [UsuarioId] ASC);
GO

-- Creating primary key on [Id] in table 'Moduloes'
ALTER TABLE [dbo].[Moduloes]
ADD CONSTRAINT [PK_Moduloes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CargoId], [ModuloId] in table 'Cargo_Modulo'
ALTER TABLE [dbo].[Cargo_Modulo]
ADD CONSTRAINT [PK_Cargo_Modulo]
    PRIMARY KEY CLUSTERED ([CargoId], [ModuloId] ASC);
GO

-- Creating primary key on [Id] in table 'Unidad_Medida'
ALTER TABLE [dbo].[Unidad_Medida]
ADD CONSTRAINT [PK_Unidad_Medida]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VentaSet'
ALTER TABLE [dbo].[VentaSet]
ADD CONSTRAINT [PK_VentaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Detalle_VentaSet'
ALTER TABLE [dbo].[Detalle_VentaSet]
ADD CONSTRAINT [PK_Detalle_VentaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'Detalle_CarroSet'
ALTER TABLE [dbo].[Detalle_CarroSet]
ADD CONSTRAINT [PK_Detalle_CarroSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'Carro_CompraSet'
ALTER TABLE [dbo].[Carro_CompraSet]
ADD CONSTRAINT [PK_Carro_CompraSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CajaSet'
ALTER TABLE [dbo].[CajaSet]
ADD CONSTRAINT [PK_CajaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EAN_ID] in table 'Articulo_Proveedor'
ALTER TABLE [dbo].[Articulo_Proveedor]
ADD CONSTRAINT [FK_ArticuloArticulo_Proveedor]
    FOREIGN KEY ([EAN_ID])
    REFERENCES [dbo].[Articuloes]
        ([EAN])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [EmpresaRut] in table 'Empresa_Articulo'
ALTER TABLE [dbo].[Empresa_Articulo]
ADD CONSTRAINT [FK_EmpresaEmpresa_Articulo]
    FOREIGN KEY ([EmpresaRut])
    REFERENCES [dbo].[Empresas]
        ([Rut])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [EAN_ID] in table 'Empresa_Articulo'
ALTER TABLE [dbo].[Empresa_Articulo]
ADD CONSTRAINT [FK_ArticuloEmpresa_Articulo]
    FOREIGN KEY ([EAN_ID])
    REFERENCES [dbo].[Articuloes]
        ([EAN])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloEmpresa_Articulo'
CREATE INDEX [IX_FK_ArticuloEmpresa_Articulo]
ON [dbo].[Empresa_Articulo]
    ([EAN_ID]);
GO

-- Creating foreign key on [CategoriaId] in table 'Empresa_Articulo'
ALTER TABLE [dbo].[Empresa_Articulo]
ADD CONSTRAINT [FK_CategoriaEmpresa_Articulo]
    FOREIGN KEY ([CategoriaId])
    REFERENCES [dbo].[Categorias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaEmpresa_Articulo'
CREATE INDEX [IX_FK_CategoriaEmpresa_Articulo]
ON [dbo].[Empresa_Articulo]
    ([CategoriaId]);
GO

-- Creating foreign key on [Personal_Rut] in table 'Usuario_Personal'
ALTER TABLE [dbo].[Usuario_Personal]
ADD CONSTRAINT [FK_PersonalUsuario_Personal]
    FOREIGN KEY ([Personal_Rut])
    REFERENCES [dbo].[Personals]
        ([Rut])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonalUsuario_Personal'
CREATE INDEX [IX_FK_PersonalUsuario_Personal]
ON [dbo].[Usuario_Personal]
    ([Personal_Rut]);
GO

-- Creating foreign key on [CargoId] in table 'Personals'
ALTER TABLE [dbo].[Personals]
ADD CONSTRAINT [FK_CargoPersonal]
    FOREIGN KEY ([CargoId])
    REFERENCES [dbo].[Cargoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CargoPersonal'
CREATE INDEX [IX_FK_CargoPersonal]
ON [dbo].[Personals]
    ([CargoId]);
GO

-- Creating foreign key on [CargoId] in table 'Cargo_Modulo'
ALTER TABLE [dbo].[Cargo_Modulo]
ADD CONSTRAINT [FK_CargoCargo_Modulo]
    FOREIGN KEY ([CargoId])
    REFERENCES [dbo].[Cargoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ModuloId] in table 'Cargo_Modulo'
ALTER TABLE [dbo].[Cargo_Modulo]
ADD CONSTRAINT [FK_ModuloCargo_Modulo]
    FOREIGN KEY ([ModuloId])
    REFERENCES [dbo].[Moduloes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModuloCargo_Modulo'
CREATE INDEX [IX_FK_ModuloCargo_Modulo]
ON [dbo].[Cargo_Modulo]
    ([ModuloId]);
GO

-- Creating foreign key on [Unidad_MedidaId] in table 'Empresa_Articulo'
ALTER TABLE [dbo].[Empresa_Articulo]
ADD CONSTRAINT [FK_Unidad_MedidaEmpresa_Articulo]
    FOREIGN KEY ([Unidad_MedidaId])
    REFERENCES [dbo].[Unidad_Medida]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Unidad_MedidaEmpresa_Articulo'
CREATE INDEX [IX_FK_Unidad_MedidaEmpresa_Articulo]
ON [dbo].[Empresa_Articulo]
    ([Unidad_MedidaId]);
GO

-- Creating foreign key on [ProveedorRut] in table 'Articulo_Proveedor'
ALTER TABLE [dbo].[Articulo_Proveedor]
ADD CONSTRAINT [FK_ProveedorArticulo_Proveedor]
    FOREIGN KEY ([ProveedorRut])
    REFERENCES [dbo].[Proveedors]
        ([Rut])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProveedorArticulo_Proveedor'
CREATE INDEX [IX_FK_ProveedorArticulo_Proveedor]
ON [dbo].[Articulo_Proveedor]
    ([ProveedorRut]);
GO

-- Creating foreign key on [EmpresaRut] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_EmpresaUsuario]
    FOREIGN KEY ([EmpresaRut])
    REFERENCES [dbo].[Empresas]
        ([Rut])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaUsuario'
CREATE INDEX [IX_FK_EmpresaUsuario]
ON [dbo].[Usuarios]
    ([EmpresaRut]);
GO

-- Creating foreign key on [Usuario_Id] in table 'Usuario_Personal'
ALTER TABLE [dbo].[Usuario_Personal]
ADD CONSTRAINT [FK_UsuarioUsuario_Personal]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioUsuario_Personal'
CREATE INDEX [IX_FK_UsuarioUsuario_Personal]
ON [dbo].[Usuario_Personal]
    ([Usuario_Id]);
GO

-- Creating foreign key on [Empresa_Rut] in table 'VentaSet'
ALTER TABLE [dbo].[VentaSet]
ADD CONSTRAINT [FK_VentaEmpresa]
    FOREIGN KEY ([Empresa_Rut])
    REFERENCES [dbo].[Empresas]
        ([Rut])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VentaEmpresa'
CREATE INDEX [IX_FK_VentaEmpresa]
ON [dbo].[VentaSet]
    ([Empresa_Rut]);
GO

-- Creating foreign key on [VentaId] in table 'Detalle_VentaSet'
ALTER TABLE [dbo].[Detalle_VentaSet]
ADD CONSTRAINT [FK_VentaDetalle_Venta]
    FOREIGN KEY ([VentaId])
    REFERENCES [dbo].[VentaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VentaDetalle_Venta'
CREATE INDEX [IX_FK_VentaDetalle_Venta]
ON [dbo].[Detalle_VentaSet]
    ([VentaId]);
GO

-- Creating foreign key on [ArticuloEAN] in table 'Detalle_VentaSet'
ALTER TABLE [dbo].[Detalle_VentaSet]
ADD CONSTRAINT [FK_ArticuloDetalle_Venta]
    FOREIGN KEY ([ArticuloEAN])
    REFERENCES [dbo].[Articuloes]
        ([EAN])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloDetalle_Venta'
CREATE INDEX [IX_FK_ArticuloDetalle_Venta]
ON [dbo].[Detalle_VentaSet]
    ([ArticuloEAN]);
GO

-- Creating foreign key on [UsuarioId] in table 'Carro_CompraSet'
ALTER TABLE [dbo].[Carro_CompraSet]
ADD CONSTRAINT [FK_UsuarioCarro_Compra]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioCarro_Compra'
CREATE INDEX [IX_FK_UsuarioCarro_Compra]
ON [dbo].[Carro_CompraSet]
    ([UsuarioId]);
GO

-- Creating foreign key on [Carro_CompraId] in table 'Detalle_CarroSet'
ALTER TABLE [dbo].[Detalle_CarroSet]
ADD CONSTRAINT [FK_Carro_CompraDetalle_Carro]
    FOREIGN KEY ([Carro_CompraId])
    REFERENCES [dbo].[Carro_CompraSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Carro_CompraDetalle_Carro'
CREATE INDEX [IX_FK_Carro_CompraDetalle_Carro]
ON [dbo].[Detalle_CarroSet]
    ([Carro_CompraId]);
GO

-- Creating foreign key on [ArticuloEAN] in table 'Detalle_CarroSet'
ALTER TABLE [dbo].[Detalle_CarroSet]
ADD CONSTRAINT [FK_ArticuloDetalle_Carro]
    FOREIGN KEY ([ArticuloEAN])
    REFERENCES [dbo].[Articuloes]
        ([EAN])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloDetalle_Carro'
CREATE INDEX [IX_FK_ArticuloDetalle_Carro]
ON [dbo].[Detalle_CarroSet]
    ([ArticuloEAN]);
GO

-- Creating foreign key on [UsuarioId] in table 'CajaSet'
ALTER TABLE [dbo].[CajaSet]
ADD CONSTRAINT [FK_UsuarioCaja]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioCaja'
CREATE INDEX [IX_FK_UsuarioCaja]
ON [dbo].[CajaSet]
    ([UsuarioId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------