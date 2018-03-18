
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/13/2018 22:31:05
-- Generated from EDMX file: C:\Prisma\WEB\PrismaWEB\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PrismaWEBDesenv];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Bairros_Cidades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bairros] DROP CONSTRAINT [FK_Bairros_Cidades];
GO
IF OBJECT_ID(N'[dbo].[FK_Candidatocargo_Cargos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Candidatocargo] DROP CONSTRAINT [FK_Candidatocargo_Cargos];
GO
IF OBJECT_ID(N'[dbo].[FK_Candidatocargo_Pessoas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Candidatocargo] DROP CONSTRAINT [FK_Candidatocargo_Pessoas];
GO
IF OBJECT_ID(N'[dbo].[FK_Cidades_Estados]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cidades] DROP CONSTRAINT [FK_Cidades_Estados];
GO
IF OBJECT_ID(N'[dbo].[FK_Estados_Paises]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Estados] DROP CONSTRAINT [FK_Estados_Paises];
GO
IF OBJECT_ID(N'[dbo].[FK_Favoritos_PessoasCandidato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Favoritos] DROP CONSTRAINT [FK_Favoritos_PessoasCandidato];
GO
IF OBJECT_ID(N'[dbo].[FK_Favoritos_PessoasUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Favoritos] DROP CONSTRAINT [FK_Favoritos_PessoasUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Logradouros_Bairros]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Logradouros] DROP CONSTRAINT [FK_Logradouros_Bairros];
GO
IF OBJECT_ID(N'[dbo].[FK_Pessoas_Bairros]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pessoas] DROP CONSTRAINT [FK_Pessoas_Bairros];
GO
IF OBJECT_ID(N'[dbo].[FK_Pessoas_Cidades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pessoas] DROP CONSTRAINT [FK_Pessoas_Cidades];
GO
IF OBJECT_ID(N'[dbo].[FK_Pessoas_Estados]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pessoas] DROP CONSTRAINT [FK_Pessoas_Estados];
GO
IF OBJECT_ID(N'[dbo].[FK_Pessoas_Logradouros]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pessoas] DROP CONSTRAINT [FK_Pessoas_Logradouros];
GO
IF OBJECT_ID(N'[dbo].[FK_Pessoas_Paises]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pessoas] DROP CONSTRAINT [FK_Pessoas_Paises];
GO
IF OBJECT_ID(N'[dbo].[FK_Presidentes_PessoasCandidato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Presidentes] DROP CONSTRAINT [FK_Presidentes_PessoasCandidato];
GO
IF OBJECT_ID(N'[dbo].[FK_Presidentes_PessoasVice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Presidentes] DROP CONSTRAINT [FK_Presidentes_PessoasVice];
GO
IF OBJECT_ID(N'[dbo].[FK_Votocandidatolei_Leis]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Votocandidatolei] DROP CONSTRAINT [FK_Votocandidatolei_Leis];
GO
IF OBJECT_ID(N'[dbo].[FK_Votocandidatolei_Pessoas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Votocandidatolei] DROP CONSTRAINT [FK_Votocandidatolei_Pessoas];
GO
IF OBJECT_ID(N'[dbo].[FK_Votos_PessoasCandidato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Votos] DROP CONSTRAINT [FK_Votos_PessoasCandidato];
GO
IF OBJECT_ID(N'[dbo].[FK_Votos_PessoasUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Votos] DROP CONSTRAINT [FK_Votos_PessoasUsuario];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bairros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bairros];
GO
IF OBJECT_ID(N'[dbo].[Candidatocargo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Candidatocargo];
GO
IF OBJECT_ID(N'[dbo].[Cargos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cargos];
GO
IF OBJECT_ID(N'[dbo].[Cidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cidades];
GO
IF OBJECT_ID(N'[dbo].[Estados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estados];
GO
IF OBJECT_ID(N'[dbo].[Favoritos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Favoritos];
GO
IF OBJECT_ID(N'[dbo].[Leis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Leis];
GO
IF OBJECT_ID(N'[dbo].[Logradouros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Logradouros];
GO
IF OBJECT_ID(N'[dbo].[Paises]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Paises];
GO
IF OBJECT_ID(N'[dbo].[Pessoas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pessoas];
GO
IF OBJECT_ID(N'[dbo].[Presidentes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Presidentes];
GO
IF OBJECT_ID(N'[dbo].[Votocandidatolei]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Votocandidatolei];
GO
IF OBJECT_ID(N'[dbo].[Votos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Votos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bairros'
CREATE TABLE [dbo].[Bairros] (
    [Id] int  NOT NULL,
    [Nome] varchar(120)  NOT NULL,
    [Cidade] int  NOT NULL
);
GO

-- Creating table 'Candidatocargo'
CREATE TABLE [dbo].[Candidatocargo] (
    [Id] int  NOT NULL,
    [Candidato_Id] int  NOT NULL,
    [Cargo_Id] int  NOT NULL,
    [DataCriacao] datetime  NULL
);
GO

-- Creating table 'Cargos'
CREATE TABLE [dbo].[Cargos] (
    [Id] int  NOT NULL,
    [Nome] varchar(60)  NOT NULL,
    [Descricao] varchar(420)  NOT NULL,
    [DataCraicao] datetime  NULL,
    [DataAlteracao] datetime  NULL
);
GO

-- Creating table 'Cidades'
CREATE TABLE [dbo].[Cidades] (
    [Id] int  NOT NULL,
    [Nome] varchar(120)  NULL,
    [Estado] int  NULL
);
GO

-- Creating table 'Estados'
CREATE TABLE [dbo].[Estados] (
    [Id] int  NOT NULL,
    [Nome] varchar(75)  NULL,
    [Uf] varchar(5)  NULL,
    [Pais] int  NULL
);
GO

-- Creating table 'Favoritos'
CREATE TABLE [dbo].[Favoritos] (
    [Id] int  NOT NULL,
    [Usuario_Id] int  NULL,
    [Candidato_Id] int  NOT NULL,
    [DataCriacao] datetime  NULL
);
GO

-- Creating table 'Leis'
CREATE TABLE [dbo].[Leis] (
    [Id] int  NOT NULL,
    [Numero] varchar(15)  NOT NULL,
    [Nome] varchar(60)  NOT NULL,
    [Descricao] varchar(max)  NOT NULL
);
GO

-- Creating table 'Logradouros'
CREATE TABLE [dbo].[Logradouros] (
    [Id] int  NOT NULL,
    [Nome] varchar(120)  NOT NULL,
    [Bairro] int  NOT NULL
);
GO

-- Creating table 'Paises'
CREATE TABLE [dbo].[Paises] (
    [Id] int  NOT NULL,
    [Nome] varchar(60)  NULL,
    [Sigla] varchar(10)  NULL
);
GO

-- Creating table 'Pessoas'
CREATE TABLE [dbo].[Pessoas] (
    [Id] int  NOT NULL,
    [Nome] varchar(60)  NULL,
    [DataNascimento] datetime  NULL,
    [Cpf] varchar(11)  NULL,
    [Foto] varchar(max)  NULL,
    [DataCriacao] datetime  NULL,
    [DataAlteracao] datetime  NULL,
    [Ativo] int  NULL,
    [Email] varchar(60)  NULL,
    [TelefoneFixo] varchar(12)  NULL,
    [TelefoneMovel] varchar(12)  NULL,
    [Endereco] varchar(60)  NULL,
    [Pais_Id] int  NULL,
    [Estado_Id] int  NULL,
    [Cidade_Id] int  NULL,
    [Bairro_Id] int  NULL,
    [Logradouro_Id] int  NULL,
    [Cep] varchar(8)  NULL,
    [Numero] varchar(6)  NULL,
    [Complemento] varchar(60)  NULL,
    [Tipo] int  NULL
);
GO

-- Creating table 'Presidentes'
CREATE TABLE [dbo].[Presidentes] (
    [Id] int  NOT NULL,
    [Candidato_Id] int  NULL,
    [Vice_Id] int  NULL,
    [DataCriacao] datetime  NULL,
    [DataAlteracao] datetime  NULL
);
GO

-- Creating table 'Votocandidatolei'
CREATE TABLE [dbo].[Votocandidatolei] (
    [Id] int  NOT NULL,
    [Candidato_Id] int  NOT NULL,
    [Lei_Id] int  NOT NULL,
    [Votou] int  NOT NULL,
    [DataCriacao] datetime  NULL
);
GO

-- Creating table 'Votos'
CREATE TABLE [dbo].[Votos] (
    [Id] int  NOT NULL,
    [Usuario_Id] int  NOT NULL,
    [Candidato_Id] int  NOT NULL,
    [DataCriacao] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Bairros'
ALTER TABLE [dbo].[Bairros]
ADD CONSTRAINT [PK_Bairros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Candidatocargo'
ALTER TABLE [dbo].[Candidatocargo]
ADD CONSTRAINT [PK_Candidatocargo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cargos'
ALTER TABLE [dbo].[Cargos]
ADD CONSTRAINT [PK_Cargos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cidades'
ALTER TABLE [dbo].[Cidades]
ADD CONSTRAINT [PK_Cidades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Estados'
ALTER TABLE [dbo].[Estados]
ADD CONSTRAINT [PK_Estados]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Favoritos'
ALTER TABLE [dbo].[Favoritos]
ADD CONSTRAINT [PK_Favoritos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Leis'
ALTER TABLE [dbo].[Leis]
ADD CONSTRAINT [PK_Leis]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Logradouros'
ALTER TABLE [dbo].[Logradouros]
ADD CONSTRAINT [PK_Logradouros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Paises'
ALTER TABLE [dbo].[Paises]
ADD CONSTRAINT [PK_Paises]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pessoas'
ALTER TABLE [dbo].[Pessoas]
ADD CONSTRAINT [PK_Pessoas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Presidentes'
ALTER TABLE [dbo].[Presidentes]
ADD CONSTRAINT [PK_Presidentes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Votocandidatolei'
ALTER TABLE [dbo].[Votocandidatolei]
ADD CONSTRAINT [PK_Votocandidatolei]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Votos'
ALTER TABLE [dbo].[Votos]
ADD CONSTRAINT [PK_Votos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Cidade] in table 'Bairros'
ALTER TABLE [dbo].[Bairros]
ADD CONSTRAINT [FK_Bairros_Cidades]
    FOREIGN KEY ([Cidade])
    REFERENCES [dbo].[Cidades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Bairros_Cidades'
CREATE INDEX [IX_FK_Bairros_Cidades]
ON [dbo].[Bairros]
    ([Cidade]);
GO

-- Creating foreign key on [Bairro] in table 'Logradouros'
ALTER TABLE [dbo].[Logradouros]
ADD CONSTRAINT [FK_Logradouros_Bairros]
    FOREIGN KEY ([Bairro])
    REFERENCES [dbo].[Bairros]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Logradouros_Bairros'
CREATE INDEX [IX_FK_Logradouros_Bairros]
ON [dbo].[Logradouros]
    ([Bairro]);
GO

-- Creating foreign key on [Bairro_Id] in table 'Pessoas'
ALTER TABLE [dbo].[Pessoas]
ADD CONSTRAINT [FK_Pessoas_Bairros]
    FOREIGN KEY ([Bairro_Id])
    REFERENCES [dbo].[Bairros]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pessoas_Bairros'
CREATE INDEX [IX_FK_Pessoas_Bairros]
ON [dbo].[Pessoas]
    ([Bairro_Id]);
GO

-- Creating foreign key on [Cargo_Id] in table 'Candidatocargo'
ALTER TABLE [dbo].[Candidatocargo]
ADD CONSTRAINT [FK_Candidatocargo_Cargos]
    FOREIGN KEY ([Cargo_Id])
    REFERENCES [dbo].[Cargos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Candidatocargo_Cargos'
CREATE INDEX [IX_FK_Candidatocargo_Cargos]
ON [dbo].[Candidatocargo]
    ([Cargo_Id]);
GO

-- Creating foreign key on [Candidato_Id] in table 'Candidatocargo'
ALTER TABLE [dbo].[Candidatocargo]
ADD CONSTRAINT [FK_Candidatocargo_Pessoas]
    FOREIGN KEY ([Candidato_Id])
    REFERENCES [dbo].[Pessoas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Candidatocargo_Pessoas'
CREATE INDEX [IX_FK_Candidatocargo_Pessoas]
ON [dbo].[Candidatocargo]
    ([Candidato_Id]);
GO

-- Creating foreign key on [Estado] in table 'Cidades'
ALTER TABLE [dbo].[Cidades]
ADD CONSTRAINT [FK_Cidades_Estados]
    FOREIGN KEY ([Estado])
    REFERENCES [dbo].[Estados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cidades_Estados'
CREATE INDEX [IX_FK_Cidades_Estados]
ON [dbo].[Cidades]
    ([Estado]);
GO

-- Creating foreign key on [Cidade_Id] in table 'Pessoas'
ALTER TABLE [dbo].[Pessoas]
ADD CONSTRAINT [FK_Pessoas_Cidades]
    FOREIGN KEY ([Cidade_Id])
    REFERENCES [dbo].[Cidades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pessoas_Cidades'
CREATE INDEX [IX_FK_Pessoas_Cidades]
ON [dbo].[Pessoas]
    ([Cidade_Id]);
GO

-- Creating foreign key on [Pais] in table 'Estados'
ALTER TABLE [dbo].[Estados]
ADD CONSTRAINT [FK_Estados_Paises]
    FOREIGN KEY ([Pais])
    REFERENCES [dbo].[Paises]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Estados_Paises'
CREATE INDEX [IX_FK_Estados_Paises]
ON [dbo].[Estados]
    ([Pais]);
GO

-- Creating foreign key on [Estado_Id] in table 'Pessoas'
ALTER TABLE [dbo].[Pessoas]
ADD CONSTRAINT [FK_Pessoas_Estados]
    FOREIGN KEY ([Estado_Id])
    REFERENCES [dbo].[Estados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pessoas_Estados'
CREATE INDEX [IX_FK_Pessoas_Estados]
ON [dbo].[Pessoas]
    ([Estado_Id]);
GO

-- Creating foreign key on [Candidato_Id] in table 'Favoritos'
ALTER TABLE [dbo].[Favoritos]
ADD CONSTRAINT [FK_Favoritos_PessoasCandidato]
    FOREIGN KEY ([Candidato_Id])
    REFERENCES [dbo].[Pessoas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Favoritos_PessoasCandidato'
CREATE INDEX [IX_FK_Favoritos_PessoasCandidato]
ON [dbo].[Favoritos]
    ([Candidato_Id]);
GO

-- Creating foreign key on [Usuario_Id] in table 'Favoritos'
ALTER TABLE [dbo].[Favoritos]
ADD CONSTRAINT [FK_Favoritos_PessoasUsuario]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[Pessoas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Favoritos_PessoasUsuario'
CREATE INDEX [IX_FK_Favoritos_PessoasUsuario]
ON [dbo].[Favoritos]
    ([Usuario_Id]);
GO

-- Creating foreign key on [Lei_Id] in table 'Votocandidatolei'
ALTER TABLE [dbo].[Votocandidatolei]
ADD CONSTRAINT [FK_Votocandidatolei_Leis]
    FOREIGN KEY ([Lei_Id])
    REFERENCES [dbo].[Leis]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Votocandidatolei_Leis'
CREATE INDEX [IX_FK_Votocandidatolei_Leis]
ON [dbo].[Votocandidatolei]
    ([Lei_Id]);
GO

-- Creating foreign key on [Logradouro_Id] in table 'Pessoas'
ALTER TABLE [dbo].[Pessoas]
ADD CONSTRAINT [FK_Pessoas_Logradouros]
    FOREIGN KEY ([Logradouro_Id])
    REFERENCES [dbo].[Logradouros]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pessoas_Logradouros'
CREATE INDEX [IX_FK_Pessoas_Logradouros]
ON [dbo].[Pessoas]
    ([Logradouro_Id]);
GO

-- Creating foreign key on [Pais_Id] in table 'Pessoas'
ALTER TABLE [dbo].[Pessoas]
ADD CONSTRAINT [FK_Pessoas_Paises]
    FOREIGN KEY ([Pais_Id])
    REFERENCES [dbo].[Paises]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pessoas_Paises'
CREATE INDEX [IX_FK_Pessoas_Paises]
ON [dbo].[Pessoas]
    ([Pais_Id]);
GO

-- Creating foreign key on [Candidato_Id] in table 'Presidentes'
ALTER TABLE [dbo].[Presidentes]
ADD CONSTRAINT [FK_Presidentes_PessoasCandidato]
    FOREIGN KEY ([Candidato_Id])
    REFERENCES [dbo].[Pessoas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Presidentes_PessoasCandidato'
CREATE INDEX [IX_FK_Presidentes_PessoasCandidato]
ON [dbo].[Presidentes]
    ([Candidato_Id]);
GO

-- Creating foreign key on [Vice_Id] in table 'Presidentes'
ALTER TABLE [dbo].[Presidentes]
ADD CONSTRAINT [FK_Presidentes_PessoasVice]
    FOREIGN KEY ([Vice_Id])
    REFERENCES [dbo].[Pessoas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Presidentes_PessoasVice'
CREATE INDEX [IX_FK_Presidentes_PessoasVice]
ON [dbo].[Presidentes]
    ([Vice_Id]);
GO

-- Creating foreign key on [Candidato_Id] in table 'Votocandidatolei'
ALTER TABLE [dbo].[Votocandidatolei]
ADD CONSTRAINT [FK_Votocandidatolei_Pessoas]
    FOREIGN KEY ([Candidato_Id])
    REFERENCES [dbo].[Pessoas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Votocandidatolei_Pessoas'
CREATE INDEX [IX_FK_Votocandidatolei_Pessoas]
ON [dbo].[Votocandidatolei]
    ([Candidato_Id]);
GO

-- Creating foreign key on [Candidato_Id] in table 'Votos'
ALTER TABLE [dbo].[Votos]
ADD CONSTRAINT [FK_Votos_PessoasCandidato]
    FOREIGN KEY ([Candidato_Id])
    REFERENCES [dbo].[Pessoas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Votos_PessoasCandidato'
CREATE INDEX [IX_FK_Votos_PessoasCandidato]
ON [dbo].[Votos]
    ([Candidato_Id]);
GO

-- Creating foreign key on [Usuario_Id] in table 'Votos'
ALTER TABLE [dbo].[Votos]
ADD CONSTRAINT [FK_Votos_PessoasUsuario]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[Pessoas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Votos_PessoasUsuario'
CREATE INDEX [IX_FK_Votos_PessoasUsuario]
ON [dbo].[Votos]
    ([Usuario_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------