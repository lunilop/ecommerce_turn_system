
USE eCommerce
GO

												---	 AGREGAR EMPLEADO	--

CREATE PROCEDURE[dbo].[spAgregarUsuario]
	 @CODUSUARIOS char (10), 
	 @CODRUBROS char (10),
	 @NOMBRE varchar (100),
	 @APELLIDO varchar (100),
	 @DNI varchar (8),
	 @GENERO varchar (30),
	 @TELEFONO varchar (20),
	 @EMAIL varchar (30),
	 @DIRECCION varchar (100),
	 @NACIONALIDAD varchar (100),
	 @CODLOCALIDADES char (10),
	 @CODPROVINCIAS char (10),
	 @CLAVE varchar (50)
	 AS
	 BEGIN
		 INSERT INTO Usuarios(CodUsuarios_U,CodRubros_U, Nombre_U,Apellido_U,DNI_U,Genero_U,Telefono_U,Email_U,Direccion_U,Nacionalidad_U,CodLocalidades_U,CodProvincias_U,Clave_U,CodTipoUsuario_U,Estado_U) 
		 SELECT @CODUSUARIOS, @CODRUBROS, @NOMBRE, @APELLIDO, @DNI, @GENERO, @TELEFONO, @EMAIL, @DIRECCION, @NACIONALIDAD, @CODLOCALIDADES, @CODPROVINCIAS, @CLAVE, '2', 1;
	 END
 GO


												---	 "ELIMINAR" EMPLEADO	--

CREATE PROCEDURE[dbo].[spEliminarUsuario]
	@CODUSUARIOS char (10)
	AS
	UPDATE Usuarios SET Estado_U = 0 WHERE CodUsuarios_U = @CODUSUARIOS;
GO

CREATE PROCEDURE[dbo].[spEliminarUsuarioXDiaXHorario]
	@CODUSUARIOS char (10)
	AS
	UPDATE UsuariosXDiasXHorarios SET Estado_UXDXH = 0 WHERE CodUsuarios_UXDXH = @CODUSUARIOS;
GO


												---	 MODIFICAR EMPLEADO	--

CREATE PROCEDURE spActualizarUsuario
	 @CODUSUARIOS char (10), 
	 @CODRUBROS char (10),
	 @NOMBRE varchar (100),
	 @APELLIDO varchar (100),
	 @DNI varchar (8),
	 @GENERO varchar (30),
	 @TELEFONO varchar (20),
	 @EMAIL varchar (30),
	 @DIRECCION varchar (100),
	 @NACIONALIDAD varchar (100),
	 @CODLOCALIDAD char (10),
	 @CODPROVINCIA char (10),
	 @CLAVE varchar (50)

	AS
	BEGIN
		UPDATE Usuarios SET  CodRubros_U = @CODRUBROS, Nombre_U = @NOMBRE, 
		Apellido_U = @APELLIDO, DNI_U = @DNI, Genero_U = @GENERO,
		Telefono_U = @TELEFONO, Email_U = @EMAIL, Direccion_U = @DIRECCION, 
		Nacionalidad_U = @NACIONALIDAD, CodLocalidades_U = @CODLOCALIDAD, 
		CodProvincias_U = @CODPROVINCIA WHERE CodUsuarios_U = @CODUSUARIOS
	END
GO


CREATE PROCEDURE[dbo].[spAgregarUsuarioXDiaXHorario]
	 @CODUSUARIOS char (10), 
	 @CODDIAS char (10),
	 @CODHORARIOS char (10)
	 AS
	 BEGIN
		 INSERT INTO UsuariosXDiasXHorarios(CodUsuarios_UXDXH, CodDias_UXDXH, CodHorarios_UXDXH, Estado_UXDXH) 
		 SELECT @CODUSUARIOS, @CODDIAS,@CODHORARIOS, 1;
	 END
GO

CREATE PROCEDURE[dbo].[spEliminarUsuarioXDiaXHorarioD]
	@CODUSUARIOS char (10)
	AS
    DELETE UsuariosXDiasXHorarios WHERE CodUsuarios_UXDXH = @CODUSUARIOS;
GO



												---	 AGREGAR CLIENTE	--

