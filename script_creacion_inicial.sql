--Me conecto a la base de datos a usar
USE [GD2C2017]
GO


/** CREACION DE SCHEMA **/

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'GAME_OF_CODE')
BEGIN
    EXEC ('CREATE SCHEMA GAME_OF_CODE AUTHORIZATION gd')
END
GO

/** FIN CREACION DE SCHEMA**/


/** VALIDACION DE TABLAS **/

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Detalle_Factura'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Detalle_Factura DROP CONSTRAINT Detalle_Factura_id_factura;
	DROP TABLE GAME_OF_CODE.Detalle_Factura
END

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Detalle_Rendicion'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Detalle_Rendicion DROP CONSTRAINT Detalle_Rendicion_id_rendicion;
	ALTER TABLE GAME_OF_CODE.Detalle_Rendicion DROP CONSTRAINT Detalle_Rendicion_id_factura;
	DROP TABLE GAME_OF_CODE.Detalle_Rendicion
END

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Devolucion'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Devolucion DROP CONSTRAINT Devolucion_id_factura;
	ALTER TABLE GAME_OF_CODE.Devolucion DROP CONSTRAINT Devolucion_id_pago_facturas;
	DROP TABLE GAME_OF_CODE.Devolucion
END

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Factura'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Factura DROP CONSTRAINT Factura_id_cliente;
	ALTER TABLE GAME_OF_CODE.Factura DROP CONSTRAINT Factura_id_empresa;
	ALTER TABLE GAME_OF_CODE.Factura DROP CONSTRAINT Factura_id_Pago;
	DROP TABLE GAME_OF_CODE.Factura
END

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Pago_de_Facturas'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Pago_de_Facturas DROP CONSTRAINT Pago_de_Facturas_id_sucursal;
	ALTER TABLE GAME_OF_CODE.Pago_de_Facturas DROP CONSTRAINT Pago_de_Facturas_id_medio_pago;
	DROP TABLE GAME_OF_CODE.Pago_de_Facturas
END

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Medio_de_Pago'))
BEGIN
	DROP TABLE GAME_OF_CODE.Medio_de_Pago
END

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Usuario_por_Sucursal'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Usuario_por_Sucursal DROP CONSTRAINT Usuario_por_Sucursal_id_usuario;
	ALTER TABLE GAME_OF_CODE.Usuario_por_Sucursal DROP CONSTRAINT Usuario_por_Sucursal_id_sucursal;
	DROP TABLE GAME_OF_CODE.Usuario_por_Sucursal
END

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Rol_por_Usuario'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Rol_por_Usuario DROP CONSTRAINT Rol_por_Usuario_id_usuario;
	ALTER TABLE GAME_OF_CODE.Rol_por_Usuario DROP CONSTRAINT Rol_por_Usuario_id_rol;
	DROP TABLE GAME_OF_CODE.Rol_por_Usuario
END

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Funcionalidad_por_Rol'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Funcionalidad_por_Rol DROP CONSTRAINT Funcionalidad_por_Rol_id_funcionalidad;
	ALTER TABLE GAME_OF_CODE.Funcionalidad_por_Rol DROP CONSTRAINT Funcionalidad_por_Rol_id_rol;
	DROP TABLE GAME_OF_CODE.Funcionalidad_por_Rol
END

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Empresa'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Empresa DROP CONSTRAINT Empresa_id_rubro;
	DROP TABLE GAME_OF_CODE.Empresa
END

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Cliente'))
	DROP TABLE GAME_OF_CODE.Cliente

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Usuario'))
	DROP TABLE GAME_OF_CODE.Usuario

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Rol'))
	DROP TABLE GAME_OF_CODE.Rol

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Funcionalidad'))
	DROP TABLE GAME_OF_CODE.Funcionalidad

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Rendicion'))
	DROP TABLE GAME_OF_CODE.Rendicion

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Sucursal'))
	DROP TABLE GAME_OF_CODE.Sucursal

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Rubro'))
	DROP TABLE GAME_OF_CODE.Rubro
	
/** FIN VALIDACION DE TABLAS **/


/** CREACION DE TABLAS **/

CREATE TABLE [GAME_OF_CODE].[Usuario] (
    [id_usuario] INT IDENTITY(1,1) PRIMARY KEY,
    [username] [nvarchar](50) UNIQUE NOT NULL,
    [password] [nvarchar](150) NOT NULL,
    [estado_habilitacion] [bit] NOT NULL DEFAULT 1,
    [intentos_fallidos] [tinyint] DEFAULT 0
)

CREATE TABLE [GAME_OF_CODE].[Rol_por_Usuario] (
    [id_rol_por_usuario] INT IDENTITY(1,1) PRIMARY KEY,
	[id_usuario] INT NOT NULL,
	[id_rol] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Rol] (
    [id_rol] INT IDENTITY(1,1) PRIMARY KEY,
    [nombre] [nvarchar](20) UNIQUE NOT NULL,  
    [estado_habilitacion] [bit] NOT NULL DEFAULT 1
)

