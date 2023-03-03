CREATE DATABasE SistemaVentas
GO
USE SistemaVentas
GO


--------------------------------------------------------------------
--------------------------------------------------------------------
--Usuarios

CREATE TABLE tbUsuarios(
	usuarioId					INT IDENTITY(1,1),
	usuarioUsuario				NVARCHAR(150) NOT NULL UNIQUE,
	usuarioContrasenia			NVARCHAR(MAX) NOT NULL,
	empleadoId					INT NOT NULL,
	usuarioUsuarioCreacion		INT NOT NULL,
	usuarioFechaCreacion		DATETIME NOT NULL,
	usuarioUsuarioModificacion INT ,
	usuarioFechaModificacion	DATETIME,
	usuarioEstado				BIT NOT NULL,
	CONSTRAINT PK_dbo_tbUsuarios_usuarioId PRIMARY KEY(usuarioId)
);

--------------------------------------------------------------------
--------------------------------------------------------------------
--Estado Civil
CREATE TABLE tbEstadosCiviles(
	estadoCivilId					CHAR(1) NOT NULL,
	estadoCivilNombre				NVARCHAR(200) NOT NULL,
	estadoCivilFechaCreacion		DATETIME NOT NULL,
	estadoCivilUsuarioCreacion		INT NOT NULL,
	estadoCivilFechaModificacion	DATETIME,
	estadoCivilUsuarioModificacion  INT,
	estadoCivilEstado				BIT NOT NULL, 
	CONSTRAINT PK_dbo_tbEstadosCiviles_estadoCivilId PRIMARY KEY(estadoCivilId),
	CONSTRAINT FK_dbo_tbEstadosCiviles_dbo_tbUsuarios_estadoCivilUsuarioCreacion_estadoCivilId FOREIGN KEY(estadoCivilUsuarioCreacion) REFERENCES tbUsuarios(usuarioId),
	CONSTRAINT FK_dbo_tbEstadosCiviles_dbo_tbUsuarios_estadoCivilFechaModificacion_estadoCivilId FOREIGN KEY(estadoCivilUsuarioModificacion) REFERENCES tbUsuarios(usuarioId)
);

--------------------------------------------------------------------
--------------------------------------------------------------------
--Departamentos
CREATE TABLE tbDepartamentos(
	departamentoId					CHAR(2) NOT NULL,
	departamentoNombre				NVARCHAR(200) NOT NULL,
	departamentoFechaCreacion		DATETIME NOT NULL,
	departamentoUsuarioCreacion		INT NOT NULL,
	departamentoFechaModificacion	DATETIME,
	departamentoUsuarioModificacion INT,
	departamentoEstado				BIT NOT NULL,
	CONSTRAINT PK_dbo_tbDepartamentos_departamentoId PRIMARY KEY(departamentoId),
	CONSTRAINT FK_dbo_tbDepartamentos_dbo_tbUsuarios_departamentoUsuarioCreacion_usuarioId FOREIGN KEY(departamentoUsuarioCreacion) REFERENCES tbUsuarios(usuarioId),
	CONSTRAINT FK_dbo_tbDepartamentos_dbo_tbUsuarios_departamentoUsuarioModificacion_usuarioId FOREIGN KEY(departamentoUsuarioModificacion) REFERENCES tbUsuarios(usuarioId)
);


--------------------------------------------------------------------
--------------------------------------------------------------------
--Municipios

CREATE TABLE tbMunicipios(
	municipioId						CHAR(4) NOT NULL,
	departamentoId					CHAR(2) NOT NULL,
	municipioNombre					NVARCHAR(200) NOT NULL,
	municipioFechaCreacion			DATETIME NOT NULL,
	municipioUsuarioCreacion		INT NOT NULL,
	municipioFechaModificacion		DATETIME,
	municipioUsuarioModificacion	INT,
	municipioEstado					BIT NOT NULL,
	CONSTRAINT PK_dbo_tbMunicipios_municipioId PRIMARY KEY(municipioId),
	CONSTRAINT FK_tbMunicipios_tbDepartamentos_departamentoId FOREIGN KEY(departamentoId) REFERENCES tbDepartamentos(departamentoId),
	CONSTRAINT FK_dbo_tbMunicipios_dbo_tbUsuarios_municipioUsuarioCreacion_usuarioId FOREIGN KEY(municipioUsuarioCreacion) REFERENCES tbUsuarios(usuarioId),
	CONSTRAINT FK_dbo_tbMunicipios_dbo_tbUsuarios_municipioUsuarioModificacion_usuarioId FOREIGN KEY(municipioUsuarioModificacion) REFERENCES tbUsuarios(usuarioId)
);

---------------------------------------------------------------------------------
---------------------------------------------------------------------------------

--Categorias
CREATE TABLE tbCategoria(
categoriaId						INT IDENTITY(1,1),
categoriaDescripcion			NVARCHAR (150) NOT NULL,
categoriaFechaCreacion			DATETIME NOT NULL,
categoriaUsuarioCreacion		INT NOT NULL,
categoriaFechaModificacion		DATETIME,
categoriaUsuarioModificacion	INT,
categoriaEstado					BIT NOT NULL,
CONSTRAINT PK_dbo_tbCategoria_categoriaId PRIMARY KEY(categoriaId),
	CONSTRAINT FK_dbo_tbCategoria_dbo_tbUsuarios_categoriaUsuarioCreacion_usuarioId FOREIGN KEY(categoriaUsuarioCreacion) REFERENCES tbUsuarios(usuarioId),
	CONSTRAINT FK_dbo_tbCategoria_dbo_tbUsuarios_categoriaFechaModificacion_usuarioId FOREIGN KEY(categoriaUsuarioModificacion) REFERENCES tbUsuarios(usuarioId)
);



--------------------------------------------------------------------
--------------------------------------------------------------------
--Cargos
CREATE TABLE tbCargos(
	cargoId					INT IDENTITY(1,1) NOT NULL,
	cargoNombre				NVARCHAR(150) NOT NULL,
	cargoFechaCreacion		DATETIME NOT NULL,
	cargoUsuarioCreacion		INT NOT NULL,
	cargoFechaModificacion	DATETIME,
	cargoUsuarioModificacion INT,
	cargoEstado				BIT NOT NULL,
	CONSTRAINT PK_dbo_tbCargos_cargoId PRIMARY KEY(cargoId),
	CONSTRAINT FK_dbo_tbCargos_dbo_tbUsuarios_cargoUsuarioCreacion_usuarioId FOREIGN KEY(cargoUsuarioCreacion) REFERENCES tbUsuarios(usuarioId),
	CONSTRAINT FK_dbo_tbCargos_dbo_tbUsuarios_cargoUsuarioModificacion_usuarioId FOREIGN KEY(cargoUsuarioModificacion) REFERENCES tbUsuarios(usuarioId)
);

---------------------------------------------------------------------------------
---------------------------------------------------------------------------------
--Metodo de Pago
CREATE TABLE tbMetodoPago(
	metodopagoId						Char(1) NOT NULL,
	metodopagoDescripcion				NVARCHAR (100) NOT NULL,
	metodopagoFechaCreacion				DATETIME NOT NULL,
	metodopagoUsuarioCreacion			INT NOT NULL,
	metodopagoFechaModificacion			DATETIME,
	metodopagoUsuarioModificacion		INT,
	metodopagoEstado					BIT NOT NULL,
	
	CONSTRAINT PK_dbo_tbMetodoPagos_metodopagoId PRIMARY KEY(metodopagoId),
	CONSTRAINT FK_dbo_tbMetodoPago_dbo_tbUsuarios_metodopagoUsuarioCreacion_usuarioId FOREIGN KEY(metodopagoUsuarioCreacion) REFERENCES tbUsuarios(usuarioId),
	CONSTRAINT FK_dbo_tbMetodoPago_dbo_tbUsuarios_metodopagoUsuarioModificacion_usuarioId FOREIGN KEY(metodopagoUsuarioModificacion) REFERENCES tbUsuarios(usuarioId)

);

------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------

--Proveedores
CREATE TABLE tbProveedores (
proveedorId                             INT IDENTITY(1,1),
proveedorNombre                         NVARCHAR(250) NOT NULL,
municipioId								CHAR(04) NOT NULL,
proveedorDireccionExacta                NVARCHAR(500),
proveedorTelefono                       VARCHAR(50),
proveedorEmail                          NVARCHAR(150) NOT NULL,
proveedorFechaCreacion					DATETIME NOT NULL,
proveedorUsuarioCreacion				INT NOT NULL,
proveedorFechaModificacion				DATETIME,
proveedorUsuarioModificacion			INT,
proveedorEstado							BIT NOT NULL,
CONSTRAINT PK_dbo_tbProveedores_proveedorId PRIMARY KEY(proveedorId),
CONSTRAINT FK_dbo_tbProveedores_dbo_tbMunicipios_municipioId FOREIGN KEY(municipioId) REFERENCES tbMunicipios(municipioId),
CONSTRAINT FK_dbo_tbproveedores_dbo_tbUsuarios_proveedorUsuarioCreacion_usuarioId FOREIGN KEY(proveedorUsuarioCreacion) REFERENCES tbUsuarios(usuarioId),
CONSTRAINT FK_dbo_tbProveedores_dbo_tbUsuarios_proveedorUsuarioModificacion_usuarioId FOREIGN KEY(proveedorUsuarioModificacion) REFERENCES tbUsuarios(usuarioId)	
);


------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------

--Productos
CREATE TABLE tbProductos(
productoId								INT IDENTITY(1,1),
productoNombre							NVARCHAR (150) NOT NULL,
productoPrecio							DECIMAL (18,2) NOT NULL,
categoriaId								INT NOT NULL,
proveedorid								INT NOT NULL,
productoStock							INT NOT NULL,
productoFechaCreacion					DATETIME NOT NULL,
productoUsuarioCreacion					INT NOT NULL,
productoFechaModificacion				DATETIME,
productoUsuarioModificacion				INT,
productoEstado							BIT NOT NULL,

CONSTRAINT PK_dbo_tbProdutos_productoId PRIMARY KEY(productoId),
CONSTRAINT FK_dbo_tbProductos_tbCategoria_categoriaId FOREIGN KEY (categoriaId) REFERENCES tbCategoria (categoriaId),
CONSTRAINT FK_dbo_tbProductos_tbProveedores_proveedorid FOREIGN KEY (proveedorid) REFERENCES tbProveedores (proveedorId),
CONSTRAINT FK_dbo_tbProductos_dbo_tbUsuarios_productoUsuarioCreacion_usuarioId FOREIGN KEY(productoUsuarioCreacion) REFERENCES tbUsuarios(usuarioId),
CONSTRAINT FK_dbo_tbProductos_dbo_tbUsuarios_productoUsuarioModificacion_usuarioId FOREIGN KEY(productoUsuarioModificacion) REFERENCES tbUsuarios(usuarioId)

);

