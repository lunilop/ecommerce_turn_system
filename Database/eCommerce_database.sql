CREATE DATABASE	eCommerce
ON (NAME='eCommerce.dat', FILENAME = 'C:\Proyectos\eCommerce.mdf')
GO

USE eCommerce
GO

CREATE TABLE Provincias
(
	CodProvincias_P char (10) NOT NULL,
	Nombre_P varchar (100) NOT NULL,

	Constraint PK_Provincias PRIMARY KEY (CodProvincias_P)
)
GO


CREATE TABLE Localidades
(
	CodProvincias_L char (10) NOT NULL,
	CodLocalidades_L char (10) NOT NULL,
	Nombre_L varchar (100) NOT NULL,

	Constraint PK_Localidades PRIMARY KEY (CodProvincias_L, CodLocalidades_L),
	Constraint FK_Localidades_Provincias FOREIGN KEY (CodProvincias_L) REFERENCES Provincias(CodProvincias_P) 
)
GO

CREATE TABLE Rubros
(
	CodRubros_R char (10) NOT NULL,
	Descripcion_R varchar (100) NOT NULL,

	Constraint PK_Rubros PRIMARY KEY (CodRubros_R)
)
GO

CREATE TABLE TipoUsuario
(
	CodTipoUsuario_TU char (10) NOT NULL,
	Descripcion_TU varchar (100) NOT NULL,

	Constraint PK_TipoUsuario PRIMARY KEY (CodTipoUsuario_TU)
)
GO


CREATE TABLE Usuarios
(
	CodUsuarios_U char (10) NOT NULL, 
	CodRubros_U char (10) NOT NULL,
	Nombre_U varchar (100) NOT NULL,
	Apellido_U varchar (100) NOT NULL,
	DNI_U varchar (8) NOT NULL,
	Genero_U varchar (30) NOT NULL,
	Telefono_U varchar (20) NOT NULL,
	Email_U varchar (30) NOT NULL,
	Direccion_U varchar (100) NOT NULL,
	Nacionalidad_U varchar (100) NOT NULL,
	CodLocalidades_U char (10) NOT NULL,
	CodProvincias_U char (10) NOT NULL,
	Clave_U varchar (50) NOT NULL,
	CodTipoUsuario_U char (10) NOT NULL,
	Estado_U bit NOT NULL,

	Constraint PK_Usuarios PRIMARY KEY (CodUsuarios_U),
	Constraint FK_Usuarios_TipoUsuario FOREIGN KEY (CodTipoUsuario_U) REFERENCES TipoUsuario(CodTipoUsuario_TU),
	Constraint FK_Usuarios_Rubros FOREIGN KEY (CodRubros_U) REFERENCES Rubros(CodRubros_R),
	Constraint UK_Usuarios_DNI UNIQUE (DNI_U),
	Constraint FK_Usuarios_Localidades FOREIGN KEY (CodProvincias_U, CodLocalidades_U) REFERENCES Localidades(CodProvincias_L, CodLocalidades_L)
)
GO


CREATE TABLE Clientes
(
	CodEmpresas_C char (10) NOT NULL,
	NombreEmpresa_C varchar (100) NOT NULL,
	RazonSocial_C varchar (50) NOT NULL,
	Telefono_C varchar (20) NOT NULL,
	Email_C varchar (100) NOT NULL,
	Direccion_C varchar (100) NOT NULL,
	CodLocalidades_C char (10) NOT NULL,
	CodProvincias_C char (10) NOT NULL,
	Estado_C bit NOT NULL,

	Constraint PK_Clientes PRIMARY KEY (CodEmpresas_C),
	Constraint UK_Clientes_RazonSocial UNIQUE (RazonSocial_C),
	Constraint FK_Clientes_Localidades FOREIGN KEY (CodProvincias_C, CodLocalidades_C) REFERENCES Localidades(CodProvincias_L, CodLocalidades_L) 
)
GO

CREATE TABLE Horarios 
(
    CodHorarios_H char (10) NOT NULL,
	Descripcion_H varchar (100) NOT NULL,

	Constraint PK_Horarios PRIMARY KEY (CodHorarios_H)
)
GO

CREATE TABLE Dias 
(
    CodDias_D char (10) NOT NULL,
    NombreDia_D varchar (100) NOT NULL,

	Constraint PK_Dias PRIMARY KEY (CodDias_D)
)
GO


