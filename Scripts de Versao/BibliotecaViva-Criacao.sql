CREATE TABLE Idioma (
  Id INTEGER  NOT NULL  ,
  Nome VARCHAR(20)  NOT NULL    ,
PRIMARY KEY(Id));

CREATE TABLE LinhaDoTempo (
  Id INTEGER  NOT NULL  ,
  Nome VARCHAR(50)  NOT NULL  ,
  Descricao TEXT  NOT NULL    ,
PRIMARY KEY(Id));

CREATE TABLE Genero (
  Id INTEGER  NOT NULL  ,
  Nome VARCHAR(20)  NOT NULL    ,
PRIMARY KEY(Id));

CREATE TABLE Glossario (
  Id INTEGER  NOT NULL  ,
  Nome VARCHAR(50)  NOT NULL  ,
  Descricao TEXT  NOT NULL    ,
PRIMARY KEY(Id));

CREATE TABLE Localizacao (
  Id INTEGER  NOT NULL  ,
  Nome VARCHAR(100)  NOT NULL  ,
  Latitude DOUBLE  NOT NULL  ,
  Longitude DOUBLE  NOT NULL  ,
  DataHora TIMESTAMP  NOT NULL    ,
PRIMARY KEY(Id));

CREATE TABLE TipoEvento (
  Id INTEGER  NOT NULL  ,
  Nome VARCHAR(50)  NOT NULL    ,
PRIMARY KEY(Id));

CREATE TABLE TipoParticipacao (
  Id INTEGER  NOT NULL  ,
  Nome INTEGER  NOT NULL    ,
PRIMARY KEY(Id));

CREATE TABLE NomeSocial (
  Id INTEGER  NOT NULL  ,
  Nome VARCHAR(20)  NOT NULL    ,
PRIMARY KEY(Id));

CREATE TABLE Termo (
  Id INTEGER  NOT NULL  ,
  Nome INTEGER  NOT NULL  ,
  Texto INTEGER  NOT NULL    ,
PRIMARY KEY(Id));

CREATE TABLE Apelido (
  Id INTEGER  NOT NULL  ,
  Nome VARCHAR(20)  NOT NULL    ,
PRIMARY KEY(Id));

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

CREATE INDEX Pessoa_FKIndex1 ON Pessoa (Genero);