------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------

--Clientes
CREATE TABLE tbClientes(
clienteId                              INT IDENTITY (1,1),
clienteNombre							NVARCHAR(150) NOT NULL,
clienteApellido						NVARCHAR(150) NOT NULL,
municipioId								CHAR(04) NOT NULL,
clienteDireccionExacta					NVARCHAR(500) NOT NULL,
clienteTelefono						NVARCHAR(20) NOT NULL,
clienteCorreoElectronico				NVARCHAR(100) NOT NULL,
clienteFechaCreacion					DATETIME NOT NULL,
clienteUsuarioCreacion					INT NOT NULL,
clienteFechaModificacion				DATETIME,
clienteUsuarioModificacion				INT,
clienteEstado							BIT NOT NULL,

CONSTRAINT PK_dbo_tbClientes_clienteId PRIMARY KEY(clienteid),
CONSTRAINT FK_dbo_tbClientes_dbo_tbMunicipios_municipioId FOREIGN KEY(municipioId) REFERENCES tbMunicipios(municipioId),
CONSTRAINT FK_dbo_tbClientes_dbo_tbUsuarios_clienteUsuarioCreacion_usuarioId FOREIGN KEY(clienteUsuarioCreacion) REFERENCES tbUsuarios(usuarioId),
CONSTRAINT FK_dbo_tbClientes_dbo_tbUsuarios_clienteUsuarioModificacion_usuarioId FOREIGN KEY(clienteUsuarioModificacion) REFERENCES tbUsuarios(usuarioId)

);

------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------

--Empleados
CREATE TABLE tbEmpleados(
empleadoId                              INT IDENTITY (1,1),
empleadoNombre							NVARCHAR(150) NOT NULL,
empleadoApellido						NVARCHAR(150) NOT NULL,
empleadoSexo							CHAR(1) NOT NULL,
municipioId								CHAR(04) NOT NULL,
empleadoDireccionExacta					NVARCHAR(500) NOT NULL,
estadoCivilId							CHAR(1) NOT NULL,
empleadoTelefono						NVARCHAR(20) NOT NULL,
empleadoCorreoElectronico				NVARCHAR(100) NOT NULL,
empleadoFechaNacimiento					Date NOT NULL,
empleadoFechaContratacion				Date NOT NULL,
cargoId									INT NOT NULL,
empleadoFechaCreacion					DATETIME NOT NULL,
empleadoUsuarioCreacion					INT NOT NULL,
empleadoFechaModificacion				DATETIME,
empleadoUsuarioModificacion				INT,
empleadoEstado							BIT NOT NULL,

CONSTRAINT PK_dbo_tbEmpleados_empleadoId PRIMARY KEY(empleadoId),
CONSTRAINT FK_dbo_tbEmpleados_dbo_tbMunicipios_municipioId FOREIGN KEY(municipioId) REFERENCES tbMunicipios(municipioId),
CONSTRAINT FK_dbo_tbEmpleados_dbo_tbEstadosCiviles_estadoCivilId FOREIGN KEY(estadoCivilId) REFERENCES tbEstadosCiviles(estadoCivilId),
CONSTRAINT FK_dbo_tbEmpleados_dbo_tbCargos_cargoId FOREIGN KEY(cargoId) REFERENCES tbCargos(cargoId),
CONSTRAINT FK_dbo_tbEmpleados_dbo_tbUsuarios_empleadoUsuarioCreacion_usuarioId FOREIGN KEY(empleadoUsuarioCreacion) REFERENCES tbUsuarios(usuarioId),
CONSTRAINT FK_dbo_tbEmpleados_dbo_tbUsuarios_empleadoUsuarioModificacion_usuarioId FOREIGN KEY(empleadoUsuarioModificacion) REFERENCES tbUsuarios(usuarioId)
);


--venta
CREATE TABLE tbventa(
ventaId								INT IDENTITY(1,1),
clienteId								INT NOT NULL,
ventaFecha							Datetime NOT NULL,
empleadoId								INT NOT NULL,
metodopagoId							CHAR(1) NOT NULL,
ventaFechaCreacion					DATETIME NOT NULL,
ventaUsuarioCreacion					INT NOT NULL,
ventaFechaModificacion				DATETIME,
ventaUsuarioModificacion				INT,
ventaEstado							BIT NOT NULL,

CONSTRAINT PK_dbo_tbventa_ventaId PRIMARY KEY(ventaId),
CONSTRAINT FK_dbo_tbventa_tbClientes_clienteId FOREIGN KEY(clienteId) REFERENCES tbClientes(clienteId),
CONSTRAINT FK_dbo_tbventa_tbMetodoPago_metodopagoId FOREIGN KEY(metodopagoId) REFERENCES tbMetodoPago(metodopagoId),
CONSTRAINT FK_dbo_tbventa_dbo_tbEmpleados_empleadoId FOREIGN KEY(empleadoId) REFERENCES tbEmpleados(empleadoId),
CONSTRAINT FK_dbo_tbventa_dbo_tbUsuarios_ventaUsuarioCreacion_usuarioId FOREIGN KEY(ventaUsuarioCreacion) REFERENCES tbUsuarios(usuarioId),
CONSTRAINT FK_dbo_tbventa_dbo_tbUsuarios_ventaUsuarioModificacion_usuarioId FOREIGN KEY(ventaUsuarioModificacion) REFERENCES tbUsuarios(usuarioId)
);

--------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------

--ventaDetalles
CREATE TABLE tbventaDetalles (
ventaDetalle_Id                            INT IDENTITY(1,1),
ventaId									 INT NOT NULL,
productoId									 INT NOT NULL,
ventaDetalle_catidad						 INT NOT NULL,
ventaDetalle_Precio						 DECIMAL (18,2) NOT NULL,
ventaDetalle_FechaCreacion				 DATETIME NOT NULL,
ventaDetalle_UsuarioCreacion				 INT NOT NULL,
ventaDetalle_FechaModificacion			 DATETIME,
ventaDetalle_UsuarioModificacion			 INT,
ventaDetalle_Estado						 BIT NOT NULL,
CONSTRAINT PK_dbo_tbventaDetalles_ventaDetalle_Id PRIMARY KEY(ventaDetalle_Id),
CONSTRAINT FK_dbo_tbventaDetalles_tbventa_ventaId FOREIGN KEY(ventaId) REFERENCES tbventa(ventaId),
CONSTRAINT FK_dbo_tbventaDetalles_tbProducto_productoId FOREIGN KEY(productoId) REFERENCES tbProductos(productoId),
CONSTRAINT FK_dbo_tbventaDetalles_dbo_tbUsuarios_ventaDetalle_UsuarioCreacion_usuarioId FOREIGN KEY(ventaDetalle_UsuarioCreacion) REFERENCES tbUsuarios(usuarioId),
CONSTRAINT FK_dbo_tbventaDetalles_dbo_tbUsuarios_ventaDetalle_UsuarioModificacion_usuarioId FOREIGN KEY(ventaDetalle_UsuarioModificacion) REFERENCES tbUsuarios(usuarioId)

);


------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------



--Compra
CREATE TABLE tbCompras(
compraId                            INT IDENTITY(1,1),
proveedorId                         INT NOT NULL,
compraFecha							Datetime NOT NULL,
compraFechaCreacion					DATETIME NOT NULL,
compraUsuarioCreacion				INT NOT NULL,
compraFechaModificacion				DATETIME,
compraUsuarioModificacion			INT,
compraEstado						BIT NOT NULL,

CONSTRAINT PK_dbo_tbCompras_compraId PRIMARY KEY(compraId),
CONSTRAINT FK_dbo_tbCompras_tbProveedores_proveedorId FOREIGN KEY(proveedorId) REFERENCES tbProveedores(proveedorId),
CONSTRAINT FK_dbo_tbCompras_dbo_tbUsuarios_compraUsuarioCreacion_usuarioId FOREIGN KEY(compraUsuarioCreacion) REFERENCES tbUsuarios(usuarioId),
CONSTRAINT FK_dbo_tbCompras_dbo_tbUsuarios_compraUsuarioModificacion_usuarioId FOREIGN KEY(compraUsuarioModificacion) REFERENCES tbUsuarios(usuarioId)

);
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------

--CompraDetalles
CREATE TABLE tbCompraDetalles (
compraDetalleId                             INT IDENTITY(1,1),
compraId									INT NOT NULL,
productoId									INT NOT NULL,
compraDetallecatidad						INT NOT NULL,
compraDetallePrecio							DECIMAL (18,2) NOT NULL,
compraDetalleFechaCreacion					DATETIME NOT NULL,
compraDetalleUsuarioCreacion				INT NOT NULL,
compraDetalleFechaModificacion				DATETIME,
compraDetalleUsuarioModificacion			INT,
compraDetalleEstado							BIT NOT NULL,
CONSTRAINT PK_dbo_tbCompraDetalles_compraDetalleId PRIMARY KEY(compraDetalleId),
CONSTRAINT FK_dbo_tbCompraDetalles_tbCompras_compraId FOREIGN KEY(compraId) REFERENCES tbCompras(compraId),
CONSTRAINT FK_dbo_tbCompraDetalles_tbProducto_productoId FOREIGN KEY(productoId) REFERENCES tbProductos(productoId),
CONSTRAINT FK_dbo_tbCompraDetalles_dbo_tbUsuarios_compraDetalleUsuarioCreacion_usuarioId FOREIGN KEY(compraDetalleUsuarioCreacion) REFERENCES tbUsuarios(usuarioId),
CONSTRAINT FK_dbo_tbCompraDetalles_dbo_tbUsuarios_compraDetalleUsuarioModificacion_usuarioId FOREIGN KEY(compraDetalleUsuarioModificacion) REFERENCES tbUsuarios(usuarioId)

);


------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
go

CREATE TRIGGER trg_AumentarStockluegoBorrar
   ON  [dbo].[tbventaDetalles]
   AFTER Delete
as 
BEGIN
	

	DECLARE @NuevoStock int = (SELECT t1.productoStock from [tbProductos] as t1 WHERE t1.productoId = (SELECT t1.productoId from deleted as t1)) + (SELECT t1.ventaDetalle_catidad from deleted as t1 WHERE t1.productoId = (SELECT t1.productoId from deleted as t1))

UPDATE [dbo].[tbProductos]
   SET [productoStock] = @NuevoStock
 WHERE productoId = (SELECT t1.productoId from deleted as t1)


END
GO
go

-------------------------------------------------------------------------------------------



-------------------------------------------------------------------------------------------



go

CREATE TRIGGER trg_AumentarStock
   ON  [dbo].[tbCompraDetalles]
   AFTER INSERT
as 
BEGIN
	
DECLARE @NuevoStock int = (SELECT t1.productoStock from [tbProductos] as t1 WHERE t1.productoId = (SELECT t1.productoId from inserted as t1)) + (SELECT t1.compraDetallecatidad from inserted as t1 WHERE t1.productoId = (SELECT t1.productoId from inserted as t1))

