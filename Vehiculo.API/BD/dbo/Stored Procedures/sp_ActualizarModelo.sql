
CREATE PROCEDURE sp_ActualizarModelo
    @Id UNIQUEIDENTIFIER,
    @IdMarca UNIQUEIDENTIFIER,
    @Nombre VARCHAR(MAX)
AS
BEGIN
    UPDATE Modelos
    SET IdMarca = @IdMarca,
        Nombre = @Nombre
    WHERE Id = @Id
END