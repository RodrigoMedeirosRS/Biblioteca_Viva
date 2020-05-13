CREATE TABLE Trilha (
  codtrilha SERIAL  NOT NULL ,
  nometrilha VARCHAR(50) UNIQUE  NOT NULL   ,
PRIMARY KEY(codtrilha));

CREATE TABLE Aplicacao (
  codaplicacao SERIAL  NOT NULL ,
  nomeaplicacao VARCHAR(50) UNIQUE NOT NULL ,
PRIMARY KEY(codaplicacao));

CREATE TABLE Registro (
  codregistro SERIAL  NOT NULL ,
  codaplicacao INTEGER   NOT NULL ,
  codtrilha INTEGER   NOT NULL ,
  tituloregistro VARCHAR(50) UNIQUE NOT NULL ,
  dataregistro DATE    ,
  sinopseregistro VARCHAR(200)      ,
PRIMARY KEY(codregistro)    ,
  FOREIGN KEY(codtrilha)
    REFERENCES Trilha(codtrilha),
  FOREIGN KEY(codaplicacao)
    REFERENCES Aplicacao(codaplicacao));


CREATE INDEX Registro_FKIndex1 ON Registro (codtrilha);
CREATE INDEX Registro_FKIndex2 ON Registro (codaplicacao);


CREATE INDEX IFK_Rel_06 ON Registro (codtrilha);
CREATE INDEX IFK_Rel_09 ON Registro (codaplicacao);


CREATE TABLE RegistroLink (
  codlink SERIAL  NOT NULL ,
  codregistro INTEGER   NOT NULL ,
  link VARCHAR(100)   NOT NULL ,
  titulolink VARCHAR(50)  UNIQUE NOT NULL   ,
PRIMARY KEY(codlink)  ,
  FOREIGN KEY(codregistro)
    REFERENCES Registro(codregistro));


CREATE INDEX RegistroLink_FKIndex1 ON RegistroLink (codregistro);


CREATE INDEX IFK_Rel_05 ON RegistroLink (codregistro);


CREATE TABLE RegistroTexto (
  codtexto SERIAL  NOT NULL ,
  codregistro INTEGER   NOT NULL ,
  texto TEXT    ,
  titulotexto VARCHAR(50) UNIQUE NOT NULL  ,
PRIMARY KEY(codtexto)  ,
  FOREIGN KEY(codregistro)
    REFERENCES Registro(codregistro));


CREATE INDEX RegistroTexto_FKIndex1 ON RegistroTexto (codregistro);


CREATE INDEX IFK_Rel_02 ON RegistroTexto (codregistro);


CREATE TABLE RegistroVideo (
  codvideo SERIAL  NOT NULL ,
  codregistro INTEGER   NOT NULL ,
  videobase64 TEXT   NOT NULL ,
  titulovideo VARCHAR(50) UNIQUE  NOT NULL   ,
PRIMARY KEY(codvideo)  ,
  FOREIGN KEY(codregistro)
    REFERENCES Registro(codregistro));


CREATE INDEX RegistroVideo_FKIndex1 ON RegistroVideo (codregistro);


CREATE INDEX IFK_Rel_01 ON RegistroVideo (codregistro);


CREATE TABLE Registro3D (
  codregistro3D SERIAL  NOT NULL ,
  codregistro INTEGER   NOT NULL ,
  regsitro3dbase64 TEXT    ,
  titloregistro VARCHAR(50)  UNIQUE NOT NULL    ,
PRIMARY KEY(codregistro3D)  ,
  FOREIGN KEY(codregistro)
    REFERENCES Registro(codregistro));


CREATE INDEX Registro3D_FKIndex1 ON Registro3D (codregistro);


CREATE INDEX IFK_Rel_08 ON Registro3D (codregistro);


CREATE TABLE RegistroAudio (
  codaudio SERIAL  NOT NULL ,
  codregistro INTEGER   NOT NULL ,
  audiobase64 TEXT   NOT NULL ,
  tituloaudio VARCHAR(50) UNIQUE  NOT NULL   ,
PRIMARY KEY(codaudio)  ,
  FOREIGN KEY(codregistro)
    REFERENCES Registro(codregistro));


CREATE INDEX RegistroAudio_FKIndex1 ON RegistroAudio (codregistro);


CREATE INDEX IFK_Rel_03 ON RegistroAudio (codregistro);


CREATE TABLE RegistroImagem (
  codimagem SERIAL  NOT NULL ,
  codregistro INTEGER   NOT NULL ,
  imagembase64 TEXT    ,
  tituloimagem VARCHAR(50) UNIQUE NOT NULL     ,
PRIMARY KEY(codimagem)  ,
  FOREIGN KEY(codregistro)
    REFERENCES Registro(codregistro));


CREATE INDEX RegistroImagem_FKIndex1 ON RegistroImagem (codregistro);


CREATE INDEX IFK_Rel_04 ON RegistroImagem (codregistro);