UPDATE [dbo].[tbProductos]
   SET [productoStock] = @NuevoStock
 WHERE productoId = (SELECT t1.productoId from inserted as t1)

END
GO
go

-------------------------------------------------------------------------------------------

go

CREATE TRIGGER trg_DisminuirStock
   ON  [dbo].[tbventaDetalles]
   AFTER INSERT
as 
BEGIN
	

	DECLARE @NuevoStock int = (SELECT t1.productoStock from [tbProductos] as t1 WHERE t1.productoId = (SELECT t1.productoId from inserted as t1)) - (SELECT t1.ventaDetalle_catidad from inserted as t1 WHERE t1.productoId = (SELECT t1.productoId from inserted as t1))

UPDATE [dbo].[tbProductos]
   SET [productoStock] = @NuevoStock
 WHERE productoId = (SELECT t1.productoId from inserted as t1)


END
GO
go



-------------------------------------------------------------------------------------------

INSERT INTO [dbo].[tbUsuarios]
           ([usuarioUsuario]
           ,[usuarioContrasenia]
           ,[empleadoId]
           ,[usuarioUsuarioCreacion]
           ,[usuarioFechaCreacion]
           ,[usuarioUsuarioModificacion]
           ,[usuarioFechaModificacion]
           ,[usuarioEstado])
     VALUES
           ('admin',HasHBYTES('SHA2_512','123'),1,1,GETDATE(),null,null,1)
GO


INSERT INTO [dbo].[tbDepartamentos]
VALUES ('01', 'Atlantida', GETDATE(), 1,null,null,1),
	   ('02', 'Colon', GETDATE(), 1,null,null,1),
	   ('03', 'Comayagua', GETDATE(), 1,null,null,1),
	   ('04', 'Copan', GETDATE(), 1,null,null,1),
	   ('05', 'Cortes', GETDATE(), 1,null,null,1),
	   ('06', 'Choluteca', GETDATE(), 1,null,null,1),
	   ('07', 'El Paraiso', GETDATE(), 1,null,null,1),
	   ('08', 'Francisco Morazan', GETDATE(), 1,null,null,1),
	   ('09', 'Gracias a Dios', GETDATE(), 1,null,null,1),
	   ('10', 'Intibuca', GETDATE(), 1,null,null,1),
	   ('11', 'Islas de la Bahia', GETDATE(), 1,null,null,1),
	   ('12', 'La Paz', GETDATE(), 1,null,null,1),
	   ('13', 'Lempira', GETDATE(), 1,null,null,1),
	   ('14', 'Ocotepeque', GETDATE(), 1,null,null,1),
	   ('15', 'Olancho', GETDATE(), 1,null,null,1),
	   ('16', 'Santa Brbara', GETDATE(), 1,null,null,1),
	   ('17', 'Valle', GETDATE(), 1,null,null,1),
	   ('18', 'Yoro', GETDATE(), 1,null,null,1)

INSERT INTO [dbo].[tbMunicipios]([municipioId], [municipioNombre], [departamentoId], [municipioFechaCreacion],[municipioUsuarioCreacion],[municipioFechaModificacion], [municipioUsuarioModificacion],[municipioEstado])
VALUES ('0101', 'La Ceiba', '01', GETDATE(), 1,null,null,1),
	   ('0107', 'Tela', '01', GETDATE(), 1,null,null,1),
	   ('0301', 'Comayagua', '03', GETDATE(), 1,null,null,1),
	   ('0401', 'Santa Rosa de Copan', '04', GETDATE(), 1,null,null,1),
	   ('0501', 'San Pedro Sula', '05', GETDATE(), 1,null,null,1),
	   ('0502', 'Choloma', '05', GETDATE(), 1,null,null,1),
	   ('0511', 'Villanueva', '05', GETDATE(), 1,null,null,1),
	   ('0801', 'Distrito Central', '08', GETDATE(), 1,null,null,1),
	   ('0901', 'Puerto Lempira', '09', GETDATE(), 1,null,null,1),
	   ('1001', 'La Esperanza', '10', GETDATE(), 1,null,null,1),
	   ('1101', 'Roatan', '11', GETDATE(), 1,null,null,1)

	   INSERT INTO [dbo].[tbEstadosCiviles]
VALUES ('C', 'Casado(a)',  GETDATE(), 1, NULL, NULL, 1),
	   ('S', 'Soltero(a)',  GETDATE(), 1, NULL, NULL, 1),
	   ('D', 'Divorciado(a)',  GETDATE(), 1, NULL, NULL, 1),
	   ('V', 'Viudo(a)',  GETDATE(), 1, NULL, NULL, 1),
	   ('U', 'Union libre',  GETDATE(), 1, NULL, NULL, 1)


	   Insert INTO [dbo].[tbCargos]
	   Values('Jefe',GetDate(),1,null,null,1)

INSERT INTO [dbo].[tbEmpleados]
           ([empleadoNombre]
           ,[empleadoApellido]
           ,[empleadoSexo]
           ,[municipioId]
           ,[empleadoDireccionExacta]
           ,[estadoCivilId]
           ,[empleadoTelefono]
           ,[empleadoCorreoElectronico]
           ,[empleadoFechaNacimiento]
           ,[empleadoFechaContratacion]
           ,[cargoId]
           ,[empleadoFechaCreacion]
           ,[empleadoUsuarioCreacion]
           ,[empleadoFechaModificacion]
           ,[empleadoUsuarioModificacion]
           ,[empleadoEstado])
     VALUES
           ('Daniel','Espinoza' ,'M','0501' ,'Col. Municipal','S' ,'87756952' ,'daniele09099@gmail.com','02-04-2005' ,GetDate() ,1 ,GetDate() ,1 ,null ,null,1)
GO



ALTER TABLE [dbo].[tbUsuarios] 
ADD CONSTRAINT FK_dbo_tbUsuarios_dbo_tbUsuarios_usuarioUsuarioCreacion_usuarioId FOREIGN KEY([usuarioUsuarioCreacion]) REFERENCES tbUsuarios(usuarioId);

GO

ALTER TABLE [dbo].[tbUsuarios] 
ADD CONSTRAINT FK_dbo_tbUsuarios_dbo_tbUsuarios_usuarioUsuarioModificacion_usuarioId FOREIGN KEY([usuarioUsuarioModificacion]) REFERENCES tbUsuarios(usuarioId);

GO

ALTER TABLE [dbo].[tbUsuarios] 
ADD CONSTRAINT FK_dbo_tbUsuarios_dbo_tbEmpleados_empleadoId FOREIGN KEY([empleadoId]) REFERENCES tbEmpleados([empleadoId]);



INSERT INTO [dbo].[tbMetodoPago]
           ([metodoPagoId]
           ,[metodoPagoDescripcion]
           ,[metodoPagoFechaCreacion]
           ,[metodoPagoUsuarioCreacion]
           ,[metodoPagoFechaModificacion]
           ,[metodoPagoUsuarioModificacion]
           ,[metodoPagoEstado])
     VALUES
           ('E','Efectivo',GetDate(),1,null ,null,1),
           ('C','Tarjeta de Credito',GetDate(),1,null ,null,1),
           ('D','Tarjeta de Debito',GetDate(),1,null ,null,1)
GO

INSERT INTO [dbo].[tbProveedores]
           ([proveedorNombre]
           ,[municipioId]
           ,[proveedorDireccionExacta]
           ,[proveedorTelefono]
           ,[proveedorEmail]
           ,[proveedorFechaCreacion]
           ,[proveedorUsuarioCreacion]
           ,[proveedorFechaModificacion]
           ,[proveedorUsuarioModificacion]
           ,[proveedorEstado])
     VALUES
           ('Emsula','0501','Bulevar las torres','25002010','emsula@gmail.com',GetDate(),1,null,null ,1),
		   ('Ricasula','0501','Satelite','90002010','ricasula@gmail.com',GetDate(),1,null,null ,1),
		   ('lokilo','0501','Salida la lima','74550020','lokilo@gmail.com',GetDate(),1,null,null ,1),
		   ('Pollos Norteno','0501','15 calle','95660022','nortenios@gmail.com',GetDate(),1,null,null ,1),
		   ('Policarpio','0501','7 Calle','85556320','policarpio@gmail.com',GetDate(),1,null,null ,1)

GO


INSERT INTO [dbo].[tbClientes]
           ([clienteNombre]
           ,[clienteApellido]
           ,[municipioId]
           ,[clienteDireccionExacta]
           ,[clienteTelefono]
           ,[clienteCorreoElectronico]
           ,[clienteFechaCreacion]
           ,[clienteUsuarioCreacion]
           ,[clienteFechaModificacion]
           ,[clienteUsuarioModificacion]
           ,[clienteEstado])
     VALUES
			('Comprador Final','NA','0501','NA','NA','NA',getDate(),1,null,null,1),
           ('Daniel','Martinez','0501','C10 15','87756952','daniel.martinez@gmail.com',getDate(),1,null,null,1),
		   ('Christopher','Aguiar Garcia','0501','Col Satelite','95299620','chrisaguila@gmail.com',getDate(),1,null,null,1),
		   ('Mario','Hernandez','0501','Ciudad nueva','74552012','marioh@gmail.com',getDate(),1,null,null,1)
GO



INSERT INTO [dbo].[tbCategoria]
           ([categoriaDescripcion]
           ,[categoriaFechaCreacion]
           ,[categoriaUsuarioCreacion]
           ,[categoriaFechaModificacion]
           ,[categoriaUsuarioModificacion]
           ,[categoriaEstado])
     VALUES
           ('Carnes',GETDATE(),'1',null,null,1),
		   ('Vegetales',GETDATE(),'1',null,null,1),
		   ('Juguetes',GETDATE(),'1',null,null,1),
		   ('Lacteos',GETDATE(),'1',null,null,1),
		   ('Medicamentos',GETDATE(),'1',null,null,1),
		   ('Electronicos',GETDATE(),'1',null,null,1),
		   ('Domesticos',GETDATE(),'1',null,null,1)
GO




INSERT INTO [dbo].[tbProductos]
           ([productoNombre]
           ,[productoPrecio]
           ,[categoriaId]
           ,[proveedorId]
           ,[productoStock]
           ,[productoFechaCreacion]
           ,[productoUsuarioCreacion]
           ,[productoFechaModificacion]
           ,[productoUsuarioModificacion]
           ,[productoEstado])
     VALUES
           ('Pollo',38.5,1,4,0 ,GETDATE(),1,null,null,1),
		   ('Carne Molida',30.5,1,4,0 ,GETDATE(),1,null,null,1),
		   ('Chuleta',42.5,1,4,0 ,GETDATE(),1,null,null,1),
		   ('Papas',16.5,2,3,0 ,GETDATE(),1,null,null,1),
		   ('Repollo',7.5,2,3,0 ,GETDATE(),1,null,null,1),
		   ('Cebolla',20.5,2,3,0 ,GETDATE(),1,null,null,1),
		   ('Leche',30.5,4,1,0 ,GETDATE(),1,null,null,1),
		   ('Queso',45.5,4,1,0 ,GETDATE(),1,null,null,1),
		   ('Mantequilla',40.5,4,1,0 ,GETDATE(),1,null,null,1),
		   ('Acetaminofen',24,5,5,0 ,GETDATE(),1,null,null,1)
