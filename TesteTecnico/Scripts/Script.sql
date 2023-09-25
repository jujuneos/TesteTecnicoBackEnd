CREATE DATABASE TesteTecnicoDB;

CREATE TABLE TesteTecnicoDB.dbo.Escolaridade(
	IdEscolaridade INT IDENTITY(1,1) PRIMARY KEY,
	NomeEscolaridade VARCHAR(40)
);

CREATE TABLE TesteTecnicoDB.dbo.Usuario(
	IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
	Nome VARCHAR(20) NOT NULL,
	Sobrenome VARCHAR(100) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	DataNascimento DATE NOT NULL,
	IdEscolaridade INT NOT NULL,
	FOREIGN KEY(IdEscolaridade) REFERENCES TesteTecnicoDB.dbo.Escolaridade(IdEscolaridade)
);

INSERT INTO TesteTecnicoDB.dbo.Escolaridade(NomeEscolaridade) VALUES('Infantil');
INSERT INTO TesteTecnicoDB.dbo.Escolaridade(NomeEscolaridade) VALUES('Fundamental');
INSERT INTO TesteTecnicoDB.dbo.Escolaridade(NomeEscolaridade) VALUES('Médio');
INSERT INTO TesteTecnicoDB.dbo.Escolaridade(NomeEscolaridade) VALUES('Superior');

SELECT TOP (5) * FROM TesteTecnicoDB.dbo.Usuario WHERE IdEscolaridade = 4;