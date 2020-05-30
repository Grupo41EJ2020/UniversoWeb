CREATE DATABASE PIADS

CREATE TABLE Empleado(
	IdEmpleado int primary key IDENTITY(1,1),
	Nombre nvarchar(100),
	Direccion nvarchar(100))

CREATE TABLE Tema(
	IdTema int primary key IDENTITY(1,1),
	Nombre nvarchar(100))

CREATE TABLE Video(
	IdVideo int  primary key IDENTITY(1,1),
	Nombre nvarchar(200),
	Url nvarchar(100),
	FechaPublicacion datetime)

CREATE TABLE Curso(
	IdCurso int primary key IDENTITY(1,1),
	Descripcion nvarchar(200),
	IdEmpleado int,
	constraint fk_idEmp FOREIGN KEY(IdEmpleado) REFERENCES Empleado(IdEmpleado)
)

CREATE TABLE Curso_Tema(
	IdCT int  primary key IDENTITY(1,1),
	IdCurso int,
	IdTema int,
	constraint fk_idCurso FOREIGN KEY(IdCurso) REFERENCES Curso(IdCurso),
	constraint fk_idTema FOREIGN KEY(IdTema) REFERENCES Tema(IdTema),
)

CREATE TABLE Curso_Tema_Video(
	IdCTV int primary key IDENTITY(1,1),
	IdCT int,
	IdVideo int,
	constraint fk_idCT FOREIGN KEY(IdCT) REFERENCES Curso_Tema(IdCT),
	constraint fk_idVideo FOREIGN KEY(IdVideo) REFERENCES Video(IdVideo),
)

--STORED PROCEDURE DE VIDEO
CREATE PROCEDURE sp_Agregar_Video
@Nombre nvarchar(50),
@Url nvarchar(100),
@FechaPublicacion datetime
AS
BEGIN
INSERT INTO Video(Nombre,Url,FechaPublicacion) VALUES (@Nombre,@Url,@FechaPublicacion);
END;

CREATE PROCEDURE sp_ConsultarTodo_Video
AS
BEGIN
SELECT*FROM Video
END;

CREATE PROCEDURE sp_ConsultarUno_Video
@IdVideo int
AS
BEGIN
SELECT*FROM Video WHERE IdVideo = @IdVideo
END;

CREATE PROCEDURE sp_Eliminar_Video
@IdVideo int
AS
BEGIN
DELETE FROM Video WHERE IdVideo = @IdVideo;
END;

CREATE PROCEDURE sp_Actualizar_Video
@IdVideo int,
@Nombre nvarchar(200),
@Url nvarchar(100),
@FechaPublicacion DateTime
AS
BEGIN
UPDATE Video SET Nombre=@Nombre, Url=@Url, FechaPublicacion=@FechaPublicacion Where IdVideo=@IdVideo
END;

--STORED PROCEDURES DE TEMA

CREATE PROCEDURE sp_Agregar_Tema
@Nombre nvarchar(100)
AS
BEGIN
INSERT INTO Tema(Nombre) VALUES (@Nombre);
END;

CREATE PROCEDURE sp_ConsultarTodo_Tema
AS
BEGIN
SELECT*FROM Tema
END;

CREATE PROCEDURE sp_ConsultarUno_Tema
@IdTema int
AS
BEGIN
SELECT*FROM Tema WHERE IdTema = @IdTema
END;

CREATE PROCEDURE sp_Eliminar_Tema
@IdTema int
AS
BEGIN
DELETE FROM Tema WHERE IdTema = @IdTema;
END;

CREATE PROCEDURE sp_Actualizar_Tema
@IdTema int,
@Nombre nvarchar(100)
AS
BEGIN
UPDATE Tema SET Nombre=@Nombre Where IdTema=@IdTema
END;

--STORED PROCEDURES DE Curso_Tema_Video

CREATE PROCEDURE sp_Agregar_CTV
@IdCT int,
@IdVideo int
AS
BEGIN
INSERT INTO Curso_Tema_Video(IdCT,IdVideo) VALUES (@IdCT,@IdVideo);
END;

CREATE PROCEDURE sp_ConsultarTodo_CTV
AS
BEGIN
SELECT*FROM Curso_Tema_Video
END;

