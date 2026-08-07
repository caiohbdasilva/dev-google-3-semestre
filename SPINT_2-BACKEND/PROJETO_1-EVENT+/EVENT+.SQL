CREATE DATABASE eventplus

USE eventplus

DROP DATABASE eventplus

SET DATEFORMAT ymd;

CREATE TABLE TIPO_USUARIO
(
    IdTipoUsuario UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    TituloUsuario VARCHAR(100) NOT NULL
)
GO
CREATE TABLE TIPO_EVENTO
(
    IdTipoEvento UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    TituloEvento VARCHAR(100) NOT NULL
)
GO
CREATE TABLE INSTITUICAO
(
    IdInstituicao UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    CNPJ VARCHAR(14) UNIQUE NOT NULL,
    NomeFantasia VARCHAR(100) NOT NULL,
    Endereco VARCHAR(100) NOT NULL,
)
GO
CREATE TABLE USUARIO
(
    IdUsuario UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    IdTipoUsuario UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TIPO_USUARIO(IdTipoUsuario),
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Senha VARCHAR(60) NOT NULL
)
GO
CREATE TABLE EVENTO
(
    IdEvento UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    IdInstituicao UNIQUEIDENTIFIER FOREIGN KEY REFERENCES INSTITUICAO(IdInstituicao),
    IdTipoEvento UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TIPO_EVENTO(IdTipoEvento),
    NomeEvento VARCHAR(100) NOT NULL,
    DescricaoEvento TEXT NOT NULL,
    DataEvento DATETIME NOT NULL,
    URLImagem VARCHAR(200)
)
GO
CREATE TABLE PRESENCA
(
    IdPresenca UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    IdUsuario UNIQUEIDENTIFIER FOREIGN KEY REFERENCES USUARIO(IdUsuario),
    IdEvento UNIQUEIDENTIFIER FOREIGN KEY REFERENCES EVENTO(IdEvento),
    Situacao BIT NOT NULL
)
GO
CREATE TABLE COMENTARIO
(
    IdComentario UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    IdEvento UNIQUEIDENTIFIER FOREIGN KEY REFERENCES EVENTO(IdEvento),
    IdUsuario UNIQUEIDENTIFIER FOREIGN KEY REFERENCES USUARIO(IdUsuario),
    DescricaoComentario VARCHAR(250) NOT NULL,
    DataComentario DATETIME NOT NULL,
    Exibe BIT NOT NULL
)



select * from EVENTO


SET DATEFORMAT ymd;


DECLARE @IdTipoUsuario1 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoUsuario2 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoUsuario3 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoUsuario4 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoUsuario5 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoUsuario6 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoUsuario7 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoUsuario8 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoUsuario9 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoUsuario10 UNIQUEIDENTIFIER = NEWID();


DECLARE @IdTipoEvento1 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoEvento2 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoEvento3 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoEvento4 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoEvento5 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoEvento6 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoEvento7 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoEvento8 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoEvento9 UNIQUEIDENTIFIER = NEWID(),
        @IdTipoEvento10 UNIQUEIDENTIFIER = NEWID();

DECLARE @IdInstituicao1 UNIQUEIDENTIFIER = NEWID(),
        @IdInstituicao2 UNIQUEIDENTIFIER = NEWID(),
        @IdInstituicao3 UNIQUEIDENTIFIER = NEWID(),
        @IdInstituicao4 UNIQUEIDENTIFIER = NEWID(),
        @IdInstituicao5 UNIQUEIDENTIFIER = NEWID(),
        @IdInstituicao6 UNIQUEIDENTIFIER = NEWID(),
        @IdInstituicao7 UNIQUEIDENTIFIER = NEWID(),
        @IdInstituicao8 UNIQUEIDENTIFIER = NEWID(),
        @IdInstituicao9 UNIQUEIDENTIFIER = NEWID(),
        @IdInstituicao10 UNIQUEIDENTIFIER = NEWID();


DECLARE @IdUsuario1 UNIQUEIDENTIFIER = NEWID(),
        @IdUsuario2 UNIQUEIDENTIFIER = NEWID(),
        @IdUsuario3 UNIQUEIDENTIFIER = NEWID(),
        @IdUsuario4 UNIQUEIDENTIFIER = NEWID(),
        @IdUsuario5 UNIQUEIDENTIFIER = NEWID(),
        @IdUsuario6 UNIQUEIDENTIFIER = NEWID(),
        @IdUsuario7 UNIQUEIDENTIFIER = NEWID(),
        @IdUsuario8 UNIQUEIDENTIFIER = NEWID(),
        @IdUsuario9 UNIQUEIDENTIFIER = NEWID(),
        @IdUsuario10 UNIQUEIDENTIFIER = NEWID();


