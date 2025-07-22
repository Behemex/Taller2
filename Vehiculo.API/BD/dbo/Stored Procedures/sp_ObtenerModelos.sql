CREATE PROCEDURE sp_ObtenerModelos
AS
BEGIN
    SELECT Id, IdMarca, Nombre
    FROM Modelos
END