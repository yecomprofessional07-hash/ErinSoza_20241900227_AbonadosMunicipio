USE master
GO

-- Eliminando base de datos de servicios
DROP DATABASE IF EXISTS DbServiciosPublicos
GO

-- Creacion de base de datos
CREATE DATABASE DbServiciosPublicos
GO

-- Utilizar base de datos
USE DbServiciosPublicos
GO

/*
TABLA MAESTRA: Tipos de Servicio (Equivalente a Categorias)
*/
CREATE TABLE TiposServicio (
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(250) NOT NULL, -- Ej: Agua, Luz, Gas
)
GO

/*
TABLA PRINCIPAL: Abonados (Equivalente a Peliculas)
*/
CREATE TABLE Abonados (
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	NombreCompleto VARCHAR(250) NOT NULL,
	Direccion VARCHAR(500) NOT NULL,
	NumeroMedidor VARCHAR(50) NOT NULL,
	ConsumoMensual INT NOT NULL DEFAULT 0, -- En Kw o m3
	TipoServicioId INT NOT NULL,

	FOREIGN KEY (TipoServicioId) REFERENCES TiposServicio(Id)
)
GO

-- Agregando y mostrando tipos de servicio
INSERT INTO TiposServicio (Nombre)
VALUES
	('Energia Electrica'),
	('Agua Potable'),
	('Gas Natural')
GO

SELECT * FROM TiposServicio
GO

-- Agregando y mostrando abonados
INSERT INTO Abonados 
(
	NombreCompleto,
	Direccion,
	NumeroMedidor,
	ConsumoMensual,
	TipoServicioId
)
VALUES
('Juan Perez','Calle Falsa 123','MED-001', 150, 1),
('Maria Lopez','Av. Central 456','MED-002', 40, 2),
('Carlos Ruiz','Barrio Lindo 789','MED-003', 200, 1),
('Ana Gomez','Calle 10 Nro 50','MED-004', 10, 3),
('Pedro Picapiedra','Roca Viva 001','MED-005', 85, 2)
GO

-- Mostrar todos los abonados
SELECT * FROM Abonados
GO

/*
FILTRANDO POR WHERE
*/

-- Por Id de abonado
SELECT * FROM Abonados
WHERE Id = 1

-- Por nombre exacto
SELECT * FROM Abonados
WHERE NombreCompleto = 'Maria Lopez'

-- Abonados con alto consumo (mayor a 100)
SELECT * FROM Abonados
WHERE ConsumoMensual > 100

-- Buscar por dirección (comodín)
SELECT * FROM Abonados
WHERE Direccion LIKE '%Calle%'

-- Obtener los 3 abonados con mayor consumo
SELECT TOP 3 * FROM Abonados
ORDER BY ConsumoMensual DESC

-- UPDATE: Actualizar el consumo de un abonado
UPDATE Abonados
	SET
		ConsumoMensual = 180,
		Direccion = 'Nueva Calle 456'
WHERE Id = 1

-- DELETE: Eliminar un abonado por Id
DELETE Abonados
WHERE Id = 5
GO

SELECT * FROM Abonados
GO
