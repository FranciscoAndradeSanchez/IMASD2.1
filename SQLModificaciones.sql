CREATE TABLE Temas_Relacionados
(
	id_tema int IDENTITY Not null,
	Nombre_Proyecto varchar(max) not null,
	Institucion Varchar(250) not null,
	Titulo varchar(250) not null,
	link varchar(max),
	constraint pk_tema primary key(id_tema)
)
---------------------------
CREATE PROCEDURE spTemasRelacionados_Detalle	
	 @filtro AS varchar(100)
AS
BEGIN
	SELECT * FROM Temas_Relacionados 
	WHERE Nombre_Proyecto Like '%'+@filtro+'%' or Titulo  Like '%'+@filtro+'%' or Institucion  Like '%'+@filtro+'%'
END
GO

-------------------------------------------------
CREATE PROCEDURE spTemasRelacionados_Delete
(
	@id_tema int
)
AS
BEGIN
	SET NOCOUNT ON;
  DELETE FROM Temas_Relacionados WHERE ((id_tema = @id_tema))
END
GO

-----------------------------------------------------------
CREATE PROCEDURE spTemasRelacionados_Insert
(
	@Nombre_Proyecto as varchar(300),
	@Institucion As varchar(300),
	@Titulo As varchar(300),
	@link As varchar(Max)
)
AS
BEGIN
	SET NOCOUNT ON;
INSERT INTO Temas_Relacionados
  (Nombre_Proyecto,Institucion,Titulo,link)
     VALUES
	 (@Nombre_Proyecto, @Institucion,@Titulo,@link)
END
GO
--------------------------------------------------------------
CREATE PROCEDURE spTemasRelacionados_Update
(
	@id_tema as int,
	@Nombre_Proyecto as varchar(300),
	@Institucion As varchar(300),
	@Titulo As varchar(300),
	@link As varchar(Max)
)
AS
BEGIN
SET NOCOUNT ON;
UPDATE Temas_Relacionados
   SET Nombre_Proyecto = @Nombre_Proyecto,
       Institucion = @Institucion,
       Titulo = @Titulo,
	   link = @link
 WHERE id_tema = @id_tema

END
GO

-------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE TemasRelacionados_CuentaTotal
AS
BEGIN
	SET NOCOUNT ON;
	SELECT COUNT(id_tema) FROM Temas_Relacionados
END
GO
---------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE TemasRelacionados_CuentaTotalFiltro
(
	@filtro as varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT COUNT(id_tema) FROM Temas_Relacionados
	WHERE id_tema LIKE '%'+@filtro+'%' or  Nombre_Proyecto Like '%'+@filtro+'%' or Titulo  Like '%'+@filtro+'%' or Institucion  Like '%'+@filtro+'%'
END
GO
