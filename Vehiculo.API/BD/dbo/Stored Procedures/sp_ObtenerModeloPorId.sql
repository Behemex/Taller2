
CREATE PROCEDURE sp_ObtenerModeloPorId
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT Id, IdMarca, Nombre
    FROM Modelos
    WHERE Id = @Id
END