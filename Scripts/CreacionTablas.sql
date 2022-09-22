USE DB_Invitados
GO

--TABLA Persona
CREATE TABLE Persona(
    nIdPersona INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
    sDNI VARCHAR(20),
	sApellidoPaterno VARCHAR(MAX),
	sApellidoMaterno VARCHAR(MAX),
	sNombre VARCHAR(MAX),
	bEstado BIT NOT NULL DEFAULT 1
)
GO


