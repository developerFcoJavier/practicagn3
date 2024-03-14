CREATE PROCEDURE CrearDepartamento
    @ClaveDepartamento INT,
    @Descripcion VARCHAR(100)
AS
BEGIN
    INSERT INTO Departamentos (ClaveDepartamento, Descripcion)
    VALUES (@ClaveDepartamento, @Descripcion);
END;

CREATE PROCEDURE LeerDepartamentos
AS
BEGIN
    SELECT * FROM Departamentos;
END;

CREATE PROCEDURE ActualizarDepartamento
    @ClaveDepartamento INT,
    @Descripcion VARCHAR(100)
AS
BEGIN
    UPDATE Departamentos
    SET Descripcion = @Descripcion
    WHERE ClaveDepartamento = @ClaveDepartamento;
END;

CREATE PROCEDURE EliminarDepartamento
    @ClaveDepartamento INT
AS
BEGIN
    DELETE FROM Departamentos
    WHERE ClaveDepartamento = @ClaveDepartamento;
END;
