CREATE DATABASE metalurgica
GO
USE metalurgica
GO


CREATE TABLE setor(
    Id_setor UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    Nome VARCHAR (100)
);

CREATE TABLE maquina(
    Id_Maquina UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    Nome VARCHAR (100),
    Id_setor UNIQUEIDENTIFIER FOREIGN KEY REFERENCES setor(Id_setor),
);

CREATE TABLE OS(
    Id_OS UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    Data_Abertura DATE,
    Problema_Relatado VARCHAR(100),
    Id_Maquina UNIQUEIDENTIFIER FOREIGN KEY REFERENCES maquina(Id_Maquina)
);

CREATE TABLE Tecnicos(
    Id_Tecnicos UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    Nome VARCHAR(100),
    Especialidade VARCHAR(50)
);

CREATE TABLE OS_Tecnicos(
    Id_OS_Tecnico UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    Id_OS UNIQUEIDENTIFIER FOREIGN KEY REFERENCES OS(Id_OS),
    Id_Tecnicos UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Tecnicos(Id_Tecnicos)
);

CREATE TABLE Pecas(
    Id_Peca UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    Nome_Peca VARCHAR(100),
    Preco_unitario DECIMAL,
    Codigo_ref_pecas VARCHAR(50)
);

CREATE TABLE OS_Pecas(
    Id_OS_Pecas UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    Id_OS UNIQUEIDENTIFIER FOREIGN KEY REFERENCES OS(Id_OS),
    Id_Peca UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Pecas(Id_Peca),
    Quantidade INT NOT NULL,
    Preco_Total DECIMAL
);

DECLARE @IdSetorProducao UNIQUEIDENTIFIER = NEWID();
DECLARE @IdSetorEmbalagem UNIQUEIDENTIFIER = NEWID();

DECLARE @IdMaquinaTorno UNIQUEIDENTIFIER = NEWID();
DECLARE @IdMaquinaEsteira UNIQUEIDENTIFIER = NEWID();

DECLARE @IdTecnicoCarlos UNIQUEIDENTIFIER = NEWID();
DECLARE @IdTecnicoAna UNIQUEIDENTIFIER = NEWID();

DECLARE @IdPecaMotor UNIQUEIDENTIFIER = NEWID();
DECLARE @IdPecaFiltro UNIQUEIDENTIFIER = NEWID();

DECLARE @IdOS1 UNIQUEIDENTIFIER = NEWID();
DECLARE @IdOS2 UNIQUEIDENTIFIER = NEWID();


INSERT INTO setor (Id_setor, Nome) 
VALUES 
(@IdSetorProducao, 'Produção'),
(@IdSetorEmbalagem, 'Embalagem');

INSERT INTO maquina (Id_Maquina, Nome, Id_setor) 
VALUES 
(@IdMaquinaTorno, 'Torno CNC', @IdSetorProducao),
(@IdMaquinaEsteira, 'Esteira Transportadora', @IdSetorEmbalagem);

INSERT INTO Tecnicos (Id_Tecnicos, Nome, Especialidade) 
VALUES 
(@IdTecnicoCarlos, 'Carlos Silva', 'Mecânica'),
(@IdTecnicoAna, 'Ana Souza', 'Eletrônica');

INSERT INTO Pecas (Id_Peca, Nome_Peca, Preco_unitario, Codigo_ref_pecas) 
VALUES 
(@IdPecaMotor, 'Motor de Passo', 1500.00, 'MT-01'),
(@IdPecaFiltro, 'Filtro de Óleo', 45.00, 'FL-02');


INSERT INTO OS (Id_OS, Data_Abertura, Problema_Relatado, Id_Maquina) 
VALUES 
(@IdOS1, '2023-10-15', 'Troca do motor principal', @IdMaquinaTorno),
(@IdOS2, '2023-10-16', 'Vazamento de óleo', @IdMaquinaEsteira);

INSERT INTO OS_Tecnicos (Id_OS_Tecnico, Id_OS, Id_Tecnicos) 
VALUES 
(NEWID(), @IdOS1, @IdTecnicoCarlos), -- Carlos trabalhando na OS1
(NEWID(), @IdOS1, @IdTecnicoAna),    -- Ana também trabalhando na OS1 (Em dupla)
(NEWID(), @IdOS2, @IdTecnicoCarlos); -- Carlos trabalhando sozinho na OS2

INSERT INTO OS_Pecas (Id_OS_Pecas, Id_OS, Id_Peca, Quantidade, Preco_Total) 
VALUES 
(NEWID(), @IdOS1, @IdPecaMotor, 1, 1500.00), -- 1 Motor usado na OS1
(NEWID(), @IdOS2, @IdPecaFiltro, 2, 90.00);  -- 2 Filtros usados na OS2 (2 * 45.00)