CREATE TABLE DiasXHorarios 
(
    CodDias_DXH char (10) NOT NULL,
    CodHorarios_DXH char (10) NOT NULL,

    Constraint PK_DiasXHorarios PRIMARY KEY (CodDias_DXH, CodHorarios_DXH),
    Constraint FK_DiasXHorarios_Dias FOREIGN KEY (CodDias_DXH) REFERENCES Dias(CodDias_D),
	Constraint FK_DiasXHorarios_Horarios FOREIGN KEY (CodHorarios_DXH) REFERENCES Horarios(CodHorarios_H) 
)
GO

CREATE TABLE UsuariosXDiasXHorarios
(
    CodUsuarios_UXDXH char (10) NOT NULL,
    CodDias_UXDXH char (10) NOT NULL,
    CodHorarios_UXDXH char (10) NOT NULL,
	Estado_UXDXH bit DEFAULT 1 NOT NULL,

	Constraint PK_UsuariosXDiasXHorarios PRIMARY KEY (CodUsuarios_UXDXH, CodDias_UXDXH, CodHorarios_UXDXH),
	Constraint FK_UsuariosXDiasXHorarios_Usuarios FOREIGN KEY (CodUsuarios_UXDXH) REFERENCES Usuarios(CodUsuarios_U),
	Constraint FK_UsuariosXDiasXHorarios_DiasXHorarios FOREIGN KEY (CodDias_UXDXH, CodHorarios_UXDXH) REFERENCES DiasXHorarios(CodDias_DXH, CodHorarios_DXH)
)
GO

CREATE TABLE Estados
(
	CodEstados_E char (10) NOT NULL,
	Descripcion_E varchar (100) NULL,

	Constraint PK_Estados PRIMARY KEY (CodEstados_E)
)
GO

CREATE TABLE Turnos
(
	CodTurnos_T char (10) NOT NULL,
	CodEmpresas_T char (10) NOT NULL,
	CodRubros_T char (10) NOT NULL,
	CodUsuarios_T char (10) NOT NULL,
	CodDias_T char (10) NOT NULL,
	CodHorarios_T char (10) NOT NULL,
	CodFechas_T datetime NOT NULL,
	CodEstados_T char (10) NOT NULL,
	Observaciones_T varchar (100) NULL,
	Estado_T bit NOT NULL,
	
	Constraint PK_Turnos PRIMARY KEY (CodTurnos_T),
	Constraint FK_Turnos_Rubros FOREIGN KEY (CodRubros_T) REFERENCES Rubros(CodRubros_R),
	Constraint FK_Turnos_UsuariosXDiasXHorarios FOREIGN KEY (CodUsuarios_T, CodDias_T, CodHorarios_T) REFERENCES UsuariosXDiasXHorarios(CodUsuarios_UXDXH, CodDias_UXDXH, CodHorarios_UXDXH),
	Constraint FK_Turnos_Estados FOREIGN KEY (CodEstados_T) REFERENCES Estados(CodEstados_E)
)
GO


INSERT INTO Provincias (CodProvincias_P, Nombre_P) 
SELECT 'PROV001', 'Buenos Aires' UNION
SELECT 'PROV002', 'Córdoba' UNION
SELECT 'PROV003', 'Mendoza' UNION
SELECT 'PROV004', 'Santa Fe' UNION
SELECT 'PROV005', 'Tucumán';
GO

INSERT INTO Localidades(CodProvincias_L, CodLocalidades_L, Nombre_L)
SELECT 'PROV001', 'L001', 'La Plata' UNION
SELECT 'PROV001', 'L002', 'CABA' UNION
SELECT 'PROV001', 'L003','Bahía Blanca' UNION
SELECT 'PROV002', 'L004', 'Córdoba' UNION
SELECT 'PROV002', 'L005', 'Villa Carlos Paz' UNION
SELECT 'PROV002', 'L006', 'Río Cuarto' UNION
SELECT 'PROV003', 'L007', 'Mendoza' UNION
SELECT 'PROV003', 'L008', 'San Rafael' UNION
SELECT 'PROV003', 'L009', 'Godoy Cruz' UNION
SELECT 'PROV004', 'L010', 'Santa Fe' UNION
SELECT 'PROV004', 'L011', 'Rosario' UNION
SELECT 'PROV004', 'L012', 'Rafaela' UNION
SELECT 'PROV005', 'L013', 'San Miguel' UNION
SELECT 'PROV005', 'L014', 'Tafí del Valle' UNION
SELECT 'PROV005', 'L015', 'Yerba Buena';
GO

INSERT INTO TipoUsuario(CodTipoUsuario_TU, Descripcion_TU)
SELECT '1', 'Gerente' UNION
SELECT '2', 'Empleado'; 
GO