GO



INSERT INTO [dbo].[tbCompras]
           ([proveedorId]
           ,[compraFecha]
           ,[compraFechaCreacion]
           ,[compraUsuarioCreacion]
           ,[compraFechaModificacion]
           ,[compraUsuarioModificacion]
           ,[compraEstado])
     VALUES
           (4,GETDATE(),GETDATE(),1,null,null,1),
		   (3,GETDATE(),GETDATE(),1,null,null,1),
		   (1,GETDATE(),GETDATE(),1,null,null,1),
		   (5,GETDATE(),GETDATE(),1,null,null,1)
GO


INSERT INTO [dbo].[tbCompraDetalles]
           ([compraId],[productoId],[compraDetallecatidad],[compraDetallePrecio],[compraDetalleFechaCreacion],[compraDetalleUsuarioCreacion],[compraDetalleFechaModificacion],[compraDetalleUsuarioModificacion],[compraDetalleEstado])
     VALUES
           (1,1,20 ,35,GETDATE(),1,null ,null,1)
GO
INSERT INTO [dbo].[tbCompraDetalles]
           ([compraId],[productoId],[compraDetallecatidad],[compraDetallePrecio],[compraDetalleFechaCreacion],[compraDetalleUsuarioCreacion],[compraDetalleFechaModificacion],[compraDetalleUsuarioModificacion],[compraDetalleEstado])
     VALUES
		   (1,2,20 ,28,GETDATE(),1,null ,null,1)
GO
INSERT INTO [dbo].[tbCompraDetalles]
           ([compraId],[productoId],[compraDetallecatidad],[compraDetallePrecio],[compraDetalleFechaCreacion],[compraDetalleUsuarioCreacion],[compraDetalleFechaModificacion],[compraDetalleUsuarioModificacion],[compraDetalleEstado])
     VALUES
		   (1,3,20 ,40,GETDATE(),1,null ,null,1)
GO
INSERT INTO [dbo].[tbCompraDetalles]
           ([compraId],[productoId],[compraDetallecatidad],[compraDetallePrecio],[compraDetalleFechaCreacion],[compraDetalleUsuarioCreacion],[compraDetalleFechaModificacion],[compraDetalleUsuarioModificacion],[compraDetalleEstado])
     VALUES
		   (2,4,20 ,15,GETDATE(),1,null ,null,1)
GO
INSERT INTO [dbo].[tbCompraDetalles]
           ([compraId],[productoId],[compraDetallecatidad],[compraDetallePrecio],[compraDetalleFechaCreacion],[compraDetalleUsuarioCreacion],[compraDetalleFechaModificacion],[compraDetalleUsuarioModificacion],[compraDetalleEstado])
     VALUES
		   (2,5,20 ,5,GETDATE(),1,null ,null,1)
GO
INSERT INTO [dbo].[tbCompraDetalles]
           ([compraId],[productoId],[compraDetallecatidad],[compraDetallePrecio],[compraDetalleFechaCreacion],[compraDetalleUsuarioCreacion],[compraDetalleFechaModificacion],[compraDetalleUsuarioModificacion],[compraDetalleEstado])
     VALUES
		   (2,6,20 ,18,GETDATE(),1,null ,null,1)
GO
INSERT INTO [dbo].[tbCompraDetalles]
           ([compraId],[productoId],[compraDetallecatidad],[compraDetallePrecio],[compraDetalleFechaCreacion],[compraDetalleUsuarioCreacion],[compraDetalleFechaModificacion],[compraDetalleUsuarioModificacion],[compraDetalleEstado])
     VALUES
		   (3,7,20 ,28,GETDATE(),1,null ,null,1)
GO
INSERT INTO [dbo].[tbCompraDetalles]
           ([compraId],[productoId],[compraDetallecatidad],[compraDetallePrecio],[compraDetalleFechaCreacion],[compraDetalleUsuarioCreacion],[compraDetalleFechaModificacion],[compraDetalleUsuarioModificacion],[compraDetalleEstado])
     VALUES
		   (3,8,20 ,42,GETDATE(),1,null ,null,1)
GO
INSERT INTO [dbo].[tbCompraDetalles]
           ([compraId],[productoId],[compraDetallecatidad],[compraDetallePrecio],[compraDetalleFechaCreacion],[compraDetalleUsuarioCreacion],[compraDetalleFechaModificacion],[compraDetalleUsuarioModificacion],[compraDetalleEstado])
     VALUES
		   (3,9,20 ,38,GETDATE(),1,null ,null,1)
GO
INSERT INTO [dbo].[tbCompraDetalles]
           ([compraId],[productoId],[compraDetallecatidad],[compraDetallePrecio],[compraDetalleFechaCreacion],[compraDetalleUsuarioCreacion],[compraDetalleFechaModificacion],[compraDetalleUsuarioModificacion],[compraDetalleEstado])
     VALUES
		   (4,10,20 ,20,GETDATE(),1,null ,null,1)
GO

INSERT INTO [dbo].[tbventa]
           ([clienteId]
           ,[ventaFecha]
           ,[empleadoid]
           ,[metodoPagoId]
           ,[ventaFechaCreacion]
           ,[ventaUsuarioCreacion]
           ,[ventaFechaModificacion]
           ,[ventaUsuarioModificacion]
           ,[ventaEstado])
     VALUES
           (1,GETDATE() ,1,'E',GETDATE(),'1' ,null,null,1),
		   (2,GETDATE() ,1,'C',GETDATE(),'1' ,null,null,1),
		   (3,GETDATE() ,1,'D',GETDATE(),'1' ,null,null,1)

GO

INSERT INTO [dbo].[tbventaDetalles]
           ([ventaId],[productoId],[ventaDetalle_catidad],[ventaDetalle_Precio],[ventaDetalle_FechaCreacion],[ventaDetalle_UsuarioCreacion],[ventaDetalle_FechaModificacion],[ventaDetalle_UsuarioModificacion],[ventaDetalle_Estado])
     VALUES
           (1,7,2,(SELECT T1.productoPrecio from tbProductos T1 WHERE t1.productoId = 7),GETDATE(),1,null,null,1)

GO
INSERT INTO [dbo].[tbventaDetalles]
           ([ventaId],[productoId],[ventaDetalle_catidad],[ventaDetalle_Precio],[ventaDetalle_FechaCreacion],[ventaDetalle_UsuarioCreacion],[ventaDetalle_FechaModificacion],[ventaDetalle_UsuarioModificacion],[ventaDetalle_Estado])
     VALUES
		   (2,1,3,(SELECT T1.productoPrecio from tbProductos T1 WHERE t1.productoId = 1),GETDATE(),1,null,null,1)

GO
INSERT INTO [dbo].[tbventaDetalles]
           ([ventaId],[productoId],[ventaDetalle_catidad],[ventaDetalle_Precio],[ventaDetalle_FechaCreacion],[ventaDetalle_UsuarioCreacion],[ventaDetalle_FechaModificacion],[ventaDetalle_UsuarioModificacion],[ventaDetalle_Estado])
     VALUES
		   (2,2,4,(SELECT T1.productoPrecio from tbProductos T1 WHERE t1.productoId = 2),GETDATE(),1,null,null,1)

GO
INSERT INTO [dbo].[tbventaDetalles]
           ([ventaId],[productoId],[ventaDetalle_catidad],[ventaDetalle_Precio],[ventaDetalle_FechaCreacion],[ventaDetalle_UsuarioCreacion],[ventaDetalle_FechaModificacion],[ventaDetalle_UsuarioModificacion],[ventaDetalle_Estado])
     VALUES
		   (3,3,6,(SELECT T1.productoPrecio from tbProductos T1 WHERE t1.productoId = 3),GETDATE(),1,null,null,1)

GO
INSERT INTO [dbo].[tbventaDetalles]
           ([ventaId],[productoId],[ventaDetalle_catidad],[ventaDetalle_Precio],[ventaDetalle_FechaCreacion],[ventaDetalle_UsuarioCreacion],[ventaDetalle_FechaModificacion],[ventaDetalle_UsuarioModificacion],[ventaDetalle_Estado])
     VALUES
		   (3,4,8,(SELECT T1.productoPrecio from tbProductos T1 WHERE t1.productoId = 4),GETDATE(),1,null,null,1)

GO
INSERT INTO [dbo].[tbventaDetalles]
           ([ventaId],[productoId],[ventaDetalle_catidad],[ventaDetalle_Precio],[ventaDetalle_FechaCreacion],[ventaDetalle_UsuarioCreacion],[ventaDetalle_FechaModificacion],[ventaDetalle_UsuarioModificacion],[ventaDetalle_Estado])
     VALUES
		   (3,6,10,(SELECT T1.productoPrecio from tbProductos T1 WHERE t1.productoId = 6),GETDATE(),1,null,null,1)

GO

----------------------------------------------------------------------------------------------------------------
-----------------------------------------------------PROCEDIMIENTOS ALMACENADOS---------------------------------
----------------------------------------------------------------------------------------------------------------



-- Index prooveedores
create or alter procedure UDP_BuscarProveedores
@frase nvarchar(250)
as
begin


SELECT   proveedorId,
		 proveedorNombre, 
		 t1.municipioId, 
		 t2.municipioNombre + ', '+ t3.departamentoNombre as municipioNombre,
		 proveedorDireccionExacta, 
		 proveedorTelefono, 
		 proveedorEmail, 
		 proveedorFechaCreacion, 
		 proveedorUsuarioCreacion, 
		 proveedorFechaModificacion,
		  proveedorUsuarioModificacion, 
		  proveedorEstado     
FROM            tbProveedores t1 INNER JOIN  [dbo].[tbMunicipios]  t2
ON t1.municipioId = t2.municipioId INNER JOIN [dbo].[tbDepartamentos] t3 
ON t2.departamentoId = t3.departamentoId
WHERE  (( proveedorId LIKE '%'+@frase+'%')
or     (proveedorNombre LIKE '%'+@frase+'%')
or     (proveedorDireccionExacta LIKE '%'+@frase+'%')
or     ( proveedorTelefono LIKE '%'+@frase+'%')
or     ( proveedorEmail LIKE '%'+@frase+'%'))
AND t1.proveedorEstado = 1
end 
GO




--Procedimiento Editar Proveedor

