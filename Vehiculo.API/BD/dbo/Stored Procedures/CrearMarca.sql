CREATE PROCEDURE CrearMarca
    @Nombre VARCHAR(MAX)
AS
BEGIN
    INSERT INTO Marca (Id, Nombre)
    VALUES (NEWID(), @Nombre);
END