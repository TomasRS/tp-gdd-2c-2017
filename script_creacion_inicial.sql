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

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Medio_de_Pago'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Medio_de_Pago DROP CONSTRAINT Medio_de_Pago_id_pago_facturas;
    DROP TABLE GAME_OF_CODE.Medio_de_Pago
END

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Detalle_Rendicion'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Detalle_Rendicion DROP CONSTRAINT Detalle_Rendicion_id_rendicion;
	ALTER TABLE GAME_OF_CODE.Detalle_Rendicion DROP CONSTRAINT Detalle_Rendicion_id_pago_facturas;
	DROP TABLE GAME_OF_CODE.Detalle_Rendicion
END

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Pago_de_Facturas'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Pago_de_Facturas DROP CONSTRAINT Pago_de_Facturas_id_factura;
	ALTER TABLE GAME_OF_CODE.Pago_de_Facturas DROP CONSTRAINT Pago_de_Facturas_id_sucursal;
    DROP TABLE GAME_OF_CODE.Pago_de_Facturas
END

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Factura'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Factura DROP CONSTRAINT Factura_id_cliente;
	ALTER TABLE GAME_OF_CODE.Factura DROP CONSTRAINT Factura_id_empresa;
	ALTER TABLE GAME_OF_CODE.Factura DROP CONSTRAINT Factura_id_devolucion;
    DROP TABLE GAME_OF_CODE.Factura
END

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Devolucion'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Devolucion DROP CONSTRAINT Devolucion_id_usuario;
    DROP TABLE GAME_OF_CODE.Devolucion
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
    [username] [nvarchar](50),
    [password] [nvarchar](150) NOT NULL,
    [estado_habilitacion] [bit] NOT NULL DEFAULT 1,
    [intentos_fallidos] [tinyint] DEFAULT 0,
)

CREATE TABLE [GAME_OF_CODE].[Rol_por_Usuario] (
    [id_rol_por_usuario] INT IDENTITY(1,1) PRIMARY KEY,
	[id_usuario] INT NOT NULL,
	[id_rol] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Rol] (
    [id_rol] INT IDENTITY(1,1) PRIMARY KEY,
    [nombre] [nvarchar](20) NOT NULL,  
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
	[id_factura] INT NOT NULL,
	[item_factura] [nvarchar](50) NOT  NULL,
	[monto_unitario] INT NOT NULL,
	[cantidad] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Devolucion] (
	[id_devolucion] INT IDENTITY(1,1) PRIMARY KEY,
	[id_usuario] INT NOT NULL,
	[motivo] [nvarchar](255) NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Pago_de_Facturas] (
	[id_pago_facturas] INT IDENTITY(1,1) PRIMARY KEY,
	[id_factura] INT NOT NULL,
	[id_sucursal] INT NOT NULL,
	[fecha_cobro] [datetime] NOT NULL,
	[importe] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Factura] (
	[id_factura] INT IDENTITY(1,1) PRIMARY KEY,
	[id_cliente] INT NOT NULL,
	[id_empresa] INT NOT NULL,
	[id_devolucion] INT NOT NULL,
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
	[id_detalle_rendicion] INT IDENTITY(1,1) PRIMARY KEY,
	[id_rendicion] INT NOT NULL,
	[id_pago_facturas] INT NOT NULL,
)