DECLARE @IdEvento1 UNIQUEIDENTIFIER = NEWID(),
        @IdEvento2 UNIQUEIDENTIFIER = NEWID(),
        @IdEvento3 UNIQUEIDENTIFIER = NEWID(),
        @IdEvento4 UNIQUEIDENTIFIER = NEWID(),
        @IdEvento5 UNIQUEIDENTIFIER = NEWID(),
        @IdEvento6 UNIQUEIDENTIFIER = NEWID(),
        @IdEvento7 UNIQUEIDENTIFIER = NEWID(),
        @IdEvento8 UNIQUEIDENTIFIER = NEWID(),
        @IdEvento9 UNIQUEIDENTIFIER = NEWID(),
        @IdEvento10 UNIQUEIDENTIFIER = NEWID();

DECLARE @IdPresenca1 UNIQUEIDENTIFIER = NEWID(),
        @IdPresenca2 UNIQUEIDENTIFIER = NEWID(),
        @IdPresenca3 UNIQUEIDENTIFIER = NEWID(),
        @IdPresenca4 UNIQUEIDENTIFIER = NEWID(),
        @IdPresenca5 UNIQUEIDENTIFIER = NEWID(),
        @IdPresenca6 UNIQUEIDENTIFIER = NEWID(),
        @IdPresenca7 UNIQUEIDENTIFIER = NEWID(),
        @IdPresenca8 UNIQUEIDENTIFIER = NEWID(),
        @IdPresenca9 UNIQUEIDENTIFIER = NEWID(),
        @IdPresenca10 UNIQUEIDENTIFIER = NEWID();

DECLARE @IdComentario1 UNIQUEIDENTIFIER = NEWID(),
        @IdComentario2 UNIQUEIDENTIFIER = NEWID(),
        @IdComentario3 UNIQUEIDENTIFIER = NEWID(),
        @IdComentario4 UNIQUEIDENTIFIER = NEWID(),
        @IdComentario5 UNIQUEIDENTIFIER = NEWID(),
        @IdComentario6 UNIQUEIDENTIFIER = NEWID(),
        @IdComentario7 UNIQUEIDENTIFIER = NEWID(),
        @IdComentario8 UNIQUEIDENTIFIER = NEWID(),
        @IdComentario9 UNIQUEIDENTIFIER = NEWID(),
        @IdComentario10 UNIQUEIDENTIFIER = NEWID();



INSERT INTO TIPO_USUARIO (IdTipoUsuario, TituloUsuario) VALUES
(@IdTipoUsuario1, 'Administrador'),
(@IdTipoUsuario2, 'Espectador'),
(@IdTipoUsuario3, 'Palestrante'),
(@IdTipoUsuario4, 'Coordenador'),
(@IdTipoUsuario5, 'Moderador'),
(@IdTipoUsuario6, 'Suporte Técnico'),
(@IdTipoUsuario7, 'Aluno'),
(@IdTipoUsuario8, 'Professor'),
(@IdTipoUsuario9, 'Recrutador'),
(@IdTipoUsuario10, 'Organizador de Eventos');


INSERT INTO TIPO_EVENTO (IdTipoEvento, TituloEvento) VALUES
(@IdTipoEvento1, 'Palestra'),
(@IdTipoEvento2, 'Workshop'),
(@IdTipoEvento3, 'Hackathon'),
(@IdTipoEvento4, 'Bootcamp'),
(@IdTipoEvento5, 'Meetup'),
(@IdTipoEvento6, 'Webinar'),
(@IdTipoEvento7, 'Painel de Discussão'),
(@IdTipoEvento8, 'Feira de Carreiras'),
(@IdTipoEvento9, 'Minicurso'),
(@IdTipoEvento10, 'Seminário');


INSERT INTO INSTITUICAO (IdInstituicao, CNPJ, NomeFantasia, Endereco) VALUES
(@IdInstituicao1, '12345678000101', 'DevSchool Matriz', 'Av. Goiás, 1000 - São Caetano do Sul/SP'),
(@IdInstituicao2, '98765432000109', 'TechInnovate Solutions', 'Rua Amazonas, 500 - São Caetano do Sul/SP'),
(@IdInstituicao3, '11223344000155', 'CloudTech Brasil', 'Av. Paulista, 1500 - São Paulo/SP'),
(@IdInstituicao4, '22334455000166', 'DataLabs Analytics', 'Rua das Nogueiras, 200 - Santo André/SP'),
(@IdInstituicao5, '33445566000177', 'DevSchool Filial SP', 'Rua Augusta, 800 - São Paulo/SP'),
(@IdInstituicao6, '44556677000188', 'CodeHouse Software', 'Alameda Santos, 400 - São Paulo/SP'),
(@IdInstituicao7, '55667788000199', 'AI Solutions Brasil', 'Av. Kennedy, 300 - São Bernardo do Campo/SP'),
(@IdInstituicao8, '66778899000111', 'CyberSec Security', 'Rua Vergueiro, 1200 - São Paulo/SP'),
(@IdInstituicao9, '77889900000122', 'FullStack Edge', 'Rua Alegre, 150 - São Caetano do Sul/SP'),
(@IdInstituicao10, '88990011000133', 'DevPartners Recruitment', 'Av. Portugal, 450 - Santo André/SP');


