CREATE TABLE linhadotempo (
  id SERIAL  NOT NULL ,
  nome VARCHAR(50) UNIQUE NOT NULL ,
  descricacao TEXT   NOT NULL   ,
PRIMARY KEY(id));

CREATE TABLE idioma (
  id SERIAL  NOT NULL ,
  nome VARCHAR(20) UNIQUE NOT NULL   ,
PRIMARY KEY(id));

CREATE TABLE glossario (
  id SERIAL  NOT NULL ,
  nome VARCHAR(50) UNIQUE NOT NULL ,
  descricao TEXT   NOT NULL   ,
PRIMARY KEY(id));

CREATE TABLE localizacao (
  id SERIAL  NOT NULL ,
  nome VARCHAR(100) UNIQUE NOT NULL ,
  latitude DOUBLE   NOT NULL ,
  longitude DOUBLE   NOT NULL ,
  datahora TIMESTAMP   NOT NULL   ,
PRIMARY KEY(id));

CREATE TABLE tipoparticipacao (
  id SERIAL  NOT NULL ,
  nome INTEGER UNIQUE NOT NULL   ,
PRIMARY KEY(id));

CREATE TABLE tipoevento (
  id SERIAL  NOT NULL ,
  nome VARCHAR(50) UNIQUE NOT NULL   ,
PRIMARY KEY(id));

CREATE TABLE pessoa (
  id SERIAL  NOT NULL ,
  nome VARCHAR(25)   NOT NULL ,
  sobrenome VARCHAR(100) UNIQUE NOT NULL   ,
PRIMARY KEY(id));

CREATE TABLE documento (
  id SERIAL  NOT NULL ,
  nome VARCHAR(50) UNIQUE NOT NULL ,
  dataregistro TIMESTAMP   NOT NULL ,
  datadigitalizacao TIMESTAMP   NOT NULL   ,
PRIMARY KEY(id));

CREATE TABLE texto (
  id SERIAL  NOT NULL ,
  documento_id INTEGER   NOT NULL ,
  texto TEXT   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(documento_id)
    REFERENCES documento(id));

CREATE INDEX IFK_Rel_04 ON texto (documento_id);

CREATE TABLE audio (
  id SERIAL  NOT NULL ,
  documento_id INTEGER   NOT NULL ,
  base64 TEXT   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(documento_id)
    REFERENCES documento(id));

CREATE INDEX IFK_Rel_04 ON audio (documento_id);

CREATE TABLE conceito (
  id SERIAL  NOT NULL ,
  glossario_id INTEGER   NOT NULL ,
  nome VARCHAR(50)   NOT NULL   ,
PRIMARY KEY(id)  ,
  FOREIGN KEY(glossario_id)
    REFERENCES glossario(id));

CREATE INDEX conceito_FKIndex1 ON conceito (glossario_id);

CREATE INDEX IFK_Rel_39 ON conceito (glossario_id);

CREATE TABLE nomesocial (
  id SERIAL  NOT NULL ,
  pessoa_id INTEGER   NOT NULL ,
  nome VARCHAR(20)   NOT NULL   ,
PRIMARY KEY(id)  ,
  FOREIGN KEY(pessoa_id)
    REFERENCES pessoa(id));

CREATE INDEX nomesocial_FKIndex1 ON nomesocial (pessoa_id);

CREATE INDEX IFK_Rel_46 ON nomesocial (pessoa_id);

CREATE TABLE termo (
  id SERIAL  NOT NULL ,
  pessoa_id INTEGER   NOT NULL ,
  nome INTEGER UNIQUE NOT NULL ,
  texto INTEGER   NOT NULL ,
  aceito BOOL  DEFAULT false NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(pessoa_id)
    REFERENCES pessoa(id));

CREATE INDEX IFK_Rel_10 ON termo (pessoa_id);

CREATE TABLE video (
  id SERIAL  NOT NULL ,
  documento_id INTEGER   NOT NULL ,
  url VARCHAR(100)   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(documento_id)
    REFERENCES documento(id));

CREATE INDEX IFK_Rel_03 ON video (documento_id);

CREATE TABLE evento (
  id SERIAL  NOT NULL ,
  tipoevento_id INTEGER   NOT NULL ,
  nome VARCHAR(100) UNIQUE NOT NULL ,
  datahora TIMESTAMP   NOT NULL ,
  descricao TEXT   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(tipoevento_id)
    REFERENCES tipoevento(id));

CREATE INDEX IFK_Rel_27 ON evento (tipoevento_id);

CREATE TABLE dossie (
  id SERIAL  NOT NULL ,
  documento_id INTEGER   NOT NULL ,
  nome VARCHAR(50) UNIQUE NOT NULL ,
  text TEXT   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(documento_id)
    REFERENCES documento(id));

