CREATE PROCEDURE CrearEmpleado
    @ClaveEmpleado INT,
    @Nombre VARCHAR(100),
    @FechaIngreso DATE,
    @FechaNacimiento DATE,
    @DepartamentoID INT
AS
BEGIN
    INSERT INTO Empleados (ClaveEmpleado, Nombre, FechaIngreso, FechaNacimiento, DepartamentoID)
    VALUES (@ClaveEmpleado, @Nombre, @FechaIngreso, @FechaNacimiento, @DepartamentoID);
END;

CREATE PROCEDURE LeerEmpleados
AS
BEGIN
    SELECT * FROM Empleados;
END;

CREATE PROCEDURE ActualizarEmpleado
    @ClaveEmpleado INT,
    @Nombre VARCHAR(100),
    @FechaIngreso DATE,
    @FechaNacimiento DATE,
    @DepartamentoID INT
AS
BEGIN
    UPDATE Empleados
    SET Nombre = @Nombre, FechaIngreso = @FechaIngreso, FechaNacimiento = @FechaNacimiento, DepartamentoID = @DepartamentoID
    WHERE ClaveEmpleado = @ClaveEmpleado;
END;

CREATE PROCEDURE EliminarEmpleado
    @ClaveEmpleado INT
AS
BEGIN
    DELETE FROM Empleados
    WHERE ClaveEmpleado = @ClaveEmpleado;
END;
