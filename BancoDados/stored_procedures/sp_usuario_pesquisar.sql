USE [bibliosystem]
GO
/****** Object:  StoredProcedure [dbo].[sp_usuario_pesquisar]    Script Date: 22/01/2021 11:40:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_usuario_pesquisar]
@filtro VARCHAR(10), -- nome ou cpf
@valor VARCHAR(200)
AS
BEGIN
	IF(@filtro = 'cpf')
		SELECT * FROM usuarios WHERE cpf = @valor
	ELSE
		SELECT * FROM usuarios WHERE nome LIKE '%'+ @valor +'%'
END