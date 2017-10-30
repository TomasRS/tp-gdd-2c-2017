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

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Factura'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Factura DROP CONSTRAINT Factura_id_cliente;
	ALTER TABLE GAME_OF_CODE.Factura DROP CONSTRAINT Factura_id_empresa;
	ALTER TABLE GAME_OF_CODE.Factura DROP CONSTRAINT Factura_id_devolucion;
	ALTER TABLE GAME_OF_CODE.Factura DROP CONSTRAINT Factura_Id_Pago;
	DROP TABLE GAME_OF_CODE.Factura
END

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GAME_OF_CODE.Pago_de_Facturas'))
BEGIN
	ALTER TABLE GAME_OF_CODE.Pago_de_Facturas DROP CONSTRAINT Pago_de_Facturas_id_sucursal;
	DROP TABLE GAME_OF_CODE.Pago_de_Facturas
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
	[item_factura] [nvarchar](50) NOT NULL DEFAULT 'Producto',
	[monto_unitario] INT NOT NULL,
	[cantidad] INT NOT NULL,
	[id_factura] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Devolucion] (
	[id_devolucion] INT IDENTITY(1,1) PRIMARY KEY,
	[motivo] [nvarchar](255) NOT NULL,
	[id_usuario] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Pago_de_Facturas] (
	[id_pago_facturas] INT IDENTITY(1,1) PRIMARY KEY,
	[fecha_cobro] [datetime] NOT NULL,
	[importe] INT NOT NULL,
	[id_sucursal] INT NOT NULL
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
	[id_devolucion] INT
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
	[id_rendicion] INT PRIMARY KEY,
	[fecha_rendicion] [datetime] NOT NULL,
	[importe_total] INT NOT NULL,
	[porcentaje_comision] INT NOT NULL,
	[cant_facturas_rendidas] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Detalle_Rendicion] (
	[id_detalle_rendicion] INT IDENTITY(1,1) PRIMARY KEY,
	[id_rendicion] INT NOT NULL,
	[id_pago_facturas] INT NOT NULL,
)

CREATE TABLE [GAME_OF_CODE].[Medio_de_Pago] (
	[id_medio_pago] INT IDENTITY(1,1) PRIMARY KEY,
	[descripcion] [nvarchar](50) NOT NULL,
	[id_pago_facturas] INT NOT NULL
)

