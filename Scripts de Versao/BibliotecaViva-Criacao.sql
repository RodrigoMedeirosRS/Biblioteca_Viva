--
-- File generated with SQLiteStudio v3.2.1 on seg out 12 21:12:35 2020
--
-- Text encoding used: UTF-8
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Apelido
CREATE TABLE Apelido (
  Pessoa INTEGER  NOT NULL  ,
  Nome VARCHAR(20)  NOT NULL    ,
PRIMARY KEY(Pessoa)  ,
  FOREIGN KEY(Pessoa)
    REFERENCES Pessoa(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

-- Table: Audio
CREATE TABLE Audio (
  Documento INTEGER  NOT NULL  ,
  Base64 TEXT  NOT NULL    ,
PRIMARY KEY(Documento)  ,
  FOREIGN KEY(Documento)
    REFERENCES Documento(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

-- Table: AudioDescricaoImagem
CREATE TABLE AudioDescricaoImagem (
  Imagem INTEGER  NOT NULL  ,
  Audio INTEGER  NOT NULL    ,
PRIMARY KEY(Imagem)    ,
  FOREIGN KEY(Audio)
    REFERENCES Audio(Documento)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Imagem)
    REFERENCES Imagem(Documento)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

-- Table: AudioDescricaoVideo
CREATE TABLE AudioDescricaoVideo (
  Video INTEGER  NOT NULL  ,
  Audio INTEGER  NOT NULL    ,
PRIMARY KEY(Video)    ,
  FOREIGN KEY(Audio)
    REFERENCES Audio(Documento)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Video)
    REFERENCES Video(Documento)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

-- Table: Conceito
CREATE TABLE Conceito (Id INTEGER PRIMARY KEY AUTOINCREMENT, Glossario INTEGER NOT NULL, Nome VARCHAR (50) NOT NULL, FOREIGN KEY (Glossario) REFERENCES Glossario (Id) ON DELETE NO ACTION ON UPDATE NO ACTION);

-- Table: Documento
CREATE TABLE Documento (Id INTEGER, Idioma INTEGER NOT NULL, Nome VARCHAR (50) NOT NULL, DataRegistro DATE NOT NULL, DataDigitalizacao DATE NOT NULL, PRIMARY KEY (Id), FOREIGN KEY (Idioma) REFERENCES Idioma (Id) ON DELETE NO ACTION ON UPDATE NO ACTION);

-- Table: DocumentoGlossario
CREATE TABLE DocumentoGlossario (Id INTEGER PRIMARY KEY AUTOINCREMENT, Glossario INTEGER NOT NULL, Documento INTEGER NOT NULL, FOREIGN KEY (Documento) REFERENCES Documento (id) ON DELETE NO ACTION ON UPDATE NO ACTION, FOREIGN KEY (Glossario) REFERENCES Glossario (Id) ON DELETE NO ACTION ON UPDATE NO ACTION);

-- Table: Dossie
CREATE TABLE Dossie (Documento INTEGER NOT NULL, Texto TEXT NOT NULL, PRIMARY KEY (Documento), FOREIGN KEY (Documento) REFERENCES Documento (Id) ON DELETE NO ACTION ON UPDATE NO ACTION);

-- Table: DossieDocumento
CREATE TABLE DossieDocumento (Id INTEGER PRIMARY KEY AUTOINCREMENT, Dossie INTEGER NOT NULL, Documento INTEGER NOT NULL, FOREIGN KEY (Documento) REFERENCES Documento (id) ON DELETE NO ACTION ON UPDATE NO ACTION, FOREIGN KEY (Dossie) REFERENCES Dossie (Documento) ON DELETE NO ACTION ON UPDATE NO ACTION);

-- Table: Evento
CREATE TABLE Evento (Id INTEGER NOT NULL, TipoEvento INTEGER NOT NULL, Nome VARCHAR (100) NOT NULL UNIQUE, DataHora TIMESTAMP NOT NULL, Descricao TEXT NOT NULL, PRIMARY KEY (Id), FOREIGN KEY (TipoEvento) REFERENCES TipoEvento (id) ON DELETE NO ACTION ON UPDATE NO ACTION);

-- Table: EventoDocumento
CREATE TABLE EventoDocumento (Id INTEGER PRIMARY KEY AUTOINCREMENT, Evento INTEGER NOT NULL, Documento INTEGER NOT NULL, FOREIGN KEY (Evento) REFERENCES Evento (Id) ON DELETE NO ACTION ON UPDATE NO ACTION, FOREIGN KEY (Documento) REFERENCES Documento (Id) ON DELETE NO ACTION ON UPDATE NO ACTION);

-- Table: EventoLocalizacao
CREATE TABLE EventoLocalizacao (Id INTEGER PRIMARY KEY, Evento INTEGER NOT NULL, Localizacao INTEGER NOT NULL, FOREIGN KEY (Localizacao) REFERENCES Localizacao (id) ON DELETE NO ACTION ON UPDATE NO ACTION, FOREIGN KEY (Evento) REFERENCES Evento (Id) ON DELETE NO ACTION ON UPDATE NO ACTION);

-- Table: Genero
CREATE TABLE Genero (
  Id INTEGER  NOT NULL  ,
  Nome VARCHAR(20)  NOT NULL    ,
PRIMARY KEY(Id));
INSERT INTO Genero (Id, Nome) VALUES (1, 'Masculino');
INSERT INTO Genero (Id, Nome) VALUES (2, 'Feminino');

-- Table: Glossario
CREATE TABLE Glossario (Id INTEGER NOT NULL, Nome VARCHAR (50) NOT NULL UNIQUE, Descricao TEXT NOT NULL, PRIMARY KEY (Id));

-- Table: GlossarioLocal
CREATE TABLE GlossarioLocal (
  Glossario INTEGER  NOT NULL  ,
  Localizacao INTEGER  NOT NULL    ,
PRIMARY KEY(Glossario)    ,
  FOREIGN KEY(Localizacao)
    REFERENCES Localizacao(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Glossario)
    REFERENCES Glossario(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

-- Table: Idioma
CREATE TABLE Idioma (Id INTEGER NOT NULL, Nome VARCHAR (20) NOT NULL UNIQUE, PRIMARY KEY (Id));
INSERT INTO Idioma (Id, Nome) VALUES (1, 'Português Brasil');
INSERT INTO Idioma (Id, Nome) VALUES (2, 'Português Portugal');
INSERT INTO Idioma (Id, Nome) VALUES (3, 'Inglês');
INSERT INTO Idioma (Id, Nome) VALUES (4, 'Espanhol');
INSERT INTO Idioma (Id, Nome) VALUES (5, 'Italiano');
INSERT INTO Idioma (Id, Nome) VALUES (6, 'Alemão');

-- Table: Imagem
CREATE TABLE Imagem (
  Documento INTEGER  NOT NULL  ,
  Termo INTEGER  NOT NULL  ,
  Base64 TEXT  NOT NULL    ,
PRIMARY KEY(Documento)    ,
  FOREIGN KEY(Termo)
    REFERENCES Termo(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Documento)
    REFERENCES Documento(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

-- Table: Legenda
CREATE TABLE Legenda (
  Video INTEGER  NOT NULL  ,
  Texto INTEGER  NOT NULL    ,
PRIMARY KEY(Video)    ,
  FOREIGN KEY(Texto)
    REFERENCES Texto(Documento)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Video)
    REFERENCES Video(Documento)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

-- Table: LinhaDoTempo
CREATE TABLE LinhaDoTempo (Id INTEGER NOT NULL, Nome VARCHAR (50) NOT NULL UNIQUE, Descricao TEXT NOT NULL, PRIMARY KEY (Id));

-- Table: LinhaDoTempoDocumento
CREATE TABLE LinhaDoTempoDocumento (Id INTEGER PRIMARY KEY AUTOINCREMENT, LinhaDoTempo INTEGER, Documento INTEGER NOT NULL, FOREIGN KEY (Documento) REFERENCES Documento (id) ON DELETE NO ACTION ON UPDATE NO ACTION, FOREIGN KEY (LinhaDoTempo) REFERENCES LinhaDoTempo (Id) ON DELETE NO ACTION ON UPDATE NO ACTION);

-- Table: LinhaDoTempoEvento
CREATE TABLE LinhaDoTempoEvento (Id INTEGER PRIMARY KEY AUTOINCREMENT, LinhaDoTempo INTEGER, Evento INTEGER NOT NULL, FOREIGN KEY (Evento) REFERENCES Evento (id) ON DELETE NO ACTION ON UPDATE NO ACTION, FOREIGN KEY (LinhaDoTempo) REFERENCES LinhaDoTempo (Id) ON DELETE NO ACTION ON UPDATE NO ACTION);

-- Table: LinhaDoTempoPessoa
CREATE TABLE LinhaDoTempoPessoa (Id INTEGER PRIMARY KEY AUTOINCREMENT, LinhaDoTempo INTEGER, Pessoa INTEGER NOT NULL, FOREIGN KEY (Pessoa) REFERENCES Pessoa (id) ON DELETE NO ACTION ON UPDATE NO ACTION, FOREIGN KEY (LinhaDoTempo) REFERENCES LinhaDoTempo (Id) ON DELETE NO ACTION ON UPDATE NO ACTION);

-- Table: Localizacao
CREATE TABLE Localizacao (Id INTEGER NOT NULL, Nome VARCHAR (100) NOT NULL UNIQUE, Latitude DOUBLE NOT NULL, Longitude DOUBLE NOT NULL, DataHora TIMESTAMP NOT NULL, PRIMARY KEY (Id));

-- Table: NomeSocial
CREATE TABLE NomeSocial (
  Pessoa INTEGER  NOT NULL  ,
  Nome VARCHAR(20)  NOT NULL    ,
PRIMARY KEY(Pessoa)  ,
  FOREIGN KEY(Pessoa)
    REFERENCES Pessoa(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

-- Table: Participacao
CREATE TABLE Participacao (
  Id INTEGER  NOT NULL  ,
  Evento INTEGER  NOT NULL  ,
  TipoParticipacao INTEGER  NOT NULL  ,
  Pessoa INTEGER  NOT NULL    ,
PRIMARY KEY(Id)      ,
  FOREIGN KEY(TipoParticipacao)
    REFERENCES TipoParticipacao(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Evento)
    REFERENCES Evento(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Pessoa)
    REFERENCES Pessoa(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

-- Table: Pessoa
CREATE TABLE Pessoa (
  Id INTEGER  NOT NULL  ,
  Genero INTEGER  NOT NULL  ,
  Nome VARCHAR(25)  NOT NULL  ,
  Sobrenome VARCHAR(100)  NOT NULL    ,
PRIMARY KEY(Id)  ,
  FOREIGN KEY(Genero)
    REFERENCES Genero(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

-- Table: PessoaDocumento
CREATE TABLE PessoaDocumento (Id INTEGER PRIMARY KEY AUTOINCREMENT, Pessoa INTEGER NOT NULL, TipoDeRelacao INTEGER NOT NULL, Documento INTEGER NOT NULL, FOREIGN KEY (Pessoa) REFERENCES Pessoa (Id) ON DELETE NO ACTION ON UPDATE NO ACTION, FOREIGN KEY (Documento) REFERENCES Documento (Id) ON DELETE NO ACTION ON UPDATE NO ACTION, FOREIGN KEY (TipoDeRelacao) REFERENCES TipoDeRelacao (Id) ON DELETE NO ACTION ON UPDATE NO ACTION);

-- Table: PessoaTermo
CREATE TABLE PessoaTermo (Id INTEGER PRIMARY KEY AUTOINCREMENT, Pessoa INTEGER NOT NULL, Termo INTEGER NOT NULL, Aceito BOOL NOT NULL DEFAULT false, FOREIGN KEY (Termo) REFERENCES Termo (id) ON DELETE NO ACTION ON UPDATE NO ACTION, FOREIGN KEY (Pessoa) REFERENCES Pessoa (Id) ON DELETE NO ACTION ON UPDATE NO ACTION);

-- Table: RegiaoLocal
CREATE TABLE RegiaoLocal (
  Regiao INTEGER  NOT NULL  ,
  Local INTEGER  NOT NULL    ,
PRIMARY KEY(Regiao)    ,
  FOREIGN KEY(Regiao)
    REFERENCES Localizacao(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Local)
    REFERENCES Localizacao(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

-- Table: Significado
CREATE TABLE Significado (Id INTEGER PRIMARY KEY AUTOINCREMENT, Conceito INTEGER NOT NULL, Idioma INTEGER NOT NULL, Link VARCHAR (100), Descricao TEXT NOT NULL, FOREIGN KEY (Idioma) REFERENCES Idioma (id) ON DELETE NO ACTION ON UPDATE NO ACTION, FOREIGN KEY (Conceito) REFERENCES Conceito (Glossario) ON DELETE NO ACTION ON UPDATE NO ACTION);

-- Table: Termo
CREATE TABLE Termo (
  Id INTEGER  NOT NULL  ,
  Nome INTEGER  NOT NULL  ,
  Texto INTEGER  NOT NULL    ,
PRIMARY KEY(Id));

-- Table: Texto
CREATE TABLE Texto (Documento INTEGER NOT NULL, Corpo TEXT NOT NULL, PRIMARY KEY (Documento), FOREIGN KEY (Documento) REFERENCES Documento (Id) ON DELETE NO ACTION ON UPDATE NO ACTION);

-- Table: TipoDeRelacao
CREATE TABLE TipoDeRelacao (Id INTEGER NOT NULL, Nome INTEGER UNIQUE, PRIMARY KEY (Id));
INSERT INTO TipoDeRelacao (Id, Nome) VALUES (1, 'Autor');
INSERT INTO TipoDeRelacao (Id, Nome) VALUES (2, 'Mencao');

-- Table: TipoEvento
CREATE TABLE TipoEvento (Id INTEGER NOT NULL, Nome VARCHAR (50) NOT NULL UNIQUE, PRIMARY KEY (Id));

-- Table: TipoParticipacao
CREATE TABLE TipoParticipacao (Id INTEGER NOT NULL, Nome INTEGER NOT NULL UNIQUE, PRIMARY KEY (Id));

-- Table: Transcricao
CREATE TABLE Transcricao (
  Audio INTEGER  NOT NULL  ,
  Texto INTEGER  NOT NULL    ,
PRIMARY KEY(Audio)    ,
  FOREIGN KEY(Texto)
    REFERENCES Texto(Documento)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Audio)
    REFERENCES Audio(Documento)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

-- Table: Video
CREATE TABLE Video (
  Documento INTEGER  NOT NULL  ,
  Url VARCHAR(100)  NOT NULL    ,
PRIMARY KEY(Documento)  ,
  FOREIGN KEY(Documento)
    REFERENCES Documento(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

-- Index: Apelido_FKIndex1
CREATE INDEX Apelido_FKIndex1 ON Apelido (Pessoa);

-- Index: Audio_FKIndex1
CREATE INDEX Audio_FKIndex1 ON Audio (Documento);

-- Index: AudioDescricao_FKIndex2
CREATE INDEX AudioDescricao_FKIndex2 ON AudioDescricaoVideo (Video);

-- Index: AudioDescricaoImagem_FKIndex1
CREATE INDEX AudioDescricaoImagem_FKIndex1 ON AudioDescricaoImagem (Imagem);

-- Index: AudioDescricaoImagem_FKIndex2
CREATE INDEX AudioDescricaoImagem_FKIndex2 ON AudioDescricaoImagem (Audio);

-- Index: AudioDescricaoVideo_FKIndex2
CREATE INDEX AudioDescricaoVideo_FKIndex2 ON AudioDescricaoVideo (Audio);

-- Index: conceito_FKIndex1
CREATE INDEX conceito_FKIndex1 ON Conceito (Glossario);

-- Index: Documento_FKIndex1
CREATE INDEX Documento_FKIndex1 ON Documento (Idioma);

-- Index: documentodossie_FKIndex1
CREATE INDEX documentodossie_FKIndex1 ON DossieDocumento (Documento);

-- Index: documentoglossario_FKIndex1
CREATE INDEX documentoglossario_FKIndex1 ON DocumentoGlossario (Documento);

-- Index: DocumentoGlossario_FKIndex2
CREATE INDEX DocumentoGlossario_FKIndex2 ON DocumentoGlossario (Glossario);

-- Index: Dossie_FKIndex1
CREATE INDEX Dossie_FKIndex1 ON Dossie (Documento);

-- Index: DossieDocumento_FKIndex2
CREATE INDEX DossieDocumento_FKIndex2 ON DossieDocumento (Dossie);

-- Index: evento_FKIndex1
CREATE INDEX evento_FKIndex1 ON Evento (TipoEvento);

-- Index: eventodocumento_FKIndex1
CREATE INDEX eventodocumento_FKIndex1 ON EventoDocumento (Evento);

-- Index: EventoDocumento_FKIndex2
CREATE INDEX EventoDocumento_FKIndex2 ON EventoDocumento (Documento);

-- Index: EventoLocalizacao_FKIndex2
CREATE INDEX EventoLocalizacao_FKIndex2 ON EventoLocalizacao (Evento);

-- Index: GlossarioLocal_FKIndex2
CREATE INDEX GlossarioLocal_FKIndex2 ON GlossarioLocal (Glossario);

-- Index: imagem_FKIndex1
CREATE INDEX imagem_FKIndex1 ON Imagem (Termo);

-- Index: imagem_FKIndex2
CREATE INDEX imagem_FKIndex2 ON Imagem (Documento);

-- Index: legenda_FKIndex1
CREATE INDEX legenda_FKIndex1 ON Legenda (Video);

-- Index: Legenda_FKIndex2
CREATE INDEX Legenda_FKIndex2 ON Legenda (Texto);

-- Index: linhadotempodocumento_FKIndex1
CREATE INDEX linhadotempodocumento_FKIndex1 ON LinhaDoTempoDocumento (Documento);

-- Index: LinhaDoTempoDocumento_FKIndex2
CREATE INDEX LinhaDoTempoDocumento_FKIndex2 ON LinhaDoTempoDocumento (LinhaDoTempo);

-- Index: linhadotempoevento_FKIndex1
CREATE INDEX linhadotempoevento_FKIndex1 ON LinhaDoTempoEvento (Evento);

-- Index: LinhaDoTempoEvento_FKIndex2
CREATE INDEX LinhaDoTempoEvento_FKIndex2 ON LinhaDoTempoEvento (LinhaDoTempo);

-- Index: linhadotempopessoa_FKIndex1
CREATE INDEX linhadotempopessoa_FKIndex1 ON LinhaDoTempoPessoa (Pessoa);

-- Index: linhadotempopessoa_FKIndex2
CREATE INDEX linhadotempopessoa_FKIndex2 ON LinhaDoTempoPessoa (LinhaDoTempo);

-- Index: localevento_FKIndex2
CREATE INDEX localevento_FKIndex2 ON EventoLocalizacao (Localizacao);

-- Index: localglossario_FKIndex1
CREATE INDEX localglossario_FKIndex1 ON GlossarioLocal (Localizacao);

-- Index: localizacaolocalizacao_FKIndex1
CREATE INDEX localizacaolocalizacao_FKIndex1 ON RegiaoLocal (Regiao);

-- Index: localizacaolocalizacao_FKIndex2
CREATE INDEX localizacaolocalizacao_FKIndex2 ON RegiaoLocal (Local);

-- Index: NomeSocial_FKIndex1
CREATE INDEX NomeSocial_FKIndex1 ON NomeSocial (Pessoa);

-- Index: participacao_FKIndex1
CREATE INDEX participacao_FKIndex1 ON Participacao (TipoParticipacao);

-- Index: participacao_FKIndex2
CREATE INDEX participacao_FKIndex2 ON Participacao (Evento);

-- Index: participacao_FKIndex3
CREATE INDEX participacao_FKIndex3 ON Participacao (Pessoa);

-- Index: Pessoa_FKIndex1
CREATE INDEX Pessoa_FKIndex1 ON Pessoa (Genero);

-- Index: PessoaDocumento_FKIndex1
CREATE INDEX PessoaDocumento_FKIndex1 ON PessoaDocumento (Pessoa);

-- Index: PessoaDocumento_FKIndex2
CREATE INDEX PessoaDocumento_FKIndex2 ON PessoaDocumento (Documento);

-- Index: PessoaDocumento_FKIndex3
CREATE INDEX PessoaDocumento_FKIndex3 ON PessoaDocumento (TipoDeRelacao);

-- Index: significado_FKIndex1
CREATE INDEX significado_FKIndex1 ON Significado (Idioma);

-- Index: Significado_FKIndex2
CREATE INDEX Significado_FKIndex2 ON Significado (Conceito);

-- Index: termopessoa_FKIndex1
CREATE INDEX termopessoa_FKIndex1 ON PessoaTermo (Termo);

-- Index: TermoPessoa_FKIndex2
CREATE INDEX TermoPessoa_FKIndex2 ON PessoaTermo (Pessoa);

-- Index: texto_FKIndex1
CREATE INDEX texto_FKIndex1 ON Texto (Documento);

-- Index: Transcricao_FKIndex1
CREATE INDEX Transcricao_FKIndex1 ON Transcricao (Audio);

-- Index: Transcricao_FKIndex2
CREATE INDEX Transcricao_FKIndex2 ON Transcricao (Texto);

-- Index: video_FKIndex1
CREATE INDEX video_FKIndex1 ON Video (Documento);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