INSERT INTO Rubros(CodRubros_R, Descripcion_R)
SELECT 'R001', 'Webmastering' UNION
SELECT 'R002', 'Diseño' UNION
SELECT 'R003', 'Marketing' UNION
SELECT 'R004', 'Ventas'  UNION
SELECT 'R005', 'Desarrollador';  
GO

INSERT INTO Usuarios(CodUsuarios_U, CodRubros_U, Nombre_U, Apellido_U, DNI_U, Genero_U, Telefono_U, Email_U, Direccion_U, Nacionalidad_U, CodLocalidades_U, CodProvincias_U, Clave_U, CodTipoUsuario_U, Estado_U)
SELECT 'U001', 'R001', 'Nicolas', 'Volponi', '46013055', 'Masculino', '1165452210', 'Nvolponi@gmail.com', '25 de mayo 1934', 'Argentino', 'L001', 'PROV001', '1111', '1', 1 UNION
SELECT 'U002', 'R002', 'Luna', 'Lopez', '46025950', 'Femenino', '1152034590', 'Llopez@gmail.com', 'Don orione 123', 'Argentina', 'L004', 'PROV002', '2222', '1', 1 UNION
SELECT 'U003', 'R003', 'Sofi', 'Gomez', '36028470', 'Femenino', '1123347658', 'Sgomez@gmail.com', '3 de febrero 2347', 'Uruguaya', 'L008', 'PROV003', '3333', '2', 1 UNION
SELECT 'U004', 'R004', 'Agus', 'Dimasi', '43564389', 'Masculino', '1123246538', 'Adimasi@gmail.com', 'Maipu 701', 'Argentino', 'L005', 'PROV002', '4444', '2', 1 UNION
SELECT 'U005', 'R005', 'Roberto', 'González', '42666711', 'Masculino', '1121234235', 'Rgonzalez@gmail.com', 'libertador 678', 'Colombiano', 'L014', 'PROV005', '5555', '2', 1 UNION
SELECT 'U006', 'R001', 'Juana', 'Volponi', '41765432', 'Femenino', '1178563397', 'Jvolponi@gmail.com', 'Av.Peron 1111', 'Argentina', 'L009', 'PROV003', '6666', '2', 1 UNION
SELECT 'U007', 'R002', 'Daniela', 'Villalobos', '40561944', 'Femenino', '1122334455', 'Dvillalobos@gmail.com', 'Quintana 764', 'Uruguaya', 'L010', 'PROV004', '7777', '2', 1 UNION
SELECT 'U008', 'R003', 'Martin', 'Escobar', '48991234', 'Masculino', '1178962234', 'Mescobar@gmail.com', '25 de mayo 1321', 'Argentino', 'L002', 'PROV001', '8888', '2', 1 UNION
SELECT 'U009', 'R004', 'Mauro', 'Tiginelli', '39064311', 'Masculino', '1187539321', 'Mtiginelli@gmail.com', 'ayacucho 234', 'Argentino', 'L001', 'PROV001', '9999', '1', 1 UNION
SELECT 'U010', 'R005', 'Clara', 'Fernandez', '47201832', 'Femenino', '1198765432', 'Cfernandez@gmail.com', 'Rivadavia 432', 'Argentina', 'L003', 'PROV001', '1010', '1', 1 UNION
SELECT 'U011', 'R001', 'Ricardo', 'Torres', '45123456', 'Masculino', '1165437890', 'Rtorres@gmail.com', 'Belgrano 789', 'Chileno', 'L005', 'PROV002', '1112', '2', 1 UNION
SELECT 'U012', 'R002', 'Marina', 'Diaz', '47200123', 'Femenino', '1187643210', 'Mdiaz@gmail.com', 'San Martin 987', 'Argentina', 'L006', 'PROV002', '1212', '2', 1 UNION
SELECT 'U013', 'R003', 'Diego', 'Martinez', '45123422', 'Masculino', '1145678901', 'Dmartinez@gmail.com', 'Corrientes 123', 'Argentino', 'L007', 'PROV003', '1313', '2', 1 UNION
SELECT 'U014', 'R004', 'Elena', 'Suarez', '46234567', 'Femenino', '1134567890', 'Esuarez@gmail.com', 'San Juan 456', 'Paraguaya', 'L008', 'PROV003', '1414', '2', 1 UNION
SELECT 'U015', 'R005', 'Pablo', 'Garcia', '49012345', 'Masculino', '1123456789', 'Pgarcia@gmail.com', 'Mitre 678', 'Argentino', 'L009', 'PROV003', '1515', '2', 1 UNION
SELECT 'U016', 'R003', 'Pedro', 'Escobar', '34562167', 'Masculino', '1178962234', 'Mescobar@gmail.com', '25 de mayo 456', 'Argentino', 'L015', 'PROV005', '1616', '1', 1;