CREATE TABLE [GAME_OF_CODE].[Empresa] (
    [id_empresa] INT IDENTITY(1,1) PRIMARY KEY,
    [nombre] [nvarchar](255) NOT NULL,
    [emp_cuit] [nvarchar](50) NOT NULL,
    [emp_direccion] [nvarchar](255) NOT NULL,
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

ALTER TABLE [GAME_OF_CODE].[Devolucion] ADD CONSTRAINT Devolucion_id_usuario FOREIGN KEY (id_usuario) REFERENCES [GAME_OF_CODE].[Usuario](id_usuario)

ALTER TABLE [GAME_OF_CODE].[Factura] ADD CONSTRAINT Factura_Id_Pago FOREIGN KEY (id_pago) REFERENCES [GAME_OF_CODE].[Pago_de_Facturas](id_pago_facturas)

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
IF (OBJECT_ID('GAME_OF_CODE.pr_crear_usuario_con_valores') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.pr_crear_usuario_con_valores
GO

IF (OBJECT_ID('GAME_OF_CODE.get_cantidad_roles_de_usuario') IS NOT NULL)
    DROP PROCEDURE GAME_OF_CODE.get_cantidad_roles_de_usuario
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
	SELECT COUNT(id_rol) FROM GAME_OF_CODE.Rol_por_Usuario WHERE (SELECT id_usuario FROM GAME_OF_CODE.Usuario WHERE username = @username) = id_usuario
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
	@id int OUTPUT
AS
BEGIN
	INSERT INTO GAME_OF_CODE.Empresa
		(nombre, emp_cuit, emp_direccion, id_rubro)
	VALUES
		(@nombre, @emp_cuit, @emp_direccion, @id_rubro);
	SET @id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GAME_OF_CODE.pr_modificar_empresa
	@nombre nvarchar(255),
	@emp_cuit nvarchar(50),
	@emp_direccion nvarchar(255),
	@id_rubro int,
	@id int, /*id_empresa*/
	@id_output int OUTPUT
AS
BEGIN
	UPDATE GAME_OF_CODE.Empresa
	SET nombre = @nombre, emp_cuit = @emp_cuit, emp_direccion = @emp_direccion, id_rubro = @id_rubro
	WHERE id_empresa = @id
	SET @id_output = SCOPE_IDENTITY();
END
GO

/** FIN CREACION DE FUNCIONES Y PROCEDURES **/


/******************************
*         MIGRACION           *
******************************/


/** Migracion de Clientes **/

INSERT INTO GAME_OF_CODE.Rubro (descripcion)
			SELECT DISTINCT Rubro_Descripcion
			FROM gd_esquema.Maestra
			WHERE Rubro_Descripcion IS NOT NULL

INSERT INTO GAME_OF_CODE.Sucursal (nombre, direccion, codigo_postal)
	SELECT DISTINCT Sucursal_Nombre, Sucursal_Dirección, Sucursal_Codigo_Postal
	FROM gd_esquema.Maestra
	WHERE Sucursal_Nombre IS NOT NULL
	  AND Sucursal_Codigo_Postal IS NOT NULL

INSERT INTO GAME_OF_CODE.Rendicion (id_rendicion, fecha_rendicion, importe_total, porcentaje_comision, cant_facturas_rendidas)
	SELECT  Rendicion_Nro,
			Rendicion_Fecha,
			SUM (ItemRendicion_Importe),
            0,
            COUNT (Rendicion_Nro)
	FROM gd_esquema.Maestra
	WHERE Rendicion_Nro IS NOT NULL
	GROUP BY Rendicion_Nro, Rendicion_Fecha

INSERT INTO GAME_OF_CODE.Cliente (nombre, apellido, dni, mail, direccion, codigo_postal, cli_fecha_nac)
	SELECT DISTINCT [Cliente-Nombre], [Cliente-Apellido], [Cliente-Dni], Cliente_Mail, Cliente_Direccion, Cliente_Codigo_Postal, [Cliente-Fecha_Nac]
	FROM gd_esquema.Maestra
	WHERE [Cliente-Nombre] IS NOT NULL
	  AND [Cliente-Apellido] IS NOT NULL
	  AND [Cliente-Dni] IS NOT NULL
	  AND Cliente_Mail IS NOT NULL

INSERT INTO GAME_OF_CODE.Empresa (nombre, emp_cuit, emp_direccion, id_rubro)
   SELECT DISTINCT Empresa_Nombre, Empresa_Cuit, Empresa_Direccion, Empresa_Rubro
   FROM gd_esquema.Maestra
   WHERE Empresa_Nombre IS NOT NULL
     AND Empresa_Cuit IS NOT NULL

SET IDENTITY_INSERT GAME_OF_CODE.Pago_de_Facturas ON;
INSERT INTO GAME_OF_CODE.Pago_de_Facturas(id_pago_facturas,fecha_cobro,id_sucursal, importe)
	SELECT A.Pago_nro, A.Pago_Fecha, B.id_sucursal ,sum(A.ItemFactura_Monto * A.ItemFactura_Cantidad) 
	FROM gd_esquema.Maestra A, GAME_OF_CODE.Sucursal B
	WHERE B.nombre = A.Sucursal_Nombre 
	GROUP BY Pago_nro, B.id_sucursal, A.Pago_Fecha
SET IDENTITY_INSERT GAME_OF_CODE.Pago_de_Facturas OFF;

/*Debido a que en la tabla maestra se encontraron para una misma facturas items asociados a un numero
  de pago, y otros items sin asociar a un numero de pago, se opto por cagar primero las facturas donde
  se registren items que esten asociados a un numero de pago, y luego cargar aquellas que no esten asociadas
  a un numero de pago.
	  
  Por esta inconsistencia en los datos, ya que se supone que si un item esta pago para una factura, el resto de los items
  de esa misma factura deberían estan pagos, es que se tuvo que realizar este preoceso con 2 inserts.
	  
  NOTA: En el segundo insert solo se van a insertar aquellas facturas cuyos items no registren pago, y que a su vez
  no hayan sido cargadas en el insert anterior, ya que como la tabla maestra presenta la inconsistencia anteriormente mencionada,
  existen registros con numeros de facturas asociados a un numero de pago y a su vez no asociados a un numero de pago.*/

/*PRIMER INSERT: 
  Primero se insertan las facturas que estén asociadas a un númerpo de pago
*/
	INSERT INTO GAME_OF_CODE.Factura (numero_factura, fecha_alta, monto_total, fecha_vencimiento, id_cliente,id_empresa, id_pago) 
	SELECT Nro_Factura, Factura_Fecha, SUM(ItemFactura_Monto*ItemFactura_Cantidad),Factura_Fecha_Vencimiento, B.id_cliente, C.id_empresa, A.Pago_nro
	FROM gd_esquema.Maestra A
	INNER JOIN GAME_OF_CODE.Cliente B ON A.[Cliente-Dni] = B.dni
	INNER JOIN GAME_OF_CODE.Empresa C ON A.Empresa_Cuit = C.emp_cuit
	INNER JOIN GAME_OF_CODE.Pago_de_Facturas D ON D.id_pago_facturas = Pago_nro
	WHERE A.ItemFactura_Cantidad IS NOT NULL
	  AND A.ItemFactura_Monto IS NOT NULL
	  AND Pago_nro IS NOT NULL
	GROUP BY Nro_Factura, Factura_Fecha, Factura_Fecha_Vencimiento, B.id_cliente, C.id_empresa, A.Pago_nro

/*SEGUNDO INSERT: 
  Se insertan aquellas facturas que no hayan sido insertadas en el paso anterior
*/
	INSERT INTO GAME_OF_CODE.Factura (numero_factura, fecha_alta, monto_total, fecha_vencimiento, id_cliente,id_empresa) 
	SELECT Nro_Factura, Factura_Fecha, SUM(ItemFactura_Monto*ItemFactura_Cantidad),Factura_Fecha_Vencimiento, B.id_cliente, C.id_empresa
	FROM gd_esquema.Maestra A
	INNER JOIN GAME_OF_CODE.Cliente B ON A.[Cliente-Dni] = B.dni
	INNER JOIN GAME_OF_CODE.Empresa C ON A.Empresa_Cuit = C.emp_cuit
	WHERE A.ItemFactura_Cantidad IS NOT NULL
	  AND A.ItemFactura_Monto IS NOT NULL
	  AND A.Pago_nro IS NULL --Se verifica que no este pagado
	  AND A.Nro_Factura NOT IN (SELECT numero_factura FROM GAME_OF_CODE.Factura) --Se verifica que no este insertada
	GROUP BY Nro_Factura, Factura_Fecha, Factura_Fecha_Vencimiento, B.id_cliente, C.id_empresa

INSERT INTO GAME_OF_CODE.Detalle_Factura (monto_unitario, cantidad, id_factura)
	SELECT DISTINCT ItemFactura_Monto, ItemFactura_Cantidad, B.id_factura
	FROM gd_esquema.Maestra A, GAME_OF_CODE.Factura B
	WHERE ItemFactura_Monto IS NOT NULL
	  AND ItemFactura_Cantidad IS NOT NULL
	  AND A.Nro_Factura = B.numero_factura

/** FIN MIGRACION **/

-------------------------------------------------------------------------------------------------------------------------------------------
/** Inserto usuario administrador para manejar la app (admin:w23e) **/
INSERT INTO GAME_OF_CODE.Rol (nombre)
	VALUES ('Administrador')


DECLARE @id_admin INT
EXEC GAME_OF_CODE.pr_crear_usuario_con_valores 'admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', @id_admin output   

INSERT INTO GAME_OF_CODE.Rol_por_Usuario (id_rol, id_usuario)
    VALUES	(1, @id_admin)


/** Alta de Funcionalidades **/

INSERT INTO GAME_OF_CODE.Funcionalidad(descripcion)
    VALUES  ('Alta de clientes'),
            ('Modificación y baja de clientes'),
            ('Alta de empresas'),
            ('Modificación y baja de empresas'),
            ('Alta de facturas'),
            ('Modificación y baja de facturas'),
            ('Alta de roles'),
            ('Modificación y baja de roles'),
            ('Alta de sucursales'),
            ('Modificación y baja de sucursales'),
            ('Devolución de facturas pagas'),
            ('Listado estadístico'),
            ('Pagar facturas'),
            ('Realizar rendicion de facturas')

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
---------------------------------------------------------------------------------------------------------------------------------------------




-- CREACION DE VISTAS

-- FIN DE CREACION DE VISTAS

-- CREACION DE TRIGGERS