CREATE TABLE [GAME_OF_CODE].[Funcionalidad_por_Rol] (
    [id_funcionalidad_por_rol] INT IDENTITY(1,1) PRIMARY KEY,
	[id_rol] INT NOT NULL,
	[id_funcionalidad] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Funcionalidad] (
    [id_funcionalidad] INT IDENTITY(1,1) PRIMARY KEY,
    [descripcion] [nvarchar](255) NOT NULL       
)

CREATE TABLE [GAME_OF_CODE].[Usuario_por_Sucursal] (
	[id_usuario_por_sucursal] INT IDENTITY(1,1) PRIMARY KEY,
	[id_usuario] INT NOT NULL,
	[id_sucursal] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Sucursal] (
	[id_sucursal] INT IDENTITY(1,1) PRIMARY KEY,
	[nombre] [nvarchar](50) NOT NULL,
	[direccion] [nvarchar](150) NOT NULL,
	[codigo_postal] INT NOT NULL,
	[estado_habilitacion] [bit] NOT NULL DEFAULT 1
)

CREATE TABLE [GAME_OF_CODE].[Detalle_Factura] (
	[id_detalle_factura] INT IDENTITY(1,1) PRIMARY KEY,
	[item_factura] [nvarchar](50) NOT NULL DEFAULT 'Producto',
	[item_monto] INT NOT NULL,
	[cantidad] INT NOT NULL,
	[id_factura] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Pago_de_Facturas] (
	[id_pago_facturas] INT IDENTITY(1,1) PRIMARY KEY,
	[fecha_cobro] [datetime] NOT NULL,
	[importe] INT NOT NULL,
	[id_sucursal] INT NOT NULL,
	[id_medio_pago] INT
)

CREATE TABLE [GAME_OF_CODE].[Factura] (
	[id_factura] INT IDENTITY(1,1) PRIMARY KEY,
	[numero_factura] INT NOT NULL,
	[fecha_alta] [datetime] NOT NULL,
	[monto_total] INT NOT NULL,
	[fecha_vencimiento] [datetime] NOT NULL,
	[id_cliente] INT NOT NULL,
	[id_empresa] INT NOT NULL,
	[id_pago] INT,
	[estado_habilitacion] [bit] NOT NULL DEFAULT 1
)

CREATE TABLE [GAME_OF_CODE].[Devolucion] (
	[id_devolucion] INT IDENTITY(1,1) PRIMARY KEY,
	[motivo] [nvarchar](255) NOT NULL,
	[id_factura] INT NOT NULL,
	[id_pago_facturas] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Cliente] (
    [id_cliente] INT IDENTITY(1,1) PRIMARY KEY,
    [nombre] [nvarchar](255) NOT NULL,
    [apellido] [nvarchar](255) NOT NULL,
    [dni] [NUMERIC](18, 0) NOT NULL,
	[mail] [nvarchar](255) NOT NULL,
	[telefono] [NUMERIC](18,0) NOT NULL DEFAULT 0,
	[direccion] [nvarchar](150) NOT NULL,
	[codigo_postal] INT NOT NULL,
    [cli_fecha_nac] [datetime] NOT NULL,
	[estado_habilitacion] [bit] NOT NULL DEFAULT 1
)

CREATE TABLE [GAME_OF_CODE].[Rendicion] (
	[id_rendicion] INT IDENTITY(1,1) PRIMARY KEY,
	[fecha_rendicion] [datetime] NOT NULL,
	[total_rendicion] INT NOT NULL,
	[porcentaje_comision] INT NOT NULL,
	[importe_comision] FLOAT NOT NULL,
	[cant_facturas_rendidas] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Detalle_Rendicion] (
	[id_detalle_rendicion] INT IDENTITY(1,1) PRIMARY KEY,
	[id_rendicion] INT NOT NULL,
	[id_factura] INT NOT NULL,
)

CREATE TABLE [GAME_OF_CODE].[Medio_de_Pago] (
	[id_medio_pago] INT IDENTITY(1,1) PRIMARY KEY,
	[descripcion] [nvarchar](50) NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Empresa] (
    [id_empresa] INT IDENTITY(1,1) PRIMARY KEY,
    [nombre] [nvarchar](255) NOT NULL,
    [emp_cuit] [nvarchar](50) NOT NULL,
    [emp_direccion] [nvarchar](255) NOT NULL,
	[porcentaje_comision] INT NOT NULL,
	[id_rubro] INT NOT NULL,
	[estado_habilitacion] [bit] NOT NULL DEFAULT 1
)

CREATE TABLE [GAME_OF_CODE].[Rubro] (
	[id_rubro] INT IDENTITY(1,1) PRIMARY KEY,
	[descripcion] [nvarchar](50) NOT NULL
)


/* FKs */

ALTER TABLE [GAME_OF_CODE].[Rol_por_Usuario] ADD CONSTRAINT Rol_por_Usuario_id_usuario FOREIGN KEY (id_usuario) REFERENCES [GAME_OF_CODE].[Usuario](id_usuario)