INSERT INTO Dias (CodDias_D, NombreDia_D)
SELECT 'D001', 'Lunes' UNION
SELECT 'D002', 'Martes' UNION
SELECT 'D003', 'Miercoles' UNION
SELECT 'D004', 'Jueves'  UNION
SELECT 'D005', 'Viernes' UNION
SELECT 'D006', 'Sabado';
GO

INSERT INTO Horarios (CodHorarios_H, Descripcion_H)
SELECT 'H001', '08:00 a 09:00 Hs' UNION
SELECT 'H002', '09:00 a 10:00 Hs' UNION
SELECT 'H003', '10:00 a 11:00 Hs' UNION
SELECT 'H004', '11:00 a 12:00 Hs' UNION
SELECT 'H005', '13:00 a 14:00 Hs' UNION
SELECT 'H006', '14:00 a 15:00 Hs' UNION
SELECT 'H007', '15:00 a 16:00 Hs' UNION
SELECT 'H008', '16:00 a 17:00 Hs';
GO

INSERT INTO DiasXHorarios (CodDias_DXH, CodHorarios_DXH)
SELECT 'D001', 'H001' UNION	SELECT 'D001', 'H002' UNION	SELECT 'D001', 'H003' UNION	SELECT 'D001', 'H004' UNION
SELECT 'D001', 'H005' UNION	SELECT 'D001', 'H006' UNION	SELECT 'D001', 'H007' UNION SELECT 'D001', 'H008' UNION

SELECT 'D002', 'H001' UNION	SELECT 'D002', 'H002' UNION	SELECT 'D002', 'H003' UNION	SELECT 'D002', 'H004' UNION
SELECT 'D002', 'H005' UNION	SELECT 'D002', 'H006' UNION	SELECT 'D002', 'H007' UNION SELECT 'D002', 'H008' UNION

SELECT 'D003', 'H001' UNION	SELECT 'D003', 'H002' UNION	SELECT 'D003', 'H003' UNION	SELECT 'D003', 'H004' UNION
SELECT 'D003', 'H005' UNION	SELECT 'D003', 'H006' UNION	SELECT 'D003', 'H007' UNION SELECT 'D003', 'H008' UNION

SELECT 'D004', 'H001' UNION	SELECT 'D004', 'H002' UNION	SELECT 'D004', 'H003' UNION	SELECT 'D004', 'H004' UNION
SELECT 'D004', 'H005' UNION	SELECT 'D004', 'H006' UNION	SELECT 'D004', 'H007' UNION SELECT 'D004', 'H008' UNION

SELECT 'D005', 'H001' UNION	SELECT 'D005', 'H002' UNION	SELECT 'D005', 'H003' UNION	SELECT 'D005', 'H004' UNION
SELECT 'D005', 'H005' UNION	SELECT 'D005', 'H006' UNION	SELECT 'D005', 'H007' UNION SELECT 'D005', 'H008' UNION

SELECT 'D006', 'H001' UNION	SELECT 'D006', 'H002' UNION	SELECT 'D006', 'H003' UNION	SELECT 'D006', 'H004' UNION
SELECT 'D006', 'H005' UNION SELECT 'D006', 'H006' UNION	SELECT 'D006', 'H007' UNION SELECT 'D006', 'H008';
GO