create or alter procedure UDP_EditarProveedores
@id int,
@Nombre nvarchar(220),
@Municipio nvarchar(200),
@Direccion nvarchar(500),
@Telefono nvarchar(20),
@Email  nvarchar(150),
@UsuarioModificacion INT
as
begin


UPDATE tbProveedores
set proveedorNombre = @Nombre,
	proveedorDireccionExacta = @Direccion,
    proveedorTelefono= @Telefono, 
	proveedorEmail=@Email,
	proveedorFechaModificacion=  GETDATE(),
	proveedorUsuarioModificacion = @UsuarioModificacion
where proveedorId=@id
end

go
--Procedimiento Almacenado Eliminar Proveedor
create or alter procedure UDP_EliminarProveedores
@id int
as
begin

UPDATE tbProveedores
set proveedorEstado = 0
where proveedorId=@id

end
go


 --Insertar Proveedores


 
create or alter procedure UDP_InsertarProveedores
@Nombre nvarchar(220),
@Municipio nvarchar(200),
@Direccion nvarchar(500),
@Telefono nvarchar(20),
@Email  nvarchar(100),
@UsuarioCreacion INT
as
begin



INSERT INTO [dbo].[tbProveedores]
           ([proveedorNombre]
           ,[municipioId]
           ,[proveedorDireccionExacta]
           ,[proveedorTelefono]
           ,[proveedorEmail]
           ,[proveedorFechaCreacion]
           ,[proveedorUsuarioCreacion]
           ,[proveedorFechaModificacion]
           ,[proveedorUsuarioModificacion]
           ,[proveedorEstado])
     VALUES
           (@Nombre,@Municipio,@Direccion,@Telefono,@Email,GetDate(),1,null,null ,1)

end

GO


--Insertar Usuario
CREATE OR ALTER PROCEDURE UDP_InsertarUsuario
	@Usuario Nvarchar(150),
	@Contrasenia Nvarchar(max),
	@Empleado int,
	@usuarioCreacion int

as
BEGIN
DECLARE @Password nvarchar(max) = (HASHBYTES('SHA2_512', @Contrasenia))

IF NOT EXISTS (SELECT 1 FROM [dbo].[tbUsuarios] WHERE usuarioUsuario = @Usuario)
BEGIN
	INSERT INTO [dbo].[tbUsuarios]
		   ([usuarioUsuario]
		   ,[usuarioContrasenia]
		   ,[empleadoId]
		   ,[usuarioUsuarioCreacion]
		   ,[usuarioFechaCreacion]
		   ,[usuarioUsuarioModificacion]
		   ,[usuarioFechaModificacion]
		   ,[usuarioEstado])
	 VALUES
		   (@Usuario
		   ,@Password
		   ,@Empleado
		   ,@usuarioCreacion
		   ,GETDATE()
		   ,NULL
		   ,NULL
		   ,1)
END 
END
GO

--Index/Tabla Usuarios
CREATE PROCEDURE UDP_IndexUsuario

as
BEGIN

SELECT [usuarioId]
      ,[usuarioUsuario]
      ,[usuarioContrasenia]
      ,T1.[empleadoId]
	  ,t2.empleadoNombre + ' ' + t2.empleadoApellido as empleadoNombre 
      ,[usuarioUsuarioCreacion]
      ,[usuarioFechaCreacion]
      ,[usuarioUsuarioModificacion]
      ,[usuarioFechaModificacion]
      ,[usuarioEstado]
  FROM [tbUsuarios] T1 INNER JOIN [dbo].[tbEmpleados] T2
  ON T1.empleadoId = T2.empleadoId
  WHERE t1.usuarioEstado = 1

END
GO


--Editar Usuario 
CREATE OR ALTER PROCEDURE UDP_EdicionUsuario
    @usuarioId INT,
    @usuarioUsuario NVARCHAR(100)
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM tbUsuarios WHERE usuarioUsuario = @usuarioUsuario AND usuarioId <> @usuarioId)
    BEGIN
        UPDATE tbUsuarios
        SET usuarioUsuario = @usuarioUsuario
        WHERE usuarioId = @usuarioId
    END
END
GO



--borrar Usuario
CREATE OR ALTER PROCEDURE UDP_BorrarUsuario
	@IdEdicion INT
as
BEGIN

UPDATE [dbo].[tbUsuarios]
   SET [usuarioEstado] = 0
 WHERE usuarioId = @IdEdicion


END
GO


--Login
CREATE PROCEDURE UDP_Login
	@Usuario Nvarchar(100),
	@Contrasenia Nvarchar(Max)
as
BEGIN

Declare @Password Nvarchar(max) = (HasHBYTES('SHA2_512',@Contrasenia))

SELECT [usuarioId]
      ,[usuarioUsuario]
      ,[usuarioContrasenia]
      ,T1.[empleadoId]
	  ,t2.empleadoNombre + ' ' + t2.empleadoApellido as empleadoNombre 
      ,[usuarioUsuarioCreacion]
      ,[usuarioFechaCreacion]
      ,[usuarioUsuarioModificacion]
      ,[usuarioFechaModificacion]
      ,[usuarioEstado]
  FROM [tbUsuarios] T1 INNER JOIN [dbo].[tbEmpleados] T2
  ON T1.empleadoId = T2.empleadoId
  WHERE t1.usuarioContrasenia = @Password 
  AND t1.usuarioUsuario = @Usuario

END
GO

--index / buscar ventas

CREATE PROCEDURE UDP_Indexventas
as
BEGIN


SELECT [ventaId]
      ,t1.[clienteId]
	  , t2.clienteNombre + ' ' + t2.clienteApellido as nombreCliente
      ,[ventaFecha]
      ,t1.[empleadoid]
	  ,t3.empleadoNombre + ' ' + t3.empleadoApellido as nombreEmpleado
      ,t1.[metodoPagoId]
	  ,t4.metodoPagoDescripcion
      ,[ventaFechaCreacion]
      ,[ventaUsuarioCreacion]
      ,[ventaFechaModificacion]
      ,[ventaUsuarioModificacion]
      ,[ventaEstado]
  FROM [dbo].[tbventa] t1 INNER JOIN [dbo].[tbClientes] t2
  ON t2.clienteId = t1.clienteId INNER JOIN [dbo].[tbEmpleados] t3
  ON t3.empleadoId = t1.empleadoid INNER JOIN [dbo].[tbMetodoPago] t4
  ON t4.metodoPagoId = t1.metodoPagoId
  WHERE ventaEstado = 1


END
GO



--index / buscar ventaDetalles

CREATE OR ALTER PROCEDURE UDP_IndexventaDetalles
@ventaId int
as
BEGIN

SELECT [ventaDetalle_Id]
      ,t5.[ventaId]
	  ,t6.ventaFecha
	  ,t2.clienteId
	  ,t4.metodoPagoId
	  ,t2.clienteNombre + ' ' + t2.clienteApellido as nombreCliente
	  ,t3.empleadoNombre + ' ' + t3.empleadoApellido as nombreEmpleado
      ,t5.[productoId]
	  ,t7.productoNombre
	  ,t8.proveedorNombre
	  ,t4.metodoPagoDescripcion
      ,[ventaDetalle_catidad]
      ,[ventaDetalle_Precio]
	  ,t7.productoStock
	  ,[ventaDetalle_catidad] * [ventaDetalle_Precio] as CantidadPrecio
	  ,(SELECT SUM([ventaDetalle_catidad] * [ventaDetalle_Precio]) from [dbo].[tbventaDetalles] WHERE ventaDetalle_Estado = 1 AND ventaId = @ventaId) as Subtotal
	  ,(SELECT SUM(([ventaDetalle_catidad] * [ventaDetalle_Precio]) *0.15) from [dbo].[tbventaDetalles] WHERE ventaDetalle_Estado = 1 AND ventaId = @ventaId) as IVA
	  ,(SELECT SUM(([ventaDetalle_catidad] * [ventaDetalle_Precio]) + (([ventaDetalle_catidad] * [ventaDetalle_Precio]) *0.15)) from [dbo].[tbventaDetalles] WHERE ventaDetalle_Estado = 1 AND ventaId = @ventaId) as Total
      ,[ventaDetalle_FechaCreacion]
      ,[ventaDetalle_UsuarioCreacion]
      ,[ventaDetalle_FechaModificacion]
      ,[ventaDetalle_UsuarioModificacion]
      ,[ventaDetalle_Estado]
  FROM [dbo].[tbventaDetalles] t5 INNER JOIN [dbo].[tbventa] t6
  ON t5.ventaId = t6.ventaId INNER JOIN  [dbo].[tbClientes] t2
  ON t2.clienteId = t6.clienteId INNER JOIN [dbo].[tbEmpleados] t3
  ON t3.empleadoId = t6.empleadoid INNER JOIN [dbo].[tbMetodoPago] t4
  ON t4.metodoPagoId = t6.metodoPagoId INNER JOIN [dbo].[tbProductos] t7
  ON t7.productoId = t5.productoId INNER JOIN [dbo].[tbProveedores] t8
  ON t8.proveedorId = t7.proveedorId
  WHERE ventaDetalle_Estado = 1 AND t5.ventaId = @ventaId



END
GO

--Insertar venta
CREATE OR ALTER PROCEDURE UDP_Insertarventa
@ClienteId Nvarchar(100),
@MetodoPago Nvarchar(100),
@EmpleadoId Nvarchar(100),
@UsuarioCreacion Nvarchar(100)
as
BEGIN
INSERT INTO [dbo].[tbventa]
           ([clienteId]
           ,[ventaFecha]
           ,[empleadoid]
           ,[metodoPagoId]
           ,[ventaFechaCreacion]
           ,[ventaUsuarioCreacion]
           ,[ventaFechaModificacion]
           ,[ventaUsuarioModificacion]
           ,[ventaEstado])
     VALUES
           (@ClienteId
           ,GETDATE()
           ,@EmpleadoId
           ,@MetodoPago
           ,GETDATE()
           ,@UsuarioCreacion
           ,null
           ,null
           ,1)


END
GO

--Borrar venta
CREATE OR ALTER PROCEDURE UDP_Borrarventa
	@IdEdicion INT
as
BEGIN

UPDATE [dbo].[tbventa]
   SET ventaEstado = 0
 WHERE ventaId = @IdEdicion

UPDATE [dbo].[tbventaDetalles]
   SET [ventaDetalle_Estado] = 0
 WHERE ventaId = @IdEdicion


END
GO




--Insertar ventaDetalle
CREATE OR ALTER PROCEDURE UDP_InsertarventaDetalles
@ProductoId Nvarchar(100),
@Cantidad Nvarchar(100),
@UsuarioCreacion Nvarchar(100)
as
BEGIN

DECLARE @ventaMax INT = (SELECT MAX(ventaId) FROM tbventa)

Declare @Precio Nvarchar(100) = (SELECT productoPrecio From tbProductos WHERE productoEstado = 1 and productoId = @ProductoId)