CREATE TABLE [GAME_OF_CODE].[Medio_de_Pago] (
	[id_medio_pago] INT IDENTITY(1,1) PRIMARY KEY,
	[id_pago_facturas] INT NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Empresa] (
    [id_empresa] INT IDENTITY(1,1) PRIMARY KEY,
	[id_rubro] INT NOT NULL,
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

ALTER TABLE [GAME_OF_CODE].[Rol_por_Usuario] ADD CONSTRAINT Rol_por_Usuario_id_usuario FOREIGN KEY (id_usuario) REFERENCES [GAME_OF_CODE].[Usuario](id_usuario)

ALTER TABLE [GAME_OF_CODE].[Rol_por_Usuario] ADD CONSTRAINT Rol_por_Usuario_id_rol FOREIGN KEY (id_rol) REFERENCES [GAME_OF_CODE].[Rol](id_rol)

ALTER TABLE [GAME_OF_CODE].[Funcionalidad_por_Rol] ADD CONSTRAINT Funcionalidad_por_Rol_id_funcionalidad FOREIGN KEY (id_funcionalidad) REFERENCES [GAME_OF_CODE].[Funcionalidad](id_funcionalidad)

ALTER TABLE [GAME_OF_CODE].[Funcionalidad_por_Rol] ADD CONSTRAINT Funcionalidad_por_Rol_id_rol FOREIGN KEY (id_rol) REFERENCES [GAME_OF_CODE].[Rol](id_rol)

ALTER TABLE [GAME_OF_CODE].[Usuario_por_Sucursal] ADD CONSTRAINT Usuario_por_Sucursal_id_usuario FOREIGN KEY (id_usuario) REFERENCES [GAME_OF_CODE].[Usuario](id_usuario)

ALTER TABLE [GAME_OF_CODE].[Usuario_por_Sucursal] ADD CONSTRAINT Usuario_por_Sucursal_id_sucursal FOREIGN KEY (id_sucursal) REFERENCES [GAME_OF_CODE].[Sucursal](id_sucursal)

ALTER TABLE [GAME_OF_CODE].[Detalle_Factura] ADD CONSTRAINT Detalle_Factura_id_factura FOREIGN KEY (id_factura) REFERENCES [GAME_OF_CODE].[Factura](id_factura)

ALTER TABLE [GAME_OF_CODE].[Devolucion] ADD CONSTRAINT Devolucion_id_usuario FOREIGN KEY (id_usuario) REFERENCES [GAME_OF_CODE].[Usuario](id_usuario)

ALTER TABLE [GAME_OF_CODE].[Pago_de_Facturas] ADD CONSTRAINT Pago_de_Facturas_id_factura FOREIGN KEY (id_factura) REFERENCES [GAME_OF_CODE].[Factura](id_factura)

ALTER TABLE [GAME_OF_CODE].[Pago_de_Facturas] ADD CONSTRAINT Pago_de_Facturas_id_sucursal FOREIGN KEY (id_sucursal) REFERENCES [GAME_OF_CODE].[Sucursal](id_sucursal)

ALTER TABLE [GAME_OF_CODE].[Factura] ADD CONSTRAINT Factura_id_cliente FOREIGN KEY (id_cliente) REFERENCES [GAME_OF_CODE].[Cliente](id_cliente)

ALTER TABLE [GAME_OF_CODE].[Factura] ADD CONSTRAINT Factura_id_empresa FOREIGN KEY (id_empresa) REFERENCES [GAME_OF_CODE].[Empresa](id_empresa)

ALTER TABLE [GAME_OF_CODE].[Factura] ADD CONSTRAINT Factura_id_devolucion FOREIGN KEY (id_devolucion) REFERENCES [GAME_OF_CODE].[Devolucion](id_devolucion)

ALTER TABLE [GAME_OF_CODE].[Detalle_Rendicion] ADD CONSTRAINT Detalle_Rendicion_id_rendicion FOREIGN KEY (id_rendicion) REFERENCES [GAME_OF_CODE].[Rendicion](id_rendicion)

ALTER TABLE [GAME_OF_CODE].[Detalle_Rendicion] ADD CONSTRAINT Detalle_Rendicion_id_pago_facturas FOREIGN KEY (id_pago_facturas) REFERENCES [GAME_OF_CODE].[Pago_de_Facturas](id_pago_facturas)

ALTER TABLE [GAME_OF_CODE].[Medio_de_Pago] ADD CONSTRAINT Medio_de_Pago_id_pago_facturas FOREIGN KEY (id_pago_facturas) REFERENCES [GAME_OF_CODE].[Pago_de_Facturas](id_pago_facturas)

ALTER TABLE [GAME_OF_CODE].[Empresa] ADD CONSTRAINT Empresa_id_rubro FOREIGN KEY (id_rubro) REFERENCES [GAME_OF_CODE].[Rubro](id_rubro)

/** FIN CREACION DE TABLAS **/


/** VALIDACION DE FUNCIONES, PROCEDURES, VISTAS Y TRIGGERS**/

/** FIN VALIDACION DE FUNCIONES, PROCEDURES, VISTAS Y TRIGGERS **/



/** CREACION DE FUNCIONES Y PROCEDURES **/

/** FIN CREACION DE FUNCIONES Y PROCEDURES **/



/******************************
*         MIGRACION           *
******************************/

/** Migracion de Clientes **/


INSERT INTO GAME_OF_CODE.Rubro (descripcion)
			SELECT DISTINCT Rubro_Descripcion
			FROM gd_esquema.Maestra
			WHERE Rubro_Descripcion IS NOT NULL


INSERT INTO GAME_OF_CODE.Empresa (nombre, emp_cuit, emp_direccion, id_rubro, estado_habilitacion)
   SELECT DISTINCT Empresa_Nombre, Empresa_Cuit, Empresa_Direccion, Empresa_Rubro, 1
   FROM gd_esquema.Maestra
   WHERE Empresa_Nombre IS NOT NULL
     AND Empresa_Cuit IS NOT NULL

/*
INSERT INTO GAME_OF_CODE.Cliente (nombre, apellido, dni, mail, direccion, codigo_postal, cli_fecha_nac)
			SELECT DISTINCT Cliente_Nombre, Cliente_Apellido, Cliente_Dni, Cliente_Mail, Cliente_Direccion, Cliente_Codigo_Postal, Cliente_Fecha_Nac
			FROM gd_esquema.Maestra
			WHERE Cliente_Dni IS NOT NULL
			

INSERT INTO GAME_OF_CODE.Factura (numero_factura, fecha_alta, monto_total ,fecha_vencimiento)
			SELECT DISTINCT Nro_Factura, Factura_Fecha, Factura_Total, Factura_Fecha_Vencimiento
			FROM gd_esquema.Maestra
			WHERE Nro_Factura IS NOT NULL

			
INSERT INTO GAME_OF_CODE.Detalle_Factura (monto_unitario, cantidad)
			SELECT DISTINCT ItemFactura_Monto, ItemFactura_Cantidad
			FROM gd.esquema_Maestra
			WHERE ItemFactura_Monto IS NOT NULL
*/
			

			
/** FIN MIGRACION **/

-- CREACION DE VISTAS

-- FIN DE CREACION DE VISTAS

-- CREACION DE TRIGGERS



/** Inserto usuario administrador para manejar la app (admin:w23e) **/