INSERT INTO Clientes(CodEmpresas_C, NombreEmpresa_C, RazonSocial_C, Telefono_C, Email_C, Direccion_C, CodLocalidades_C, CodProvincias_C, Estado_C)
SELECT 'C001', 'Accenture', '123', '1123086497', 'accenture@gmail.com', 'AV. Libertador 15099', 'L003', 'PROV001', 1  UNION
SELECT 'C002', 'CocaCola Argentina', '321', '1158614725', 'cocacola@gmail.com', '3 de Febrero 334', 'L006', 'PROV002', 1  UNION
SELECT 'C003', 'Sony Argentina', '231', '1188547128', 'sorny@gmail.com.ar', 'Maipú 1349', 'L009', 'PROV003', 1  UNION
SELECT 'C004', 'Mercado Libre', '213', '1114154712', 'mercado_libre@gmail.com', 'Constitución 3234', 'L008', 'PROV003', 1  UNION
SELECT 'C005', 'Netflix', '132', '1199659259', 'netflix@gmail.com', 'Sarmiento 937', 'L013', 'PROV005', 1  UNION
SELECT 'C006', 'Bimbo', '312', '1155254515', 'bimbo4@gmail.com', 'Gral. San Martin 277', 'L007', 'PROV003', 1  UNION
SELECT 'C007', 'La Serenisima', '555', '1122362242', 'la_serenisima@gmail.com', 'Almirante Brown 1999', 'L010', 'PROV004', 1  UNION
SELECT 'C008', 'YPF', '666', '1177478755', 'ypf@gmail.com', 'Quintana 510', 'L002', 'PROV001', 1  UNION
SELECT 'C009', 'Nestle', '777', '1144514244', 'nestle7@gmail.com', 'Av. Livertadores 2345', 'L001', 'PROV001', 1 UNION
SELECT 'C010', 'Toyota', '888', '1133325313', 'toyota@gmail.com', 'Don Bosco 1021', 'L007', 'PROV003', 1  UNION
SELECT 'C011', 'Arcor', '999', '1147896523', 'arcor@gmail.com', 'Avellaneda 1266', 'L004', 'PROV002', 1  UNION
SELECT 'C012', 'Google', '444', '1125364789', 'google@gmail.com', 'Av. Hipólito Yrigoyen 1043', 'L015', 'PROV005', 1  UNION
SELECT 'C013', 'Avon', '333', '1122334455', 'avon@gmail.com', 'Juncal 1347', 'L003', 'PROV001', 1  UNION
SELECT 'C014', 'Samsung', '222', '1199887766', 'samsung@gmail.com', 'Av. Belgrano 3389', 'L009', 'PROV003', 1  UNION
SELECT 'C015', 'IBM', '111', '1155228877', 'ibm@gmail.com', 'Av. Independencia 200', 'L011', 'PROV004', 1;
GO
																													

INSERT INTO UsuariosXDiasXHorarios(CodUsuarios_UXDXH, CodDias_UXDXH, CodHorarios_UXDXH)
SELECT 'U003', 'D001', 'H001' UNION
SELECT 'U003', 'D001', 'H002' UNION
SELECT 'U003', 'D001', 'H003' UNION
SELECT 'U003', 'D001', 'H004' UNION
SELECT 'U003', 'D002', 'H001' UNION
SELECT 'U003', 'D002', 'H002' UNION
SELECT 'U003', 'D002', 'H003' UNION
SELECT 'U003', 'D002', 'H004' UNION
SELECT 'U003', 'D003', 'H001' UNION
SELECT 'U003', 'D003', 'H002' UNION
SELECT 'U003', 'D003', 'H003' UNION
SELECT 'U003', 'D003', 'H004' UNION

SELECT 'U004', 'D004', 'H005' UNION
SELECT 'U004', 'D004', 'H006' UNION
SELECT 'U004', 'D004', 'H007' UNION
SELECT 'U004', 'D004', 'H008' UNION
SELECT 'U004', 'D005', 'H005' UNION
SELECT 'U004', 'D005', 'H006' UNION
SELECT 'U004', 'D005', 'H007' UNION
SELECT 'U004', 'D005', 'H008' UNION
SELECT 'U004', 'D006', 'H005' UNION
SELECT 'U004', 'D006', 'H006' UNION
SELECT 'U004', 'D006', 'H007' UNION
SELECT 'U004', 'D006', 'H008' UNION

SELECT 'U005', 'D001', 'H001' UNION
SELECT 'U005', 'D001', 'H002' UNION
SELECT 'U005', 'D001', 'H003' UNION
SELECT 'U005', 'D001', 'H004' UNION
SELECT 'U005', 'D002', 'H001' UNION
SELECT 'U005', 'D002', 'H002' UNION
SELECT 'U005', 'D002', 'H003' UNION
SELECT 'U005', 'D002', 'H004' UNION
SELECT 'U005', 'D003', 'H001' UNION
SELECT 'U005', 'D003', 'H002' UNION
SELECT 'U005', 'D003', 'H003' UNION
SELECT 'U005', 'D003', 'H004' UNION

SELECT 'U006', 'D004', 'H005' UNION
SELECT 'U006', 'D004', 'H006' UNION
SELECT 'U006', 'D004', 'H007' UNION
SELECT 'U006', 'D004', 'H008' UNION
SELECT 'U006', 'D005', 'H005' UNION
SELECT 'U006', 'D005', 'H006' UNION
SELECT 'U006', 'D005', 'H007' UNION
SELECT 'U006', 'D005', 'H008' UNION
SELECT 'U006', 'D006', 'H005' UNION
SELECT 'U006', 'D006', 'H006' UNION
SELECT 'U006', 'D006', 'H007' UNION
SELECT 'U006', 'D006', 'H008' UNION