INSERT INTO [dbo].[tbventaDetalles]
           ([ventaId]
           ,[productoId]
           ,[ventaDetalle_catidad]
           ,[ventaDetalle_Precio]
           ,[ventaDetalle_FechaCreacion]
           ,[ventaDetalle_UsuarioCreacion]
           ,[ventaDetalle_FechaModificacion]
           ,[ventaDetalle_UsuarioModificacion]
           ,[ventaDetalle_Estado])
     VALUES
           (@ventaMax
           ,@ProductoId
           ,@Cantidad
           ,@Precio
           ,GETDATE()
           ,@UsuarioCreacion
           ,null
           ,null
           ,1)




END
GO



--Cambiar Contraenia
CREATE PROCEDURE UDP_CambiarContrasenia
	@Usuario Nvarchar(200),
	@Contrasenia Nvarchar(max)
as
BEGIN

Declare @Password Nvarchar(max) = (HasHBYTES('SHA2_512',@Contrasenia))

UPDATE [dbo].[tbUsuarios]
   SET [usuarioContrasenia] = @Password
 WHERE usuarioUsuario = @Usuario


END
GO



--index / buscar Empleados

CREATE OR ALTER PROCEDURE UDP_IndexEmpleados
as
BEGIN


SELECT [empleadoId]
      ,[empleadoNombre]
      ,[empleadoApellido]
	  ,empleadoNombre +' '+ empleadoApellido as Nombre
      ,[empleadoSexo]
	  ,CasE
			WHEN empleadoSexo='M' THEN 'Masculino'
			WHEN empleadoSexo='F' THEN 'Femenino'
			ELSE 'Otro'
		END as Sexo
      ,t1.[municipioId]
	  ,t4.municipioNombre + ', ' + t5.departamentoNombre as Ciudad
      ,[empleadoDireccionExacta]
      ,t1.[estadoCivilId]
	  ,t2.estadoCivilNombre
      ,[empleadoTelefono]
      ,[empleadoCorreoElectronico]
      ,[empleadoFechaNacimiento]
	  ,DATEDIFF(YEAR, empleadoFechaNacimiento,GetDate()) as Edad
      ,[empleadoFechaContratacion]
      ,t1.[cargoId]
	  ,t3.cargoNombre
      ,[empleadoFechaCreacion]
      ,[empleadoUsuarioCreacion]
      ,[empleadoFechaModificacion]
      ,[empleadoUsuarioModificacion]
      ,[empleadoEstado]
  FROM [dbo].[tbEmpleados] T1 INNER JOIN [dbo].[tbEstadosCiviles] T2
  ON T1.estadoCivilId = T2.estadoCivilId Inner JOIN [dbo].[tbCargos] T3
  ON t3.cargoId = t1.cargoId INNER JOIN [dbo].[tbMunicipios] T4
  ON t4.municipioId = t1.municipioId INNER JOIN [dbo].[tbDepartamentos] T5
  ON t4.departamentoId = t5.departamentoId
  WHERE empleadoEstado = 1



END
GO

--Insertar Empleado

CREATE OR ALTER PROCEDURE UDP_InsertarEmpleados
	@Nombre Nvarchar(150),
	@Apellido Nvarchar(150),
	@Sexo char(1),
	@Municipio Nvarchar(10),
	@DireccionExacta Nvarchar(500),
	@EstadoCivil char(1),
	@Telefono Nvarchar(20),
	@Correo Nvarchar(100),
	@FechaNacimiento Nvarchar(100),
	@FechaContaratacion Nvarchar(100),
	@Cargo Nvarchar(20),
	@UsuarioCreacion int
as
BEGIN

INSERT INTO [dbo].[tbEmpleados]
           ([empleadoNombre]
           ,[empleadoApellido]
           ,[empleadoSexo]
           ,[municipioId]
           ,[empleadoDireccionExacta]
           ,[estadoCivilId]
           ,[empleadoTelefono]
           ,[empleadoCorreoElectronico]
           ,[empleadoFechaNacimiento]
           ,[empleadoFechaContratacion]
           ,[cargoId]
           ,[empleadoFechaCreacion]
           ,[empleadoUsuarioCreacion]
           ,[empleadoFechaModificacion]
           ,[empleadoUsuarioModificacion]
           ,[empleadoEstado])
     VALUES
           (@Nombre
           ,@Apellido
           ,@Sexo
           ,@Municipio
           ,@DireccionExacta
           ,@EstadoCivil
           ,@Telefono
           ,@Correo
           ,@FechaNacimiento
           ,@FechaContaratacion
           ,@Cargo
           ,GETDATE()
           ,@UsuarioCreacion
           ,null
           ,null
           ,1)



END
GO





--Insertar Empleado

CREATE OR ALTER PROCEDURE UDP_EditarEmpleados
	@Id INT,
	@Nombre Nvarchar(150),
	@Apellido Nvarchar(150),
	@Sexo char(1),
	@Municipio Nvarchar(10),
	@DireccionExacta Nvarchar(500),
	@EstadoCivil char(1),
	@Telefono Nvarchar(20),
	@Correo Nvarchar(100),
	@FechaNacimiento Nvarchar(100),
	@FechaContaratacion Nvarchar(100),
	@Cargo Nvarchar(20),
	@UsuarioModificacion int
as
BEGIN

UPDATE [dbo].[tbEmpleados]
   SET [empleadoNombre] = @Nombre
      ,[empleadoApellido] = @Apellido
      ,[empleadoSexo] = @Sexo
      ,[municipioId] = @Municipio
      ,[empleadoDireccionExacta] = @DireccionExacta
      ,[estadoCivilId] = @EstadoCivil
      ,[empleadoTelefono] = @Telefono
      ,[empleadoCorreoElectronico] = @Correo
      ,[empleadoFechaNacimiento] = @FechaNacimiento
      ,[empleadoFechaContratacion] = @FechaContaratacion
      ,[cargoId] = @Cargo
      ,[empleadoFechaModificacion] = GETDATE()
      ,[empleadoUsuarioModificacion] = @UsuarioModificacion
 WHERE empleadoId = @Id



END
GO



--Insertar Empleado

CREATE OR ALTER PROCEDURE UDP_EliminarEmpleados
	@Id INT
as
BEGIN

UPDATE [dbo].[tbEmpleados]
   SET empleadoEstado = 0
 WHERE empleadoId = @Id



END
GO






--Insertar Usuario
CREATE OR ALTER PROCEDURE UDP_InsertarCargos
	@Cargo Nvarchar(150),
	@usuarioCreacion int

as
BEGIN
INSERT INTO [dbo].[tbCargos]
           ([cargoNombre]
           ,[cargoFechaCreacion]
           ,[cargoUsuarioCreacion]
           ,[cargoFechaModificacion]
           ,[cargoUsuarioModificacion]
           ,[cargoEstado])
     VALUES
           (@Cargo
           ,GETDATE()
           ,@usuarioCreacion
           ,null
           ,null
           ,1)


END
GO

--Index/Tabla Usuarios
CREATE OR ALTER PROCEDURE UDP_IndexCargos

as
BEGIN

SELECT [cargoId]
      ,[cargoNombre]
      ,[cargoFechaCreacion]
      ,[cargoUsuarioCreacion]
      ,[cargoFechaModificacion]
      ,[cargoUsuarioModificacion]
      ,[cargoEstado]
  FROM [dbo].[tbCargos]
	WHERE cargoEstado = 1

END
GO


--Editar Usuario 
CREATE OR ALTER PROCEDURE UDP_EditarCargo
	@IdEdicion INT,
	@Cargo Nvarchar(200),
	@usuarioModificacion int
as
BEGIN

UPDATE [dbo].[tbCargos]
   SET [cargoNombre] = @Cargo
      ,[cargoFechaModificacion] = GETDATE()
      ,[cargoUsuarioModificacion] = @usuarioModificacion
 WHERE cargoId = @IdEdicion


END
GO


--borrar Usuario
CREATE OR ALTER PROCEDURE UDP_BorrarCargo
	@IdEdicion INT
as
BEGIN


UPDATE [dbo].[tbCargos]
   SET [cargoEstado] = 0
 WHERE cargoId = @IdEdicion


END
GO











--Insertar Usuario
CREATE OR ALTER PROCEDURE UDP_InsertarCategorias
	@Categoria Nvarchar(150),
	@usuarioCreacion int

as
BEGIN

INSERT INTO [dbo].[tbCategoria]
           ([categoriaDescripcion]
           ,[categoriaFechaCreacion]
           ,[categoriaUsuarioCreacion]
           ,[categoriaFechaModificacion]
           ,[categoriaUsuarioModificacion]
           ,[categoriaEstado])
     VALUES
           (@Categoria
           ,GETDATE()
           ,@usuarioCreacion
           ,null
           ,null
           ,1)


END
GO

--Index/Tabla Usuarios
CREATE OR ALTER PROCEDURE UDP_IndexCategorias

as
BEGIN

SELECT [categoriaId]
      ,[categoriaDescripcion]
      ,[categoriaFechaCreacion]
      ,[categoriaUsuarioCreacion]
      ,[categoriaFechaModificacion]
      ,[categoriaUsuarioModificacion]
      ,[categoriaEstado]
  FROM [dbo].[tbCategoria]
WHERE categoriaEstado = 1

END
GO


--Editar Usuario 
CREATE OR ALTER PROCEDURE UDP_EditarCategorias
	@IdEdicion INT,
	@Categoria Nvarchar(200),
	@usuarioModificacion int
as
BEGIN

UPDATE [dbo].[tbCategoria]
   SET [categoriaDescripcion] = @Categoria
      ,[categoriaFechaModificacion] = GETDATE()
      ,[categoriaUsuarioModificacion] = @usuarioModificacion
 WHERE categoriaId = @IdEdicion


END
GO


--borrar Usuario
CREATE OR ALTER PROCEDURE UDP_BorrarCaTegorias
	@IdEdicion INT
as
BEGIN


UPDATE [dbo].[tbCategoria]
   SET [categoriaEstado] = 0
 WHERE categoriaId = @IdEdicion


END
GO





--------------------------------------------------------------------


-- Index prooveedores
create or alter procedure UDP_BuscarProveedores
@frase nvarchar(250)
as
begin


SELECT   proveedorId,
		 proveedorNombre, 
		 t1.municipioId, 
		 t2.municipioNombre + ', '+ t3.departamentoNombre as municipioNombre,
		 proveedorDireccionExacta, 
		 proveedorTelefono, 
		 proveedorEmail, 
		 proveedorFechaCreacion, 
		 proveedorUsuarioCreacion, 
		 proveedorFechaModificacion,
		  proveedorUsuarioModificacion, 
		  proveedorEstado     
