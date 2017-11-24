

																					/*DATA BASE:   RegistrosDb */
																					/*Tablas:          8      */
																			 /*Anthony Santana POlanco -- 2014-0527 */

																			 CREATE TABLE [dbo].[ArticuloCategorias] (
    [ArticuloCategoriasid] INT IDENTITY (1, 1) NOT NULL,
    [IdArticulo]           INT NULL,
    [CategoriaId]          INT NULL,
    PRIMARY KEY CLUSTERED ([ArticuloCategoriasid] ASC)
);


CREATE TABLE [dbo].[Articulos] (
    [IdArticulo]     INT          IDENTITY (1, 1) NOT NULL,
    [NombreArticulo] VARCHAR (80) NULL,
    [Existencia]     INT          NULL,
    [Precio]         DECIMAL (18) NULL,
    [Costo]          DECIMAL (18) NULL,
    [Categoria]      VARCHAR (80) NULL,
    [CodigoArticulo] VARCHAR (80) NULL,
    [FechaIngreso]   DATETIME     NULL,
    [CategoriaId]    INT          NULL,
    [ITBIS]          DECIMAL (18) NULL,
    PRIMARY KEY CLUSTERED ([IdArticulo] ASC)
);

CREATE TABLE [dbo].[Categorias] (
    [CategoriaId]     INT          IDENTITY (1, 1) NOT NULL,
    [NombreCategoria] VARCHAR (80) NULL,
    PRIMARY KEY CLUSTERED ([CategoriaId] ASC)
);

CREATE TABLE [dbo].[Clientes] (
    [ClienteId]       INT           IDENTITY (1, 1) NOT NULL,
    [Nombres]         VARCHAR (80)  NULL,
    [Direccion]       VARCHAR (100) NULL,
    [Email]           VARCHAR (80)  NULL,
    [Telefono]        VARCHAR (80)  NULL,
    [Sexo]            VARCHAR (50)  NULL,
    [FechaNacimiento] DATETIME      NULL,
    [Cedula]          VARCHAR (80)  NULL,
    PRIMARY KEY CLUSTERED ([ClienteId] ASC)
);

CREATE TABLE [dbo].[Deudasclientes] (
    [IdDeudas] INT          IDENTITY (1, 1) NOT NULL,
    [Cliente]  VARCHAR (80) NULL,
    [Deuda]    DECIMAL (18) NULL,
    PRIMARY KEY CLUSTERED ([IdDeudas] ASC)
);

CREATE TABLE [dbo].[FacturaDetalles] (
    [IdDetalle]  INT          IDENTITY (1, 1) NOT NULL,
    [IdFactura]  INT          NULL,
    [IdArticulo] INT          NULL,
    [Precio]     DECIMAL (18) NULL,
    [Cantidad]   INT          NULL,
    [Nombre]     VARCHAR (80) NULL,
    [ITBIS]      DECIMAL (18) NULL,
    PRIMARY KEY CLUSTERED ([IdDetalle] ASC),
    FOREIGN KEY ([IdFactura]) REFERENCES [dbo].[Facturas] ([IdFactura])
);

CREATE TABLE [dbo].[Facturas] (
    [IdFactura]     INT          IDENTITY (1, 1) NOT NULL,
    [NombreUsuario] VARCHAR (50) NULL,
    [FechaVenta]    DATETIME     NULL,
    [Cliente]       VARCHAR (80) NULL,
    [TipoVenta]     VARCHAR (80) NULL,
    [CantidadProd]  INT          NULL,
    [Total]         DECIMAL (18) NULL,
    PRIMARY KEY CLUSTERED ([IdFactura] ASC)
);


CREATE TABLE [dbo].[Usuarios] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [nombreUsuario] VARCHAR (50) NULL,
    [PassUsuario]   VARCHAR (70) NULL,
    [Tipo]          VARCHAR (50) NULL,
    [FechaIngreso]  DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);