ALTER TABLE [GAME_OF_CODE].[Rol_por_Usuario] ADD CONSTRAINT Rol_por_Usuario_id_rol FOREIGN KEY (id_rol) REFERENCES [GAME_OF_CODE].[Rol](id_rol)

ALTER TABLE [GAME_OF_CODE].[Funcionalidad_por_Rol] ADD CONSTRAINT Funcionalidad_por_Rol_id_funcionalidad FOREIGN KEY (id_funcionalidad) REFERENCES [GAME_OF_CODE].[Funcionalidad](id_funcionalidad)

ALTER TABLE [GAME_OF_CODE].[Funcionalidad_por_Rol] ADD CONSTRAINT Funcionalidad_por_Rol_id_rol FOREIGN KEY (id_rol) REFERENCES [GAME_OF_CODE].[Rol](id_rol)

ALTER TABLE [GAME_OF_CODE].[Usuario_por_Sucursal] ADD CONSTRAINT Usuario_por_Sucursal_id_usuario FOREIGN KEY (id_usuario) REFERENCES [GAME_OF_CODE].[Usuario](id_usuario)

ALTER TABLE [GAME_OF_CODE].[Usuario_por_Sucursal] ADD CONSTRAINT Usuario_por_Sucursal_id_sucursal FOREIGN KEY (id_sucursal) REFERENCES [GAME_OF_CODE].[Sucursal](id_sucursal)

ALTER TABLE [GAME_OF_CODE].[Detalle_Factura] ADD CONSTRAINT Detalle_Factura_id_factura FOREIGN KEY (id_factura) REFERENCES [GAME_OF_CODE].[Factura](id_factura)

ALTER TABLE [GAME_OF_CODE].[Pago_de_Facturas] ADD CONSTRAINT Pago_de_Facturas_id_sucursal FOREIGN KEY (id_sucursal) REFERENCES [GAME_OF_CODE].[Sucursal](id_sucursal)

ALTER TABLE [GAME_OF_CODE].[Pago_de_Facturas] ADD CONSTRAINT Pago_de_Facturas_id_medio_pago FOREIGN KEY (id_medio_pago) REFERENCES [GAME_OF_CODE].[Medio_de_Pago](id_medio_pago)

ALTER TABLE [GAME_OF_CODE].[Detalle_Rendicion] ADD CONSTRAINT Detalle_Rendicion_id_rendicion FOREIGN KEY (id_rendicion) REFERENCES [GAME_OF_CODE].[Rendicion](id_rendicion)

ALTER TABLE [GAME_OF_CODE].[Detalle_Rendicion] ADD CONSTRAINT Detalle_Rendicion_id_factura FOREIGN KEY (id_factura) REFERENCES [GAME_OF_CODE].[Factura](id_factura)

ALTER TABLE [GAME_OF_CODE].[Factura] ADD CONSTRAINT Factura_id_cliente FOREIGN KEY (id_cliente) REFERENCES [GAME_OF_CODE].[Cliente](id_cliente)

ALTER TABLE [GAME_OF_CODE].[Factura] ADD CONSTRAINT Factura_id_empresa FOREIGN KEY (id_empresa) REFERENCES [GAME_OF_CODE].[Empresa](id_empresa)

ALTER TABLE [GAME_OF_CODE].[Factura] ADD CONSTRAINT Factura_id_Pago FOREIGN KEY (id_pago) REFERENCES [GAME_OF_CODE].[Pago_de_Facturas](id_pago_facturas)

ALTER TABLE [GAME_OF_CODE].[Devolucion] ADD CONSTRAINT Devolucion_id_factura FOREIGN KEY (id_factura) REFERENCES [GAME_OF_CODE].[Factura](id_factura)

ALTER TABLE [GAME_OF_CODE].[Devolucion] ADD CONSTRAINT Devolucion_id_pago_facturas FOREIGN KEY (id_pago_facturas) REFERENCES [GAME_OF_CODE].[Pago_de_Facturas](id_pago_facturas)

ALTER TABLE [GAME_OF_CODE].[Empresa] ADD CONSTRAINT Empresa_id_rubro FOREIGN KEY (id_rubro) REFERENCES [GAME_OF_CODE].[Rubro](id_rubro)

/** FIN CREACION DE TABLAS **/