INSERT INTO USUARIO (IdUsuario, IdTipoUsuario, Nome, Email, Senha) VALUES
(@IdUsuario1, @IdTipoUsuario1, 'Carlos Roque', 'carlos.roque@devschool.com.br', '$2b$10$EixZaYVK1fsbw1ZfbX3OXePaWxn96p36WQoeG6Lruj3vjPGga31lW'),
(@IdUsuario2, @IdTipoUsuario1, 'Marcos Vinícius', 'marcos.vinicius@devschool.com.br', '$2b$10$EixZaYVK1fsbw1ZfbX3OXePaWxn96p36WQoeG6Lruj3vjPGga31lW'),
(@IdUsuario3, @IdTipoUsuario3, 'Ana Silva', 'ana.silva@techinnovate.com', '$2b$10$EixZaYVK1fsbw1ZfbX3OXePaWxn96p36WQoeG6Lruj3vjPGga31lW'),
(@IdUsuario4, @IdTipoUsuario3, 'Bruno Costa', 'bruno.costa@cloudtech.com', '$2b$10$EixZaYVK1fsbw1ZfbX3OXePaWxn96p36WQoeG6Lruj3vjPGga31lW'),
(@IdUsuario5, @IdTipoUsuario2, 'Camila Oliveira', 'camila.oliveira@gmail.com', '$2b$10$EixZaYVK1fsbw1ZfbX3OXePaWxn96p36WQoeG6Lruj3vjPGga31lW'),
(@IdUsuario6, @IdTipoUsuario2, 'Diego Santos', 'diego.santos@gmail.com', '$2b$10$EixZaYVK1fsbw1ZfbX3OXePaWxn96p36WQoeG6Lruj3vjPGga31lW'),
(@IdUsuario7, @IdTipoUsuario2, 'Eduardo Lima', 'eduardo.lima@outlook.com', '$2b$10$EixZaYVK1fsbw1ZfbX3OXePaWxn96p36WQoeG6Lruj3vjPGga31lW'),
(@IdUsuario8, @IdTipoUsuario4, 'Fernanda Rocha', 'fernanda.rocha@devschool.com.br', '$2b$10$EixZaYVK1fsbw1ZfbX3OXePaWxn96p36WQoeG6Lruj3vjPGga31lW'),
(@IdUsuario9, @IdTipoUsuario7, 'Gabriel Souza', 'gabriel.souza@aluno.devschool.com.br', '$2b$10$EixZaYVK1fsbw1ZfbX3OXePaWxn96p36WQoeG6Lruj3vjPGga31lW'),
(@IdUsuario10, @IdTipoUsuario5, 'Helena Martins', 'helena.martins@devschool.com.br', '$2b$10$EixZaYVK1fsbw1ZfbX3OXePaWxn96p36WQoeG6Lruj3vjPGga31lW');


