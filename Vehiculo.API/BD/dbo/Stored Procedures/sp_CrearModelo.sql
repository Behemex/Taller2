
CREATE PROCEDURE sp_CrearModelo
    @Id UNIQUEIDENTIFIER,
    @IdMarca UNIQUEIDENTIFIER,
    @Nombre VARCHAR(MAX)
AS
BEGIN
    INSERT INTO Modelos (Id, IdMarca, Nombre)
    VALUES (@Id, @IdMarca, @Nombre)
END