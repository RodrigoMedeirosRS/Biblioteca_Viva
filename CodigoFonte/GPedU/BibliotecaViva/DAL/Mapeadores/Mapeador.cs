using System;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Mapeadores
{
    public static class Mapeador
    {
        public static Pessoa MapearPessoa(PessoaDTO pessoaDTO, int genero)
        {
            return new Pessoa()
            {
                Id = pessoaDTO.GetId(),
                Genero = genero,
                Nome = pessoaDTO.Nome,
                Sobrenome = pessoaDTO.Sobrenome
            };
        }

        public static PessoaDTO MapearPessoa(Pessoa pessoa, Genero genero, Apelido apelido, NomeSocial nomeSocial)
        {
            var pessoaDTO = new PessoaDTO()
            {
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Genero = genero.Nome,
                Apelido = apelido != null ? apelido.Nome : string.Empty,
                NomeSocial = nomeSocial != null ? nomeSocial.Nome : string.Empty
            };

            pessoaDTO.SetId(pessoa.Id);
            return pessoaDTO;
        }

        public static Documento MapearCabecalhoDocumento(DocumentoDTO documentoDTO, int idioma)
        {
            return new Documento()
            {
                Nome = documentoDTO.Nome,
                Idioma = idioma,
                DataRegistro = documentoDTO.DataRegistro,
                DataDigitalizacao = documentoDTO.DataDigitalizacao
            };           
        }

        public static CorpoDocumento MapearCorpoDocumento(DocumentoDTO documentoDTO, int documentoId, int termoId = 0)
        {
            switch (documentoDTO.GetType().Name)
            {
                case ("TextoDTO"):
                    return new Texto()
                    {
                        Documento = documentoId,
                        Corpo = (documentoDTO as TextoDTO).Texto
                    };
                case ("AudioDTO"):
                    return new Audio()
                    {
                        Documento = documentoId,
                        Base64 = (documentoDTO as AudioDTO).Base64
                    };
                case ("VideoDTO"):
                    return new Video()
                    {
                        Documento = documentoId,
                        Url = (documentoDTO as VideoDTO).Url
                    };
                case ("ImagemDTO"):
                    return new Imagem()
                    {
                        Documento = documentoId,
                        Base64 = (documentoDTO as ImagemDTO).Base64,
                        Termo = termoId
                    };
                default:
                    throw new Exception("Tipo de documento inválido!");
            }
        }
    }
}
