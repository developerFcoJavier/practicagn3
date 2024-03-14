CREATE DATABASE PracticaGN3;

USE PracticaGN3;

-- Crear la tabla Departamentos
CREATE TABLE Departamentos (
    ClaveDepartamento INT PRIMARY KEY,
    Descripcion VARCHAR(100)
);

-- Crear la tabla Empleados
CREATE TABLE Empleados (
    ClaveEmpleado INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    FechaIngreso DATE NOT NULL,
    FechaNacimiento DATE NOT NULL,
    DepartamentoID INT,
    FOREIGN KEY (DepartamentoID) REFERENCES Departamentos (ClaveDepartamento)
);

-- Crear la tabla Sueldos
CREATE TABLE Sueldos (
    EmpleadoID INT PRIMARY KEY,
    SueldoMensual DECIMAL(10,2),
    FormaPago VARCHAR(20),
    FOREIGN KEY (EmpleadoID) REFERENCES Empleados (ClaveEmpleado)
);