CREATE PROCEDURE spAgregarCliente
	 @CODEMPRESAS_C char (10), 
	 @NOMBREEMPRESA_C varchar (100),
	 @RAZONSOCIAL_C varchar (100),
	 @TELEFONO_C varchar (20),
	 @EMAIL_C varchar (30),
	 @DIRECCION_C varchar (100),
	 @CODLOCALIDADES_U char (10),
	 @CODPROVINCIAS_U char (10)
	 AS
	 INSERT INTO Clientes(CodEmpresas_C,NombreEmpresa_C,RazonSocial_C,Telefono_C,Email_C,Direccion_C,CodLocalidades_C,CodProvincias_C, Estado_C) 
	 SELECT @CODEMPRESAS_C, @NOMBREEMPRESA_C, @RAZONSOCIAL_C, @TELEFONO_C, @EMAIL_C, @DIRECCION_C, @CODLOCALIDADES_U, @CODPROVINCIAS_U, '1';
 GO


												---	 "ELIMINAR" EMPLEADO	--

CREATE PROCEDURE[dbo].[spEliminarCliente]
	@CODEMPRESAS char (10)
	AS
	UPDATE Clientes SET Estado_C = 0 WHERE CodEmpresas_C = @CODEMPRESAS;
GO


												---	 MODIFICAR CLIENTE	--

CREATE PROCEDURE spActualizarCliente

	@CODEMPRESA char (10),
	@NOMBREEMPRESA varchar (100),
	@RAZONSOCIAL varchar (50),
	@TELEFONO varchar (20),
	@EMAIL varchar (100),
	@DIRECCION varchar (100),
	@CODLOCALIDAD char (10),
	@CODPROVINCIA char (10)

	AS
	BEGIN
		UPDATE Clientes SET  NombreEmpresa_C  = @NOMBREEMPRESA, RazonSocial_C = @RAZONSOCIAL, 
		Telefono_C = @TELEFONO, Email_C = @EMAIL, Direccion_C = @DIRECCION, CodLocalidades_C = @CODLOCALIDAD, 
		CodProvincias_C = @CODPROVINCIA WHERE CodEmpresas_C = @CODEMPRESA
	END
GO



												---	 AGREGAR TURNO	--

CREATE PROCEDURE[dbo].[spAgregarTurno]
	 @CODTURNOS char (10),
	 @CODCLIENTES char (10),
	 @CODRUBROS char (10),
	 @CODUSUARIOS char (10),
	 @CODDIAS char (10),
	 @CODHORARIOS char (10),
	 @CODFECHAS date
	 AS
	 BEGIN
		 INSERT INTO Turnos(CodTurnos_T, CodEmpresas_T, CodRubros_T, CodUsuarios_T, CodDias_T, CodHorarios_T, CodFechas_T,CodEstados_T, Estado_T) 
		 SELECT @CODTURNOS, @CODCLIENTES, @CODRUBROS, @CODUSUARIOS, @CODDIAS, @CODHORARIOS, @CODFECHAS, 'E002', 1 ;
	 END
 GO



												---	 MODIFICAR TURNO	--

CREATE PROCEDURE spActualizarTurno

	@CODTURNO char (10),
	@CODESTADO char (10),
	@OBSERVACIONES varchar (100)
	AS
	BEGIN
		UPDATE Turnos SET CodEstados_T = @CODESTADO, Observaciones_T = @OBSERVACIONES
		WHERE CodTurnos_T = @CODTURNO
	END
GO



													---	 FILTRADO	--

CREATE PROCEDURE spFiltrarTurnosPorMes
    @Mes INT,
    @Ano INT
AS
BEGIN
    SELECT  CodTurnos_T, NombreEmpresa_C, NombreDia_D, Descripcion_H,  CodFechas_T,   CodEstados_T,   Observaciones_T 
    FROM Turnos 
        INNER JOIN Clientes ON CodEmpresas_C = CodEmpresas_T 
        INNER JOIN Dias ON CodDias_D = CodDias_T 
        INNER JOIN Horarios ON CodHorarios_H = CodHorarios_T 
    WHERE  Estado_T = 1 
        AND MONTH(CodFechas_T) = @Mes 
        AND YEAR(CodFechas_T) = @Ano;