SELECT 'U007', 'D004', 'H001' UNION
SELECT 'U007', 'D004', 'H002' UNION
SELECT 'U007', 'D004', 'H003' UNION
SELECT 'U007', 'D004', 'H004' UNION
SELECT 'U007', 'D005', 'H001' UNION
SELECT 'U007', 'D005', 'H002' UNION
SELECT 'U007', 'D005', 'H003' UNION
SELECT 'U007', 'D005', 'H004' UNION
SELECT 'U007', 'D006', 'H001' UNION
SELECT 'U007', 'D006', 'H002' UNION
SELECT 'U007', 'D006', 'H003' UNION
SELECT 'U007', 'D006', 'H004' UNION 

SELECT 'U008', 'D001', 'H005' UNION
SELECT 'U008', 'D001', 'H006' UNION
SELECT 'U008', 'D001', 'H007' UNION
SELECT 'U008', 'D001', 'H008' UNION
SELECT 'U008', 'D002', 'H005' UNION
SELECT 'U008', 'D002', 'H006' UNION
SELECT 'U008', 'D002', 'H007' UNION
SELECT 'U008', 'D002', 'H008' UNION
SELECT 'U008', 'D003', 'H005' UNION
SELECT 'U008', 'D003', 'H006' UNION
SELECT 'U008', 'D003', 'H007' UNION
SELECT 'U008', 'D003', 'H008' UNION

SELECT 'U011', 'D004', 'H001' UNION
SELECT 'U011', 'D004', 'H002' UNION
SELECT 'U011', 'D004', 'H003' UNION
SELECT 'U011', 'D004', 'H004' UNION
SELECT 'U011', 'D005', 'H001' UNION
SELECT 'U011', 'D005', 'H002' UNION
SELECT 'U011', 'D005', 'H003' UNION
SELECT 'U011', 'D005', 'H004' UNION
SELECT 'U011', 'D006', 'H001' UNION
SELECT 'U011', 'D006', 'H002' UNION
SELECT 'U011', 'D006', 'H003' UNION
SELECT 'U011', 'D006', 'H004' UNION 

SELECT 'U012', 'D001', 'H005' UNION
SELECT 'U012', 'D001', 'H006' UNION
SELECT 'U012', 'D001', 'H007' UNION
SELECT 'U012', 'D001', 'H008' UNION
SELECT 'U012', 'D002', 'H005' UNION
SELECT 'U012', 'D002', 'H006' UNION
SELECT 'U012', 'D002', 'H007' UNION
SELECT 'U012', 'D002', 'H008' UNION
SELECT 'U012', 'D003', 'H005' UNION
SELECT 'U012', 'D003', 'H006' UNION
SELECT 'U012', 'D003', 'H007' UNION
SELECT 'U012', 'D003', 'H008' UNION

SELECT 'U013', 'D001', 'H001' UNION
SELECT 'U013', 'D001', 'H002' UNION
SELECT 'U013', 'D001', 'H003' UNION
SELECT 'U013', 'D001', 'H004' UNION
SELECT 'U013', 'D002', 'H001' UNION
SELECT 'U013', 'D002', 'H002' UNION
SELECT 'U013', 'D002', 'H003' UNION
SELECT 'U013', 'D002', 'H004' UNION
SELECT 'U013', 'D003', 'H001' UNION
SELECT 'U013', 'D003', 'H002' UNION
SELECT 'U013', 'D003', 'H003' UNION
SELECT 'U013', 'D003', 'H004' UNION

SELECT 'U014', 'D004', 'H001' UNION
SELECT 'U014', 'D004', 'H002' UNION
SELECT 'U014', 'D004', 'H003' UNION
SELECT 'U014', 'D004', 'H004' UNION
SELECT 'U014', 'D005', 'H001' UNION
SELECT 'U014', 'D005', 'H002' UNION
SELECT 'U014', 'D005', 'H003' UNION
SELECT 'U014', 'D005', 'H004' UNION
SELECT 'U014', 'D006', 'H001' UNION
SELECT 'U014', 'D006', 'H002' UNION
SELECT 'U014', 'D006', 'H003' UNION
SELECT 'U014', 'D006', 'H004' UNION 

SELECT 'U015', 'D004', 'H005' UNION
SELECT 'U015', 'D004', 'H006' UNION
SELECT 'U015', 'D004', 'H007' UNION
SELECT 'U015', 'D004', 'H008' UNION
SELECT 'U015', 'D005', 'H005' UNION
SELECT 'U015', 'D005', 'H006' UNION
SELECT 'U015', 'D005', 'H007' UNION
SELECT 'U015', 'D005', 'H008' UNION
SELECT 'U015', 'D006', 'H005' UNION
SELECT 'U015', 'D006', 'H006' UNION
SELECT 'U015', 'D006', 'H007' UNION
SELECT 'U015', 'D006', 'H008';
GO