CREATE TABLE Conceito (
  Glossario INTEGER  NOT NULL  ,
  Nome VARCHAR(50)  NOT NULL    ,
PRIMARY KEY(Glossario)  ,
  FOREIGN KEY(Glossario)
    REFERENCES Glossario(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

CREATE INDEX conceito_FKIndex1 ON Conceito (Glossario);

CREATE TABLE Documento (
  Id INTEGER  NOT NULL  ,
  Idioma INTEGER  NOT NULL  ,
  Nome VARCHAR(50)  NOT NULL  ,
  DataRegistro TIMESTAMP  NOT NULL  ,
  DataDigitalizacao TIMESTAMP  NOT NULL    ,
PRIMARY KEY(Id)  ,
  FOREIGN KEY(Idioma)
    REFERENCES Idioma(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

CREATE INDEX Documento_FKIndex1 ON Documento (Idioma);

CREATE TABLE Video (
  Documento INTEGER  NOT NULL  ,
  Url VARCHAR(100)  NOT NULL    ,
PRIMARY KEY(Documento)  ,
  FOREIGN KEY(Documento)
    REFERENCES Documento(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

CREATE INDEX video_FKIndex1 ON Video (Documento);

CREATE TABLE Audio (
  Documento INTEGER  NOT NULL  ,
  Base64 TEXT  NOT NULL    ,
PRIMARY KEY(Documento)  ,
  FOREIGN KEY(Documento)
    REFERENCES Documento(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

CREATE INDEX Audio_FKIndex1 ON Audio (Documento);

CREATE TABLE Texto (
  Documento INTEGER  NOT NULL  ,
  Texto TEXT  NOT NULL    ,
PRIMARY KEY(Documento)  ,
  FOREIGN KEY(Documento)
    REFERENCES Documento(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

CREATE INDEX texto_FKIndex1 ON Texto (Documento);

CREATE TABLE Dossie (
  Documento INTEGER  NOT NULL  ,
  Nome VARCHAR(50)  NOT NULL  ,
  Texto TEXT  NOT NULL    ,
PRIMARY KEY(Documento)  ,
  FOREIGN KEY(Documento)
    REFERENCES Documento(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

CREATE INDEX Dossie_FKIndex1 ON Dossie (Documento);

CREATE TABLE Evento (
  Id INTEGER  NOT NULL  ,
  TipoEvento INTEGER  NOT NULL  ,
  Nome VARCHAR(100)  NOT NULL  ,
  DataHora TIMESTAMP  NOT NULL  ,
  Descricao TEXT  NOT NULL    ,
PRIMARY KEY(Id)  ,
  FOREIGN KEY(TipoEvento)
    REFERENCES TipoEvento(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

CREATE INDEX evento_FKIndex1 ON Evento (TipoEvento);

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

CREATE INDEX localizacaolocalizacao_FKIndex1 ON RegiaoLocal (Regiao);
CREATE INDEX localizacaolocalizacao_FKIndex2 ON RegiaoLocal (Local);

CREATE TABLE Significado (
  Conceito INTEGER  NOT NULL  ,
  Idioma INTEGER  NOT NULL  ,
  Link VARCHAR(100)    ,
  Descricao TEXT  NOT NULL    ,
PRIMARY KEY(Conceito)    ,
  FOREIGN KEY(Idioma)
    REFERENCES Idioma(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Conceito)
    REFERENCES Conceito(Glossario)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

CREATE INDEX significado_FKIndex1 ON Significado (Idioma);
CREATE INDEX Significado_FKIndex2 ON Significado (Conceito);

CREATE TABLE PessoaNomeSocial (
  Pessoa INTEGER  NOT NULL  ,
  NomeSocial INTEGER  NOT NULL    ,
PRIMARY KEY(Pessoa, NomeSocial)    ,
  FOREIGN KEY(Pessoa)
    REFERENCES Pessoa(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(NomeSocial)
    REFERENCES NomeSocial(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

CREATE INDEX PessoaNomeSocial_FKIndex1 ON PessoaNomeSocial (Pessoa);
CREATE INDEX PessoaNomeSocial_FKIndex2 ON PessoaNomeSocial (NomeSocial);

CREATE TABLE PessoaTermo (
  Pessoa INTEGER  NOT NULL  ,
  Termo INTEGER  NOT NULL  ,
  Aceito BOOL  NOT NULL DEFAULT false   ,
PRIMARY KEY(Pessoa)    ,
  FOREIGN KEY(Termo)
    REFERENCES Termo(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Pessoa)
    REFERENCES Pessoa(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);

CREATE INDEX termopessoa_FKIndex1 ON PessoaTermo (Termo);
CREATE INDEX TermoPessoa_FKIndex2 ON PessoaTermo (Pessoa);



CREATE TABLE EventoDocumento (
  Evento INTEGER  NOT NULL  ,
  Documento INTEGER  NOT NULL    ,
PRIMARY KEY(Evento)    ,
  FOREIGN KEY(Evento)
    REFERENCES Evento(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Documento)
    REFERENCES Documento(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX eventodocumento_FKIndex1 ON EventoDocumento (Evento);
CREATE INDEX EventoDocumento_FKIndex2 ON EventoDocumento (Documento);



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


CREATE INDEX Transcricao_FKIndex1 ON Transcricao (Audio);
CREATE INDEX Transcricao_FKIndex2 ON Transcricao (Texto);



CREATE TABLE EventoLocalizacao (
  Evento INTEGER  NOT NULL  ,
  Localizacao INTEGER  NOT NULL    ,
PRIMARY KEY(Evento)    ,
  FOREIGN KEY(Localizacao)
    REFERENCES Localizacao(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Evento)
    REFERENCES Evento(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX localevento_FKIndex2 ON EventoLocalizacao (Localizacao);
CREATE INDEX EventoLocalizacao_FKIndex2 ON EventoLocalizacao (Evento);



CREATE TABLE DossieDocumento (
  Dossie INTEGER  NOT NULL  ,
  Documento INTEGER  NOT NULL    ,
PRIMARY KEY(Dossie)    ,
  FOREIGN KEY(Documento)
    REFERENCES Documento(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Dossie)
    REFERENCES Dossie(Documento)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX documentodossie_FKIndex1 ON DossieDocumento (Documento);
CREATE INDEX DossieDocumento_FKIndex2 ON DossieDocumento (Dossie);



CREATE TABLE LinhaDoTempoDocumento (
  LinhaDoTempo INTEGER  NOT NULL  ,
  Documento INTEGER  NOT NULL    ,
PRIMARY KEY(LinhaDoTempo)    ,
  FOREIGN KEY(Documento)
    REFERENCES Documento(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(LinhaDoTempo)
    REFERENCES LinhaDoTempo(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX linhadotempodocumento_FKIndex1 ON LinhaDoTempoDocumento (Documento);
CREATE INDEX LinhaDoTempoDocumento_FKIndex2 ON LinhaDoTempoDocumento (LinhaDoTempo);



CREATE TABLE LinhaDoTempoEvento (
  LinhaDoTempo INTEGER  NOT NULL  ,
  Evento INTEGER  NOT NULL    ,
PRIMARY KEY(LinhaDoTempo)    ,
  FOREIGN KEY(Evento)
    REFERENCES Evento(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(LinhaDoTempo)
    REFERENCES LinhaDoTempo(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX linhadotempoevento_FKIndex1 ON LinhaDoTempoEvento (Evento);
CREATE INDEX LinhaDoTempoEvento_FKIndex2 ON LinhaDoTempoEvento (LinhaDoTempo);



CREATE TABLE DocumentoGlossario (
  Glossario INTEGER  NOT NULL  ,
  Documento INTEGER  NOT NULL    ,
PRIMARY KEY(Glossario)    ,
  FOREIGN KEY(Documento)
    REFERENCES Documento(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Glossario)
    REFERENCES Glossario(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX documentoglossario_FKIndex1 ON DocumentoGlossario (Documento);
CREATE INDEX DocumentoGlossario_FKIndex2 ON DocumentoGlossario (Glossario);



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


CREATE INDEX imagem_FKIndex1 ON Imagem (Termo);
CREATE INDEX imagem_FKIndex2 ON Imagem (Documento);



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


CREATE INDEX legenda_FKIndex1 ON Legenda (Video);
CREATE INDEX Legenda_FKIndex2 ON Legenda (Texto);



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


CREATE INDEX AudioDescricao_FKIndex2 ON AudioDescricaoVideo (Video);
CREATE INDEX AudioDescricaoVideo_FKIndex2 ON AudioDescricaoVideo (Audio);



CREATE TABLE PessoaApelido (
  Apelido INTEGER  NOT NULL  ,
  Pessoa INTEGER  NOT NULL    ,
PRIMARY KEY(Apelido, Pessoa)    ,
  FOREIGN KEY(Pessoa)
    REFERENCES Pessoa(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Apelido)
    REFERENCES Apelido(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX PessoaApelido_FKIndex1 ON PessoaApelido (Pessoa);
CREATE INDEX PessoaApelido_FKIndex2 ON PessoaApelido (Apelido);



CREATE TABLE LinhaDoTempoPessoa (
  LinhaDoTempo INTEGER  NOT NULL  ,
  Pessoa INTEGER  NOT NULL    ,
PRIMARY KEY(LinhaDoTempo)    ,
  FOREIGN KEY(Pessoa)
    REFERENCES Pessoa(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(LinhaDoTempo)
    REFERENCES LinhaDoTempo(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX linhadotempopessoa_FKIndex1 ON LinhaDoTempoPessoa (Pessoa);
CREATE INDEX linhadotempopessoa_FKIndex2 ON LinhaDoTempoPessoa (LinhaDoTempo);



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


CREATE INDEX localglossario_FKIndex1 ON GlossarioLocal (Localizacao);
CREATE INDEX GlossarioLocal_FKIndex2 ON GlossarioLocal (Glossario);



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


CREATE INDEX participacao_FKIndex1 ON Participacao (TipoParticipacao);
CREATE INDEX participacao_FKIndex2 ON Participacao (Evento);
CREATE INDEX participacao_FKIndex3 ON Participacao (Pessoa);



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


CREATE INDEX AudioDescricaoImagem_FKIndex1 ON AudioDescricaoImagem (Imagem);
CREATE INDEX AudioDescricaoImagem_FKIndex2 ON AudioDescricaoImagem (Audio);



