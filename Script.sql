CREATE DATABASE CasoEstudioJN;
GO

USE CasoEstudioJN;
GO

CREATE TABLE CasasSistema (
    IdCasa BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    DescripcionCasa VARCHAR(30) NOT NULL,
    PrecioCasa DECIMAL(10,2) NOT NULL,
    UsuarioAlquiler VARCHAR(30) NULL,
    FechaAlquiler DATETIME NULL
);
GO

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa],[PrecioCasa],[UsuarioAlquiler],[FechaAlquiler])
VALUES ('Casa en San José',190000,NULL,NULL);

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa],[PrecioCasa],[UsuarioAlquiler],[FechaAlquiler])
VALUES ('Casa en Alajuela',145000,NULL,NULL);

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa],[PrecioCasa],[UsuarioAlquiler],[FechaAlquiler])
VALUES ('Casa en Cartago',115000,NULL,NULL);

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa],[PrecioCasa],[UsuarioAlquiler],[FechaAlquiler])
VALUES ('Casa en Heredia',122000,NULL,NULL);

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa],[PrecioCasa],[UsuarioAlquiler],[FechaAlquiler])
VALUES ('Casa en Guanacaste',105000,NULL,NULL);
GO

-------------------------SP-----------------------------------------------
--P4
CREATE OR ALTER PROCEDURE [dbo].[sp_IdCasaDropdown]
AS
BEGIN
	SELECT IdCasa, DescripcionCasa
	FROM CasasSistema
	WHERE FechaAlquiler IS NULL
	AND UsuarioAlquiler IS NULL
END
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_PrecioCasaText]
	@IdCasa BIGINT
AS
BEGIN
	SELECT PrecioCasa
	FROM CasasSistema
	WHERE IdCasa = @IdCasa
END
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_AlquilarCasa]
	@IdCasa BIGINT, @UsuarioAlquiler VARCHAR(30)
AS
BEGIN
	UPDATE CasasSistema
	SET UsuarioAlquiler = @UsuarioAlquiler,
	FechaAlquiler = GETDATE()
	WHERE IdCasa = @IdCasa
END
GO