CREATE PROCEDURE sp_ConsultarUno_CTV
@IdCTV int
AS
BEGIN
SELECT*FROM Curso_Tema_Video WHERE IdCTV = @IdCTV
END;

CREATE PROCEDURE sp_Eliminar_CTV
@IdCTV int
AS
BEGIN
DELETE FROM Curso_Tema_Video WHERE IdCTV = @IdCTV;
END;

CREATE PROCEDURE sp_Actualizar_CTV
@IdCTV int,
@IdCT int,
@IdVideo int
AS
BEGIN
UPDATE Curso_Tema_Video SET IdCT=@IdCT, IdVideo=@IdVideo Where IdCTV = @IdCTV
END;

--STORED PROCEDURE DE CURSO
CREATE PROCEDURE sp_Agregar_Curso
@Descripcion nvarchar(200),
@IdEmpleado int
AS
BEGIN
INSERT INTO Curso(Descripcion,IdEmpleado) VALUES (@Descripcion,@IdEmpleado);
END;

CREATE PROCEDURE sp_ConsultarTodo_Curso
AS
BEGIN
SELECT*FROM Curso
END;

CREATE PROCEDURE sp_ConsultarUno_Curso
@IdCurso int
AS
BEGIN
SELECT*FROM Curso WHERE IdCurso = @IdCurso
END;

CREATE PROCEDURE sp_Eliminar_Curso
@IdCurso int
AS
BEGIN
DELETE FROM Curso WHERE IdCurso = @IdCurso;
END;

CREATE PROCEDURE sp_Actualizar_Curso
@IdCurso int,
@Descripcion nvarchar(200),
@IdEmpleado int
AS
BEGIN
UPDATE Curso SET Descripcion=@Descripcion, IdEmpleado=@IdEmpleado Where IdCurso=@IdCurso
END;

--STORED PROCEDURE DE CURSO_TEMA
CREATE PROCEDURE sp_Agregar_CT
@IdCurso int,
@IdTema int
AS
BEGIN
INSERT INTO Curso_Tema(IdCurso,IdTema) VALUES (@IdCurso,@IdTema);
END;

CREATE PROCEDURE sp_ConsultarTodo_CT
AS
BEGIN
SELECT*FROM Curso_Tema
END;

CREATE PROCEDURE sp_ConsultarUno_CT
@IdCT int 
AS
BEGIN
SELECT*FROM Curso_Tema WHERE IdCT = @IdCT
END;

CREATE PROCEDURE sp_Eliminar_CT
@IdCT int
AS
BEGIN
DELETE FROM Curso_Tema WHERE IdCT = @IdCT;
END;

CREATE PROCEDURE sp_Actualizar_CT
@IdCT int,
@IdCurso int,
@IdTema int
AS
BEGIN
UPDATE Curso_Tema SET IdCurso=@IdCurso, IdTema=@IdTema Where IdCT=@IdCT
END;

--STORED PROCEDURE DE EMPLEADO
CREATE PROCEDURE sp_Agregar_Empleado
@Nombre nvarchar(100),
@Direccion nvarchar(100)
AS
BEGIN
INSERT INTO Empleado(Nombre,Direccion) VALUES (@Nombre,@Direccion);
END;

CREATE PROCEDURE sp_ConsultarTodo_Empleado
AS
BEGIN
SELECT*FROM Empleado
END;

CREATE PROCEDURE sp_ConsultarUno_Empleado
@IdEmpleado int 
AS
BEGIN
SELECT*FROM Empleado WHERE IdEmpleado = @IdEmpleado
END;

CREATE PROCEDURE sp_Eliminar_Empleado
@IdEmpleado int
AS
BEGIN
DELETE FROM Empleado WHERE IdEmpleado = @IdEmpleado;
END;

CREATE PROCEDURE sp_Actualizar_Empleado
@IdEmpleado int,
@Nombre nvarchar(100),
@Direccion nvarchar(100)
AS
BEGIN
UPDATE Empleado SET Nombre=@Nombre, Direccion=@Direccion Where IdEmpleado=@IdEmpleado
END;

CREATE PROCEDURE sp_Actualizar_Empleados
@IdEmpleado int,
@Nombre nvarchar(100),
@Direccion nvarchar(100)
AS
BEGIN
UPDATE Empleado SET Nombre=@Nombre, Direccion=@Direccion Where IdEmpleado=@IdEmpleado
END;