CREATE INDEX IFK_Rel_37 ON dossie (documento_id);

CREATE TABLE apelido (
  id SERIAL  NOT NULL ,
  pessoa_id INTEGER   NOT NULL ,
  nome VARCHAR(20) UNIQUE NOT NULL   ,
PRIMARY KEY(id)  ,
  FOREIGN KEY(pessoa_id)
    REFERENCES pessoa(id));

CREATE INDEX apelido_FKIndex1 ON apelido (pessoa_id);

CREATE INDEX IFK_Rel_45 ON apelido (pessoa_id);

CREATE TABLE genero (
  id SERIAL  NOT NULL ,
  pessoa_id INTEGER   NOT NULL ,
  nome VARCHAR(20) UNIQUE NOT NULL   ,
PRIMARY KEY(id)  ,
  FOREIGN KEY(pessoa_id)
    REFERENCES pessoa(id));

CREATE INDEX genero_FKIndex1 ON genero (pessoa_id);

CREATE INDEX IFK_Rel_47 ON genero (pessoa_id);

CREATE TABLE localglossario (
  id SERIAL  NOT NULL ,
  glossario_id INTEGER   NOT NULL ,
  localizacao_id INTEGER   NOT NULL   ,
PRIMARY KEY(id)    ,
  FOREIGN KEY(localizacao_id)
    REFERENCES localizacao(id),
  FOREIGN KEY(glossario_id)
    REFERENCES glossario(id));

CREATE INDEX localglossario_FKIndex1 ON localglossario (localizacao_id);
CREATE INDEX localglossario_FKIndex2 ON localglossario (glossario_id);

CREATE INDEX IFK_Rel_42 ON localglossario (localizacao_id);
CREATE INDEX IFK_Rel_43 ON localglossario (glossario_id);

CREATE TABLE transcricao (
  id SERIAL  NOT NULL ,
  texto_id INTEGER   NOT NULL ,
  audio_id INTEGER   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(texto_id)
    REFERENCES texto(id),
  FOREIGN KEY(audio_id)
    REFERENCES audio(id));

CREATE INDEX IFK_Rel_20 ON transcricao (texto_id);
CREATE INDEX IFK_Rel_21 ON transcricao (audio_id);

CREATE TABLE significado (
  id SERIAL  NOT NULL ,
  conceito_id INTEGER   NOT NULL ,
  idioma_id INTEGER   NOT NULL ,
  link VARCHAR(100)    ,
  descricao  TEXT   NOT NULL   ,
PRIMARY KEY(id)  ,
  FOREIGN KEY(idioma_id)
    REFERENCES idioma(id),
  FOREIGN KEY(conceito_id)
    REFERENCES conceito(id));

CREATE INDEX significado_FKIndex1 ON significado (conceito_id);

CREATE INDEX IFK_Rel_37 ON significado (idioma_id);
CREATE INDEX IFK_Rel_38 ON significado (conceito_id);

CREATE TABLE imagem (
  id SERIAL  NOT NULL ,
  termo_id INTEGER   NOT NULL ,
  documento_id INTEGER   NOT NULL ,
  base64 TEXT   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(documento_id)
    REFERENCES documento(id),
  FOREIGN KEY(termo_id)
    REFERENCES termo(id));

CREATE INDEX IFK_Rel_02 ON imagem (documento_id);
CREATE INDEX IFK_Rel_11 ON imagem (termo_id);

CREATE TABLE legenda (
  id SERIAL  NOT NULL ,
  texto_id INTEGER   NOT NULL ,
  video_id INTEGER   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(video_id)
    REFERENCES video(id),
  FOREIGN KEY(texto_id)
    REFERENCES texto(id));

CREATE INDEX IFK_Rel_15 ON legenda (video_id);
CREATE INDEX IFK_Rel_16 ON legenda (texto_id);

CREATE TABLE linhadotempodocumento (
  id SERIAL  NOT NULL ,
  documento_id INTEGER   NOT NULL ,
  linhadotempo_id INTEGER   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(documento_id)
    REFERENCES documento(id),
  FOREIGN KEY(linhadotempo_id)
    REFERENCES linhadotempo(id));

CREATE INDEX IFK_Rel_35 ON linhadotempodocumento (documento_id);
CREATE INDEX IFK_Rel_36 ON linhadotempodocumento (linhadotempo_id);

CREATE TABLE documentoglossario (
  id SERIAL  NOT NULL ,
  glossario_id INTEGER   NOT NULL ,
  documento_id INTEGER   NOT NULL   ,
PRIMARY KEY(id)    ,
  FOREIGN KEY(documento_id)
    REFERENCES documento(id),
  FOREIGN KEY(glossario_id)
    REFERENCES glossario(id));

CREATE INDEX documentoglossario_FKIndex1 ON documentoglossario (documento_id);
CREATE INDEX documentoglossario_FKIndex2 ON documentoglossario (glossario_id);

