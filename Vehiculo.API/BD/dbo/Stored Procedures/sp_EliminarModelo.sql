﻿
CREATE PROCEDURE sp_EliminarModelo
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM Modelos
    WHERE Id = @Id
END