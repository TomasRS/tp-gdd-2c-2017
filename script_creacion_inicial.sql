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

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Usuario'))
    DROP TABLE GAME_OF_CODE.Usuario

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Rol_por_Usuario'))
    DROP TABLE GAME_OF_CODE.Rol_por_Usuario
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Rol'))
    DROP TABLE GAME_OF_CODE.Rol	
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Funcionalidad_por_Rol'))
    DROP TABLE GAME_OF_CODE.Funcionalidad_por_Rol
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Funcionalidad'))
    DROP TABLE GAME_OF_CODE.Funcionalidad
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Usuario_por_Sucursal'))
    DROP TABLE GAME_OF_CODE.Usuario_por_Sucursal

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Sucursal'))
    DROP TABLE GAME_OF_CODE.Sucursal

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Detalle_Factura'))
    DROP TABLE GAME_OF_CODE.Detalle_Factura
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Devolucion'))
    DROP TABLE GAME_OF_CODE.Devolucion
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Pago_de_Facturas'))
    DROP TABLE GAME_OF_CODE.Pago_de_Facturas
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Factura'))
    DROP TABLE GAME_OF_CODE.Factura
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Cliente'))
    DROP TABLE GAME_OF_CODE.Cliente
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Rendicion'))
    DROP TABLE GAME_OF_CODE.Rendicion
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Detalle_Rendicion'))
    DROP TABLE GAME_OF_CODE.Detalle_Rendicion
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Medio_de_Pago'))
    DROP TABLE GAME_OF_CODE.Medio_de_Pago
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Empresa'))
    DROP TABLE GAME_OF_CODE.Empresa
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Rubro'))
    DROP TABLE GAME_OF_CODE.Rubro
	
/** FIN VALIDACION DE TABLAS **/


/** CREACION DE TABLAS **/
CREATE TABLE [GAME_OF_CODE].[Usuario] (
    [id_usuario] INT IDENTITY(1,1) PRIMARY KEY,
    [username] [nvarchar](50),
    [password] [nvarchar](150) NOT NULL default '565339bc4d33d72817b583024112eb7f5cdf3e5eef0252d6ec1b9c9a94e12bb3',  --OK en SHA 256
    [estado_habilitacion] [bit] NOT NULL DEFAULT 1,
    [intentos_fallidos] [tinyint] DEFAULT 0,
)

CREATE TABLE [GAME_OF_CODE].[Rol_por_Usuario] (
    [id_rol_por_usuario] INT IDENTITY(1,1) PRIMARY KEY
)

CREATE TABLE [GAME_OF_CODE].[Rol] (
    [id_rol] INT IDENTITY(1,1) PRIMARY KEY,
    [nombre] [nvarchar](20) NOT NULL,  
    [estado_habilitacion] [bit] NOT NULL DEFAULT 1
)

CREATE TABLE [GAME_OF_CODE].[Funcionalidad_por_Rol] (
    [id_funcionalidad_por_rol] INT IDENTITY(1,1) PRIMARY KEY
)

CREATE TABLE [GAME_OF_CODE].[Funcionalidad] (
    [id_funcionalidad] INT IDENTITY(1,1) PRIMARY KEY,
    [descripcion] [nvarchar](255) NOT NULL       
)