INSERT INTO Estados (CodEstados_E, Descripcion_E)
SELECT 'E001', 'Terminado' UNION
SELECT 'E002', 'Pendiente';


INSERT INTO Turnos(CodTurnos_T, CodEmpresas_T, CodRubros_T, CodUsuarios_T, CodDias_T, CodHorarios_T, CodFechas_T, CodEstados_T, Observaciones_T, Estado_T)
SELECT 'T011', 'C001', 'R003', 'U003', 'D003', 'H001', '2024-07-24', 'E001', 'Desarrollo de estrategia', 1 UNION
SELECT 'T012', 'C002', 'R003', 'U003', 'D002', 'H004', '2024-07-23', 'E002', ' ', 1 UNION
SELECT 'T013', 'C003', 'R003', 'U003', 'D003', 'H001', '2024-07-24', 'E001', 'Presentación de informes', 1 UNION
SELECT 'T014', 'C004', 'R003', 'U003', 'D001', 'H002', '2024-07-22', 'E002', '', 1 UNION
SELECT 'T015', 'C005', 'R003', 'U003', 'D002', 'H003', '2024-07-23', 'E001', 'Planificación de proyecto', 1 UNION

SELECT 'T016', 'C004', 'R004', 'U004', 'D004', 'H005', '2023-05-04', 'E002', ' ', 1 UNION
SELECT 'T017', 'C005', 'R004', 'U004', 'D005', 'H006', '2022-05-20', 'E001', 'Consulta de soporte', 1 UNION
SELECT 'T018', 'C006', 'R004', 'U004', 'D006', 'H008', '2024-08-03', 'E002', ' ', 1 UNION
SELECT 'T019', 'C007', 'R004', 'U004', 'D005', 'H007', '2022-02-18', 'E001', 'Revisión de rendimiento', 1 UNION
SELECT 'T020', 'C008', 'R004', 'U004', 'D005', 'H005', '2024-12-20', 'E002', ' ', 1 UNION

SELECT 'T021', 'C009', 'R005', 'U005', 'D001', 'H001', '2023-05-01', 'E001', 'Desarrollo de contenido', 1 UNION
SELECT 'T022', 'C010', 'R005', 'U005', 'D002', 'H001', '2023-02-07', 'E002', ' ', 1 UNION
SELECT 'T023', 'C011', 'R005', 'U005', 'D003', 'H002', '2024-01-10', 'E001', 'Preparación de informes', 1 UNION
SELECT 'T024', 'C012', 'R005', 'U005', 'D001', 'H003', '2024-04-15', 'E002', ' ', 1 UNION
SELECT 'T025', 'C013', 'R005', 'U005', 'D003', 'H004', '2024-06-12', 'E001', 'Soporte técnico', 1 UNION

SELECT 'T026', 'C014', 'R001', 'U006', 'D004', 'H007', '2022-01-15', 'E002', ' ', 1 UNION
SELECT 'T027', 'C015', 'R001', 'U006', 'D005', 'H008', '2023-02-11', 'E001', 'Reunión de estrategia', 1 UNION
SELECT 'T028', 'C001', 'R001', 'U006', 'D006', 'H005', '2024-03-09', 'E002', ' ', 1 UNION
SELECT 'T029', 'C002', 'R001', 'U006', 'D004', 'H006', '2022-04-14', 'E001', 'Planificación de eventos', 1 UNION
SELECT 'T030', 'C003', 'R001', 'U006', 'D005', 'H008', '2024-05-17', 'E002', ' ', 1 UNION

SELECT 'T031', 'C004', 'R002', 'U007', 'D004', 'H001', '2023-06-08', 'E001', 'Revisión de clientes', 1 UNION
SELECT 'T032', 'C005', 'R002', 'U007', 'D006', 'H002', '2022-03-12', 'E001', 'Desarrollo de nuevo producto', 1 UNION
SELECT 'T033', 'C006', 'R002', 'U007', 'D005', 'H003', '2024-07-05', 'E002', ' ', 1 UNION
SELECT 'T034', 'C007', 'R002', 'U007', 'D006', 'H004', '2022-08-20', 'E002', ' ', 1 UNION
SELECT 'T035', 'C008', 'R002', 'U007', 'D004', 'H001', '2024-09-16', 'E002', ' ', 1 UNION

