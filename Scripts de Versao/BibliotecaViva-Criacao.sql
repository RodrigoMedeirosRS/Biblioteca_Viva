CREATE TABLE LocalizacaoGeografica (
  Codigo INTEGER  NOT NULL  ,
  Latitude BIGINT  NOT NULL  ,
  Longitude BIGINT  NOT NULL    ,
PRIMARY KEY(Codigo));



CREATE TABLE TipoRelacao (
  Codigo INTEGER  NOT NULL  ,
  Nome VARCHAR(50)  NOT NULL    ,
PRIMARY KEY(Codigo));



CREATE TABLE Pessoa (
  Codigo INTEGER  NOT NULL  ,
  Nome VARCHAR(30)  NOT NULL  ,
  Sobrenome VARCHAR(50)  NOT NULL  ,
  Genero VARCHAR(20)  NOT NULL    ,
PRIMARY KEY(Codigo));



CREATE TABLE Apelido (
  Codigo INTEGER  NOT NULL  ,
  Nome VARCHAR(20)  NOT NULL    ,
PRIMARY KEY(Codigo));



CREATE TABLE Tipo (
  Codigo INTEGER  NOT NULL  ,
  Nome INTEGER  NOT NULL  ,
  Extensao VARCHAR(7)  NOT NULL    ,
PRIMARY KEY(Codigo));



CREATE TABLE Idioma (
  Codigo INTEGER  NOT NULL  ,
  Nome VARCHAR(20)      ,
PRIMARY KEY(Codigo));



CREATE TABLE NomeSocial (
  Codigo INTEGER  NOT NULL  ,
  Pessoa INTEGER  NOT NULL  ,
  Nome VARCHAR(30)  NOT NULL, 
PRIMARY KEY(Codigo)  ,
  FOREIGN KEY(Pessoa)
    REFERENCES Pessoa(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX NomeSocial_FKIndex1 ON NomeSocial (Pessoa);



CREATE TABLE Registro (
  Codigo INTEGER  NOT NULL  ,
  Idioma INTEGER  NOT NULL  ,
  Tipo INTEGER  NOT NULL  ,
  Nome VARCHAR(30)  NOT NULL  ,
  Conteudo TEXT  NOT NULL  ,
  DataInsercao TIMESTAMP  NOT NULL    ,
PRIMARY KEY(Codigo)    ,
  FOREIGN KEY(Tipo)
    REFERENCES Tipo(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Idioma)
    REFERENCES Idioma(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX Registro_FKIndex1 ON Registro (Tipo);
CREATE INDEX Registro_FKIndex2 ON Registro (Idioma);



CREATE TABLE PessoaLocalizao (
  Codigo INTEGER  NOT NULL  ,
  LocalizacaoGeografica INTEGER  NOT NULL  ,
  Pessoa INTEGER  NOT NULL    ,
PRIMARY KEY(Codigo)    ,
  FOREIGN KEY(Pessoa)
    REFERENCES Pessoa(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(LocalizacaoGeografica)
    REFERENCES LocalizacaoGeografica(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX PessoaLocalizao_FKIndex1 ON PessoaLocalizao (Pessoa);
CREATE INDEX PessoaLocalizao_FKIndex2 ON PessoaLocalizao (LocalizacaoGeografica);



CREATE TABLE PessoaApelido (
  Codigo INTEGER  NOT NULL  ,
  Apelido INTEGER  NOT NULL  ,
  Pessoa INTEGER  NOT NULL    ,
PRIMARY KEY(Codigo)    ,
  FOREIGN KEY(Pessoa)
    REFERENCES Pessoa(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Apelido)
    REFERENCES Apelido(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX PessoaApelido_FKIndex1 ON PessoaApelido (Pessoa);
CREATE INDEX PessoaApelido_FKIndex2 ON PessoaApelido (Apelido);



CREATE TABLE Referencia (
  Codigo INTEGER  NOT NULL  ,
  TipoRelacao INTEGER  NOT NULL  ,
  Referencia INTEGER  NOT NULL  ,
  Registro INTEGER  NOT NULL    ,
PRIMARY KEY(Codigo)      ,
  FOREIGN KEY(Registro)
    REFERENCES Registro(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Referencia)
    REFERENCES Registro(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(TipoRelacao)
    REFERENCES TipoRelacao(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX RegistroRelacionado_FKIndex1 ON Referencia (Registro);
CREATE INDEX RegistroRelacionado_FKIndex2 ON Referencia (Referencia);
CREATE INDEX Referencia_FKIndex3 ON Referencia (TipoRelacao);



CREATE TABLE PessoaRegistro (
  Codigo INTEGER  NOT NULL  ,
  TipoRelacao INTEGER  NOT NULL  ,
  Registro INTEGER  NOT NULL  ,
  Pessoa INTEGER  NOT NULL    ,
PRIMARY KEY(Codigo)      ,
  FOREIGN KEY(Pessoa)
    REFERENCES Pessoa(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Registro)
    REFERENCES Registro(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(TipoRelacao)
    REFERENCES TipoRelacao(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX PessoaDocumento_FKIndex1 ON PessoaRegistro (Pessoa);
CREATE INDEX PessoaDocumento_FKIndex2 ON PessoaRegistro (Registro);
CREATE INDEX PessoaDocumento_FKIndex3 ON PessoaRegistro (TipoRelacao);



CREATE TABLE Descricao (
  Codigo INTEGER  NOT NULL  ,
  Registro INTEGER  NOT NULL  ,
  Descricao TEXT  NOT NULL    ,
PRIMARY KEY(Codigo)  ,
  FOREIGN KEY(Registro)
    REFERENCES Registro(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX Descricao_FKIndex1 ON Descricao (Registro);



CREATE TABLE RegistroApelido (
  Codigo INTEGER  NOT NULL  ,
  Registro INTEGER  NOT NULL  ,
  Apelido INTEGER  NOT NULL    ,
PRIMARY KEY(Codigo)    ,
  FOREIGN KEY(Apelido)
    REFERENCES Apelido(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Registro)
    REFERENCES Registro(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX RegistroApelido_FKIndex1 ON RegistroApelido (Apelido);
CREATE INDEX RegistroApelido_FKIndex2 ON RegistroApelido (Registro);



CREATE TABLE RegistroLocalizacao (
  Codigo INTEGER  NOT NULL  ,
  Registro INTEGER  NOT NULL  ,
  LocalizacaoGeografica INTEGER  NOT NULL    ,
PRIMARY KEY(Codigo)    ,
  FOREIGN KEY(LocalizacaoGeografica)
    REFERENCES LocalizacaoGeografica(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Registro)
    REFERENCES Registro(Codigo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);


CREATE INDEX RegistroLocalizacao_FKIndex1 ON RegistroLocalizacao (LocalizacaoGeografica);
CREATE INDEX RegistroLocalizacao_FKIndex2 ON RegistroLocalizacao (Registro);



