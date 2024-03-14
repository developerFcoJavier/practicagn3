
--Devuelve un listado con los empleados y los datos de los departamentos donde trabaja cada uno junto con su sueldo de cada empleado y su forma de pago
SELECT 
    e.ClaveEmpleado,
    e.Nombre,
    d.Descripcion AS Departamento,
    s.SueldoMensual,
    s.FormaPago
FROM 
    Empleados e
JOIN 
    Sueldos s ON e.ClaveEmpleado = s.EmpleadoID
LEFT JOIN 
    Departamentos d ON e.DepartamentoID = d.ClaveDepartamento;

--Devuelve un listado con la clave y el nombre del departamento, solamente de aquellos departamentos que tienen empleados
SELECT 
    DISTINCT d.ClaveDepartamento,
    d.Descripcion AS Departamento
FROM 
    Departamentos d
JOIN 
    Empleados e ON d.ClaveDepartamento = e.DepartamentoID;

--Devuelve un listado con el total de sueldos de cada departamento separado por forma de pago
SELECT 
    d.ClaveDepartamento,
    d.Descripcion AS Departamento,
    s.FormaPago,
    SUM(s.SueldoMensual) AS TotalSueldos
FROM 
    Departamentos d
JOIN 
    Empleados e ON d.ClaveDepartamento = e.DepartamentoID
JOIN 
    Sueldos s ON e.ClaveEmpleado = s.EmpleadoID
GROUP BY 
    d.ClaveDepartamento,
    d.Descripcion,
    s.FormaPago;


--Devuelve un listado de los empleados mayores de 30 años que tengan un sueldo mayor a 6 mil ordenado de mayor a menor
SELECT 
    ClaveEmpleado,
    Nombre,
    FechaNacimiento,
    DATEDIFF(YEAR, FechaNacimiento, GETDATE()) AS Edad,
    SueldoMensual
FROM 
    Empleados e
JOIN 
    Sueldos s ON e.ClaveEmpleado = s.EmpleadoID
WHERE 
    DATEDIFF(YEAR, FechaNacimiento, GETDATE()) > 30
    AND SueldoMensual > 6000
ORDER BY 
    SueldoMensual DESC;


--Devuelve un listado con los empleados que ingresaron en año actual

SELECT 
    ClaveEmpleado,
    Nombre,
    FechaIngreso
FROM 
    Empleados
WHERE 
    YEAR(FechaIngreso) = YEAR(GETDATE());


--Devuelve un listado con la edad y su fecha de nacimiento de cada empleado ordenado de mayor a menor

SELECT 
    DATEDIFF(YEAR, FechaNacimiento, GETDATE()) AS Edad,
    FechaNacimiento
FROM 
    Empleados
ORDER BY 
    Edad DESC;

