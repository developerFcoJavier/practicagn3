-- Llenar la tabla de Departamentos
INSERT INTO Departamentos (ClaveDepartamento, Descripcion)
VALUES 
    (1, 'Departamento 1'),
    (2, 'Departamento 2'),
    (3, 'Departamento 3'),
    (4, 'Departamento 4'),
    (5, 'Departamento 5');

-- Llenar la tabla de Empleados
INSERT INTO Empleados (ClaveEmpleado, Nombre, FechaIngreso, FechaNacimiento, DepartamentoID)
VALUES
    (1, 'Empleado 1', '2022-01-01', '1990-01-01', 1),
    (2, 'Empleado 2', '2022-02-01', '1991-02-02', 2),
    (3, 'Empleado 3', '2022-03-01', '1992-03-03', 3),
    (4, 'Empleado 4', '2022-04-01', '1993-04-04', 4),
    (5, 'Empleado 5', '2022-05-01', '1994-05-05', 5),
    (6, 'Empleado 6', '2024-06-01', '1995-06-06', 1),
    (7, 'Empleado 7', '2024-07-01', '1996-07-07', 2),
    (8, 'Empleado 8', '2024-08-01', '1997-08-08', 3),
    (9, 'Empleado 9', '2022-09-01', '1998-09-09', 4),
    (10, 'Empleado 10', '2022-10-01', '1999-10-10', 5);

-- Llenar la tabla de Sueldos
INSERT INTO Sueldos (EmpleadoID, SueldoMensual, FormaPago)
VALUES
    (1, 2000.00, 'Efectivo'),
    (2, 2100.00, 'Transferencia'),
    (3, 2200.00, 'Efectivo'),
    (4, 2300.00, 'Transferencia'),
    (5, 2400.00, 'Efectivo'),
    (6, 9000.00, 'Transferencia'),
    (7, 12000.00, 'Efectivo'),
    (8, 10000.00, 'Transferencia'),
    (9, 2800.00, 'Efectivo'),
    (10, 2900.00, 'Transferencia');