SELECT 'T036', 'C009', 'R003', 'U008', 'D001', 'H005', '2023-11-06', 'E002', ' ', 1 UNION
SELECT 'T037', 'C010', 'R003', 'U008', 'D001', 'H006', '2024-06-03', 'E001', 'Mantenimiento preventivo', 1 UNION
SELECT 'T038', 'C011', 'R003', 'U008', 'D002', 'H007', '2024-07-31', 'E002', ' ', 1 UNION
SELECT 'T039', 'C012', 'R003', 'U008', 'D003', 'H008', '2023-12-25', 'E001', 'Soporte continuo', 1 UNION
SELECT 'T040', 'C013', 'R003', 'U008', 'D002', 'H005', '2024-01-20', 'E002', ' ', 1 UNION

SELECT 'T051', 'C001', 'R001', 'U011', 'D004', 'H001', '2022-08-01', 'E001', 'Desarrollo de estrategia', 1 UNION
SELECT 'T052', 'C002', 'R001', 'U011', 'D005', 'H002', '2023-05-02', 'E002', '', 1 UNION
SELECT 'T053', 'C003', 'R001', 'U011', 'D006', 'H003', '2023-11-03', 'E001', 'Revisión de informes', 1 UNION
SELECT 'T054', 'C004', 'R001', 'U011', 'D004', 'H004', '2023-10-12', 'E002', '', 1 UNION
SELECT 'T055', 'C005', 'R001', 'U011', 'D005', 'H003', '2024-03-15', 'E001', 'Planificación de actividades', 1 UNION

SELECT 'T056', 'C009', 'R002', 'U012', 'D001', 'H005', '2023-01-09', 'E002', '', 1 UNION
SELECT 'T057', 'C010', 'R002', 'U012', 'D002', 'H006', '2023-02-07', 'E001', 'Consultoría técnica', 1 UNION
SELECT 'T058', 'C011', 'R002', 'U012', 'D003', 'H007', '2024-03-13', 'E002', '', 1 UNION
SELECT 'T059', 'C012', 'R002', 'U012', 'D001', 'H008', '2024-04-11', 'E001', 'Preparación de reportes', 1 UNION
SELECT 'T060', 'C013', 'R002', 'U012', 'D002', 'H007', '2023-05-02', 'E002', '', 1 UNION

SELECT 'T061', 'C014', 'R003', 'U013', 'D001', 'H001', '2022-06-01', 'E001', 'Desarrollo de producto', 1 UNION
SELECT 'T062', 'C015', 'R003', 'U013', 'D002', 'H002', '2022-07-25', 'E002', '', 1 UNION
SELECT 'T063', 'C001', 'R003', 'U013', 'D003', 'H003', '2022-08-03', 'E001', 'Estrategia de mercado', 1 UNION
SELECT 'T064', 'C002', 'R003', 'U013', 'D003', 'H004', '2023-09-20', 'E002', '', 1 UNION
SELECT 'T065', 'C003', 'R003', 'U013', 'D002', 'H004', '2023-10-16', 'E001', 'Revisión de producto', 1 UNION

SELECT 'T066', 'C004', 'R004', 'U014', 'D004', 'H001', '2024-11-21', 'E002', '', 1 UNION
SELECT 'T067', 'C005', 'R004', 'U014', 'D005', 'H002', '2022-12-30', 'E001', 'Consultoría de sistemas', 1 UNION
SELECT 'T068', 'C006', 'R004', 'U014', 'D006', 'H003', '2024-01-13', 'E002', '', 1 UNION
SELECT 'T069', 'C007', 'R004', 'U014', 'D004', 'H004', '2023-02-16', 'E001', 'Planificación de proyecto', 1 UNION
SELECT 'T070', 'C008', 'R004', 'U014', 'D006', 'H004', '2024-03-20', 'E002', '', 1 UNION

SELECT 'T071', 'C009', 'R005', 'U015', 'D004', 'H008', '2022-04-28', 'E001', 'Desarrollo de software', 1 UNION
SELECT 'T072', 'C010', 'R005', 'U015', 'D005', 'H005', '2024-05-15', 'E002', '', 1 UNION
SELECT 'T073', 'C011', 'R005', 'U015', 'D006', 'H006', '2023-06-24', 'E001', 'Revisión de código', 1 UNION
SELECT 'T074', 'C012', 'R005', 'U015', 'D005', 'H007', '2022-07-16', 'E002', '', 1 UNION
SELECT 'T075', 'C013', 'R005', 'U015', 'D006', 'H008', '2024-08-31', 'E001', 'Pruebas de integración', 1;