FROM            tbProveedores t1 INNER JOIN  [dbo].[tbMunicipios]  t2
ON t1.municipioId = t2.municipioId INNER JOIN [dbo].[tbDepartamentos] t3 
ON t2.departamentoId = t3.departamentoId
WHERE  (( proveedorId LIKE '%'+@frase+'%')
or     (proveedorNombre LIKE '%'+@frase+'%')
or     (proveedorDireccionExacta LIKE '%'+@frase+'%')
or     ( proveedorTelefono LIKE '%'+@frase+'%')
or     ( proveedorEmail LIKE '%'+@frase+'%'))
AND t1.proveedorEstado = 1
end 
GO




--Procedimiento Editar Proveedor

create or alter procedure UDP_EditarProveedores
@id int,
@Nombre nvarchar(220),
@Municipio nvarchar(200),
@Direccion nvarchar(500),
@Telefono nvarchar(20),
@Email  nvarchar(100),
@UsuarioModificacion INT
as
begin


UPDATE tbProveedores
set proveedorNombre = @Nombre,
    municipioId= @Municipio,
	proveedorDireccionExacta = @Direccion,
    proveedorTelefono= @Telefono,
	proveedorEmail=@Email,
	proveedorFechaModificacion=  GETDATE(),
	proveedorUsuarioModificacion = @UsuarioModificacion
where proveedorId=@id
end

go
--Procedimiento Eliminar Proveedor
create or alter procedure UDP_EliminarProveedores
@id int
as
begin

UPDATE tbProveedores
set proveedorEstado = 0
where proveedorId=@id

end
go


 --Insertar Proveedores

 
 
create or alter procedure UDP_InsertarProveedores
@Nombre nvarchar(220),
@Municipio nvarchar(200),
@Direccion nvarchar(500),
@Telefono nvarchar(20),
@Email  nvarchar(100),
@UsuarioCreacion INT
as
begin
INSERT INTO [dbo].[tbProveedores]
           ([proveedorNombre]
           ,[municipioId]
           ,[proveedorDireccionExacta]
           ,[proveedorTelefono]
           ,[proveedorEmail]
           ,[proveedorFechaCreacion]
           ,[proveedorUsuarioCreacion]
           ,[proveedorFechaModificacion]
           ,[proveedorUsuarioModificacion]
           ,[proveedorEstado])
     VALUES
           (@Nombre,@Municipio,@Direccion,@Telefono,@Email,GetDate(),1,null,null ,1)

end
go
--Procedimiento Index cliente
create or alter procedure UDP_LlenarCliente
as
begin
SELECT  clienteId
      ,clienteNombre
      ,clienteApellido
	  ,t1.municipioId
      ,t2.municipioNombre + ', '+ t3.departamentoNombre as municipioNombre
      ,clienteDireccionExacta
      ,clienteTelefono
      ,clienteCorreoElectronico
      ,clienteFechaCreacion
      ,clienteUsuarioCreacion
      ,clienteFechaModificacion
      ,clienteUsuarioModificacion
      ,clienteEstado
FROM tbClientes t1 INNER JOIN  [dbo].[tbMunicipios]  t2
ON t1.municipioId = t2.municipioId INNER JOIN [dbo].[tbDepartamentos] t3 
ON t2.departamentoId = t3.departamentoId
WHERE  t1.clienteEstado = 1
end 
go
--UDP_LlenarCliente

--Procedimiento Insertar clientes

create or alter procedure UDP_InsertarClientes
@Nombre nvarchar(220),
@Apellido nvarchar(220),
@Municipio nvarchar(200),
@Direccion nvarchar(500),
@Telefono nvarchar(20),
@Email  nvarchar(100),
@UsuarioCreacion INT
as
begin
INSERT INTO  tbClientes
       (
       clienteNombre
      ,clienteApellido
	  ,municipioId
      ,clienteDireccionExacta
      ,clienteTelefono
      ,clienteCorreoElectronico
      ,clienteFechaCreacion
      ,clienteUsuarioCreacion
      ,clienteFechaModificacion
      ,clienteUsuarioModificacion
      ,clienteEstado)
     VALUES
           (@Nombre,@Apellido,@Municipio,@Direccion,@Telefono,@Email,GetDate(),1,null,null ,1)
end
go

--Procedimiento Editar Clientes
create or alter procedure UDP_EditarClientes
@id int,
@Nombre nvarchar(220),
@Apellido nvarchar(220),
@Municipio nvarchar(200),
@Direccion nvarchar(500),
@Telefono nvarchar(20),
@Email  nvarchar(100),
@UsuarioModificacion INT
as
begin


UPDATE tbClientes
set clienteNombre = @Nombre,
    clienteApellido = @Apellido,
    municipioId= @Municipio,
	clienteDireccionExacta = @Direccion,
    clienteTelefono= @Telefono,
	clienteCorreoElectronico=@Email,
	clienteFechaModificacion=  GETDATE(),
	clienteUsuarioModificacion = @UsuarioModificacion
where clienteId=@id
end
go

--Procedimiento Eliminar Clientes
create or alter procedure UDP_EliminarClientes
@id int
as
begin

UPDATE tbClientes
set clienteEstado = 0
where clienteId=@id

end
go


--Procedimiento Index Producto
create or alter procedure UDP_LlenarProductos
as
begin    
SELECT productoId
      ,productoNombre
	  ,productoPrecio
      ,t1.categoriaId
	  ,t3.categoriaDescripcion
	  ,t1.proveedorId
	  ,t2.proveedorNombre 
      ,productoStock
      ,productoFechaCreacion
      ,productoUsuarioCreacion
      ,productoFechaModificacion
      ,productoUsuarioModificacion
	  ,productoEstado 
FROM tbProductos t1 INNER JOIN tbProveedores t2
on t1.proveedorId = t2.proveedorId INNER JOIN tbCategoria t3
on t1.categoriaId = t3.categoriaId
WHERE  t1. productoEstado  = 1
end 
go
--Procedimiento Borrar Producto

create or alter procedure UDP_EliminarProducto
@id int
as
begin

UPDATE tbProductos
set productoEstado = 0
where productoId=@id

end
go


--Prsocedimiento Insertar Producto
create or alter procedure UDP_InsertarProductos
@Nombre nvarchar(220),
@Precio decimal,
@categoria int,
@Proveedor int,
@Stock int,
@UsuarioCreacion int
as
begin
INSERT INTO [dbo].[tbProductos]
          ( 
		   productoNombre, 
		   productoPrecio, 
		   categoriaId, 
		   proveedorId, 
		   productoStock,
		   productoFechaCreacion, 
		   productoUsuarioCreacion, 
		   productoFechaModificacion, 
		   productoUsuarioModificacion, 
		   productoEstado)
     VALUES
           (@Nombre,@Precio,@categoria,@Proveedor,@Stock,GetDate(),@UsuarioCreacion,null,null ,1)

end

go

--Procedimiento Editar Producto
create or alter procedure UDP_EditarProducto
@id int,
@Nombre nvarchar(220),
@Precio decimal,
@categoria int,
@Proveedor int,
@Stock int,
@UsuarioModificacion int
as
begin
UPDATE tbProductos
set  [productoNombre]= @Nombre,
   [productoPrecio] =@Precio,
   [categoriaId] = @categoria,
	[proveedorId] = @Proveedor ,
    [productoStock]= @Stock,
	[productoFechaModificacion]=  GETDATE(),
	[productoUsuarioModificacion] = @UsuarioModificacion
where [productoId]=@id
end

GO


--UDP COMPRAS INDEX
CREATE PROCEDURE UDP_ComprasIndex 
AS
BEGIN
SELECT compraId,
 proveedorId,
  compraFecha,
   compraFechaCreacion,
    compraUsuarioCreacion,
	 compraFechaModificacion,
	  compraUsuarioModificacion,
	   compraEstado
FROM tbCompras
END

GO


--UDP Compra Insert
CREATE PROCEDURE UDP_ComprasInsert
@proveedorId INT,
@compraUsuarioCreacion INT
AS
BEGIN 
INSERT INTO tbCompras
VALUES(@proveedorId,GETDATE(),GETDATE(),@compraUsuarioCreacion,NULL,NULL,1)
END

GO
	
--UDP SelectMaxIDVenta
CREATE OR ALTER PROCEDURE UDP_SelectIdVentaMax
AS
BEGIN
SELECT MAX(ventaID) AS clientemax FROM tbventa
WHERE ventaEstado = 1
END

GO

--UDP Index Municipio x departamentoId
CREATE PROCEDURE UDP_SelectMunicipiosByDepartamentoId
@departamentoId VARCHAR(2)
AS
BEGIN 
SELECT municipioId FROM tbMunicipios WHERE departamentoId = @departamentoId
END

GO

--UDP Index Productos
CREATE OR ALTER PROCEDURE UDP_SelectProductos
AS
BEGIN
SELECT productoId,
productoNombre
FROM tbProductos WHERE productoEstado = 1
END

GO
--UDP Eliminar Venta
CREATE OR ALTER PROCEDURE UDP_EliminarVenta
@ventaId INT 
AS
BEGIN
UPDATE tbventa
SET ventaEstado = 0
WHERE ventaId = @ventaId
END

GO

--Mostra los municipios
CREATE OR ALTER PROCEDURE UDP_CargarMunicipios 
@departamentoId NVARCHAR(10)
AS
BEGIN
SELECT [municipioId],[municipioNombre]
FROM tbMunicipios
where [departamentoId] = @departamentoId
END 

GO

--UDP Para mostrar los detalle del producto agregado 
CREATE OR ALTER PROCEDURE UDP_DetalleEnTabla
@ventaId INT
AS
BEGIN
SELECT t1.ventaDetalle_Id,t2.productoNombre,t1.ventaDetalle_Precio,t1.ventaDetalle_catidad 
FROM tbventaDetalles t1, tbProductos t2
WHERE t1.productoId = t2.productoId AND t1.ventaId = @ventaId
END 

SELECT * FROM tbProductos
SELECT * FROM tbventaDetalles

GO

--UDP_EliminarVentaDetalle
CREATE OR ALTER PROCEDURE UDP_EliminarVentaDetalle
@ventaDetalle_Id INT 
AS
BEGIN
DELETE tbventaDetalles
WHERE ventaDetalle_Id = @ventaDetalle_Id
END

GO

--Insertar CompraDetalle
CREATE PROCEDURE UDP_InsertarCompraDetalles
@productoId NVARCHAR(100),
@compraDetallecantidad NVARCHAR(100),
@compraDetalleUsuarioCreacion NVARCHAR(100)
AS 
BEGIN
DECLARE @compraMax INT = (SELECT MAX(compraId) FROM tbCompras);
Declare @Precio Nvarchar(100) = (SELECT productoPrecio From tbProductos WHERE productoEstado = 1 and productoId = @productoId)
INSERT INTO tbCompraDetalles 
VALUES(@compraMax,@productoId,@compraDetallecantidad,@Precio,GETDATE(),@compraDetalleUsuarioCreacion,NULL,NULL,1)
END

