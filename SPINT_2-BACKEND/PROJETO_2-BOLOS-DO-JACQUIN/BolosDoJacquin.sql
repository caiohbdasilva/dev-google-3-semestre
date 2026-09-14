CREATE DATABASE bolosdojacquin

GO

USE bolosdojacquin

GO

CREATE TABLE TipoUsuario(
    IdTipoUsuario UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    TipoUsuario VARCHAR(60) NOT NULL,
    Descricao VARCHAR(100) NOT NULL,
    DataCadastro DATETIME NOT NULL
)

GO

CREATE TABLE Usuario(
    IdUsuario UNIQUEIDENTIFIER DEFAULT NEWID () PRIMARY KEY,
    IdTipoUsuario UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario),
    NomeUsuario VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Senha VARCHAR(60) NOT NULL,
    Situacao VARCHAR(60) NOT NULL,
    DataCadastro DATETIME NOT NULL
)

GO

CREATE TABLE Categoria(
    IdCategoria UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    NomeCategoria VARCHAR(60) NOT NULL UNIQUE,
    NCM VARCHAR(8) NOT NULL,
    DataCadastro DATETIME NOT NULL,
    DataAtualizacao DATETIME
)

GO

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

GO

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

DROP DATABASE bolosdojacquin