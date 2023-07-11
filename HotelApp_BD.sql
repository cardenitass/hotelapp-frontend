CREATE DATABASE HotelApp_BD

-- Crear primero la base de datos de forma individual, ya después correr los scrips para crear insertar, etc 

USE HotelApp_BD

--------------------------------------------------------------
---------------- Creación de Tablas---------------------------
--------------------------------------------------------------
CREATE TABLE Tipo_Habitacion ( 
IDTipoHabitacion INT IDENTITY (1,1) NOT NULL CONSTRAINT pk_tipo_habitacion PRIMARY KEY,
NombreTipoHabitacion VARCHAR(30) NOT NULL ,
CantPersonas INT NOT NULL ,
CantCamas INT NOT NULL ,
Cocina BIT NOT NULL, 
CostoNoche DECIMAL(12,2) NOT NULL);


CREATE TABLE Habitacion (
IDHabitacion INT IDENTITY (1,1) NOT NULL CONSTRAINT pk_product PRIMARY KEY,
IDTipoHabitacion INT NOT NULL,
NumeroPiso INT NOT NULL,
Disponible BIT NOT NULL,
Path_Img VARCHAR(50) NOT NULL,
FOREIGN KEY (IDTipoHabitacion) REFERENCES Tipo_Habitacion);

CREATE TABLE Roles ( 
IDRol INT IDENTITY (1,1) NOT NULL CONSTRAINT pk_roles PRIMARY KEY,
NombreRol VARCHAR(20) NOT NULL );

CREATE TABLE Usuarios ( 
IDUsuario INT IDENTITY (1,1) NOT NULL CONSTRAINT pk_usuarios PRIMARY KEY,
Nombre VARCHAR(40) NOT NULL,
FechaNacimiento DATE NOT NULL,
Correo VARCHAR (50) NOT NULL,
Contrasena VARCHAR(40) NOT NULL,
Estado BIT NOT NULL,
IDRol INT NOT NULL,
FOREIGN KEY (IDRol) REFERENCES Roles);


CREATE TABLE Reservaciones ( 
IDReservacion INT IDENTITY (1,1) NOT NULL CONSTRAINT pk_reservaciones PRIMARY KEY,
IDHabitacion INT NOT NULL,
IDUsuario INT NULL,
CantidadNoches INT NOT NULL,
FechaInicio DATE NOT NULL,
FechaFin  DATE NOT NULL,
Costo_Total DECIMAL(20, 2) NOT NULL,
FOREIGN KEY (IDHabitacion) REFERENCES Habitacion,
FOREIGN KEY (IDUsuario) REFERENCES Usuarios);

-- Registrar errores en la app de usuarios logueados

CREATE TABLE  Errores (
	IDerror INT  NOT NULL CONSTRAINT pk_errores PRIMARY KEY,
	Descripcion VARCHAR(500) NOT NULL,
	Fecha DATETIME NOT NULL,
	Origen VARCHAR(100) NOT NULL,
	IDUsuario INT NOT NULL,
	FOREIGN KEY (IDUsuario) REFERENCES Usuarios);

-- Registrar errores en la app cuando el usuario no esta logueado

CREATE TABLE  Bitacora (
	IDbitacora INT  NOT NULL CONSTRAINT pk_bitacora PRIMARY KEY,
	Descripcion VARCHAR(500) NOT NULL,
	Fecha DATETIME NOT NULL,
	Origen VARCHAR(100) NOT NULL);


--------------------------------------------------------------
-----------------------Inserts--------------------------------
--------------------------------------------------------------

INSERT INTO TIPO_HABITACION VALUES (
'Habitación Presidencial', 5, 5, 1000000)

INSERT INTO Habitacion VALUES (1, 1, 'D')

INSERT INTO Roles VALUES ('Empleado')
INSERT INTO Roles VALUES ('Usuario')

INSERT INTO Reservaciones VALUES (
1, 1, 1, 2, '2023-09-14', '2023-09-16', 2000000)

INSERT INTO Usuarios VALUES ('David Cárdenas Orozco', '2002-09-24', 'davidcardenasorozco@gmail.com', 'admin12345', 1)

GO