GO
--UDP DETALLE EN TABLA COMPRA
CREATE OR ALTER PROCEDURE UDP_DetalleEnTablaCompra
AS
BEGIN
DECLARE @compraMax NVARCHAR(100) = (SELECT MAX(compraId) FROM tbCompras)
SELECT t1.compraDetalleId,t2.productoNombre,t1.compraDetallePrecio,t1.compraDetallecatidad 
FROM tbCompraDetalles t1, tbProductos t2
WHERE t1.productoId = t2.productoId AND t1.compraId = @compraMax
END 

GO

--UDP DETALLE EN TABLA COMPRA
CREATE OR ALTER PROCEDURE UDP_DetalleEnTablaCompraxId
@compraId INT 
AS
BEGIN
SELECT t1.compraDetalleId,t2.productoNombre,t1.compraDetallePrecio,t1.compraDetallecatidad 
FROM tbCompraDetalles t1, tbProductos t2
WHERE t1.productoId = t2.productoId AND t1.compraId = @compraId
END 

GO

--UDP_EliminarVentaDetalle
CREATE OR ALTER PROCEDURE UDP_EliminarCompraDetalle
@compraDetalleId INT 
AS
BEGIN
DELETE tbCompraDetalles
WHERE compraDetalleId = @compraDetalleId
END
	
	
GO

--Select Usuario 
CREATE PROCEDURE UDP_SelectUsuario
@usuarioUsuario NVARCHAR(100)
AS
BEGIN
SELECT usuarioUsuario FROM tbUsuarios WHERE usuarioUsuario = @usuarioUsuario
END

GO

----------------Insertar Municipios----------------
CREATE OR ALTER PROCEDURE UDP_InsertarMunicipios
	@Municipio			NVARCHAR(75),
	@Departamento		NVARCHAR(100),
	@UsuarioCreacion	INT
AS
BEGIN
INSERT INTO [dbo].[tbMunicipios]
           ([departamentoId]
           ,[municipioNombre]
           ,[municipioFechaCreacion]
           ,[municipioUsuarioCreacion]
           ,[municipioFechaModificacion]
           ,[municipioUsuarioModificacion]
           ,[municipioEstado])
     VALUES
           (@Departamento,
			@Municipio,
			GETDATE(),
            @UsuarioCreacion,
			NULL,
            NULL,
            1)
END
GO
----------------Editar Municipios----------------
CREATE OR ALTER PROCEDURE UDP_EditarMunicipios
	@IdEdidcion NVARCHAR(100),
	@Municipio NVARCHAR(75),
	@UsuarioModificacion INT
AS
BEGIN

UPDATE [dbo].[tbMunicipios]
   SET [municipioNombre] = @Municipio,
       [municipioFechaModificacion] = GETDATE(),
       [municipioUsuarioModificacion] = @UsuarioModificacion
 WHERE [municipioId] = @IdEdidcion

END
GO
----------------Eliminar Municipios----------------
CREATE OR ALTER PROCEDURE UDP_EliminarMunicipios
	@IdEdicion INT
AS
BEGIN
	UPDATE [dbo].[tbMunicipios]
	SET [municipioEstado] = 0
	WHERE [municipioId] = @IdEdicion
END
GO

----------------Listar Municipios----------------
CREATE PROCEDURE UDP_IndexMunicipios
AS
BEGIN
SELECT [municipioId]
      ,[departamentoId]
      ,[municipioNombre]
      ,[municipioFechaCreacion]
      ,[municipioUsuarioCreacion]
      ,[municipioFechaModificacion]
      ,[municipioUsuarioModificacion]
      ,[municipioEstado]
  FROM [dbo].[tbMunicipios]
  WHERE [municipioEstado] = 1

END
GO
-------------------------------------------------------------------


----------------Insertar Departamentos----------------
CREATE OR ALTER PROCEDURE UDP_InsertarDepartamentos
	@DepartamentoId     NVARCHAR(4),
	@Departamento		NVARCHAR(75),
	@UsuarioCreacion	INT
AS
BEGIN

INSERT INTO [dbo].[tbDepartamentos]
           (departamentoId,
		   [departamentoNombre]
           ,[departamentoFechaCreacion]
           ,[departamentoUsuarioCreacion]
           ,[departamentoFechaModificacion]
           ,[departamentoUsuarioModificacion]
           ,[departamentoEstado])
     VALUES
           (@DepartamentoId,
		   @Departamento,
           GETDATE(),
           @UsuarioCreacion,
           NULL,
           NULL,
           1)
END
GO
----------------Editar Departamentos----------------
CREATE OR ALTER PROCEDURE UDP_EditarDepartamentos
	@IdEdidcion INT,
	@Departamento NVARCHAR(75),
	@UsuarioModificacion INT
AS
BEGIN

UPDATE [dbo].[tbDepartamentos]
   SET [departamentoNombre] = @Departamento,
       [departamentoFechaModificacion] = GETDATE(),
       [departamentoUsuarioModificacion] = @UsuarioModificacion
 WHERE [departamentoId] = @IdEdidcion

END
GO

----------------Eliminar Departamentos----------------
CREATE OR ALTER PROCEDURE UDP_EliminarDepartamentos
	@IdEdicion INT
AS
BEGIN
	UPDATE [dbo].[tbDepartamentos]
	SET [departamentoEstado] = 0
	WHERE [departamentoId] = @IdEdicion
END
GO

----------------Listar Departamentos----------------
CREATE OR ALTER PROCEDURE UDP_IndexDepartamentos 

AS
BEGIN

SELECT [departamentoId]
      ,[departamentoNombre]
      ,[departamentoFechaCreacion]
      ,[departamentoUsuarioCreacion]
      ,[departamentoFechaModificacion]
      ,[departamentoUsuarioModificacion]
      ,[departamentoEstado]
  FROM [dbo].[tbDepartamentos]
  WHERE [departamentoEstado] = 1
	
END
GO

----------------Listar Municipios----------------
CREATE OR ALTER PROCEDURE UDP_IndexMunicipios
AS
BEGIN
SELECT [municipioId]
      ,[departamentoId]
      ,[municipioNombre]
      ,[municipioFechaCreacion]
      ,[municipioUsuarioCreacion]
      ,[municipioFechaModificacion]
      ,[municipioUsuarioModificacion]
      ,[municipioEstado]
  FROM [dbo].[tbMunicipios]
  WHERE [municipioEstado] = 1

END
GO

--Procedimiento Insertar Categoria
CREATE OR ALTER PROCEDURE UDP_InsertaCategorias
@categoriaDescripcion nvarchar (200),
@categoriaUsuarioCreacion int
AS
BEGIN 
INSERT INTO [dbo].[tbCategoria]
VALUES(@categoriaDescripcion,GETDATE(),@categoriaUsuarioCreacion,NULL,NULL,1)
END

GO
--Procedimiento Index Categoria

CREATE OR ALTER PROCEDURE UDP_ComprasIndex 
AS
BEGIN
SELECT compraId,
 proveedorId,
  compraFecha,
   compraFechaCreacion,
    compraUsuarioCreacion,
	 compraFechaModificacion,
	  compraUsuarioModificacion,
	   compraEstado
FROM tbCompras
END

GO
--Mostra los municipios
CREATE OR ALTER PROCEDURE UDP_CargarMunicipios 
@departamentoId NVARCHAR(10)
AS
BEGIN
SELECT [municipioId],[municipioNombre]
FROM tbMunicipios
where [departamentoId] = @departamentoId
END

--Procedimiento Almacenado de index Proveedores
GO

create or alter procedure UDP_BuscarProveedores
as
begin
SELECT   proveedorId,
		 proveedorNombre, 
		 t1.municipioId, 
		 t2.municipioNombre + ', '+ t3.departamentoNombre as municipioNombre,
		 proveedorDireccionExacta, 
		 proveedorTelefono, 
		 proveedorEmail, 
		 proveedorFechaCreacion, 
		 proveedorUsuarioCreacion, 
		 proveedorFechaModificacion,
		  proveedorUsuarioModificacion, 
		  proveedorEstado     
FROM            tbProveedores t1 INNER JOIN  [dbo].[tbMunicipios]  t2
ON t1.municipioId = t2.municipioId INNER JOIN [dbo].[tbDepartamentos] t3 
ON t2.departamentoId = t3.departamentoId
WHERE  t1.proveedorEstado = 1
end 
GO

--Procedimiento almacenado de borrar Proveedores

create or alter procedure UDP_EliminarProveedores
@id int
as
begin

UPDATE tbProveedores
set proveedorEstado = 0
where proveedorId=@id

end
go

--Procedimiento Eliminar Clientes
create or alter procedure UDP_EliminarClientes
@id int
as
begin

UPDATE tbClientes
set clienteEstado = 0
where clienteId=@id

end

GO

--Seleccionar Cargo x Id
CREATE OR ALTER PROCEDURE UDP_SelectCargoxId
@cargoId INT
AS
BEGIN
SELECT cargoId,cargoNombre FROM tbCargos WHERE cargoId = @cargoId
END

GO

--Select Empleados
CREATE PROCEDURE UDP_DDLEmpleados
AS
BEGIN
SELECT * FROM tbEmpleados
END 

GO

--UDP_CargarUsuarios
CREATE PROCEDURE UDP_CargarUsuarios
@UsuarioId INT
AS
BEGIN
SELECT * FROM tbUsuarios WHERE usuarioId = @UsuarioId
END


GO 

--UDP_SelectMunicipioxId
CREATE OR ALTER PROCEDURE UDP_SelectMunicipioxId
@municipioId NVARCHAR(100)
AS
BEGIN
SELECT * FROM tbMunicipios WHERE municipioId = @municipioId
END

GO

--UDP_LoginParaEmpleadoId
CREATE PROCEDURE UDP_LoginParaEmpleadoId
	@Usuario Nvarchar(100),
	@Contrasenia Nvarchar(Max)
AS
BEGIN

Declare @Password Nvarchar(max) = (HasHBYTES('SHA2_512',@Contrasenia))
SELECT t1.empleadoId
  FROM [tbUsuarios] T1 INNER JOIN [dbo].[tbEmpleados] T2
  ON T1.empleadoId = T2.empleadoId
  WHERE t1.usuarioContrasenia = @Password 
  AND t1.usuarioUsuario = @Usuario

END
GO

--DDl Municipios 
CREATE PROCEDURE UDP_DDLMunicipios
AS 
BEGIN
SELECT * FROM tbMunicipios
END

GO
--UDP_MUNICIPIOxMunicipioId
CREATE PROCEDURE UDP_MUNICIPIOxMunicipioId
@municipioId NVARCHAR(100)
AS
BEGIN
SELECT * FROM tbMunicipios WHERE municipioId = @municipioId
END

GO

--UDP_CargarCategoria
CREATE OR ALTER PROCEDURE UDP_CargarCategoria
@categoriaId INT 
AS
BEGIN 
SELECT * FROM tbCategoria WHERE categoriaId = @categoriaId
END