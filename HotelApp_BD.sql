CREATE DATABASE HotelApp_BD

-- Crear primero la base de datos de forma individual, ya después correr los scrips para crear insertar, etc 

USE HotelApp_BD


--------------------------------------------------------------
---------------- Creación de Tablas---------------------------
--------------------------------------------------------------
CREATE TABLE Habitacion ( 
IDHabitacion INT IDENTITY (1,1) NOT NULL CONSTRAINT pk_habitacion PRIMARY KEY,
NombreHabitacion VARCHAR(30) NOT NULL,
Descripcion VARCHAR(500) NOT NULL,
Path_Img VARCHAR(MAX) NOT NULL,
CantPersonas INT NOT NULL ,
CantCamas INT NOT NULL ,
Disponible BIT NOT NULL DEFAULT 1,
CostoNoche DECIMAL(12,2) NOT NULL);

CREATE TABLE Roles ( 
IDRol INT IDENTITY (1,1) NOT NULL CONSTRAINT pk_roles PRIMARY KEY,
NombreRol VARCHAR(20) NOT NULL );

CREATE TABLE Usuarios ( 
IDUsuario INT IDENTITY (1,1) NOT NULL CONSTRAINT pk_usuarios PRIMARY KEY,
Nombre VARCHAR(40) NOT NULL,
FechaNacimiento DATE NOT NULL,
Correo VARCHAR (50) NOT NULL,
Contrasena VARCHAR(40) NOT NULL,
Estado BIT NOT NULL DEFAULT 1,
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
	IDerror INT IDENTITY (1,1) NOT NULL CONSTRAINT pk_errores PRIMARY KEY,
	Descripcion VARCHAR(500) NOT NULL,
	Fecha DATETIME NOT NULL,
	Origen VARCHAR(100) NOT NULL,
	IDUsuario INT NOT NULL,
	FOREIGN KEY (IDUsuario) REFERENCES Usuarios);

-- Registrar errores en la app cuando el usuario no esta logueado

CREATE TABLE  Bitacora (
	IDbitacora INT IDENTITY (1,1) NOT NULL CONSTRAINT pk_bitacora PRIMARY KEY,
	Descripcion VARCHAR(500) NOT NULL,
	Fecha DATETIME NOT NULL,
	Origen VARCHAR(100) NOT NULL);


--------------------------------------------------------------
-----------------------Inserts--------------------------------
--------------------------------------------------------------

INSERT INTO Habitacion (NombreHabitacion, Path_Img, CantPersonas, CantCamas, Descripcion, CostoNoche)
VALUES (
    'Habitación Presidencial',
    'https://colineal.com/cdn/shop/articles/estilos-decoracion-habitaciones-principales.jpg?v=1620156517',
    5, -- CantPersonas
    5, -- CantCamas
    'Esta habitacion cuenta con balcon y cocina, ademas tiene la capacidad de recibir hasta 10 huespedes para organizar eventos',
    1000000 -- CostoNoche
);


INSERT INTO Roles VALUES ('Administrator')
INSERT INTO Roles VALUES ('Client')

INSERT INTO Usuarios (Nombre, FechaNacimiento, Correo, Contrasena, IDRol)
VALUES ('David Cárdenas Orozco', '2002-09-24', 'davidcardenasorozco@gmail.com', 'admin12345', 1);

INSERT INTO Usuarios (Nombre, FechaNacimiento, Correo, Contrasena, IDRol)
VALUES ('Edgar Herrera Varela', '2002-09-24', 'eherrera10234@ufide.ac.cr', 'admin12345', 1);

INSERT INTO Usuarios (Nombre, FechaNacimiento, Correo, Contrasena, IDRol)
VALUES ('Edgar Herrera Varela', '2002-09-24', 'edgarherrer100@gmail.com', 'admin12345', 1);

Select * from Habitacion

Select * from Roles

Select * from Usuarios