INSERT INTO EVENTO (IdEvento, IdInstituicao, IdTipoEvento, NomeEvento, DescricaoEvento, DataEvento, URLImagem) VALUES
(@IdEvento1, @IdInstituicao1, @IdTipoEvento2, 'Workshop ReactJS na Prática', 'Aprenda a construir componentes reutilizáveis e gerenciar estado com React.', '2026-03-15T14:00:00', 'https://images.unsplash.com/photo-1633356122544-f134324a6cee?w=800'),
(@IdEvento2, @IdInstituicao1, @IdTipoEvento1, 'Inteligência Artificial e Moderação com Google Cloud', 'Como utilizar a Google Cloud Natural Language API para moderação de conteúdo.', '2026-03-20T19:00:00', 'https://storage.googleapis.com/gweb-uniblog-publish-prod/images/HERO_image_IO.width-1300.jpg'),
(@IdEvento3, @IdInstituicao1, @IdTipoEvento3, 'Hackathon Event+ 2026', 'Maratona de programação para solucionar desafios da comunidade DevSchool.', '2026-04-10T08:00:00', 'https://images.unsplash.com/photo-1504384308090-c894fdcc538d?w=800'),
(@IdEvento4, @IdInstituicao5, @IdTipoEvento4, 'Bootcamp C# e Entity Framework Core', 'Imersão em desenvolvimento backend utilizando EF Core e SQL Server.', '2026-04-18T09:00:00', 'https://images.unsplash.com/photo-1555066931-4365d14bab8c?w=800'),
(@IdEvento5, @IdInstituicao2, @IdTipoEvento5, 'Meetup Arquitetura de Microsserviços', 'Discussões sobre escalabilidade, resiliência e boas práticas de arquitetura.', '2026-05-02T18:30:00', 'https://images.unsplash.com/photo-1451187580459-43490279c0fa?w=800'),
(@IdEvento6, @IdInstituicao8, @IdTipoEvento6, 'Webinar Segurança em APIs e JWT', 'Práticas essenciais de proteção e autenticação segura para aplicações web.', '2026-05-12T19:30:00', 'https://images.unsplash.com/photo-1555949963-ff9fe0c870eb?w=800'),
(@IdEvento7, @IdInstituicao10, @IdTipoEvento7, 'Painel Mulheres na Tecnologia', 'Histórias de sucesso e desafios no mercado corporativo de TI.', '2026-05-25T15:00:00', 'https://images.unsplash.com/photo-1573164713714-d95e436ab8d6?w=800'),
(@IdEvento8, @IdInstituicao1, @IdTipoEvento8, 'Feira de Carreiras DevSchool 2026', 'Conectando alunos da DevSchool a empresas recrutadoras da região.', '2026-06-01T10:00:00', 'https://images.unsplash.com/photo-1511578314322-379afb476865?w=800'),
(@IdEvento9, @IdInstituicao3, @IdTipoEvento9, 'Minicurso Docker e Containerização', 'Aprenda a empacotar e implantar suas aplicações com contêineres.', '2026-06-15T14:00:00', 'https://images.unsplash.com/photo-1605745341112-85968b19335b?w=800'),
(@IdEvento10, @IdInstituicao4, @IdTipoEvento10, 'Seminário Modelagem e Otimização SQL', 'Técnicas avançadas de modelagem lógica, física e tunagem de consultas.', '2026-06-30T09:00:00', 'https://images.unsplash.com/photo-1551288049-bebda4e38f71?w=800');


INSERT INTO PRESENCA (IdPresenca, IdUsuario, IdEvento, Situacao) VALUES
(@IdPresenca1, @IdUsuario5, @IdEvento1, 1),
(@IdPresenca2, @IdUsuario6, @IdEvento1, 1),
(@IdPresenca3, @IdUsuario7, @IdEvento2, 1),
(@IdPresenca4, @IdUsuario9, @IdEvento3, 1),
(@IdPresenca5, @IdUsuario1, @IdEvento2, 1),
(@IdPresenca6, @IdUsuario2, @IdEvento3, 1),
(@IdPresenca7, @IdUsuario3, @IdEvento5, 0),
(@IdPresenca8, @IdUsuario4, @IdEvento4, 1),
(@IdPresenca9, @IdUsuario5, @IdEvento6, 1),
(@IdPresenca10, @IdUsuario9, @IdEvento8, 1);

INSERT INTO COMENTARIO (IdComentario, IdEvento, IdUsuario, DescricaoComentario, DataComentario, Exibe) VALUES
(@IdComentario1, @IdEvento1, @IdUsuario5, 'Workshop incrível! A didática sobre os componentes React foi excelente.', '2026-03-15T17:30:00', 1),
(@IdComentario2, @IdEvento1, @IdUsuario6, 'Excelente evento, tirou todas as minhas dúvidas sobre hooks!', '2026-03-15T18:00:00', 1),
(@IdComentario3, @IdEvento2, @IdUsuario7, 'Muito interessante a integração com a API da Google Cloud para moderação.', '2026-03-20T21:15:00', 1),
(@IdComentario4, @IdEvento3, @IdUsuario9, 'O Hackathon foi muito desafiador e aprendi muito trabalhando em equipe.', '2026-04-10T20:00:00', 1),
(@IdComentario5, @IdEvento4, @IdUsuario4, 'Conteúdo de alta qualidade sobre ORM e boas práticas de banco de dados.', '2026-04-18T17:00:00', 1),
(@IdComentario6, @IdEvento5, @IdUsuario5, 'Ótimas discussões sobre padrões de arquitetura de microsserviços.', '2026-05-02T21:00:00', 1),
(@IdComentario7, @IdEvento6, @IdUsuario6, 'A aula sobre tokens JWT e boas práticas de segurança foi sensacional.', '2026-05-12T21:00:00', 1),
(@IdComentario8, @IdEvento7, @IdUsuario5, 'Painel inspirador! Muito importante ver profissionais qualificadas compartilhando experiências.', '2026-05-25T17:30:00', 1),
(@IdComentario9, @IdEvento8, @IdUsuario9, 'Consegui realizar entrevistas com duas empresas parceiras da DevSchool!', '2026-06-01T16:00:00', 1),
(@IdComentario10, @IdEvento2, @IdUsuario7, 'Este evento foi horrível e uma perda de tempo total!', '2026-03-20T21:30:00', 0);










































