CREATE TABLE [GAME_OF_CODE].[Usuario_por_Sucursal] (
	[id_usuario_por_sucursal] INT IDENTITY(1,1) PRIMARY KEY
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
	[item_factura] [nvarchar](50) NOT  NULL,
	[monto_unitario] INT NOT NULL,
	[cantidad] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Devolucion] (
	[id_devolucion] INT IDENTITY(1,1) PRIMARY KEY,
	[motivo] [nvarchar](255) NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Pago_de_Facturas] (
	[id_pago_facturas] INT IDENTITY(1,1) PRIMARY KEY,
	[fecha_cobro] [datetime] NOT NULL,
	[importe] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Factura] (
	[id_factura] INT IDENTITY(1,1) PRIMARY KEY,
	[numero_factura] INT NOT NULL,
	[fecha_alta] [datetime] NOT NULL,
	[monto_total] INT NOT NULL,
	[fecha_vencimiento] [datetime] NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Cliente] (
    [id_cliente] INT IDENTITY(1,1) PRIMARY KEY,
    [nombre] [nvarchar](255) NOT NULL,
    [apellido] [nvarchar](255) NOT NULL,
    [dni] [NUMERIC](18, 0) NOT NULL,
	[mail] [nvarchar](255) UNIQUE NOT NULL,
	[telefono] [NUMERIC](18,0) NOT NULL,
	[direccion] [nvarchar](150) NOT NULL,
	[codigo_postal] INT NOT NULL,
    [cli_fecha_nac] [datetime] NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Rendicion] (
	[id_rendicion] INT IDENTITY(1,1) PRIMARY KEY,
	[porcentaje_comision] INT NOT NULL,
	[importe_total] INT NOT NULL,
	[cant_facturas_rendidas] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Detalle_Rendicion] (
	[id_detalle_rendicion] INT IDENTITY(1,1) PRIMARY KEY
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
	[estado_habilitacion] [bit] NOT NULL DEFAULT 1
)

CREATE TABLE [GAME_OF_CODE].[Rubro] (
	[id_rubro] INT IDENTITY(1,1) PRIMARY KEY,
	[descripcion] [nvarchar](50) NOT NULL
)

/* FKs */

ALTER TABLE [GAME_OF_CODE].[Rol_por_Usuario] ADD CONSTRAINT id_usuario FOREIGN KEY (id_usuario) REFERENCES [GAME_OF_CODE].[Usuario](id_usuario)

ALTER TABLE [GAME_OF_CODE].[Rol_por_Usuario] ADD CONSTRAINT id_rol FOREIGN KEY (id_rol) REFERENCES [GAME_OF_CODE].[Rol](id_rol)

ALTER TABLE [GAME_OF_CODE].[Funcionalidad_por_Rol] ADD CONSTRAINT id_funcionalidad FOREIGN KEY (id_funcionalidad) REFERENCES [GAME_OF_CODE].[Funcionalidad](id_funcionalidad)

ALTER TABLE [GAME_OF_CODE].[Funcionalidad_por_Rol] ADD CONSTRAINT id_rol FOREIGN KEY (id_rol) REFERENCES [GAME_OF_CODE].[Rol](id_rol)

ALTER TABLE [GAME_OF_CODE].[Usuario_por_Sucursal] ADD CONSTRAINT id_usuario FOREIGN KEY (id_usuario) REFERENCES [GAME_OF_CODE].[Usuario](id_usuario)

ALTER TABLE [GAME_OF_CODE].[Usuario_por_Sucursal] ADD CONSTRAINT id_sucursal FOREIGN KEY (id_sucursal) REFERENCES [GAME_OF_CODE].[Sucursal](id_sucursal)

ALTER TABLE [GAME_OF_CODE].[Detalle_Factura] ADD CONSTRAINT id_factura FOREIGN KEY (id_factura) REFERENCES [GAME_OF_CODE].[Factura](id_factura)

ALTER TABLE [GAME_OF_CODE].[Devolucion] ADD CONSTRAINT id_usuario FOREIGN KEY (id_usuario) REFERENCES [GAME_OF_CODE].[Usuario](id_usuario)

ALTER TABLE [GAME_OF_CODE].[Devolucion] ADD CONSTRAINT id_rendicion FOREIGN KEY (id_rendicion) REFERENCES [GAME_OF_CODE].[Rendicion](id_rendicion)

ALTER TABLE [GAME_OF_CODE].[Devolucion] ADD CONSTRAINT id_factura FOREIGN KEY (id_factura) REFERENCES [GAME_OF_CODE].[Factura](id_factura)

ALTER TABLE [GAME_OF_CODE].[Pago_de_Facturas] ADD CONSTRAINT id_factura FOREIGN KEY (id_factura) REFERENCES [GAME_OF_CODE].[Factura](id_factura)

