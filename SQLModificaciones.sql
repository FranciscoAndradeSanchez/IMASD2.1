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
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spTemasRelacionados_Detalle	
	 @filtro AS varchar(100)
AS
BEGIN
	SELECT * FROM Temas_Relacionados 
	WHERE Nombre_Proyecto Like '%'+@filtro+'%' or Titulo  Like '%'+@filtro+'%' or Institucion  Like '%'+@filtro+'%'
END
GO

-------------------------------------------------

exec spTemasRelacionados_Detalle 'm'