CREATE PROCEDURE CrearSueldo
    @EmpleadoID INT,
    @SueldoMensual DECIMAL(10, 2),
    @FormaPago VARCHAR(20)
AS
BEGIN
    INSERT INTO Sueldos (EmpleadoID, SueldoMensual, FormaPago)
    VALUES (@EmpleadoID, @SueldoMensual, @FormaPago);
END;

CREATE PROCEDURE LeerSueldos
AS
BEGIN
    SELECT * FROM Sueldos;
END;

CREATE PROCEDURE ActualizarSueldo
    @EmpleadoID INT,
    @SueldoMensual DECIMAL(10, 2),
    @FormaPago VARCHAR(20)
AS
BEGIN
    UPDATE Sueldos
    SET SueldoMensual = @SueldoMensual, FormaPago = @FormaPago
    WHERE EmpleadoID = @EmpleadoID;
END;

CREATE PROCEDURE EliminarSueldo
    @EmpleadoID INT
AS
BEGIN
    DELETE FROM Sueldos
    WHERE EmpleadoID = @EmpleadoID;
END;
