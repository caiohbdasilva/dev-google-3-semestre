CREATE DATABASE bolosdojacquin

USE bolosdojacquin

CREATE TABLE Usuario(
    IdUsuario UNIQUEIDENTIFIER DEFAULT NEWID () PRIMARY KEY,
    NomeUsuario NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Senha VARCHAR(60) NOT NULL,
    Perfil VARCHAR (60) NOT NULL,
    Situacao VARCHAR(60) NOT NULL,
    DataCadastro DATETIME NOT NULL
)

CREATE TABLE Categoria(
    IdCategoria UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    NomeCategoria VARCHAR(60) NOT NULL UNIQUE
)

CREATE TABLE Produto(
    IdProduto UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    IdCategoria UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Categoria(IdCategoria),
    NomeProduto VARCHAR(100) NOT NULL,
    Preco DECIMAL(10,2) NOT NULL,
    EnderecoImagem VARCHAR(250) NOT NULL,
    DescricaoCurta VARCHAR(50) NOT NULL,
    DescricaoLonga VARCHAR(200) NOT NULL,
    Disponibilidade INT NOT NULL,
    Situacao BIT NOT NULL
)

CREATE TABLE Avaliacao(
    IdAvaliacao UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    IdUsuario UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Usuario(IdUsuario),
    IdProduto UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Produto(IdProduto),
    Nota INT NOT NULL,
    Comentario VARCHAR(250),
    DataComentario DATETIME NOT NULL,
    DataAlteracao DATETIME,
    Situacao BIT NOT NULL,
    MotivoOcultacao VARCHAR(250),
    CONSTRAINT UQ_Usuario_Produto UNIQUE (IdUsuario, IdProduto)
)