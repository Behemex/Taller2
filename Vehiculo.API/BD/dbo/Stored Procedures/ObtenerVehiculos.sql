-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ObtenerVehiculos
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT        Vehiculo.Id AS Expr1, Vehiculo.IdModelo, Vehiculo.Placa, Vehiculo.Color, Vehiculo.Anio, Vehiculo.Precio, Vehiculo.CorreoPropietario, Vehiculo.TelefonoPropietario, Modelos.Nombre AS Modelo, Marca.Nombre AS Marca
FROM            Vehiculo INNER JOIN
                         Modelos ON Vehiculo.IdModelo = Modelos.Id INNER JOIN
                         Marca ON Modelos.IdMarca = Marca.Id
END