CREATE INDEX IFK_Rel_40 ON documentoglossario (documento_id);
CREATE INDEX IFK_Rel_41 ON documentoglossario (glossario_id);

CREATE TABLE eventodocumento (
  id SERIAL  NOT NULL ,
  documento_id INTEGER   NOT NULL ,
  evento_id INTEGER   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(evento_id)
    REFERENCES evento(id),
  FOREIGN KEY(documento_id)
    REFERENCES documento(id));

CREATE INDEX IFK_Rel_25 ON eventodocumento (evento_id);
CREATE INDEX IFK_Rel_26 ON eventodocumento (documento_id);

CREATE TABLE documentodossie (
  id SERIAL  NOT NULL ,
  dossie_id INTEGER   NOT NULL ,
  documento_id INTEGER   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(documento_id)
    REFERENCES documento(id),
  FOREIGN KEY(dossie_id)
    REFERENCES dossie(id));

CREATE INDEX IFK_Rel_08 ON documentodossie (documento_id);
CREATE INDEX IFK_Rel_09 ON documentodossie (dossie_id);

CREATE TABLE linhadotempopessoa (
  id SERIAL  NOT NULL ,
  pessoa_id INTEGER   NOT NULL ,
  linhadotempo_id INTEGER   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(pessoa_id)
    REFERENCES pessoa(id),
  FOREIGN KEY(linhadotempo_id)
    REFERENCES linhadotempo(id));

CREATE INDEX IFK_Rel_38 ON linhadotempopessoa (pessoa_id);
CREATE INDEX IFK_Rel_39 ON linhadotempopessoa (linhadotempo_id);

CREATE TABLE localevento (
  id SERIAL  NOT NULL ,
  localizacao_id INTEGER   NOT NULL ,
  evento_id INTEGER   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(evento_id)
    REFERENCES evento(id),
  FOREIGN KEY(localizacao_id)
    REFERENCES localizacao(id));

CREATE INDEX IFK_Rel_33 ON localevento (evento_id);
CREATE INDEX IFK_Rel_34 ON localevento (localizacao_id);

CREATE TABLE linhadotempoevento (
  id SERIAL  NOT NULL ,
  linhadotempo_id INTEGER   NOT NULL ,
  evento_id INTEGER   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(evento_id)
    REFERENCES evento(id),
  FOREIGN KEY(linhadotempo_id)
    REFERENCES linhadotempo(id));

CREATE INDEX IFK_Rel_35 ON linhadotempoevento (evento_id);
CREATE INDEX IFK_Rel_36 ON linhadotempoevento (linhadotempo_id);

CREATE TABLE audiodescricaovideo (
  id SERIAL  NOT NULL ,
  idioma_id INTEGER   NOT NULL ,
  audio_id INTEGER   NOT NULL ,
  video_id INTEGER   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(video_id)
    REFERENCES video(id),
  FOREIGN KEY(audio_id)
    REFERENCES audio(id),
  FOREIGN KEY(idioma_id)
    REFERENCES idioma(id));

CREATE INDEX IFK_Rel_12 ON audiodescricaovideo (video_id);
CREATE INDEX IFK_Rel_13 ON audiodescricaovideo (audio_id);
CREATE INDEX IFK_Rel_23 ON audiodescricaovideo (idioma_id);

CREATE TABLE audiodescricaoimagem (
  id SERIAL  NOT NULL ,
  idioma_id INTEGER   NOT NULL ,
  audio_id INTEGER   NOT NULL ,
  imagem_id INTEGER   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(imagem_id)
    REFERENCES imagem(id),
  FOREIGN KEY(audio_id)
    REFERENCES audio(id),
  FOREIGN KEY(idioma_id)
    REFERENCES idioma(id));

CREATE INDEX IFK_Rel_17 ON audiodescricaoimagem (imagem_id);
CREATE INDEX IFK_Rel_19 ON audiodescricaoimagem (audio_id);
CREATE INDEX IFK_Rel_22 ON audiodescricaoimagem (idioma_id);

CREATE TABLE participacao (
  id SERIAL  NOT NULL ,
  pessoa_id INTEGER   NOT NULL ,
  tipoparticipacao_id INTEGER   NOT NULL ,
  evento_id INTEGER   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(tipoparticipacao_id)
    REFERENCES tipoparticipacao(id),
  FOREIGN KEY(evento_id)
    REFERENCES evento(id),
  FOREIGN KEY(pessoa_id)
    REFERENCES pessoa(id));

CREATE INDEX IFK_Rel_28 ON participacao (tipoparticipacao_id);
CREATE INDEX IFK_Rel_30 ON participacao (evento_id);
CREATE INDEX IFK_Rel_32 ON participacao (pessoa_id);