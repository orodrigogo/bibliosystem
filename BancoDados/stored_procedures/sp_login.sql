CREATE PROCEDURE sp_login
@email VARCHAR(200),
@senha VARCHAR(50)
AS
BEGIN
	SELECT * FROM usuarios
	WHERE email = @email AND senha = @senha
END