END;
GO



CREATE PROCEDURE spFiltrarTurnosPorEstadoYRangoFechas
    @Estado varchar(100),
    @MesInicio INT,
    @AnioInicio INT,
    @MesFin INT,
    @AnioFin INT
AS
BEGIN
    SELECT 
        CodTurnos_T, 
        NombreEmpresa_C, 
        NombreDia_D, 
        Descripcion_H, 
        CodFechas_T, 
        CodEstados_T, 
        Observaciones_T 
    FROM 
        Turnos 
        INNER JOIN Clientes ON CodEmpresas_C = CodEmpresas_T 
        INNER JOIN Dias ON CodDias_D = CodDias_T 
        INNER JOIN Horarios ON CodHorarios_H = CodHorarios_T 
    WHERE 
        CodEstados_T= @Estado 
        AND CodFechas_T BETWEEN 
            DATEFROMPARTS(@AnioInicio, @MesInicio, 1) AND 
            DATEFROMPARTS(@AnioFin, @MesFin, DAY(EOMONTH(DATEFROMPARTS(@AnioFin, @MesFin, 1))))
    ORDER BY CodFechas_T;
END;
GO


CREATE PROCEDURE spPorcentajeTurnosPorEstadoYRangoFechas
    @Estado varchar(100),
    @MesInicio INT,
    @AnioInicio INT,
    @MesFin INT,
    @AnioFin INT
AS
BEGIN
    DECLARE @TotalTurnos INT;
    DECLARE @TotalEstado INT;
    DECLARE @FechaInicio DATE;
    DECLARE @FechaFin DATE;

    -- Calcular las fechas de inicio y fin
    SET @FechaInicio = DATEFROMPARTS(@AnioInicio, @MesInicio, 1);
    SET @FechaFin = DATEFROMPARTS(@AnioFin, @MesFin, DAY(EOMONTH(DATEFROMPARTS(@AnioFin, @MesFin, 1))));

    -- Total de turnos en el rango de fechas
    SELECT @TotalTurnos = COUNT(*) 
    FROM Turnos
    WHERE 
        CodFechas_T BETWEEN @FechaInicio AND @FechaFin;

    -- Total de turnos en el rango de fechas y con el estado especificado
    SELECT @TotalEstado = COUNT(*) 
    FROM Turnos
    WHERE 
        CodEstados_T = @Estado 
        AND CodFechas_T BETWEEN @FechaInicio AND @FechaFin;

    -- Verificación de valores intermedios
    PRINT 'Total de Turnos: ' + CAST(@TotalTurnos AS VARCHAR);
    PRINT 'Total de Turnos con Estado: ' + CAST(@TotalEstado AS VARCHAR);

    -- Calcular el porcentaje, manejando el caso donde @TotalTurnos sea 0
    IF @TotalTurnos = 0
    BEGIN
        SELECT CAST(0 AS DECIMAL(18, 2)) AS Porcentaje;
    END
    ELSE
    BEGIN
        DECLARE @Porcentaje DECIMAL(18, 2);
        SET @Porcentaje = CAST(@TotalEstado AS DECIMAL(18, 2)) / CAST(@TotalTurnos AS DECIMAL(18, 2)) * 100;
        SELECT @Porcentaje AS Porcentaje;
    END
END;
GO



CREATE PROCEDURE ObtenerPorcentajeUsuarios
	@Tipo CHAR(10),
	@Genero VARCHAR(30)
AS
BEGIN
    DECLARE @TotalUsuarios INT;
    DECLARE @ParcialUsuario INT;
	
    -- Obtener el total de usuarios
    SELECT @TotalUsuarios = COUNT(*) FROM Usuarios;

    -- Obtener el total de gerentes
    SELECT @ParcialUsuario = COUNT(*) 
    FROM Usuarios
    WHERE CodTipoUsuario_U = @Tipo and Genero_U = @Genero and Estado_U = 1;

    -- Calcular y devolver los porcentajes
    SELECT 
        CAST((@ParcialUsuario * 100.0 / @TotalUsuarios) AS DECIMAL(5, 2)) AS PorcentajeEmpleadosOtros;
END
GO