/** VALIDACION DE FUNCIONES, PROCEDURES, VISTAS Y TRIGGERS**/
IF (OBJECT_ID('GAME_OF_CODE.pr_crear_usuario_con_valores') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_crear_usuario_con_valores
GO

IF (OBJECT_ID('GAME_OF_CODE.get_cantidad_roles_de_usuario') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.get_cantidad_roles_de_usuario
GO

IF (OBJECT_ID('GAME_OF_CODE.get_cantidad_sucursales_de_usuario') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.get_cantidad_sucursales_de_usuario
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_crear_cliente') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_crear_cliente
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_modificar_cliente') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_modificar_cliente
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_crear_empresa') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_crear_empresa
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_modificar_empresa') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_modificar_empresa
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_crear_factura') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_crear_factura
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_modificar_factura') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_modificar_factura
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_crear_item_factura') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_crear_item_factura
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_modificar_item_factura') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_modificar_item_factura
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_crear_sucursal') IS NOT NULL)
	DROP PROCEDURE GAME_OF_CODE.pr_crear_sucursal
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_modificar_sucursal') IS NOT NULL)
	DROP PROCEDURE GAME_OF_CODE.pr_modificar_sucursal
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_crear_pago_factura') IS NOT NULL)
	DROP PROCEDURE GAME_OF_CODE.pr_crear_pago_factura
GO

IF (OBJECT_ID('dbo.totalFacturasPagasDeUnaEmpresa') IS NOT NULL)
    DROP FUNCTION dbo.totalFacturasPagasDeUnaEmpresa
GO

IF (OBJECT_ID('GAME_OF_CODE.TotalDeFacturasPorRendirDeUnaEmpresa') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.TotalDeFacturasPorRendirDeUnaEmpresa
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_crear_devolucion') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_crear_devolucion
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_set_id_pago_factura_null') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_set_id_pago_factura_null
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_crear_rendicion') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_crear_rendicion
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_modificar_rendicion') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_modificar_rendicion
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_crear_detalle_rendicion') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_crear_detalle_rendicion
GO

IF (OBJECT_ID('GAME_OF_CODE.pr_modificar_detalle_rendicion') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_modificar_detalle_rendicion
GO

IF (OBJECT_ID('dbo.PorcentajeDeCobro') IS NOT NULL)
    DROP FUNCTION dbo.PorcentajeDeCobro

IF (OBJECT_ID('dbo.MayorPorcentajeFacturasPagas') IS NOT NULL)
    DROP FUNCTION dbo.MayorPorcentajeFacturasPagas
GO

/** FIN VALIDACION DE FUNCIONES, PROCEDURES, VISTAS Y TRIGGERS **/


/** CREACION DE FUNCIONES Y PROCEDURES **/
CREATE PROCEDURE GAME_OF_CODE.pr_crear_usuario_con_valores
    @username nvarchar(50),
    @password nvarchar(150),
    @usuario_id INT OUTPUT
AS
BEGIN
    INSERT INTO GAME_OF_CODE.Usuario 
        (username, password) 
    VALUES 
        (@username, @password)
    SET @usuario_id = SCOPE_IDENTITY(); 
END
GO

CREATE PROCEDURE GAME_OF_CODE.get_cantidad_roles_de_usuario
(
    @username nvarchar(50)
)
AS
BEGIN
	SELECT COUNT(ru.id_rol) FROM GAME_OF_CODE.Rol_por_Usuario ru, GAME_OF_CODE.Rol r WHERE (SELECT id_usuario FROM GAME_OF_CODE.Usuario WHERE username = @username) = id_usuario AND ru.id_rol = r.id_rol AND r.estado_habilitacion = 1
END
GO

CREATE PROCEDURE GAME_OF_CODE.get_cantidad_sucursales_de_usuario
(
	@username nvarchar(50)
)
AS
BEGIN
	SELECT COUNT(su.id_sucursal) FROM GAME_OF_CODE.Usuario_por_Sucursal su, GAME_OF_CODE.Sucursal s WHERE (SELECT id_usuario FROM GAME_OF_CODE.Usuario WHERE username = @username) = id_usuario AND su.id_sucursal = s.id_sucursal AND s.estado_habilitacion = 1
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_crear_cliente
    @nombre nvarchar(255),
    @apellido nvarchar(255),
    @dni numeric(18,0),
    @mail nvarchar(255),
    @telefono numeric(18,0),
	@direccion nvarchar(150),
	@codigo_postal int,
	@cli_fecha_nac datetime,
    @id int OUTPUT
AS
BEGIN
    INSERT INTO GAME_OF_CODE.Cliente
        (nombre, apellido, dni, mail, telefono, direccion, codigo_postal, cli_fecha_nac) 
    VALUES 
        (@nombre, @apellido, @dni, @mail, @telefono, @direccion, @codigo_postal, @cli_fecha_nac);
    SET @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_modificar_cliente
	@nombre nvarchar(255),
    @apellido nvarchar(255),
    @dni numeric(18,0),
    @mail nvarchar(255),
    @telefono numeric(18,0),
	@direccion nvarchar(150),
	@codigo_postal int,
	@cli_fecha_nac datetime,
    @id int,
	@id_output int OUTPUT
AS
BEGIN
	UPDATE GAME_OF_CODE.Cliente
	SET nombre = @nombre, apellido = @apellido, dni = @dni, mail = @mail, telefono = @telefono, direccion = @direccion, codigo_postal = @codigo_postal, cli_fecha_nac = @cli_fecha_nac
	WHERE id_cliente = @id
	SET @id_output = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_crear_empresa
	@nombre nvarchar(255),
	@emp_cuit nvarchar(50),
	@emp_direccion nvarchar(255),
	@id_rubro int,
	@porcentaje_comision int,
	@id int OUTPUT
AS
BEGIN
	INSERT INTO GAME_OF_CODE.Empresa
		(nombre, emp_cuit, emp_direccion, id_rubro, porcentaje_comision)
	VALUES
		(@nombre, @emp_cuit, @emp_direccion, @id_rubro, @porcentaje_comision);
	SET @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_modificar_empresa
	@nombre nvarchar(255),
	@emp_cuit nvarchar(50),
	@emp_direccion nvarchar(255),
	@id_rubro int,
	@id int, /*id_empresa*/
	@porcentaje_comision int,
	@id_output int OUTPUT
AS
BEGIN
	UPDATE GAME_OF_CODE.Empresa
	SET nombre = @nombre, emp_cuit = @emp_cuit, emp_direccion = @emp_direccion, id_rubro = @id_rubro, porcentaje_comision = @porcentaje_comision
	WHERE id_empresa = @id
	SET @id_output = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_crear_factura
	@numero_factura int,
	@fecha_alta DATETIME,
	@monto_total int,
	@fecha_vencimiento DATETIME,
	@id_cliente int,
	@id_empresa int,
	@id int OUTPUT
AS
BEGIN
	INSERT INTO GAME_OF_CODE.Factura
		(numero_factura, fecha_alta, monto_total, fecha_vencimiento, id_cliente, id_empresa)
	VALUES
		(@numero_factura, @fecha_alta, @monto_total, @fecha_vencimiento, @id_cliente, @id_empresa);
	SET @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_modificar_factura
	@numero_factura int,
	@fecha_alta DATETIME,
	@monto_total int,
	@fecha_vencimiento DATETIME,
	@id_cliente int,
	@id_empresa int,
	@id int,
	@id_output int OUTPUT
AS
BEGIN
	UPDATE GAME_OF_CODE.Factura
	SET numero_factura = @numero_factura, fecha_alta = @fecha_alta, monto_total = @monto_total, fecha_vencimiento = @fecha_vencimiento, id_cliente = @id_cliente, id_empresa = @id_empresa
	WHERE id_factura = @id
	SET @id_output = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_crear_item_factura
	@item_factura nvarchar(50),
	@item_monto int,
	@cantidad int,
	@id_factura int,
	@id int output
AS
BEGIN
	INSERT INTO GAME_OF_CODE.Detalle_Factura
		(item_factura, item_monto, cantidad, id_factura)
	VALUES
		(@item_factura, @item_monto, @cantidad, @id_factura)
	SET @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_modificar_item_factura
	@item_factura nvarchar(50),
	@item_monto int,
	@cantidad int,
	@id_factura int,
	@id int,
	@id_output int OUTPUT
AS
BEGIN
	UPDATE GAME_OF_CODE.Detalle_Factura
	SET item_factura = @item_factura, item_monto = @item_monto, cantidad = @cantidad, id_factura = @id_factura
	WHERE id_detalle_factura = @id
	SET @id_output = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_crear_sucursal
	@nombre nvarchar(255),
	@direccion nvarchar(255),
	@codigo_postal nvarchar(4),
	@id int OUTPUT
AS
BEGIN
	INSERT INTO GAME_OF_CODE.Sucursal
		(nombre, direccion, codigo_postal)
	VALUES
		(@nombre, @direccion, @codigo_postal);
	SET @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_modificar_sucursal
	@nombre nvarchar(255),
	@direccion nvarchar(255),
	@codigo_postal nvarchar(4),
	@id int, /*id_sucursal*/
	@id_output int OUTPUT
AS
BEGIN
	UPDATE GAME_OF_CODE.Sucursal
	SET nombre = @nombre, direccion = @direccion, codigo_postal = @codigo_postal
	WHERE id_sucursal = @id
	SET @id_output = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_crear_pago_factura
	@fecha_cobro datetime,
	@importe int,
	@id_sucursal int,
	@id_medio_pago int,
	@id int output
AS
BEGIN
	INSERT INTO GAME_OF_CODE.Pago_de_Facturas (fecha_cobro, importe, id_sucursal, id_medio_pago)
	VALUES (@fecha_cobro, @importe, @id_sucursal, @id_medio_pago);
	SET @id = SCOPE_IDENTITY();
END
GO

CREATE FUNCTION totalFacturasPagasDeUnaEmpresa(@id_empresa INT) RETURNS INT
AS
BEGIN
	DECLARE @total INT
	SET @total = (SELECT COUNT(F.numero_factura)
				FROM GAME_OF_CODE.Factura F
				WHERE F.id_pago IS NOT NULL
				AND F.id_empresa = @id_empresa);
	RETURN @total
END
GO

CREATE PROCEDURE GAME_OF_CODE.TotalDeFacturasPorRendirDeUnaEmpresa
	@id_empresa INT,
	@cantSinRendir INT OUTPUT
AS
BEGIN

SET @cantSinRendir = (SELECT COUNT(F.numero_factura) - dbo.totalFacturasPagasDeUnaEmpresa(@id_empresa)
						FROM GAME_OF_CODE.Factura F, GAME_OF_CODE.Detalle_Rendicion DR
						WHERE F.id_pago IS NOT NULL
						  AND F.id_empresa = @id_empresa
						  AND F.id_factura = DR.id_factura)	
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_crear_devolucion
	@motivo nvarchar(255),
    @id_factura int,
    @id_pago_facturas int,
	@id int OUTPUT
AS
BEGIN
	INSERT INTO GAME_OF_CODE.Devolucion
		(motivo, id_factura, id_pago_facturas)
	VALUES
		(@motivo, @id_factura, @id_pago_facturas);
	SET @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_set_id_pago_factura_null
	@id_factura int
AS
BEGIN
	UPDATE GAME_OF_CODE.Factura SET id_pago = NULL WHERE id_factura = id_factura
END
GO

CREATE FUNCTION PorcentajeDeCobro(@id_empresa INT, @fecha_inicio DATETIME, @fecha_fin DATETIME) 
	RETURNS DECIMAL(15,2)
AS
BEGIN
	DECLARE @totalCobradas DECIMAL(15,2)
	DECLARE @totalFacturas DECIMAL(15,2)
	DECLARE @porcentajeDeCobro DECIMAL(15,2)

	SET @totalCobradas = (SELECT CONVERT(DECIMAL(15,2),COUNT(numero_factura))
							FROM GAME_OF_CODE.Factura F, GAME_OF_CODE.Pago_de_Facturas PF
							WHERE F.id_empresa = @id_empresa
							  AND F.id_pago IS NOT NULL
	  						  AND F.id_pago = PF.id_pago_facturas
							  AND PF.fecha_cobro BETWEEN @fecha_inicio AND @fecha_fin);
	SET @totalFacturas = (SELECT CONVERT(DECIMAL(15,2), COUNT(F.numero_factura))
					FROM GAME_OF_CODE.Factura F 
					WHERE F.id_empresa = @id_empresa
					  AND F.fecha_alta BETWEEN @fecha_inicio AND @fecha_fin);
	IF(@totalFacturas <1)
		SET @porcentajeDeCobro = 0
	ELSE
		SET @porcentajeDeCobro = @totalCobradas * 100 / @totalFacturas	
	RETURN @porcentajeDeCobro
END
GO

CREATE FUNCTION MayorPorcentajeFacturasPagas(@id_cliente INT, @fecha_inicio DATETIME, @fecha_fin DATETIME)
	RETURNS DECIMAL(15,2)
AS
BEGIN
	DECLARE @totalPagas DECIMAL(15,2)
	DECLARE @totalFacturas DECIMAL(15,2)
	DECLARE @mayorPorcentajeFacturasPagas DECIMAL(15,2)
	
	SET @totalPagas = (SELECT CONVERT(DECIMAL(15,2),COUNT(@id_cliente))
						FROM GAME_OF_CODE.Factura F, GAME_OF_CODE.Pago_de_Facturas PF
						WHERE F.id_cliente = @id_cliente
						  AND F.id_pago IS NOT NULL
						  AND F.id_pago = PF.id_pago_facturas
						  AND PF.fecha_cobro BETWEEN @fecha_inicio AND @fecha_fin);

	SET @totalFacturas = (SELECT CONVERT(DECIMAL(15,2), COUNT(F.id_pago))
							FROM GAME_OF_CODE.Factura F 
							WHERE F.id_cliente = @id_cliente 
							  AND F.fecha_alta BETWEEN @fecha_inicio AND @fecha_fin);
	
	IF(@totalFacturas < 1)
		SET @mayorPorcentajeFacturasPagas = 0;
	ELSE
		SET @mayorPorcentajeFacturasPagas = @totalPagas * 100 / @totalFacturas;
	
	RETURN @mayorPorcentajeFacturasPagas
END
GO

/** FIN CREACION DE FUNCIONES Y PROCEDURES **/

CREATE PROCEDURE GAME_OF_CODE.pr_crear_rendicion
	@fecha_rendicion DATETIME,
	@total_rendicion int,
	@porcentaje_comision int,
	@importe_comision float,
	@cant_facturas_rendidas int,
	@id int OUTPUT
AS
BEGIN
	INSERT INTO GAME_OF_CODE.Rendicion
		(fecha_rendicion, total_rendicion, porcentaje_comision, importe_comision, cant_facturas_rendidas)
	VALUES
		(@fecha_rendicion, @total_rendicion, @porcentaje_comision, @importe_comision, @cant_facturas_rendidas);
	SET @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_modificar_rendicion
	@fecha_rendicion DATETIME,
	@total_rendicion int,
	@porcentaje_comision int,
	@importe_comision float,
	@cant_facturas_rendidas int,
	@id int,
	@id_output int OUTPUT
AS
BEGIN
	UPDATE GAME_OF_CODE.Rendicion
	SET @fecha_rendicion = @fecha_rendicion, total_rendicion = @total_rendicion,
		porcentaje_comision = @porcentaje_comision, importe_comision = @importe_comision,
		cant_facturas_rendidas = @cant_facturas_rendidas
	WHERE id_rendicion = @id
	SET @id_output = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_crear_detalle_rendicion
	@id_rendicion int,
	@id_factura int,
	@id int output
AS
BEGIN
	INSERT INTO GAME_OF_CODE.Detalle_Rendicion
		(id_rendicion, id_factura)
	VALUES
		(@id_rendicion, @id_factura)
	SET @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_modificar_detalle_rendicion
	@id_rendicion int,
	@id_factura int,
	@id int,
	@id_output int OUTPUT
AS
BEGIN
	UPDATE GAME_OF_CODE.Detalle_Rendicion
	SET id_rendicion = @id_rendicion, id_factura = @id_factura
	WHERE id_detalle_rendicion = @id
	SET @id_output = SCOPE_IDENTITY();
END
GO

/******************************
*         MIGRACION           *
******************************/


/** Migracion de Clientes **/

INSERT INTO GAME_OF_CODE.Medio_de_Pago(descripcion)
	SELECT DISTINCT FormaPagoDescripcion 
	  FROM gd_esquema.Maestra
	 WHERE FormaPagoDescripcion IS NOT NULL;

INSERT INTO GAME_OF_CODE.Rubro (descripcion)
			SELECT DISTINCT Rubro_Descripcion
			  FROM gd_esquema.Maestra
			 WHERE Rubro_Descripcion IS NOT NULL

INSERT INTO GAME_OF_CODE.Sucursal (nombre, direccion, codigo_postal)
	SELECT DISTINCT Sucursal_Nombre, Sucursal_Dirección, Sucursal_Codigo_Postal
	  FROM gd_esquema.Maestra
	 WHERE Sucursal_Nombre IS NOT NULL
	   AND Sucursal_Codigo_Postal IS NOT NULL

SET IDENTITY_INSERT GAME_OF_CODE.Rendicion ON;
INSERT INTO GAME_OF_CODE.Rendicion (id_rendicion, fecha_rendicion, total_rendicion, porcentaje_comision,importe_comision, cant_facturas_rendidas)
	SELECT Rendicion_Nro, Rendicion_Fecha, Total, 10, ItemRendicion_Importe, 1
	FROM gd_esquema.Maestra
	WHERE Rendicion_Nro IS NOT NULL
GROUP BY Rendicion_Nro, Rendicion_Fecha, Total, ItemRendicion_Importe
SET IDENTITY_INSERT GAME_OF_CODE.Rendicion OFF;

INSERT INTO GAME_OF_CODE.Cliente (nombre, apellido, dni, mail, direccion, codigo_postal, cli_fecha_nac)
	SELECT DISTINCT [Cliente-Nombre], [Cliente-Apellido], [Cliente-Dni], Cliente_Mail, Cliente_Direccion, Cliente_Codigo_Postal, [Cliente-Fecha_Nac]
	  FROM gd_esquema.Maestra
	 WHERE [Cliente-Nombre] IS NOT NULL
	   AND [Cliente-Apellido] IS NOT NULL
	   AND [Cliente-Dni] IS NOT NULL
	   AND Cliente_Mail IS NOT NULL

INSERT INTO GAME_OF_CODE.Empresa (nombre, emp_cuit, emp_direccion, porcentaje_comision ,id_rubro)
   SELECT DISTINCT Empresa_Nombre, Empresa_Cuit, Empresa_Direccion, 10, Empresa_Rubro
     FROM gd_esquema.Maestra
    WHERE Empresa_Nombre IS NOT NULL
      AND Empresa_Cuit IS NOT NULL

SET IDENTITY_INSERT GAME_OF_CODE.Pago_de_Facturas ON;
INSERT INTO GAME_OF_CODE.Pago_de_Facturas(id_pago_facturas, fecha_cobro, id_sucursal, importe, id_medio_pago)
	SELECT Pago_nro, Pago_Fecha, S.id_sucursal, Total, MP.id_medio_pago
	FROM gd_esquema.Maestra TM, GAME_OF_CODE.Sucursal S, GAME_OF_CODE.Medio_de_Pago MP
	WHERE Pago_nro IS NOT NULL
	  AND S.nombre = TM.Sucursal_Nombre 
	  AND MP.descripcion = TM.FormaPagoDescripcion
	  AND Rendicion_Nro IS NULL
GROUP BY Pago_nro, Pago_Fecha, S.id_sucursal, Total, MP.id_medio_pago
SET IDENTITY_INSERT GAME_OF_CODE.Pago_de_Facturas OFF;

INSERT INTO GAME_OF_CODE.Factura (numero_factura, fecha_alta, monto_total, fecha_vencimiento, id_cliente,id_empresa, id_pago) 
	SELECT Nro_Factura, Factura_Fecha, Factura_Total, Factura_Fecha_Vencimiento,
		   C.id_cliente, E.id_empresa, Pago_nro
	FROM gd_esquema.Maestra TM, GAME_OF_CODE.Cliente C, GAME_OF_CODE.Empresa E
	WHERE Nro_Factura IS NOT NULL
	  AND Rendicion_Nro IS NULL
	  AND Pago_nro IS NULL
	  AND Factura_Total IS NOT NULL
	  AND TM.[Cliente-Dni] = C.dni
	  AND TM.Empresa_Cuit = E.emp_cuit
GROUP BY Nro_Factura, Factura_Fecha, Factura_Total, Factura_Fecha_Vencimiento,
		 C.id_cliente, E.id_empresa, Pago_nro

UPDATE GAME_OF_CODE.Factura 
	SET id_pago = Pago_nro
	FROM gd_esquema.Maestra TM, GAME_OF_CODE.Cliente C, GAME_OF_CODE.Empresa E
	WHERE Pago_nro IS NOT NULL
	  AND Rendicion_Nro IS NULL
	  AND numero_factura = TM.Nro_Factura
	  AND TM.[Cliente-Dni] = C.dni
	  AND TM.Empresa_Cuit = E.emp_cuit;

INSERT INTO GAME_OF_CODE.Detalle_Factura (item_monto, cantidad, id_factura)
	SELECT DISTINCT ItemFactura_Monto, ItemFactura_Cantidad, F.id_factura
	FROM gd_esquema.Maestra TM, GAME_OF_CODE.Factura F
	WHERE ItemFactura_Monto IS NOT NULL
	  AND ItemFactura_Cantidad IS NOT NULL
	  AND TM.Nro_Factura = F.numero_factura

INSERT INTO GAME_OF_CODE.Detalle_Rendicion(id_rendicion, id_factura)
	SELECT DISTINCT  id_rendicion, id_factura
	FROM gd_esquema.Maestra TM, GAME_OF_CODE.Rendicion R, GAME_OF_CODE.Factura F
	WHERE Rendicion_Nro IS NOT NULL
	  AND R.id_rendicion = TM.Rendicion_Nro
	  AND F.numero_factura = TM.Nro_Factura

/** FIN MIGRACION **/

-------------------------------------------------------------------------------------------------------------------------------------------
/** Inserto roles Administrador y Cobrador **/
INSERT INTO GAME_OF_CODE.Rol (nombre)
	VALUES ('Administrador'),
		   ('Cobrador')

--Creo usuario administrador para manejar la app (admin:w23e) y tambien usuario cobrador (tom:123)
DECLARE @id_admin INT
EXEC GAME_OF_CODE.pr_crear_usuario_con_valores 'admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', @id_admin output   

INSERT INTO GAME_OF_CODE.Rol_por_Usuario (id_rol, id_usuario)
    VALUES	(1, @id_admin)

DECLARE @id_cobrador INT
EXEC GAME_OF_CODE.pr_crear_usuario_con_valores 'tom', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', @id_cobrador output   

INSERT INTO GAME_OF_CODE.Rol_por_Usuario (id_rol, id_usuario)
    VALUES	(2, @id_cobrador)


/** Alta de Funcionalidades **/

INSERT INTO GAME_OF_CODE.Funcionalidad(descripcion)
    VALUES	('Habilitación de usuarios deshabilitados'),
			('Alta de clientes'),
            ('Modificación y baja de clientes'),
            ('Alta de empresas'),
            ('Modificación y baja de empresas'),
            ('Alta de facturas'),
            ('Modificación y baja de facturas'),
            ('Alta de roles'),
			('Asignación de roles a un usuario'),
            ('Modificación y baja de roles'),
            ('Alta de sucursales'),
			('Asignación de sucursales a un usuario'),
            ('Modificación y baja de sucursales'),
            ('Pagar facturas'),
			('Devolución de facturas pagas'),
            ('Realizar rendición de facturas'),
			('Listado estadístico')
            

-- Agrego al administrador todas las funcionalidades del sistema

BEGIN TRANSACTION
        DECLARE @cont int;
        SET @cont = 0;
        
        WHILE((SELECT COUNT(*) FROM GAME_OF_CODE.Funcionalidad) > @cont)
        BEGIN
                SET @cont = @cont + 1;
                INSERT INTO GAME_OF_CODE.Funcionalidad_por_Rol(id_funcionalidad, id_rol)
                    VALUES (@cont, (SELECT id_rol FROM GAME_OF_CODE.Rol WHERE nombre = 'Administrador'))
        END
COMMIT

-- Agrego al rol cobrador solo las funcionalidad de Pagar Facturas
BEGIN TRANSACTION
       INSERT INTO GAME_OF_CODE.Funcionalidad_por_Rol(id_funcionalidad, id_rol)
       VALUES (12, (SELECT id_rol FROM GAME_OF_CODE.Rol WHERE nombre = 'Cobrador'))
COMMIT

-- Le agrego al administrador y al cobrador la unica sucursal que hay en el sistema luego de la migracion
INSERT INTO GAME_OF_CODE.Usuario_por_Sucursal (id_usuario, id_sucursal)
	VALUES (1,1),
		   (2,1)
---------------------------------------------------------------------------------------------------------------------------------------------
