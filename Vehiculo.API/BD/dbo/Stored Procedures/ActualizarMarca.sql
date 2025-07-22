CREATE PROCEDURE ActualizarMarca
    @Id UNIQUEIDENTIFIER,
    @Nombre VARCHAR(MAX)
AS
BEGIN
    UPDATE Marca
    SET Nombre = @Nombre
    WHERE Id = @Id;
END