ALTER TABLE [GAME_OF_CODE].[Pago_de_Facturas] ADD CONSTRAINT id_sucursal FOREIGN KEY (id_sucursal) REFERENCES [GAME_OF_CODE].[Sucursal](id_sucursal)

ALTER TABLE [GAME_OF_CODE].[Factura] ADD CONSTRAINT id_cliente FOREIGN KEY (id_cliente) REFERENCES [GAME_OF_CODE].[Cliente](id_cliente)

ALTER TABLE [GAME_OF_CODE].[Factura] ADD CONSTRAINT id_empresa FOREIGN KEY (id_empresa) REFERENCES [GAME_OF_CODE].[Empresa](id_empresa)

ALTER TABLE [GAME_OF_CODE].[Detalle_Rendicion] ADD CONSTRAINT id_rendicion FOREIGN KEY (id_rendicion) REFERENCES [GAME_OF_CODE].[Rendicion](id_rendicion)

ALTER TABLE [GAME_OF_CODE].[Detalle_Rendicion] ADD CONSTRAINT id_pago_facturas FOREIGN KEY (id_pago_facturas) REFERENCES [GAME_OF_CODE].[Pago_de_Facturas](id_pago_facturas)

ALTER TABLE [GAME_OF_CODE].[Medio_de_Pago] ADD CONSTRAINT id_pago_facturas FOREIGN KEY (id_pago_facturas) REFERENCES [GAME_OF_CODE].[Pago_de_Facturas](id_pago_facturas)

ALTER TABLE [GAME_OF_CODE].[Rubro] ADD CONSTRAINT id_empresa FOREIGN KEY (id_empresa) REFERENCES [GAME_OF_CODE].[Empresa](id_empresa)

/** FIN CREACION DE TABLAS **/


/** VALIDACION DE FUNCIONES, PROCEDURES, VISTAS Y TRIGGERS**/

/** FIN VALIDACION DE FUNCIONES, PROCEDURES, VISTAS Y TRIGGERS **/



/** CREACION DE FUNCIONES Y PROCEDURES **/

/** FIN CREACION DE FUNCIONES Y PROCEDURES **/



/******************************
*         MIGRACION           *
******************************/

/** Migracion de Clientes **/
INSERT INTO GAME_OF_CODE.Cliente (nombre, apellido, dni, mail, direccion, codigo_postal, cli_fecha_nac)
			SELECT DISTINCT Cliente-Nombre, Cliente-Apellido, Cliente-Dni, Cliente_Mail, Cliente_Direccion, Cliente_Codigo_Postal, Cliente-Fecha_Nac
			FROM gd_esquema.Maestra
			WHERE Cliente-Dni IS NOT NULL


INSERT INTO GAME_OF_CODE.Factura (numero_factura, fecha_alta, monto_total ,fecha_vencimiento)
			SELECT DISTINCT Nro_Factura, Factura_Fecha, Factura_Total, Factura_Fecha_Vencimiento
			FROM gd_esquema.Maestra
			WHERE Nro_Factura IS NOT NULL

			
INSERT INTO GAME_OF_CODE.Detalle_Factura (monto_unitario, cantidad)
			SELECT DISTINCT ItemFactura_Monto, ItemFactura_Cantidad
			FROM gd.esquema_Maestra
			WHERE ItemFactura_Monto IS NOT NULL
			

INSERT INTO GAME_OF_CODE.Empresa (nombre, emp_cuit, emp_direccion)
			SELECT DISTINCT Empresa_Nombre, Empresa_Cuit, Empresa_Direccion
			FROM gd.esquema_Maestra
			WHERE Empresa_Cuit IS NOT NULL
			
			
INSERT INTO GAME_OF_CODE.Rubro (id_empresa, descripcion)
			SELECT DISTINCT Empresa_Rubro, Rubro_Descripcion
			FROM gd.esquema_Maestra
			WHERE Empresa_Rubro IS NOT NULL
			

			
/** FIN MIGRACION **/

-- CREACION DE VISTAS

-- FIN DE CREACION DE VISTAS

-- CREACION DE TRIGGERS



/** Inserto usuario administrador para manejar la app (admin:w23e) **/
